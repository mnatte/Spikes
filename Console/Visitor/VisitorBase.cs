using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DCI_spike.Visitor
{
    public abstract class VisitorBase<T>
    {
        public T State { get; set; }

        public abstract T ProcessClassA(ClassA classA, T state);
        public abstract T ProcessClassB(ClassB classB, T state);
        public abstract T ProcessClassC(ClassC classC, T state);
    }
}
