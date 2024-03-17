using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ATMSim
{
    public  class Account
    {
        private int balance;
        private String pin;
        private String accountNumber;

        private readonly Semaphore balanceSem;
        private readonly Semaphore accountSem;

        public Account(int balance, String pin, String accountNumber)
        {
            this.balance = balance;
            this.pin = pin;
            this.accountNumber = accountNumber;
            this.balanceSem = new Semaphore(1, 1);
            this.accountSem = new Semaphore(1, 1);
        }

        public int getBalance()
        {
            return balance;
        }

        public void setBalance(int balance)
        {
            this.balance = balance;
        }

        public String getPin()
        {
            return pin;
        }

        public Boolean withdraw(int amount)
        {
            Console.WriteLine("Waiting for semaphore...");
            bool semAcquired= balanceSem.WaitOne(12000); 
            try
            {
                if (semAcquired && this.balance >= amount)
                {
                    Console.WriteLine("Semaphore acquired!");
                    Thread.Sleep(3000);
                    balance -= amount;
                    return true;
                }
                else
                {
                    return false;
                }
            }
            finally
            {
                if (semAcquired)
                {
                    balanceSem.Release();
                }
            }

        }

        public Boolean deposit(int amount)
        {
            if (balanceSem.WaitOne(12000) && amount != 0)
            {
                Thread.Sleep(3000);
                balance += amount;
                balanceSem.Release();
                return true;
            } else
            {
                return false;
            }
        }

        public Boolean checkPin(String pinEntered)
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

        public Boolean changePin(String newPin)
        {
            Console.WriteLine("Waiting for semaphore...");
            if (accountSem.WaitOne(12000) && newPin.Length == 4)
            {
                Console.WriteLine("Semaphore released.");
                Thread.Sleep(3000);
                this.pin = newPin;
                accountSem.Release();
                return true;
            } else
            {
                return false;
            }
        }

        public String getAccountNumber()
        {
            return accountNumber;
        }   
    }
}
