﻿using System;
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
using System.Security.Cryptography;

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

        public ATM(Hashtable accounts)
        {
            this.accounts = accounts;
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

                bool depositSuccess = currentAcc.deposit(depositAmount);

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

                bool changeSucess = currentAcc.changePin(newPin);

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

            if (isLogin)
            {
                String pinText = textBox1.Text.Trim();
                Console.WriteLine(pinText);
                Console.WriteLine(accounts.ContainsKey(pinText));
                if (accounts.ContainsKey(pinText))
                {
                    this.currentAcc = (Account)accounts[pinText];
                    Console.WriteLine("Account found");
                    isLogin = false;
                    hideMiddlePanel();
                }
                else
                {
                    tries++;
                    label4.Text = "Incorrect pin";
                    textBox1.Visible = false;
                    await Task.Delay(1500);
                    textBox1.Text = "";
                    textBox1.Visible = true;
                    label4.Text = "Enter your PIN number: ";
                }
                
                if (tries == 3)
                {
                    label4.Text = "Your card has been locked. Please try again later";
                    textBox1.Visible = false;
                    await Task.Delay(3000);
                    this.Close();
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
                currentAcc.withdraw(amount);
                label4.Text = "Withdraw successful!";
                await Task.Delay(1750);
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

        private void padButtonClick(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if (textBox1.Text.Length < 4)
            {
                textBox1.Text += btn.Text; 
            }
        }

        private void button19_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
        }
    }
}
