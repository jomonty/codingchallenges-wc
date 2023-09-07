using System.Diagnostics;

namespace wc
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("wc");

            if (!validateInput(args))
                System.Environment.Exit(0);

            string filePath = args[1];

            Console.WriteLine(filePath);

            try
            {
                switch (args[0])
                {
                    case "-c":
                        Console.WriteLine(File.ReadAllBytes(filePath).Length);
                        break;
                    case "-l":
                        Console.WriteLine(File.ReadAllLines(filePath).Length);
                        break;
                    case "-w":
                        Console.WriteLine(countWords(filePath));
                        break;
                    case "-m":
                        Console.WriteLine("Not implemented");
                        break;
                    default:
                        
                        break;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"The file could not be read: {e.Message}");
            }

        }

        static private bool validateInput(string[] args)
        {
            if (args.Length != 2)
            {
                Console.WriteLine("Invalid number of arguments, please provide an option and a file.");
                return false;
            }

            string[] validOptions = { "-c", "-l", "-w", "-m" };

            if (!validOptions.Contains(args[0]))
            {
                Console.WriteLine("Valid options are -c, -l, -w, -m");
                return false;
            }

            return true;
        }

        static private int countWords(string filePath)
        {
            using (StreamReader sr = new StreamReader(filePath))
            {
                int counter = 0;
                string delim = " [](),.";
                string[] fields = null;
                string? line = null;

                while (!sr.EndOfStream)
                {
                    line = sr.ReadLine();
                    line?.Trim();
                    fields = line?.Split(delim.ToCharArray(), StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries);
                    counter += fields.Length;
                }

                return counter;
            }
        }
    }
}