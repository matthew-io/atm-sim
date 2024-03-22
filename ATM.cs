using System;
using System.Collections;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;

namespace ATMSim
{

    public partial class ATM : Form
    {
        private Hashtable accounts = new Hashtable();
        private Account currentAcc;
        private CentralComputer c;

        private SoundPlayer soundPlayer;

        private int tries = 0;
        private int currentATMNumber;
        private bool isWithdrawing = false;
        private bool isDepositing = false;
        private bool isChangingPin = false;
        private bool isLogin = true;
        private bool Sems;
        private delegate void SafeCallDelegate(string text);

        public ATM(Hashtable accounts, bool Sems, CentralComputer c, int currentATMNumber)
        {
            this.accounts = accounts;
            this.Sems = Sems;
            this.c = c;
            this.currentATMNumber = currentATMNumber;
            InitializeComponent();

            System.IO.Stream sound = Properties.Resources.keypress;
            soundPlayer = new SoundPlayer(sound);
            soundPlayer.Load();
            this.c = c;
        }

        private void Log(string text)
        {
            if (c.listBox2.InvokeRequired)
            {
                var d = new SafeCallDelegate(Log);
                c.listBox2.Invoke(d, new object[] { text });
            }
            else
            {
                c.listBox2.Items.Add(text);
            }
        }

        private async void enterBtnHandle()
        {
            soundPlayer.Play();
            Console.WriteLine("Is user withdrawing: " + isWithdrawing);
            if (isDepositing)
            {
                if (textBox1.Text.Length == 0)
                {
                    hideMiddleInput();
                    label4.Text = "Please enter a valid amount.";
                    await Task.Delay(2000);
                    showMiddleInput();
                    label4.Text = "Enter deposit amount: ";
                    return;
                } else
                {
                    int depositAmount = Int32.Parse(textBox1.Text);
                    hideMiddleInput();
                    label4.Text = "Depositing £" + depositAmount + "....";

                    await Task.Delay(1000);

                    bool depositSuccess = currentAcc.deposit(depositAmount, Sems, c);

                    if (depositSuccess)
                    {
                        await Task.Delay(1500);
                        label4.Text = "Deposit successful!";
                        Log("ATM #" + currentATMNumber + ": " + "Account No. " + this.currentAcc.getAccountNumber() + " deposited £" + depositAmount);
                    }
                    else
                    {
                        label4.Text = "Deposit failed.";
                    }

                    await Task.Delay(1500);


                    isDepositing = false;
                    resetMenu();
                    hideMiddlePanel();
                }
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
                    Log("ATM #" + currentATMNumber + ": " + "Account No. " + this.currentAcc.getAccountNumber() + " changed their PIN to " + newPin);
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
                    Log("ATM #" + currentATMNumber + ": has logged into Account No. " + this.currentAcc.getAccountNumber());
                    hideMiddlePanel();
                    isLogin = false;
                }
                else
                {
                    if (tries == 3)
                    {
                        textBox1.Visible = false;
                        label4.Text = "Too many tries. Please take your card.";
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
            soundPlayer.Play();

            Button btn = sender as Button;
            Console.WriteLine(textBox1.Text.Length);

            if (isLogin || isChangingPin)
            {
                textBox1.PasswordChar = '*';
                if (textBox1.Text.Length < 4)
                {
                    textBox1.Text += btn.Text;
                }
            }
            else if (isDepositing || isWithdrawing || isChangingPin)
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
            Log("ATM #" + currentATMNumber + " Opened.");
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
            exitLbl.Text = "£100";
        }

        private async void displayBalance()
        {
            hideSidePanels();
            hideMiddleInput();
            label4.Text = "Your current balance is: £" + currentAcc.getBalance();
            Log("ATM #" + currentATMNumber + ": Account No. " + this.currentAcc.getAccountNumber() + " displayed their balance.");
            await Task.Delay(3000);
            hideMiddlePanel();
        }

        private void resetMenu()
        {
            withdrawLbl.Text = "WITHDRAW";
            chkBalanceLbl.Text = "CHECK BALANCE";
            depositLbl.Text = "DEPOSIT";
            changePinLbl.Text = "CHANGE PIN";
            exitLbl.Text = "PRINT STATEMENT";
            exitLbl.Text = "EXIT";
        }

        private async void handleWithdraw(int amount)
        {
            hideSidePanels();
            hideMiddleInput();
            if (amount > currentAcc.getBalance())
            {
                label4.Text = "Insufficient funds.";
                await Task.Delay(3000);
            }
            else
            {
                label4.Text = "Withdrawing £" + amount + "....";
                Log("ATM #" + currentATMNumber + ": Account No. " + this.currentAcc.getAccountNumber() + " withdrew £" + amount);
                button8.Enabled = false;
                button1.Enabled = false;
                button2.Enabled = false;
                button3.Enabled = false;
                button4.Enabled = false;
                await Task.Delay(1000);
                
                currentAcc.withdraw(amount, Sems);
            }

            label4.Text = "Withdraw successful!";
            await Task.Delay(1500);

            isWithdrawing = false;
            resetMenu();
            button8.Enabled = true;
            button1.Enabled = true;
            button2.Enabled = true;
            button3.Enabled = true;
            button4.Enabled = true;
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
            soundPlayer.Play();

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
                    else
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
                        exitAtm();
                        break;
                    } else if (isWithdrawing)
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

        private void exitAtm()
        {
            Log("ATM #" + currentATMNumber + ": Logout initiated by user.");
            this.Close();
        }

        private void ATM_Closing(Object sender, CancelEventArgs e)
        {
            Log("ATM #" + currentATMNumber + ": Logout initiated by user.");
        }

        private void button18_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void exitLbl_Click(object sender, EventArgs e)
        {
            Log("ATM #" + currentATMNumber + ": Logout initiated by user.");
            this.Close();
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            resetMenu();
        }
    }
}
