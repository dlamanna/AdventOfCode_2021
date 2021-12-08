using System.Diagnostics;

namespace SevenSegmentSearch
{
    internal static class Program
    {
        private static List<string> testStrings = new List<string>();
        private static List<string> questionStrings = new List<string>();
        private static List<string> whichInput = questionStrings;
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            PopulateInputLists();
            Question1();   
        }

        public static void Question1()
        {
            int uniqueCount = 0;
            for(int i = 0;i<whichInput.Count;i++)
            {
                // checking for 1,4,7,8
                if (whichInput[i].Length == 2 || whichInput[i].Length == 4 ||
                    whichInput[i].Length == 3 || whichInput[i].Length == 7)
                {
                    uniqueCount++;
                }
            }
            Debug.WriteLine($"Number of unique appearances: {uniqueCount}");
        }

        public static void PopulateInputLists()
        {
            string[] testLines = File.ReadAllLines(@"C:\Users\phuze\Dropbox\Programming\AdventOfCode_2021\8_SevenSegmentSearch\TestInput.txt");
            string[] questionLines = File.ReadAllLines(@"C:\Users\phuze\Dropbox\Programming\AdventOfCode_2021\8_SevenSegmentSearch\CodeInput.txt");
            
            for(int i = 0; i < testLines.Length; i++)
            {
                string[] splitLines = testLines[i].Split(" | ");
                if(splitLines.Length == 2)
                {
                    string[] splitSplitLines = splitLines[1].Split(' ');
                    foreach(string token in splitSplitLines)
                    {
                        testStrings.Add(token);
                    }
                }
            }

            for (int i = 0; i < questionLines.Length; i++)
            {
                string[] splitLines = questionLines[i].Split(" | ");
                if (splitLines.Length == 2)
                {
                    string[] splitSplitLines = splitLines[1].Split(' ');
                    foreach (string token in splitSplitLines)
                    {
                        questionStrings.Add(token);
                    }
                }
            }
        }
    }
}