using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Compiler
{
    public class Lexer
    {
        private string _code;
        private int _line = 1;
        private int _position = 0;

        private List<Token> _tokens = new List<Token>();

        public Lexer(string code)
        {
            _code = code;
        }

        public List<Token> LexAnalisis()
        {
            while (NextToken())
            {
                //todo хз

            }

            return _tokens;
        }

        private bool NextToken()
        {
            if (_code != null && _code.Length == 0)
            {
                return false;
            }

            for (int i = 0; i < _tokenTypes.Count; i++)
            {
                var tokenType = _tokenTypes[i];
                var regex = new Regex("^"+tokenType.Regex);
                var result = regex.Match(_code).ToString();

                if (!string.IsNullOrEmpty(result))
                {

                    if (result != " " && result != "\n")
                    {
                        _tokens.Add(new Token { LexemName = tokenType.Name, Value = result, Line = _line, Position = _position });
                    }

                    if (result == "\n")
                    {
                        _line++;
                        _position = 0-1;
                    }

                    _position += result.Length;
                    _code =  _code.Substring(result.Length);
                    return true;
                }
            }

            throw new CodeException($"Ошибка в коде. Строка {_line}, позиция {_position}");
        }
        
        
        private List<TokenType> _tokenTypes = new List<TokenType>
        {
            new TokenType { Name = "Variable", Regex = "Var" },
            new TokenType { Name = "Space", Regex = " " },
            new TokenType { Name = "Ident", Regex = "[a-z]*" },
            new TokenType { Name = "Comma", Regex = "," },
            new TokenType { Name = "Semicolon", Regex = ";" },
            new TokenType { Name = "Assign", Regex = ":=" },
            new TokenType { Name = "Addition", Regex = "\\+" },
            new TokenType { Name = "Subtraction", Regex = "-" },
            new TokenType { Name = "Multiplication", Regex = "*" },
            new TokenType { Name = "Division", Regex = "/" },
            new TokenType { Name = "Minus", Regex = "-" },
            new TokenType { Name = "Left bracket", Regex = "\\(" },
            new TokenType { Name = "Right bracket", Regex = "\\)" },
            new TokenType { Name = "Line break", Regex = "\\n" },
            new TokenType { Name = "Constant", Regex = "[0-9]*" },
            new TokenType { Name = "Operand", Regex = "([a-z]*)|([0-9]*)" }
        };
    }
    
   /* { "Variable", new TokenType { Name = "Var", Regex = "Var" } },
{ "Ident", new TokenType { Name = "Ident", Regex = "[a-z]*" } },
{ "Comma", new TokenType { Name = "Comma", Regex = "," } },
{ "Semicolon", new TokenType { Name = "Semicolon", Regex = ";" } },
{ "Assign", new TokenType { Name = "Assign", Regex = ":=" } },
{ "Binary operator", new TokenType { Name = "Addition", Regex = "+" } },
{ "Binary operator", new TokenType { Name = "Subtraction", Regex = "-" } },
{ "Binary operator", new TokenType { Name = "Multiplication", Regex = "*" } },
{ "Binary operator", new TokenType { Name = "Division", Regex = "/" } },
{ "Unary operator", new TokenType { Name = "Minus", Regex = "-" } },
{ "Brackets", new TokenType { Name = "Left bracket", Regex = "(" } },
{ "Brackets", new TokenType { Name = "Right bracket", Regex = ")" } }
//{ "Space", new TokenType { Name = "Space", Regex = " " } }*/
}