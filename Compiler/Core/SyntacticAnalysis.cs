using Compiler.Exceptions;
using Compiler.Extensions;
using Compiler.Models;
using System.Collections.Generic;

namespace Compiler.Core
{
    public class SyntacticAnalysis
    {
        private List<Token> _tokens;
        private List<TokenType> _tokenTypes;
        private List<string> _variables;

        private List<string> RPNs;

        private int Cursor = 0;

        public SyntacticAnalysis(List<Token> tokens)
        {
            _tokens = new List<Token>(tokens);

            var tokenTypes = new TokenTypes();
            _tokenTypes = tokenTypes.Types;

            RPNs = new List<string>();
            _variables = new List<string>();
        }

        /// <summary>
        /// Запустить синтаксический анализ.
        /// </summary>
        public void Run()
        {
            DeclaringVariables();
            DescriptionOfCalculations();
        }
        
        /// <summary>
        /// Получить постфиксные записи выражений.
        /// </summary>
        /// <returns></returns>
        public List<string> GetRPNs()
        {
            return RPNs;
        }

        /// <summary>
        /// Получить список переменных.
        /// </summary>
        /// <returns></returns>
        public List<string> GetVariablesList()
        {
            return _variables;
        }

        private void DeclaringVariables()
        {
            ChecktVar();
            CheckIdents();
        }

        private void DescriptionOfCalculations()
        {
            CheckIdent();
            CheckAssign();

            for (int i = Cursor; i < _tokens.Count; i++)
            {
                CheckExpression();
            }
        }

        private void CheckExpression()
        {
            var isSkipNextIter = false;

            if (Cursor >= _tokens.Count)
            {
                return;
            }

            var expression = $"";

            Cursor += 2;

            for (int i = Cursor; i < _tokens.Count; i++)
            {
                if (isSkipNextIter)
                {
                    isSkipNextIter = false;
                    continue;
                }

                if (_tokens[i].Type.Name == _tokenTypes[5].Name)
                {
                    Cursor = i + 1;
                    break;
                }

                if (_tokens[i].Type.Name == _tokenTypes[1].Name && _tokens[i + 1].Type.Name == _tokenTypes[1].Name)
                {
                    isSkipNextIter = true;

                    expression += _tokens[7].Value;
                    Cursor = i + 1;
                    continue;
                }

                if (_tokens[i].Type.Name == _tokenTypes[1].Name && _tokens[i + 1].Type.Name == _tokenTypes[7].Name)
                {
                    isSkipNextIter = true;

                    expression += _tokens[i].Value;
                    Cursor = i + 1;
                    continue;
                }

                if (_tokens[i].Type.Name == _tokenTypes[1].Name && _tokens[i + 1].Type.Name == _tokenTypes[9].Name ||
                    _tokens[i].Type.Name == _tokenTypes[1].Name && _tokens[i + 1].Type.Name == _tokenTypes[10].Name)
                {
                    throw new SyntaxException($"Неправильная запись выражения  | Строка: {_tokens[Cursor + 1].Line} | Позиция: {_tokens[Cursor + 1].Position}");
                }

                Cursor = i + 1;

                expression += _tokens[i].Value;
            }

            RPNs.Add(ReversePolishNotation.Get(expression));
        }

        private void CheckAssign()
        {
            if (_tokens[Cursor + 1].Type.Name != _tokenTypes[6].Name)
            {
                throw new SyntaxException($"В блоке вычислений ожидался {_tokenTypes[6].Name} | Строка: {_tokens[Cursor + 1].Line} | Позиция: {_tokens[Cursor + 1].Position}");
            }
        }

        private void CheckIdent()
        {
            if (_tokens[Cursor].Type.Name != _tokenTypes[3].Name)
            {
                throw new SyntaxException($"В блоке вычислений ожидался {_tokenTypes[3].Name} | Строка: {_tokens[Cursor].Line} | Позиция: {_tokens[Cursor].Position}");
            }
        }

        private void ChecktVar()
        {
            if (_tokens[0].LexemName != _tokenTypes[0].Name)
            {
                throw new SyntaxException($"В блоке объявления переменных ожидался Var | Строка: {_tokens[0].Line} | Позиция: {_tokens[0].Position}");
            }
        }

        private void CheckIdents()
        {
            for (int i = 1; i <= _tokens.Count - 1; i++)
            {
                if (_tokens[i].Type.Name == _tokenTypes[4].Name && i == 1 ||
                    _tokens[i].Type.Name == _tokenTypes[5].Name && i == 1 ||
                    _tokens[i].Type.Name == _tokenTypes[4].Name && _tokens[i + 1].Type.Name == _tokenTypes[5].Name)
                {
                    throw new SyntaxException($"В блоке объявления переменных ожидался идентификатор | Строка: {_tokens[i].Line} | Позиция: {_tokens[i].Position}"); ; ;
                }

                if (_tokens[i].Type.Name == _tokenTypes[0].Name ||
                    _tokens[i].Type.Name == _tokenTypes[1].Name ||
                    _tokens[i].Type.Name == _tokenTypes[6].Name ||
                    _tokens[i].Type.Name == _tokenTypes[7].Name ||
                    _tokens[i].Type.Name == _tokenTypes[8].Name ||
                    _tokens[i].Type.Name == _tokenTypes[9].Name ||
                    _tokens[i].Type.Name == _tokenTypes[10].Name ||
                    _tokens[i].Type.Name == _tokenTypes[11].Name ||
                    _tokens[i].Type.Name == _tokenTypes[12].Name ||
                    _tokens[i].Type.Name == _tokenTypes[14].Name)
                {
                    throw new SyntaxException($"В качестве идентификатора нельзя использовать {_tokens[i].Type.Name} | Строка: {_tokens[i].Line} | Позиция: {_tokens[i].Position}"); ; ;
                }

                if (_tokens[i].Type.Name == _tokenTypes[3].Name && _tokens[i + 1].Type.Name == _tokenTypes[3].Name)
                {
                    throw new SyntaxException($"В блоке объявления переменных ожидалась запятая | Строка: {_tokens[i].Line} | Позиция: {_tokens[i].Position}"); ; ;
                }

                if (_tokens[i].Type.Name == _tokenTypes[5].Name && i > 1)
                {
                    Cursor = i + 1;
                    return;
                }

                if (_tokens[i].Type.Name != _tokenTypes[4].Name)
                {
                    _variables.Add(_tokens[i].Value);
                }
            }
        }
    }
}
