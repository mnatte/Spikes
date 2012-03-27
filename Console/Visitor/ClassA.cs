using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DCI_spike.Visitor
{
    public class ClassA : TreeBase
    {
        public override T Accept<T>(VisitorBase<T> visitor, T state)
        {
            return visitor.ProcessClassA(this, state);
        }

        public int SomeInt { get; set; }
    }
}
