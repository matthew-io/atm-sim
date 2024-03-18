using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;
using Microsoft.VisualBasic;


namespace ATMSim
{

    public partial class ATM : Form
    {
        private Hashtable accounts = new Hashtable();
        private Account currentAcc;
        private bool isWithdrawing = false;

        public ATM(Hashtable accounts)
        {
            this.accounts = accounts;
            InitializeComponent();    
        }

        private void enterBtn_Click(object sender, EventArgs e)
        {
            Console.WriteLine("Is user withdrawing: " + isWithdrawing);
            if (isWithdrawing)
            {
              
            } else
            {
                String pinText = textBox1.Text.Trim();
                Console.WriteLine(pinText);
                Console.WriteLine(accounts.ContainsKey(pinText));
                if (accounts.ContainsKey(pinText))
                {
                    this.currentAcc = (Account)accounts[pinText];
                    Console.WriteLine("Account found");
                    hideMiddlePanel();
                }
                else
                {
                    Console.WriteLine("Account not found");
                }
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {
            Console.WriteLine("Clicked");
        }


        private void ATM_Load(object sender, EventArgs e)
        {
            Console.WriteLine("ATM Loaded");
        }


        private void hideSidePanels()
        {
            panel1.Visible = false;
            panel2.Visible = false;
            panel3.Visible = true;
        }

        private void hideMiddlePanel()
        {
            panel1.Visible = true;
            panel2.Visible = true;
            panel3.Visible = false;
        }

        private void hideMiddleInput()
        {
            textBox1.Visible = false;
            enterBtn.Visible = false;
            label4.Visible = true;
        }


        private void withdrawMenu()
        {
                withdrawLbl.Text = "£10";
                chkBalanceLbl.Text = "£20";
                depositLbl.Text = "£40";
                changePinLbl.Text = "£80";
                statementLbl.Text = "£100";
                transferLbl.Text = "£200";
        }

        private async void displayBalance()
        {
            hideSidePanels();
            hideMiddleInput();
            label4.Text = "Your current balance is: £" + currentAcc.getBalance();
            await Task.Delay(3000);
            hideMiddlePanel();
        }


        private void resetMenu()
        {
            withdrawLbl.Text = "WITHDRAW";
            chkBalanceLbl.Text = "CHECK BALANCE";
            depositLbl.Text = "DEPOSIT";
            changePinLbl.Text = "CHANGE PIN";
            statementLbl.Text = "PRINT STATEMENT";
            transferLbl.Text = "TRANSFER";
        }

        private async void handleWithdraw(int amount)
        {
            hideSidePanels();
            hideMiddleInput();
            if (amount > currentAcc.getBalance())
            {
                label4.Text = "Insufficient funds.";
                await Task.Delay(3000);
            } else
            {
                label4.Text = "Withdrawing £" + amount + "....";
                await Task.Delay(1000);
                currentAcc.withdraw(amount);
            }
            isWithdrawing = false;
            resetMenu();
            hideMiddlePanel();
        }

        private void clickHandler(object sender, EventArgs e)
        {
            Button btn = sender as Button;

            // For when the user is in the main menu

            switch (btn.Name)
            {
                case "button1":
                    if (!isWithdrawing)
                    {
                        isWithdrawing = true;
                        withdrawMenu();
                        break;
                    }
                    if (isWithdrawing)
                    {
                        handleWithdraw(10);
                        break;
                    }
                    break;
                case "button2":
                    if (!isWithdrawing)
                    {
                        displayBalance();
                        break;
                    }
                    if (isWithdrawing)
                    {
                        handleWithdraw(20);
                        break;
                    }
                    break;
                case "button3":
                    if (!isWithdrawing)
                    {
                        displayBalance();
                        break;
                    }
                    if (isWithdrawing)
                    {
                        handleWithdraw(40);
                        break;
                    }
                    break;
                case "button4":
                    if (!isWithdrawing)
                    {
                        displayBalance();
                        break;
                    }
                    if (isWithdrawing)
                    {
                        handleWithdraw(80);
                        break;
                    }
                    break;
                case "button7":
                    if (!isWithdrawing)
                    {
                        displayBalance();
                        break;
                    }
                    if (isWithdrawing)
                    {
                        handleWithdraw(200);
                        break;
                    }
                    break;
                case "button8":
                    if (!isWithdrawing)
                    {
                        displayBalance();
                        break;
                    }
                    if (isWithdrawing)
                    {
                        handleWithdraw(100);
                        break;
                    }
                    break;
                default:
                    break;
            }


        }
    }
}
