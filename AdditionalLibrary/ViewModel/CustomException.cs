using System;

namespace AdditionalLibrary
{
    public class CustomException : Exception
    {
        public CustomException(string msg) : base(msg) { }
    }
}
