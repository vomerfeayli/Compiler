using System.Collections.Generic;

namespace Compiler.Core
{
    public class CodeGenerator
    {
        private List<string> rpns;
        private List<string> generatedCode;
        private Dictionary<string, double?> variableValue;
        private Stack<double> stack;
        private List<string> variables;

        private int STO = 0;
        private int LOAD = 0;
        private bool isUnary;

        public CodeGenerator(List<string> rpns, List<string> variables)
        {
            this.rpns = rpns;
            this.variables = variables;

            generatedCode = new List<string>();
            stack = new Stack<double>();
            variableValue = new Dictionary<string, double?>();
        }

        /// <summary>
        /// Запустить генератор кода.
        /// </summary>
        public void Run()
        {
            foreach (var rpn in rpns)
            {
                GenerateCode(rpn);
            }
        }

        /// <summary>
        /// Получить результат вычислений.
        /// </summary>
        /// <returns></returns>
        public Dictionary<string, double?> GetResult()
        {
            return variableValue;
        }

        /// <summary>
        /// Получить сгенерированный код.
        /// </summary>
        /// <returns></returns>
        public List<string> GetGeneratedCode()
        {
            return generatedCode;
        }

        private bool IsConstant(string s)
        {
            if (double.TryParse(s, out var _))
            {
                return true;
            }

            return false;
        }

        private void GenerateCode(string rpn)
        {
            var splitedRpn = rpn.Split(' ');

            for (int i = 0; i < splitedRpn.Length; i++)
            {
                var item = splitedRpn[i];

                if (IsConstant(item))
                {
                    LitVariable(item);

                    IsLastElementThenStorage(i, splitedRpn.Length);

                    continue;
                }

                if (!IsConstant(item) && "+-/*".IndexOf(item) == -1)
                {
                    LoadVariable(item);

                    continue;
                }

                if ("+-/*".IndexOf(item[0]) != -1)
                {
                    if (item == "+")
                    {
                        Add();

                        IsLastElementThenStorage(i, splitedRpn.Length);
                    }

                    if (item == "-")
                    {
                        Subtract();

                        if (!isUnary)
                        {
                            IsLastElementThenStorage(i, splitedRpn.Length);
                        }
                        else
                        {
                            STOAfterMinus();
                        }

                    }

                    if (item == "*")
                    {
                        Multiply();

                        IsLastElementThenStorage(i, splitedRpn.Length);
                    }

                    if (item == "/")
                    {
                        Divide();

                        IsLastElementThenStorage(i, splitedRpn.Length);
                    }
                }
            }
        }

        private void IsLastElementThenStorage(int iteration, int count)
        {
            if (iteration + 1 == count)
            {
                STOVariable(variables[STO]);
            }
        }

        private void Add()
        {
            var secondTerm = stack.Pop();
            var firstTerm = stack.Pop();

            stack.Push(firstTerm + secondTerm);

            generatedCode.Add($"ADD");
        }

        private void Subtract()
        {
            if (stack.Count == 1)
            {
                UnaryOperation();
                isUnary = true;
            }

            var secondTerm = stack.Pop();
            var firstTerm = stack.Pop();

            stack.Push(firstTerm - secondTerm);

            generatedCode.Add($"SUB");
        }

        private void Multiply()
        {
            var secondTerm = stack.Pop();
            var firstTerm = stack.Pop();

            stack.Push(firstTerm * secondTerm);

            generatedCode.Add($"MUL");
        }

        private void Divide()
        {
            var secondTerm = stack.Pop();
            var firstTerm = stack.Pop();

            stack.Push(firstTerm / secondTerm);

            generatedCode.Add($"DIV");
        }

        private void LoadVariable(string variable)
        {
            LOAD++;

            var value = variableValue[variable].Value;

            stack.Push(value);

            generatedCode.Add($"LOAD {LOAD}");
        }

        private void UnaryOperation()
        {
            var variableName = variables[LOAD];

            STOVariable(variableName);

            stack.Push(0);

            generatedCode.Add($"LOAD 0");

            var value = variableValue[variableName].Value;

            stack.Push(value);

            generatedCode.Add($"LOAD {LOAD + 1}");
        }

        private void LitVariable(string value)
        {
            var variable = double.Parse(value);

            stack.Push(variable);

            generatedCode.Add($"LIT {variable}");
        }

        private void STOVariable(string variableName)
        {
            STO++;

            var value = stack.Pop();

            variableValue.Add(variableName, value);

            generatedCode.Add($"STO {STO}");
        }

        private void STOAfterMinus()
        {
            var value = stack.Pop();

            var variableName = variables[LOAD];
            variableValue[variableName] = value;

            generatedCode.Add($"STO {STO}");
        }
    }
}
