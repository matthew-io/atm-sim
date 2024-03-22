using System;
using System.Threading;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.IO;

namespace ATMSim
{
    public partial class CentralComputer : Form
    {

        private Hashtable accounts = new Hashtable();
        private bool Sems = false;
        private int atmCount = 0;
        private int threadCount = 0;
        private Hashtable lockedAccounts = new Hashtable();

        public CentralComputer()
        {
            Account accA = new Account(123, "1111", "111111");
            Account accB = new Account(123, "2222", "222222");
            Account accC = new Account(123, "3333", "333333");
            Account accD = new Account(123, "4444", "444444");

            accounts.Add(accA.getAccountNumber(), accA);
            accounts.Add(accB.getAccountNumber(), accB);
            accounts.Add(accC.getAccountNumber(), accC);
            accounts.Add(accD.getAccountNumber(), accD);

            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Thread newATMThread = new Thread(SpawnATM);
            newATMThread.Start();
        }


        void SpawnATM()
        {
            atmCount = Int32.Parse(textBox1.Text);
            for (int i = 0; i < atmCount; i++)
            {
                int currentThreadNumber = Interlocked.Increment(ref threadCount);

                Thread atmThread = new Thread(() =>
                {
                    int currentATMNumber = currentThreadNumber;
                    string atmItemText = "ATM #" + currentATMNumber;


                    listBox1.BeginInvoke((MethodInvoker)delegate
                    {
                        listBox1.Items.Add(atmItemText);
                    });

                    ATM atm = new ATM(this.accounts, this.Sems, this, currentATMNumber);
                    atm.FormClosed += (sender, args) =>
                    {
                        Application.ExitThread();
                        listBox1.BeginInvoke((MethodInvoker)delegate
                        {
                            listBox1.Items.Remove(atmItemText);
                            listBox2.Items.Add("ATM #" + currentATMNumber + " Closed.");
                        });
                    };

                    atm.Show();
                    Application.Run();
                });

                atmThread.SetApartmentState(ApartmentState.STA);
                atmThread.Start();
            }
        }


        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                this.Sems = true;
            }
            else
            {
                this.Sems = false;
            }
        }

        private void label6_Click(object sender, EventArgs e)
        {
            Console.WriteLine(".");
        }

        private async void btnSaveLogs_Click(object sender, EventArgs e)
        {
            string timestamp = DateTime.Now.ToString("yyyyMMddHHmmss");
            string fileName = "LogFile-" + timestamp + ".txt";

            using (StreamWriter outputFile = new StreamWriter(Path.Combine(Directory.GetCurrentDirectory(), fileName)))
            {
                foreach (string item in listBox2.Items)
                {
                    outputFile.WriteLine(item);
                }
            }

            btnSaveLogs.Text = "Logs Saved.";
            btnSaveLogs.Enabled = false;
            await Task.Delay(1000);

            btnSaveLogs.Text = "Save Logs";
            btnSaveLogs.Enabled = true;
        }

    }
}