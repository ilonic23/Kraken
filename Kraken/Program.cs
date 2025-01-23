namespace Kraken
{
    internal class Program
    {
        const string version = "Kraken programming language v0.0.1";
        static void Main(string[] args)
        {
            //if (args.Length == 0)
            //{
            //    Console.WriteLine("Unknown command.");
            //    Help();
            //    return;
            //}
            //else if (args[0] == "-v")
            //{
            //    Console.WriteLine(version);
            //}
            //else if (args[0] == "-h")
            //{
            //    Help();
            //}
            //else if (args[0] == "-p")
            //{
            //    if (args.Length != 2)
            //    {
            //        Console.WriteLine("Unable to parse, no code line");
            //    }
            //    else
            //    {
            //        ErrorType error = Parser.Parse(Lexer.Tokenize(args[1]));
            //        if (error != ErrorType.KR0000)
            //        {
            //            Console.WriteLine("Error: {0}", error.ToString());
            //        }
            //    }
            //}
            List<Token> tokens = Lexer.Tokenize("print2335");
            foreach (Token token in tokens)
            {
                Console.WriteLine(token.ToString());
            }
            Parser.Parse(tokens);
            Console.ReadLine();
        }

        static void Help()
        {
            Console.WriteLine("Kraken help:");
            Console.WriteLine("-h - display this window and exit");
            Console.WriteLine("-n - create a new project, it will ask for a directory");
            Console.WriteLine("-p - parse a one string line");
            Console.WriteLine("-v - display current version");
        }
    }
}
