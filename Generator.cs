using System;
using System.Text;

namespace CodeLib.ValueGenerator
{
    public static class Generator
    {
        private readonly static Random rnd = new Random();
        private readonly static string[] caseSensitiveLetterNumberValues =
            {
                "q", "w", "e", "r", "t", "y", "u", "i", "o", "p", "a", "s", "d", "f",
                "g", "h", "j", "k", "l", "z", "x", "c", "v", "b", "n", "m", 
                "Q", "W", "E", "R", "T", "Y", "U", "I",      "P", "A", "S", "D", "F",
                "G", "H", "J", "K", "L", "Z", "X", "C", "V", "B", "N", "M",
                "1", "2", "3", "4", "5", "6", "7", "8", "9", "0",
            };
        
        private readonly static string[] caseInsensitiveLetterNumberValues =
            {
                "q", "w", "e", "r", "t", "y", "u", "i", "o", "p", "a", "s", "d", "f",
                "g", "h", "j", "k", "l", "z", "x", "c", "v", "b", "n", "m", 
                "1", "2", "3", "4", "5", "6", "7", "8", "9", "0",
            };

        private readonly static string[] commonCaseSensitiveValues =
            {
                "q", "w", "e", "r", "t", "y", "u", "i", "o", "p", "a", "s", "d", "f",
                "g", "h", "j", "k", "l", "z", "x", "c", "v", "b", "n", "m", 
                "Q", "W", "E", "R", "T", "Y", "U", "I",      "P", "A", "S", "D", "F",
                "G", "H", "J", "K", "L", "Z", "X", "C", "V", "B", "N", "M",
                "1", "2", "3", "4", "5", "6", "7", "8", "9", "0",
                "!", "@", "%", "$", "_", "-", "+"
            };

        private readonly static string[] commonCaseInsensitiveValues =
            {
                "q", "w", "e", "r", "t", "y", "u", "i", "o", "p", "a", "s", "d", "f",
                "g", "h", "j", "k", "l", "z", "x", "c", "v", "b", "n", "m", 
                "1", "2", "3", "4", "5", "6", "7", "8", "9", "0",
                "!", "@", "%", "$", "_", "-", "+"
            };
        

        public static string Generate(ValueType type, int length = 6)
        {
            if (type == ValueType.CaseInsensitiveLetterNumberValues)
                return Generate(caseInsensitiveLetterNumberValues, length);
            if (type == ValueType.CaseSensitiveLetterNumberValues)
                return Generate(caseSensitiveLetterNumberValues, length);
            if (type == ValueType.CommonCaseInsensitiveValues)
                return Generate(commonCaseInsensitiveValues, length);
            if (type == ValueType.CommonCaseSensitiveValues)
                return Generate(commonCaseSensitiveValues, length);
            
            return null;
        }

        private static string Generate(string[] possibleValues, int length)
        {
            lock (rnd)
            {
                var value = new StringBuilder();
                var maxIndex = possibleValues.Length - 1;

                for (var i = 0; i < length; i++)
                {
                    value.Append(possibleValues[rnd.Next(0, maxIndex)]);
                }

                return value.ToString();
            }
        }
    }
}
