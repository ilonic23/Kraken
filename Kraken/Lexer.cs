using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kraken
{
    internal class Lexer
    {
        public static List<Token> Tokenize(string line)
        {
            var tokens = new List<Token>();
            for (int i = 0; i < line.Length; i++)
            {
                char c = line[i];
                if (c == '=') 
                {
                    tokens.Add(new Token(TokenType.Assign));
                }
                else if (c == '+')
                {
                    tokens.Add(new Token(TokenType.Plus));
                }
                else if (c == '-')
                {
                    tokens.Add(new Token(TokenType.Minus));
                }
                else if (c == '/')
                {
                    tokens.Add(new Token(TokenType.Div));
                }
                else if (c == '*')
                {
                    tokens.Add(new Token(TokenType.Mul));
                }
                else if (c == ';')
                {
                    tokens.Add(new Token(TokenType.Semicolon));
                }
                else if (Char.IsNumber(c))
                {
                    tokens.Add(new Token(TokenType.NumLiteral, FromIndexToIndex(i, i+GetNumber(i, line)-1, line)));
                    i += GetNumber(i, line)-1;
                }
                else if (Char.IsAsciiLetter(c))
                {
                    tokens.Add(new Token(IdOrKeywordType(i, line)));
                    i += IdOrKeyword(i, line)-1;
                }
            }
            tokens.Add(new Token(TokenType.EOF));
            return tokens;
        }

        /// <summary>
        /// Gets the number
        /// </summary>
        /// <param name="currentIndex"></param>
        /// <returns>How many chars are numbers</returns>
        private static int GetNumber(int currentIndex, string line)
        {
            string number = "";
            for (int i = currentIndex; i < line.Length; i++)
            {
                char c = line[i];
                if (Char.IsNumber(c)) number += c;
                else break;
            }
            return number.Length;
        }

        /// <summary>
        /// Gets a string
        /// </summary>
        /// <param name="indexOne"></param>
        /// <param name="indexTwo"></param>
        /// <param name="source"></param>
        /// <returns>A string from specified character to another specified character</returns>
        private static string FromIndexToIndex(int indexOne, int indexTwo, string source)
        {
            string result = "";
            for (int i = indexOne; i <= indexTwo; i++)
            {
                result += source[i];
            }
            return result;
        }

        /// <summary>
        /// Determines whether the string is ID or keyword
        /// </summary>
        /// <param name="currentIndex"></param>
        /// <param name="line"></param>
        /// <returns>How many chars are ID or keyword</returns>
        private static int IdOrKeyword(int currentIndex, string line)
        {
            string idKeyword = "";
            for (int i = currentIndex; i < line.Length; i++)
            {
                char c = line[i];
                if (Char.IsAsciiLetter(c)) idKeyword += c;
            }
            return idKeyword.Length;
        }

        private static TokenType IdOrKeywordType(int currentIndex, string line)
        {
            string idKeyword = "";
            for (int i = currentIndex; i < line.Length; i++)
            {
                char c = line[i];
                if (Char.IsAsciiLetter(c)) idKeyword += c;
            }
            if (idKeyword == "print")
            {
                return TokenType.Print;
            }
            return TokenType.Id;
        }
    }
}
