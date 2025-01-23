using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kraken
{
    public class Parser
    {
        public static ErrorType Parse(List<Token> tokens)
        {
            for (int i = 0; i < tokens.Count; i++)
            {
                Token token = tokens[i];
                if (token.Type == TokenType.Print)
                {
                    Console.WriteLine(tokens[++i].Value);
                }
            }

            return ErrorType.KR0000;
        }
    }

    public enum ErrorType
    {
        KR0000,
        KR0001
    }
}
