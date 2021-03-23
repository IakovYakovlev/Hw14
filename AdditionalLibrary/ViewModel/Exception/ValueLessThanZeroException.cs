using System;

namespace AdditionalLibrary
{
    public class ValueLessThanZeroException : Exception
    {
        public ValueLessThanZeroException(string msg) : base(msg) { }
    }
}
