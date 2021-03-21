using System;

namespace AdditionalLibrary.ViewModel
{
    public class SomethingException : Exception
    {
        public SomethingException(string msg) : base(msg) { }
    }
}
