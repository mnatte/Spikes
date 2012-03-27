using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DCI_spike
{
    public class SavingsAccount : Account, TransferMoneySource, TransferMoneySink
    {
        public SavingsAccount(string accountNumber, double balance)
            :base(accountNumber)
        {
            Balance = balance;
        }

        public override string ToString()
        {
            return "Account " + this.AccountNumber;
        }
    }
}
