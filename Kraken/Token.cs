namespace Kraken
{
    public class Token
    {
        public TokenType Type { get; set; }
        public string Value { get; set; }

        public Token(TokenType type, string value = "")
        {
            Type = type; Value = value;
        }

        public override string ToString()
        {
            return String.Format("{0}:{1}", Type, Value);
        }
    }

    public enum TokenType
    {
        Assign,
        Plus,
        Minus,
        Mul,
        Div,
        NumLiteral,
        Id,
        Print,
        Semicolon,
        EOF
    }
}
