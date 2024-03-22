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

namespace ATMSim
{
    public partial class CentralComputer : Form
    {

        private Hashtable accounts = new Hashtable();
        private bool Sems = false;
        private int atmCount = 0;
        private int threadCount = 0;

        public CentralComputer()
        {
            Account accA = new Account(123, "1111", "1111111");
            Account accB = new Account(123, "2222", "2222222");
            Account accC = new Account(123, "3333", "3333333");
            Account accD = new Account(123, "4444", "4444444");

            accounts.Add("1111", accA);
            accounts.Add("2222", accB);
            accounts.Add("3333", accC);
            accounts.Add("4444", accD);

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
                Sems = true;
            }
            else
            {
                Sems = false;
            }
        }

    }
}