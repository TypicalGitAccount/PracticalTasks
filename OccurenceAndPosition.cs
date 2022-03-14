using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice
{
    public class OccurenceAndPosition
    {
        public int occurence { get; set; }
        private List<int[]> lineAndPosition;

        public OccurenceAndPosition(int frequency, int lineNumber, int linePosition)
        {
            occurence = frequency;
            lineAndPosition = new List<int[]>();
            AddLineAndPosition(lineNumber, linePosition);
        }

        public void AddLineAndPosition(int lineNumber, int linePosition)
        {
            lineAndPosition.Add(new int[] { lineNumber, linePosition });
        }

        public List<int[]> GetLineAndPosition()
        {
            return lineAndPosition;
        }

        public override string ToString()
        {
            StringBuilder output = new StringBuilder($"Occured in text - {occurence} times;\n");

            foreach (var pair in lineAndPosition)
            {
                output.AppendLine($"Occurence in line {pair[0]}, position in line - {pair[1]}\n");
            }

            return output.ToString();
        }
    }
}
