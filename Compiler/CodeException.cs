using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compiler
{
    public class CodeException : Exception
    {
        public CodeException(string message) : base(message)
        {

        }
    }
}
