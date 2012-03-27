using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DCI_spike.Visitor
{
    public class ClassB : TreeBase
    {
        public override T Accept<T>(VisitorBase<T> visitor, T state)
        {
            return visitor.ProcessClassB(this, state);
        }

        public string SomeString { get { return "Testing some string"; } }
    }
}
