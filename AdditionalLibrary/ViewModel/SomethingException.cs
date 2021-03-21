using System;

namespace AdditionalLibrary
{
    public class SomethingException : Exception
    {
        public SomethingException(string msg) : base(msg) { }
    }
}
