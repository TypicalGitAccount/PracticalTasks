using Practice;
using System.Text;

namespace Practice {
    public class Program
    {
        public static void Main(string[] args) {
            WordStats stats = new WordStats();
            Console.WriteLine("Enter your filepath:");
            string filepath = Console.ReadLine();

            try
            {
                stats.gatherStats(filepath);
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine(ex.Message);
                return;
            }

            Console.WriteLine(stats);
            Console.WriteLine("Enter a word to recieve full stats on it:");
            Console.InputEncoding = Encoding.Unicode;
            string word = Console.ReadLine();

            Console.WriteLine(stats.GetFullStats(word.ToLower()));
            Console.ReadLine();
        }
    }
}