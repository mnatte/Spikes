using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DCI_spike
{
    public interface TransferMoneySink
    {
        double Balance { get; }
        void Deposit(double amount);
        void Log(string message);
    }
}
