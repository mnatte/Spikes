using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DCI_spike
{
    // in C# the roles are interfaces, but they also need to implement the use case.
    // through extension methods (see TransferMoneySourceTrait extensions bag) this behavior, the use case implementation, is attached to the interfaces.

    // the implementation of the interface methods are passed to the (slow shear layer) domain object.
    // interfaces are needed since multiple inheritance is not possible in C#.
    public interface TransferMoneySource
    {
        double Balance { get; }
        void Withdraw(double amount);
        void Log(string message);
    }
}
