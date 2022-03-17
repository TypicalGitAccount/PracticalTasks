using System.Text;

namespace Practice
{
    public class OccurenceAndPosition
    {
        public int occurence { get; set; }
        private List<int[]> lineAndPositionIndexes;

        public OccurenceAndPosition(int frequency, int lineNumber, int linePosition)
        {
            occurence = frequency;
            lineAndPositionIndexes = new List<int[]>();
            AddLineAndPositionIndexes(lineNumber, linePosition);
        }

        public void AddLineAndPositionIndexes(int lineNumber, int linePosition)
        {
            lineAndPositionIndexes.Add(new int[] { lineNumber, linePosition });
        }

        public List<int[]> GetLineAndPosition()
        {
            return lineAndPositionIndexes;
        }

        public override string ToString()
        {
            var output = new StringBuilder($"Occured in text - {occurence} times;\n");

            foreach (var pair in lineAndPositionIndexes)
            {
                output.AppendLine($"Occurence in line {pair[0]}, position in line - {pair[1]}\n");
            }

            return output.ToString();
        }
    }
}
