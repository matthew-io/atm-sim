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
        // Initialize variables
        private Hashtable accounts = new Hashtable();
        private bool Sems = false;
        private int atmCount = 0;
        private int threadCount = 0;

        /**
         * Constructor method 
         * 
         * Initializes the accounts and adds them to an accounts variable 
        */
        public CentralComputer()
        {
            Account accA = new Account(123, "1111", "1111111");
            Account accB = new Account(123, "2222", "2222222");
            Account accC = new Account(123, "3333", "3333333");
            Account accD = new Account(123, "4444", "4444444");

            accounts.Add(accA.getPin(), accA);
            accounts.Add(accB.getPin(), accB);
            accounts.Add(accC.getPin(), accC);
            accounts.Add(accD.getPin(), accD);

            InitializeComponent();
        }

        /**
         * Button for spawning a new ATM using a thread
        */
        private void button1_Click(object sender, EventArgs e)
        {
            Thread newATMThread = new Thread(SpawnATM);
            newATMThread.Start();
        }

        /** 
         * SpawnATM() is called when creating a new method 
        */
        void SpawnATM()
        {
            atmCount = Int32.Parse(textBox1.Text);

            // loops the number of times that the user has chosen to create that many instances of ATMs
            for (int i = 0; i < atmCount; i++)
            {
                int currentThreadNumber = Interlocked.Increment(ref threadCount);

                /*
                 * Each thread adds an item to listBox1 to display the currently open ATM,
                 * it also removes the item from listBox1 when the Form is closed
                 * and finally it has an Application.Run() to create a new Form with the initialised atm object
                 */
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

        // This changes the value of the semaphore which handles the Data Race problem
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


        // This is acive when the Save Logs button is clicked and saves the values of the listBox2 into a file in the same location as the exe
        private async void btnSaveLogs_Click(object sender, EventArgs e)
        {
            string timestamp = DateTime.Now.ToString("yyyyMMddHHmmss");
            string fileName = "LogFile-" + timestamp + ".txt";

            // StreamWriter for writing the strings in listBox2 into the file
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

        private void CentralComputer_Load(object sender, EventArgs e)
        {

        }
    }
}