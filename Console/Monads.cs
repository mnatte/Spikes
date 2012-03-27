using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DCI_spike
{
    #region BasicMonad

    public class BasicMonad<T>
    {
        private readonly T _val;
        public T Value { get { return _val; } }

        public BasicMonad(T val)
        {
            _val = val;
        }

        public BasicMonad<R> Bind<R>(Func<T, BasicMonad<R>> function)
        {
            var result = function(_val);
            return new BasicMonad<R>(result.Value);
        }
    }

    #endregion

    #region SideEffectsMonad

    public class SideEffectsMonad<T>
    {
        private readonly T _val;
        private int _sum;
        public T Value { get { return _val; } }

        public SideEffectsMonad(T val, int number)
        {
            _val = val;
            _sum = number;
        }

        public SideEffectsMonad(T val)
            : this(val, 0)
        { }

        public int Sum
        {
            get { return _sum; }
        }

        /// <summary>
        /// Method to bind behavior to the SideEffectsMonad.
        /// SideEffectsMonad offers a property Sum to the external world for reading.
        /// Bind() returns a new SideEffectsMonad with updated Sum property based on the provided function argument.
        /// </summary>
        /// <typeparam name="R"></typeparam>
        /// <param name="function"></param>
        /// <returns></returns>
        public SideEffectsMonad<R> Bind<R>(Func<T, SideEffectsMonad<R>> function)
        {
            var result = function(_val);
            return new SideEffectsMonad<R>(result.Value, _sum + result._sum);
        }
    }

    public class EnumMonad<T>
    {
        private readonly T _val;
        public T Value { get { return _val; } }
        private readonly bool _isEmpty;
        public bool IsEmpty { get { return _isEmpty; } }
        public bool HasValue { get { return !_isEmpty; } }

        public static readonly EnumMonad<T> Empty = new EnumMonad<T>();

        public EnumMonad(T val)
        {
            _val = val;
        }

        private EnumMonad()
        {
            _isEmpty = true;
        }

        public EnumMonad<R> Bind<R>(Func<T, EnumMonad<R>> function)
        {
            return IsEmpty ? EnumMonad<R>.Empty : function(this.Value);
        }
    }

    #endregion

    public static class MonadExtensions
    {
        public static BasicMonad<T> ToViewModel<T>(this T val)
        {
            return new BasicMonad<T>(val);
        }

        /// <summary>
        /// transforms the provided value to a SideEffectsMonad with Sum set to 0
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="val"></param>
        /// <returns></returns>
        public static SideEffectsMonad<T> ToSideEffects<T>(this T val)
        {
            return new SideEffectsMonad<T>(val);
        }

        /// <summary>
        /// transforms the provided value to a SideEffectsMonad and sets Sum to num argument
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="val"></param>
        /// <param name="num"></param>
        /// <returns></returns>
        public static SideEffectsMonad<T> ToSideEffects<T>(this T val, int num)
        {
            return new SideEffectsMonad<T>(val, num);
        }

        public static EnumMonad<T> ToEnum<T>(this T val)
        {
            return new EnumMonad<T>(val);
        }

        public static EnumMonad<T> ToNotNullEnum<T>(this T val)
        {
            return val != null ? val.ToEnum() : EnumMonad<T>.Empty;
        }
    }
}
