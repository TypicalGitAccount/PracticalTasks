using System.Text;
using System.Text.RegularExpressions;

namespace Practice
{
    public class WordStats
    {
        public Dictionary<string, OccurenceAndPosition> wordStatistics { get; private set; }

        public WordStats()
        {
            wordStatistics = new Dictionary<string, OccurenceAndPosition>();
        }

        public string GetFullStats(string word)
        {
            if (wordStatistics.ContainsKey(word))
            {
                StringBuilder output = new StringBuilder($"Word {word} - occurs {wordStatistics[word].occurence} time(s) in text;\n");

                foreach(int[] lineAndPosition in wordStatistics[word].GetLineAndPosition())
                {
                    output.AppendLine($"occurence in line {lineAndPosition[0]}; position in line - {lineAndPosition[1]}\n");
                }

                return output.ToString();
            }

            return $"Word \'{word}\' does not apper in text.";
        }

        public void gatherStats(string filepath)
        {
            if (!File.Exists(filepath))
            {
                throw new FileNotFoundException($"No file on path \'{filepath}\' exists!");
            }

            Console.OutputEncoding = Encoding.Unicode;
            int lineCounter = 0;

            foreach (string line in File.ReadLines(filepath))
            {                 
                int positionCounter = 0;
                MatchCollection matches = Regex.Matches(line, @"[\p{L}a-zA-Z']*");

                foreach (Match m in matches) {
                    string word = m.Value.ToLower();

                    if (String.IsNullOrEmpty(word) == false)
                    {
                        if (wordStatistics.ContainsKey(word))
                        {
                            wordStatistics[word].occurence = wordStatistics[word].occurence + 1;
                            wordStatistics[word].AddLineAndPosition(lineCounter, positionCounter);
                        }
                        else
                        {
                            wordStatistics.Add(word, new OccurenceAndPosition(1, lineCounter, positionCounter));
                        }
                        positionCounter += 1;
                    }
                }
                lineCounter += 1;
            }
        }
        public override string ToString()
        {
            StringBuilder output = new StringBuilder();

            foreach(var pair in wordStatistics.OrderByDescending(el => el.Value.occurence))
            {
                output.Append($"Word - {pair.Key}; frequency in text - {pair.Value.occurence}.\n");
            }

            return output.ToString();
        }
    }
}
