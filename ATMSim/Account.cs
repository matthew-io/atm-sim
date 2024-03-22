using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ATMSim
{
    //This class deals with the accounts that are created
    public class Account
    {
        private int balance;
        private String pin;
        private String accountNumber;
        //semaphores to allow for data race fix
        private readonly Semaphore balanceSem;
        private readonly Semaphore accountSem;

        //constructor
        public Account(int balance, String pin, String accountNumber)
        {
            this.balance = balance;
            this.pin = pin;
            this.accountNumber = accountNumber;
            this.balanceSem = new Semaphore(1, 1);
            this.accountSem = new Semaphore(1, 1);
        }

        //returns balance 
        public int getBalance()
        {
            return balance;
        }

        //sets the balance of the account
        public void setBalance(int balance)
        {
            this.balance = balance;
        }

        //returns the pin for the login
        public string getPin()
        {
            return pin;
        }

        //When the user wants to withdraw money from their account this is called
        public bool withdraw(int amount, bool Sems)
        {
            if (Sems)// if statment to decide whether semaphores are being used. Sems is decided on the Central Computer
            {
                Console.WriteLine("Waiting for sempahore.");
                bool semAcquired = balanceSem.WaitOne(12000);// waiting for semaphore

                try
                {
                    if (semAcquired && this.balance >= amount) //checks if the semaphore passed and if the account has enough money in it
                    {
                        Console.WriteLine("Semaphore acquired!");
                        Thread.Sleep(3000);
                        balance -= amount;// takes away the money from the account
                        return true;
                    }
                    else
                    {
                        return false;// if the user doesnt have enouugh money or the semaphore failed to pass
                    }
                }
                finally
                {
                    if (semAcquired)
                    {
                        balanceSem.Release();// releases the semaphore
                    }
                }
            }
            else
            {// this does the same thing wiuthout the semaphores
                if (this.balance >= amount)
                {
                    balance -= amount;// takes moeny out the account
                    return true;
                }
                else
                {
                    return false;
                }
            }



        }
        // depositing money into the account
        public Boolean deposit(int amount, bool Sems, CentralComputer c)
        {
            if (Sems)// decides if semaphores are to be used to deposit the moeny into the account
            {
                if (balanceSem.WaitOne(12000) && amount != 0)// waits for the semaphore to pass and checks the amount they are wanting to put into the account is not 0
                {
                    Thread.Sleep(3000);// sleeping the thread to avoid data race conditions
                    balance += amount;
                    balanceSem.Release();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {// does it again without semaphores.
                if (amount != 0)
                {
                    balance += amount;
                    return true;
                }
                else
                {
                    return false;
                }
            }

        }

        public Boolean checkPin(String pinEntered)// checks if the user has enetered the correct pin into the text box
        {
            if (pinEntered == pin)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public Boolean changePin(String newPin, bool Sems)//allows the uesr to change their pin
        {
            if (Sems)
            {
                Console.WriteLine("Waiting for semaphore...");
                if (accountSem.WaitOne(12000) && newPin.Length == 4)//waits for semaphore to pass and checks the pin is the correct length
                {
                    Console.WriteLine("Semaphore released.");
                    Thread.Sleep(3000);// avoiding data race conditions
                    pin = newPin;// changes the pin
                    accountSem.Release();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {// does the same thing without semaphores
                if (newPin.Length == 4)
                {
                    pin = newPin;
                    return true;
                }
                else
                {
                    return false;
                }
            }

        }
        // returns the account number
        public String getAccountNumber()
        {
            return accountNumber;
        }
    }
}