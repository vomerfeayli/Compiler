using System.ComponentModel;

namespace Compiler
{
    public class Token
    {
        public string LexemName { get; set; }
        public string Value { get; set; }
        public int Line { get; set; }
        public int Position { get; set; }
    }
}