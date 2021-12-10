using System.Diagnostics;

namespace SmokeBasin
{
    enum Direction
    {
        Above,
        Below,
        Left,
        Right
    }

    internal static class Program
    {
        private static string[] testInput = { "2199943210", "3987894921", "9856789892", "8767896789", "9899965678" };
        private static string[] questionInput = File.ReadAllLines(@"C:\Users\phuze\Dropbox\Programming\AdventOfCode_2021\9_SmokeBasin\HeightMap.txt");
        private static string[] whichInput = questionInput;
        private static List<int> lowPoints = new List<int>();
        private static List<int> savedBasinSizes = new List<int>();
        private static HashSet<string> checkedLocations = new HashSet<string>();
        private static int basinSize = 0;
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        { 
            Question1();
            Question2();
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

        public static void Question2()
        {
            int numColumns = whichInput[0].Length;
            int numRows = whichInput.Length;
            for (int i = 0; i < numRows; i++)
            {
                for (int j = 0; j < numColumns; j++)
                {
                    if (IsLowerThanBelow(i, j) && IsLowerThanAbove(i, j) && IsLowerThanLeft(i, j) && IsLowerThanRight(i, j))
                    {
                        //we've found a lowpoint, now grow outwards in each direction until we hit a 9
                        savedBasinSizes.Add(CalculateBasinSize(i, j));
                    }
                }
            }
            //find size of basin and compare against other basin sizes to see if it's in top 3 biggest
            savedBasinSizes.Sort();
            int totalBasinSize = savedBasinSizes[^1] * savedBasinSizes[^2] * savedBasinSizes[^3];
            Debug.WriteLine($"Total basin size ({savedBasinSizes[^1]} * {savedBasinSizes[^2]} *" +
                            $" {savedBasinSizes[^3]}): {totalBasinSize}");
        }

        public static int CalculateBasinSize(int row, int col)
        {
            checkedLocations = new();                   // reset the checked locations since each location can only be in one basin
            checkedLocations.Add($"{row},{col}");
            basinSize = 1;
            Debug.WriteLine($"Starting basin at: [{col},{row}]");
            
            if(row < whichInput.Length-1 &&
                !checkedLocations.Contains($"{row + 1},{col}") && 
                whichInput[row+1][col] != '9')                                      // not on last row, can go down
            {
                Debug.WriteLine($"[{col},{row + 1}] _{whichInput[row+1][col]}_, going down (initial)");
                ExpandOutwards(row + 1, col, Direction.Above);
            }
            if(row > 0 &&
                !checkedLocations.Contains($"{row - 1},{col}") &&
                whichInput[row-1][col] != '9')                                      // not on first row, can go up
            {
                Debug.WriteLine($"[{col},{row - 1}] _{whichInput[row - 1][col]}_, going up (initial)");
                ExpandOutwards(row - 1, col, Direction.Below);
            }
            if(col < whichInput[row].Length-1 &&
                !checkedLocations.Contains($"{row},{col+1}") &&
                whichInput[row][col+1] != '9')                                      // not on last col, can go right
            {
                Debug.WriteLine($"[{col+1},{row}] _{whichInput[row][col + 1]}_, going right (initial)");
                ExpandOutwards(row, col + 1, Direction.Left);  
            }
            if(col > 0 &&
                !checkedLocations.Contains($"{row},{col-1}") &&
                whichInput[row][col-1] != '9')                                      // not on first col, can go left
            {
                Debug.WriteLine($"[{col-1},{row}] _{whichInput[row][col - 1]}_, going left (initial)");
                ExpandOutwards(row, col - 1, Direction.Right);
            }

            return basinSize;
        }

        public static void ExpandOutwards(int row, int col, Direction fromDirection)
        {
            basinSize++;
            checkedLocations.Add($"{row},{col}");
            
            if (fromDirection != Direction.Below &&
                !checkedLocations.Contains($"{row+1},{col}") && 
                row < whichInput.Length - 1 && 
                whichInput[row + 1][col] != '9')                                          // not on last row, can go down
            {
                Debug.WriteLine($"[{col},{row+1}] _{whichInput[row + 1][col]}_, going down ({EnumToString(fromDirection)})");
                ExpandOutwards(row + 1, col, Direction.Above);
            }
            if (fromDirection != Direction.Above &&
                !checkedLocations.Contains($"{row-1},{col}") &&
                row > 0 &&
                whichInput[row - 1][col] != '9')                                          // not on first row, can go up
            {
                Debug.WriteLine($"[{col},{row-1}] _{whichInput[row - 1][col]}_, going up ({EnumToString(fromDirection)})");
                ExpandOutwards(row - 1, col, Direction.Below);
            }
            if (fromDirection != Direction.Right &&
                !checkedLocations.Contains($"{row},{col+1}") && 
                col < whichInput[row].Length - 1 &&
                whichInput[row][col + 1] != '9')                                          // not on last col, can go right
            {
                Debug.WriteLine($"[{col+1},{row}] _{whichInput[row][col + 1]}_, going right ({EnumToString(fromDirection)})");
                ExpandOutwards(row, col + 1, Direction.Left);
            }
            if (fromDirection != Direction.Left &&
                !checkedLocations.Contains($"{row},{col-1}") &&
                col > 0 &&
                whichInput[row][col - 1] != '9')                                          // not on first col, can go left
            {
                Debug.WriteLine($"[{col-1},{row}] _{whichInput[row][col - 1]}_, going left ({EnumToString(fromDirection)})");
                ExpandOutwards(row, col - 1, Direction.Right);
            }
        }

        public static string EnumToString(Direction direction)
        {
            switch(direction)
            {
                case Direction.Left:
                    return "Left";
                case Direction.Right:
                    return "Right";
                case Direction.Above:
                    return "Above";
                case Direction.Below:
                    return "Below";
            }
            return "";
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