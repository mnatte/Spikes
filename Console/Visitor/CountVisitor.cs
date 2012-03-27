using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DCI_spike.Visitor
{
    public class CountVisitor : VisitorBase<int>
    {
        public override int ProcessClassA(ClassA classA, int state)
        {
            return classA.SomeInt + state;
        }

        public override int ProcessClassB(ClassB classB, int state)
        {
            return classB.SomeString.Count() + state;
        }

        public override int ProcessClassC(ClassC classC, int state)
        {
            return state + (classC.SomeBool ? 1 : 0);
        }
    }
}
