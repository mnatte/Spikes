using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DCI_spike.Visitor
{
    public abstract class TreeBase
    {
        public abstract T Accept<T>(VisitorBase<T> visitor, T state);
        
    }
}
