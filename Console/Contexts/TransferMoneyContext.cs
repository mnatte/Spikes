using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DCI_spike
{
    // this class wires the roles to the domain objects (in ctor) and the use case (in its Execute method) is run in this context
    // SPECIFICATION of a NETWORK of communicating objects that realizes a use case; where Interaction (the I in DCI) specifies HOW these objects communicate
    public class TransferMoneyContext
    {
        public TransferMoneySource Source { get; private set; }
        public TransferMoneySink Sink { get; private set; }
        public double Amount { get; private set; }

        public TransferMoneyContext(TransferMoneySource source, TransferMoneySink sink, double amount)
        {
            Source = source;
            Sink = sink;
            Amount = amount;
        }

        // control is handed to the role that is capable to execute the use case: the Source Account
        public void Execute()
        {
            Source.TransferTo(Sink, Amount);
            Console.WriteLine(Source.ToString() + " balance -> " + Source.Balance);
            Console.WriteLine(Sink.ToString() + " balance -> " + Sink.Balance);
        }

        public void PrintState()
        {
            Console.WriteLine("Source Role -> " + this.Source.ToString());
            Console.WriteLine("Destination Role -> " + this.Sink.ToString());
        }
    }
}
