using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Compiler.Extensions
{
    public class Helper
    {
        static public bool IsVariable(string s)
        {
            if (Regex.IsMatch(s, @"^\w+"))
            {
                return true;
            }

            return false;
        }

        static public bool IsConstant(string s)
        {
            if (double.TryParse(s, out var _))
            {
                return true;
            }

            return false;
        }
        static public bool IsDelimeter(char c)
        {
            if ((" ".IndexOf(c) != -1))
            {
                return true;
            }

            return false;
        }

        static public bool IsOperator(char с)
        {
            if (("+-/*^()".IndexOf(с) != -1))
            {
                return true;
            }

            return false;
        }

        static public byte GetPriority(char s)
        {
            switch (s)
            {
                case '(': return 0;
                case ')': return 1;
                case '+': return 2;
                case '-': return 3;
                case '*': return 4;
                case '/': return 4;
                default: return 5;
            }
        }
    }
}
