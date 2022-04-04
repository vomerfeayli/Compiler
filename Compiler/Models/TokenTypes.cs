using System.Collections.Generic;

namespace Compiler.Models
{
    public class TokenTypes
    {
        public List<TokenType> Types = new List<TokenType>
            {
                new TokenType { Name = "Variable", Regex = "Var|var" },
                new TokenType { Name = "Minus", Regex = "-" },
                new TokenType { Name = "Space", Regex = " " },  
                new TokenType { Name = "Ident", Regex = "[a-z]*" },
                new TokenType { Name = "Comma", Regex = "," },
                new TokenType { Name = "Semicolon", Regex = ";" },
                new TokenType { Name = "Assign", Regex = ":=" },
                new TokenType { Name = "Addition", Regex = "\\+" },
                new TokenType { Name = "Subtraction", Regex = "-" },
                new TokenType { Name = "Multiplication", Regex = "\\*" },
                new TokenType { Name = "Division", Regex = "/" },
                new TokenType { Name = "Left bracket", Regex = "\\(" },
                new TokenType { Name = "Right bracket", Regex = "\\)" },
                new TokenType { Name = "Line break", Regex = "\\n" },
                new TokenType { Name = "Constant", Regex = "[0-9]*" }
            };    
    }
}
