using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdditionalLibrary
{
    public class AmountNotMoreException : Exception
    {
        public AmountNotMoreException(string msg) : base(msg) { }
    }
}
