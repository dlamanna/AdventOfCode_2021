using System.Diagnostics;

namespace SevenSegmentSearch
{
    internal static class Program
    {
        private static string[] testLines = File.ReadAllLines(@"C:\Users\phuze\Dropbox\Programming\AdventOfCode_2021\8_SevenSegmentSearch\TestInput.txt");
        private static string[] questionLines = File.ReadAllLines(@"C:\Users\phuze\Dropbox\Programming\AdventOfCode_2021\8_SevenSegmentSearch\CodeInput.txt");
        private static string[] whichInputLines = testLines;
        private static List<string> testStrings = new List<string>();
        private static List<string> questionStrings = new List<string>();
        private static List<string> whichInput = testStrings;
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            PopulateInputLists();
            Question1();
            Question2();
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
            Debug.WriteLine($"Number of unique appearances (1,4,7,8): {uniqueCount}");
        }

        public static void Question2()
        {
            int outputSum = 0;
            for(int i = 0;i<whichInputLines.Count();i++)
            {
                SegmentNumber completedNumber = new();
                string[] answerToDecode;
                string[] splitLines = whichInputLines[i].Split(" | ");
                if(splitLines.Length == 2)
                {
                    List<string> decoderList = new();
                    answerToDecode = splitLines[1].Split(' ');
                    string[] splitSplitLines = splitLines[0].Split(' ');                   
                    decoderList.AddRange(splitSplitLines);
                    decoderList.AddRange(answerToDecode);
                    completedNumber = BuildSegments(ref decoderList);
                    outputSum += completedNumber.DecodeString(answerToDecode);
                }
                else
                {
                    Debug.WriteLine($"Question2::Error in splitLines.Length");
                }
            }

            Debug.WriteLine($"Answer: {outputSum}");
        }

        public static SegmentNumber BuildSegments(ref List<string> decoderList)
        {
            SegmentNumber newNumber = new();
            while(!newNumber.IsComplete())
            {
                for(int i = 0;i < decoderList.Count;i++)
                {
                    newNumber.PositionString("" + decoderList[i]);
                    if (newNumber.IsComplete())
                    {
                        //newNumber.Print();
                        return newNumber;
                    }
                }
            }
            //newNumber.Print();
            return newNumber;
        }

        public static bool CheckForCompletedNumber(ref SegmentNumber num)
        {
            return num.IsComplete();
        }

        public static void PopulateInputLists()
        {
            SplitByDelimiter(ref testLines, ref testStrings);
            SplitByDelimiter(ref questionLines, ref questionStrings);            
        }

        public static void SplitByDelimiter(ref string[] input, ref List<string> output)
        {
            for (int i = 0; i < input.Length; i++)
            {
                string[] splitLines = input[i].Split(" | ");
                if (splitLines.Length == 2)
                {
                    string[] splitSplitLines = splitLines[1].Split(' ');
                    foreach (string token in splitSplitLines)
                    {
                        output.Add(token);
                    }
                }
            }          
        }
    }
}