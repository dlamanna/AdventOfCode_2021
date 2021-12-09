using System.Diagnostics;

namespace SmokeBasin
{
    internal static class Program
    {
        private static string[] testInput = { "2199943210", "3987894921", "9856789892", "8767896789", "9899965678" };
        private static string[] questionInput = File.ReadAllLines(@"C:\Users\phuze\Dropbox\Programming\AdventOfCode_2021\9_SmokeBasin\HeightMap.txt");
        private static string[] whichInput = questionInput;
        private static List<int> lowPoints = new List<int>();
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        { 
            Question1();
        }

        public static void Question1()
        {
            int numColumns = whichInput[0].Length;
            int numRows = whichInput.Length;
            for(int i = 0;i<numRows;i++)
            {
                for(int j = 0;j<numColumns;j++)
                {
                    if(IsLowerThanBelow(i, j) && IsLowerThanAbove(i, j) && IsLowerThanLeft(i, j) && IsLowerThanRight(i, j))
                    {
                        bool successfulConversion = int.TryParse("" + whichInput[i][j], out int outInt);
                        if (successfulConversion)
                        {
                            lowPoints.Add(outInt + 1);
                        }
                    }
                }
            }

            int riskSum = 0;
            for(int i = 0;i<lowPoints.Count;i++)
            {
                Debug.WriteLine($"Low Point: {lowPoints[i]}");
                riskSum += lowPoints[i];
            }
            Debug.WriteLine($"Total Risk: {riskSum}");
        }

        public static bool IsLowerThanBelow(int row, int col)
        {
            if(row < whichInput.Length-1)
            {
                return whichInput[row][col] < whichInput[row + 1][col];
            }
            else
            {
                return true;
            }
        }
        
        public static bool IsLowerThanAbove(int row, int col)
        {
            if (row > 0)
            {
                return whichInput[row][col] < whichInput[row - 1][col];
            }
            else
            {
                return true;
            }
        }

        public static bool IsLowerThanLeft(int row, int col)
        {
            if (col > 0)
            {
                return whichInput[row][col] < whichInput[row][col-1];
            }
            else
            {
                return true;
            }
        }

        public static bool IsLowerThanRight(int row, int col)
        {
            if (col < whichInput[0].Length - 1)
            {
                return whichInput[row][col] < whichInput[row][col+1];
            }
            else
            {
                return true;
            }
        }
    }
}