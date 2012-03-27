using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DCI_spike.Visitor;

namespace DCI_spike
{
    class Program
    {
        static void Main(string[] args)
        {
            // DCI stuff
            var destination = new SavingsAccount("39.16.23.397", 0);
            var src = new SavingsAccount("1588.05.720", 19000);

            var useCase = new TransferMoneyContext(src, destination, 50.22);
            useCase.PrintState();

            useCase.Execute();

            // Monad stuff
            var strMonad = "aap".ToViewModel();
            var result = strMonad.Bind(str => { var x = str + "kip"; return x.ToViewModel(); })
                            .Bind(str => { var x = str + "schapie"; return x.ToViewModel(); });
            Console.WriteLine("Value string monad: {0}", result.Value);

            // transform current date to SideEffectsMonad with 0 as Sum
            var res = DateTime.Now.ToSideEffects()
                // add one day to internal date value of the monad (becoming tomorrow), transform it to a Monad itself and instantiate it with Sum set to 5. 
                // this is then the return value of the anonymous function called over the instantiated internal DateTime value (DateTime.Now)
                // Bind() returns a new Monad based on this result and its internal state (Today, 0) becoming (Tomorrow, 5)
                .Bind(dt => dt.AddDays(1).ToSideEffects(5))
                
                // as a result of immutable types, chaining becomes a possibility. the result value of the former Bind() is used as input for this one.
                // here we add a month to the day of tomorrow and add 0 (no param in ToSideEffects) to the Sum property.
                
                // how does this work again?
                // Bind() calls the provided function over its internal value.
                // therefore its internal _val is used for dt, which is raised by a month and then transformed to a Monad with 0 as Sum.
                // Bind merges this new Monad (TomorrowAndOneMonth, 0) with its internal state (Tomorrow, 5) to another new Monad.
                // In this merging, the new value type is copied (TomorrowAndOneMonth) and the old Sum state (5) is added to the new Monad's Sum (0)
                // This results in (TomorrowAndOneMonth, 5)
                .Bind(dt => dt.AddMonths(1).ToSideEffects());
            Console.WriteLine("Value datetime monad: {0}", res.Value);
            Console.WriteLine("Sum output datetime monad: {0}", res.Sum);

            // Visitor stuff
            var a = new ClassA();
            a.SomeInt = 62;
            var b = new ClassB();
            var i = a.Accept<int>(new CountVisitor(), 0);
            var i2 = b.Accept<int>(new CountVisitor(), i);
            Console.WriteLine("CountVisitor over Class A: {0}", i);
            Console.WriteLine("CountVisitor over Class B: {0}", i2);

            Console.ReadKey();
        }
    }
}
