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
                var output = new StringBuilder($"Word {word} - occurs {wordStatistics[word].occurence} time(s) in text;\n");

                foreach(var lineAndPositionIndexes in wordStatistics[word].GetLineAndPosition())
                {
                    output.AppendLine($"occurence in line {lineAndPositionIndexes[0]+1}; position in line - {lineAndPositionIndexes[1]+1}");
                }

                return output.ToString();
            }

            return $"Word \'{word}\' does not apper in text.";
        }

        public bool gatherStats(string filepath)
        {
            if (!File.Exists(filepath))
                return false;

            var lineCounter = 0;

            foreach (var line in File.ReadLines(filepath))
            {                 
                var positionCounter = 0;
                MatchCollection matches = Regex.Matches(line, @"[\p{L}a-zA-Z']*");

                foreach (Match m in matches) {
                    var word = m.Value.ToLower();

                    if (String.IsNullOrEmpty(word) == false)
                    {
                        if (wordStatistics.ContainsKey(word))
                        {
                            wordStatistics[word].occurence = wordStatistics[word].occurence + 1;
                            wordStatistics[word].AddLineAndPositionIndexes(lineCounter, positionCounter);
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

            return true;
        }

        public override string ToString()
        {
            StringBuilder output = new StringBuilder();

            foreach(var pair in wordStatistics.OrderByDescending(el => el.Value.occurence))
            {
                output.Append($"Word - {pair.Key}; occurences in text - {pair.Value.occurence}.\n");
            }

            return output.ToString();
        }
    }
}
