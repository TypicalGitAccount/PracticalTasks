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
            while (true)
            {
                Console.WriteLine("Enter a word to recieve full stats on it; enter \"exit\" to stop the program.");
                var word = notNullInput(warningMessage: "Word can\'t be null or empty string!");
                if (word == "exit")
                    return;
                if (!stats.Contain(word))
                {
                    Console.WriteLine($"No \"{word}\" word found in stats! Please Choose another one.");
                }
                else
                {
                    Console.WriteLine(stats.GetFullStats(word.ToLower()));
                }
                
            }
            Console.ReadLine();
        }
    }
}
