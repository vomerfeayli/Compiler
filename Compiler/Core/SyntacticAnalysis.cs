using Compiler.Exceptions;
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

            while (Cursor < _tokens.Count)
            {
                CheckExpression();
            }
        }

        private void CheckExpression()
        {
            var tokensList = new List<Token>();

            Cursor += 2;

            var iter = Cursor;

            while (_tokens[iter].Value != ";")
            {
                tokensList.Add(_tokens[iter]);
                iter++;
            }

            Cursor = iter + 1;

            RPNs.Add(GetReversePolishNotation(tokensList));
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

        /// <summary>
        /// Получить постфиксную запись выражения.
        /// </summary>
        /// <param name="tokens">Токены выражения.</param>
        /// <returns>Обратная польская нотация.</returns>
        private string GetReversePolishNotation(List<Token> tokens)
        {
            string output = string.Empty;
            var operStack = new Stack<string>();
            var unOperStack = new Stack<string>();

            var isSkip = false;

            for (int i = 0; i < tokens.Count; i++)
            {
                if (isSkip)
                {
                    isSkip = false;
                    continue;
                }

                if (tokens[i].Type.Name == "Ident" || tokens[i].Type.Name == "Constant")
                {
                    output += $"{tokens[i].Value} ";

                    continue;
                }

                if (tokens[i].Type.Name == "Left bracket")
                {
                    operStack.Push(tokens[i].Value);

                    continue;
                }

                if (tokens[i].Type.Name == "Right bracket")
                {
                    while (operStack.Count != 0 && operStack.Peek() != "(")
                    {
                        output += $"{operStack.Pop()} ";

                        continue;
                    }

                    if (operStack.Count != 0 && operStack.Peek() == "(")
                    {
                        operStack.Pop();

                        continue;
                    }

                    if (operStack.Count == 0)
                    {
                        throw new SyntaxException($"В выражении не согласованы скобки | Строка: {tokens[i].Line}");
                    }
                }

                if ("+-/*".IndexOf(tokens[i].Value) != -1)
                {
                    if (tokens[i].Type.Name == "Minus")
                    {
                        if (tokens[i + 1].Type.Name == "Minus")
                        {
                            operStack.Push("+");
                            isSkip = true;

                            continue;
                        }

                        if (tokens[i + 1].Type.Name == "Addition")
                        {
                            operStack.Push(tokens[i].Value);
                            isSkip = true;

                            continue;
                        }

                        if (tokens[i + 1].Type.Name == "Multiplication" || tokens[i + 1].Type.Name == "Division")
                        {
                            throw new SyntaxException($"В выражении допущена ошибка | Строка: {tokens[i].Line} | Позиция {tokens[i].Position}");
                        }

                        if (tokens[i + 1].Type.Name == "Constant")
                        {
                            output += $"{tokens[i].Value}{tokens[i + 1].Value} ";
                            isSkip = true;

                            continue;
                        }

                        if (tokens[i + 1].Type.Name == "Ident")
                        {
                            output += $"{tokens[i].Value}{tokens[i + 1].Value} ";

                            continue;
                        }

                        if (tokens[i + 1].Value == "(")
                        {
                            unOperStack.Push(tokens[i].Value);

                            continue;
                        }

                        throw new SyntaxException($"В выражении допущена ошибка | Строка: {tokens[i].Line} | Позиция {tokens[i].Position}");
                    }

                    if (operStack.Count != 0 && "+-/*".IndexOf(tokens[i].Value) != -1)
                    {
                        if (GetPriority(operStack.Peek()) >= GetPriority(tokens[i].Value))
                        {
                            output += $"{operStack.Pop()} ";
                        }
                    }

                    operStack.Push(tokens[i].Value);

                    continue;
                }
            }

            while (operStack.Count > 0)
            {
                output += $"{operStack.Pop()} ";
            }

            while (unOperStack.Count > 0)
            {
                output += $"{unOperStack.Pop()} ";
            }

            return output.Trim();
        }

        private byte GetPriority(string s)
        {
            switch (s)
            {
                case "(": return 1;
                case ")": return 2;
                case "+": return 3;
                case "-": return 4;
                case "*": return 5;
                case "/": return 6;
                default: return 7;
            }
        }
    }
}
