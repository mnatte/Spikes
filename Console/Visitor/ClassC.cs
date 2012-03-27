using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DCI_spike.Visitor
{
    public class ClassC : TreeBase
    {
        public override T Accept<T>(VisitorBase<T> visitor, T state)
        {
            return visitor.ProcessClassC(this, state);
        }

        public bool SomeBool { get { return false; } }
    }
}
