using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic;


namespace ATMSim
{

    public partial class ATM : Form
    {
        private Hashtable accounts = new Hashtable();
        private Account currentAcc;

        public ATM(Hashtable accounts)
        {
            this.accounts = accounts;
            InitializeComponent();
        }



        private void button1_Click(object sender, EventArgs e)
        {
            String pinText = textBox1.Text.Trim();
            Console.WriteLine(pinText);
            Console.WriteLine(accounts.ContainsKey(pinText));
            if (accounts.ContainsKey(pinText))
            {
                this.currentAcc = (Account)accounts[pinText];
                Console.WriteLine("Account found");
                textBox1.Visible = false;
                button1.Visible = false;
                label4.Visible = false;
                label1.Visible = true;
                mainPanel.Visible = true;
            } else
            {
                Console.WriteLine("Account not found");
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {
            Console.WriteLine("Clicked");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            String input = Interaction.InputBox("Enter your pin number", "Withdraw", "", this.Location.X + 200, this.Location.Y + 200);
            
            if (input == currentAcc.getPin())
            {
                currentAcc.withdraw(Int32.Parse(textBox2.Text));
            } else
            {
                Console.WriteLine("Incorrect pin!!!");
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            label2.Text = "Balance: " + currentAcc.getBalance();
        }

        private void ATM_Load(object sender, EventArgs e)
        {
            Console.WriteLine("ATM Loaded");
        }

        private void label4_Click(object sender, EventArgs e)
        {
            Console.WriteLine(".");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string input = Interaction.InputBox("Enter your pin number", "Deposit", "", this.Location.X + 200, this.Location.Y + 200);

            if (input == currentAcc.getPin())
            {
                currentAcc.deposit(Int32.Parse(textBox3.Text));
            } else
            {
                Console.WriteLine("Incorrect pin!!!");
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            currentAcc.changePin(textBox4.Text);
        }
    }
}
