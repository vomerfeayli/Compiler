using System.ComponentModel;

namespace Compiler
{
    public class Token
    {
        [Browsable(false)]
        public TokenType Type { get; set; }
        public string LexemName { get; set; }
        public string Value { get; set; }
        public int Line { get; set; }
        public int Position { get; set; }
    }
}