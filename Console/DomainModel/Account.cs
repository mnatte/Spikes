using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DCI_spike
{
    public abstract class Account
    {
        public Account(string accountNumber)
        {
            this.AccountNumber = accountNumber;
        }

        public double Balance { get; protected set; }

        public string AccountNumber { get; protected set; }

        public void Withdraw(double amount)
        {
            Balance -= amount;
        }

        public void Deposit(double amount)
        {
            Balance += amount;
        }

        public void Log(string message)
        {
            Console.WriteLine(this + " -> " + message);
        }
    }
}
