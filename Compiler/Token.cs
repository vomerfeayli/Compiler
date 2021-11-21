using System.ComponentModel;

namespace Compiler
{
    public class Token
    {
        /// <summary>
        /// Тип токена.
        /// </summary>
        [Browsable(false)]
        public TokenType Type { get; set; }

        /// <summary>
        /// Название лексемы.
        /// </summary>
        public string LexemName { get; set; }

        /// <summary>
        /// Значение лексемы.
        /// </summary>
        public string Value { get; set; }

        /// <summary>
        /// Номер линии, на которой находиться токен.
        /// </summary>
        public int Line { get; set; }

        /// <summary>
        /// Позиция токена на строчке.
        /// </summary>
        public int Position { get; set; }
    }
}