using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DCI_spike
{
    // the extension methods attach implementation of the use cases to the role interfaces; in this case the TransferTo use case to the TransferMoneySource role
    public static class TransferMoneySourceTrait
    {
        // the interface is used here as a jumpboard for kicking off the extension method (it works as a methodful role) instead of the traditional use of interfaces
        public static void TransferTo(this TransferMoneySource self, TransferMoneySink recipient, double amount)
        {
            // The implementation of the use case by using the "primitive methods" of the domain objects
            if (self.Balance < amount)
            {
                throw new ApplicationException("insufficient funds");
            }

            self.Withdraw(amount);
            self.Log("Withdrawing " + amount);
            recipient.Deposit(amount);
            recipient.Log("Depositing " + amount);
        }
    }
}
