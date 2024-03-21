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
using System.Net;


namespace ATMSim
{

    public partial class ATM : Form
    {
        private Hashtable accounts = new Hashtable();
        private Account currentAcc;

        private int tries = 0;
        private bool isWithdrawing = false;
        private bool isDepositing = false;
        private bool isChangingPin = false;
        private bool isLogin = true;
        private bool Sems;

        public ATM(Hashtable accounts, bool Sems)
        {
            this.accounts = accounts;
            this.Sems = Sems;
            InitializeComponent();    
        }

        private async void enterBtnHandle()
        {
            Console.WriteLine("Is user withdrawing: " + isWithdrawing);
            if (isDepositing)
            {
                int depositAmount = Int32.Parse(textBox1.Text);
                hideMiddleInput();
                label4.Text = "Depositing £" + depositAmount + "....";

                await Task.Delay(1000);

                bool depositSuccess = currentAcc.deposit(depositAmount, Sems);

                if (depositSuccess)
                {
                    label4.Text = "Deposit successful!";
                } else
                {
                    label4.Text = "Deposit failed.";
                }

                await Task.Delay(1500);

                isDepositing = false;
                resetMenu();
                hideMiddlePanel();
            }

            if (isChangingPin)
            {
                String newPin = textBox1.Text;
                hideMiddleInput();
                label4.Text = "Changing pin...";

                await Task.Delay(1000);

                bool changeSucess = currentAcc.changePin(newPin, Sems);

                if (changeSucess)
                {
                    label4.Text = "Pin changed sucessfully!";
                } else
                {
                    label4.Text = "Pin change unsucessful.";
                }

                await Task.Delay(1500);

                isChangingPin = false;
                resetMenu();
                hideMiddlePanel();
            }

            else
            {
                String pinText = textBox1.Text.Trim();
                Console.WriteLine(pinText);
                Console.WriteLine(accounts.ContainsKey(pinText));
                if (accounts.ContainsKey(pinText))
                {
                    this.currentAcc = (Account)accounts[pinText];
                    Console.WriteLine("Account found");
                    hideMiddlePanel();
                    isLogin = false;
                }
                else
                {
                    if (tries == 3)
                    {
                        textBox1.Visible = false;
                        label4.Text = "Too many tries. Exiting...";
                        await Task.Delay(3000);
                        this.Close();
                    }
                    tries++;
                    label4.Text = "Incorrect PIN. Please try again.";
                    textBox1.Visible = false;
                    await Task.Delay(2000);
                    textBox1.Text = "";
                    label4.Text = "Please enter your PIN number";
                    textBox1.Visible = true;
                }

                
            }
        }

        private void padClickHandler(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            Console.WriteLine(textBox1.Text.Length);

            if (isLogin)
            {
                textBox1.PasswordChar = '*';
                if (textBox1.Text.Length < 4)
                {
                    textBox1.Text += btn.Text;
                }
            }
            else
            {
                textBox1.PasswordChar = '\0';
                textBox1.Text += btn.Text; 
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


        private void showMiddleInput()
        {
            textBox1.Visible = true;
            enterBtn.Visible = true;
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
                currentAcc.withdraw(amount, Sems);
            }
            isWithdrawing = false;
            resetMenu();
            hideMiddlePanel();
        }

        public void handleDeposit()
        {
            hideSidePanels();
            showMiddleInput();
            label4.Text = "Enter deposit amount: ";
            textBox1.Text = "";
        }

        public void handlePinChange()
        {
            hideSidePanels();
            showMiddleInput();
            label4.Text = "Enter your new pin: ";
            textBox1.Text = "";
        }

    
        private void clickHandler(object sender, EventArgs e)
        {
            Button btn = sender as Button;


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
                        isDepositing = true;
                        handleDeposit();
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
                        isChangingPin = true;
                        handlePinChange();
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
                case "enterBtn":
                    enterBtnHandle();
                    break;
                default:
                    break;
            }


        }
        private void button18_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }
    }
}
