using Compiler.Exceptions;
using Compiler.Models;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Compiler.Core
{
    public class Lexer
    {
        private string _code;
        private int _line = 1;
        private int _position = 0;

        private List<Token> _tokens = new List<Token>();
        private List<TokenType> _tokenTypes;

        public Lexer(string code)
        {
            _code = code;

            var tokenTypes = new TokenTypes();
            _tokenTypes = tokenTypes.Types;
        }

        /// <summary>
        /// Запустить лексический анализатор.
        /// </summary>
        /// <returns></returns>
        public void Run()
        {
            while (GetTokensFromCode())
            {

            }
        }

        /// <summary>
        /// Вернуть все токены кода.
        /// </summary>
        /// <returns></returns>
        public List<Token> GetTokens()
        {
            return _tokens;
        }

        /// <summary>
        /// Найти в коде все токены.
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

                var result = regex.Match(_code).ToString();

                if (string.IsNullOrEmpty(result))
                {
                    continue;
                }

                var _token = new Token { Type = tokenType, LexemName = tokenType.Name, Value = result, Line = _line, Position = _position };

                if (tokenType == _tokenTypes[1] && _tokens.Count != 0
                                                && (_tokens[_tokens.Count - 1].Type == _tokenTypes[3] || _tokens[_tokens.Count - 1].Type == _tokenTypes[14]))
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
                    _position = 0 - 1;
                }

                _position += result.Length;
                _code = _code.Substring(result.Length);

                return true;
            }

            throw new CodeException($"Ошибка в коде. Строка {_line}, позиция {_position}");
        }
    }
}