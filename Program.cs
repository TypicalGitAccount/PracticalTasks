using System;
using System.Text;

namespace Practice {
    public class Program
    { 
        public static string notNullInput(string warningMessage)
        {
            while (true)
            {
                var input = Console.ReadLine();
                if (!string.IsNullOrEmpty(input))
                    return input;

                Console.WriteLine(warningMessage);
            }
        }

        public static void Main(string[] args) {
            Console.InputEncoding = Encoding.Unicode;
            Console.OutputEncoding = Encoding.Unicode;
            var stats = new WordStats();
            Console.WriteLine("Enter your filepath:");
            var filepath = notNullInput(warningMessage: "Filepath can\'t be null or empty string!");
            while(!stats.gatherStats(filepath)) {
                Console.WriteLine($"No file with path \'{filepath}\' exists!");
                filepath = notNullInput(warningMessage: "Filepath can\'t be null or empty string!");
            }
            Console.WriteLine(stats);
            Console.WriteLine("Enter a word to recieve full stats on it:");
            var word = notNullInput(warningMessage: "Word can\'t be null or empty string!");
            Console.WriteLine(stats.GetFullStats(word.ToLower()));
            Console.ReadLine();
        }
    }
}
