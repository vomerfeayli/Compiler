using System;

namespace Compiler.Exceptions
{
    public class SyntaxException : Exception
    {
        public SyntaxException(string message) : base(message)
        {

        }
    }
}
