using System;

namespace AdditionalLibrary
{
    public class LessThanZeroException : Exception
    {
        public LessThanZeroException(string msg) : base(msg) { }
    }
}
