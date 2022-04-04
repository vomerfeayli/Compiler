using System;

namespace Compiler.Exceptions
{
    public class CodeException : Exception
    {
        public CodeException(string message) : base(message)
        {

        }
    }
}
