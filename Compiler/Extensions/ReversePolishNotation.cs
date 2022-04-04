using System.Collections.Generic;

namespace Compiler.Extensions
{
    public class ReversePolishNotation
    {
        /// <summary>
        /// Получить постфиксную запись выражения.
        /// </summary>
        /// <param name="expression">Выражение</param>
        /// <returns></returns>
        static public string Get(string expression)
        {
            string output = string.Empty;
            Stack<char> operStack = new Stack<char>();

            for (int i = 0; i < expression.Length; i++)
            {
                if (Helper.IsDelimeter(expression[i]))
                {
                    continue;
                }

                if (char.IsDigit(expression[i]) || char.IsLetter(expression[i]))
                {

                    while (!Helper.IsDelimeter(expression[i]) && !Helper.IsOperator(expression[i]))
                    {
                        output += expression[i];
                        i++;
                        if (i == expression.Length)
                        {
                            break;
                        }
                    }

                    output += " ";
                    i--;
                }

                if (Helper.IsOperator(expression[i]))
                {
                    if (expression[i] == '(')
                    {
                        operStack.Push(expression[i]);
                    }
                    else if (expression[i] == ')')
                    {

                        char s = operStack.Pop();

                        while (s != '(')
                        {
                            output += s.ToString() + ' ';
                            s = operStack.Pop();
                        }
                    }
                    else
                    {
                        if (operStack.Count > 0)
                        {
                            if (Helper.GetPriority(expression[i]) <= Helper.GetPriority(operStack.Peek()))
                            {
                                output += operStack.Pop().ToString() + " ";
                            }
                        }

                        operStack.Push(char.Parse(expression[i].ToString()));
                    }
                }
            }

            while (operStack.Count > 0)
            {
                output += operStack.Pop() + " ";
            }

            return output.Trim();
        }
    }
}
