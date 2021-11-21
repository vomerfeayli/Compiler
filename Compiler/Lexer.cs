﻿using System;
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
        
        /// <summary>
        /// Возвращаем все токены кода
        /// </summary>
        /// <returns></returns>
        public List<Token> LexAnalisis()
        {
            while (GetTokensFromCode())
            {

            }

            return _tokens;
        }

        //todo надо красиво переделать
        /// <summary>
        /// Ищем в коде все токены.
        /// </summary>
        /// <returns></returns>
        private bool GetTokensFromCode()
        {
            if (_code != null && _code.Length == 0)
            {
                return false;
            }

            foreach (var tokenType in _tokenTypes)
            {
                var regex = new Regex("^" + tokenType.Regex);
                if (_code == null) return true;
                var result = regex.Match(_code).ToString();

                if (string.IsNullOrEmpty(result)) continue;
                var _token = new Token { Type = tokenType, LexemName = tokenType.Name, Value = result, Line = _line, Position = _position };

                if (tokenType == _tokenTypes[1] && _tokens.Count != 0 
                                                && (_tokens[_tokens.Count -1].Type == _tokenTypes[3] || _tokens[_tokens.Count - 1].Type == _tokenTypes[14]))
                {
                    _token.Type = _tokenTypes[8];
                    _token.LexemName = _tokenTypes[8].Name;
                }

                if (result != " " && result != "\n")
                {
                    _tokens.Add(_token);
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

            throw new CodeException($"Ошибка в коде. Строка {_line}, позиция {_position}");
        }
        
        /// <summary>
        /// Список всех токенов.
        /// </summary>
        private List<TokenType> _tokenTypes = new List<TokenType>
        {
            new TokenType { Name = "Variable", Regex = "Var" },
            new TokenType { Name = "Minus", Regex = "-" },
            new TokenType { Name = "Space", Regex = " " },
            new TokenType { Name = "Ident", Regex = "[a-z]*" },
            new TokenType { Name = "Comma", Regex = "," },
            new TokenType { Name = "Semicolon", Regex = ";" },
            new TokenType { Name = "Assign", Regex = ":=" },
            new TokenType { Name = "Addition", Regex = "\\+" },
            new TokenType { Name = "Subtraction", Regex = "-" },
            new TokenType { Name = "Multiplication", Regex = "*" },
            new TokenType { Name = "Division", Regex = "/" },
            new TokenType { Name = "Left bracket", Regex = "\\(" },
            new TokenType { Name = "Right bracket", Regex = "\\)" },
            new TokenType { Name = "Line break", Regex = "\\n" },
            new TokenType { Name = "Constant", Regex = "[0-9]*" }
        };
    }
}