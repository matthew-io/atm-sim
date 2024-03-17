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

namespace ATMSim
{
    public partial class CentralComputer : Form
    {

        private Hashtable accounts = new Hashtable();

        public CentralComputer()
        {
            Account accA = new Account(123, "1111", "1111111");
            Account accB = new Account(123, "2222", "2222222");
            Account accC = new Account(123, "3333", "3333333");
            Account accD = new Account(123, "4444", "4444444");

            accounts.Add("111111", accA);
            accounts.Add("222222", accB);
            accounts.Add("333333", accC);
            accounts.Add("444444", accD);

            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Thread newATMThread = new Thread(start);
            newATMThread.Start();
        }

        void start()
        {
            ATM atm = new ATM(this.accounts);
            Application.Run(atm);
        }
    }
}
