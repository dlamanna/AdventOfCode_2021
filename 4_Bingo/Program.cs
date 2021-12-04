using System.Diagnostics;

namespace _4_Bingo
{
    internal static class Program
    {
        private static readonly int[] testNumberOrder = { 7, 4, 9, 5, 11, 17, 23, 2, 0, 14, 21, 24, 10, 16, 13, 6, 15, 25, 12, 22, 18, 20, 8, 19, 3, 26, 1 };
        private static readonly int[] questionNumberOrder = { 26, 38, 2, 15, 36, 8, 12, 46, 88, 72, 32, 35, 64, 19, 5, 66, 20, 52, 74, 3, 59, 94, 45, 56, 0, 6, 67, 24, 97, 50, 92, 93, 84, 65, 71, 90, 96, 21, 87, 75, 58, 82, 14, 53, 95, 27, 49, 69, 16, 89, 37, 13, 1, 81, 60, 79, 51, 18, 48, 33, 42, 63, 39, 34, 62, 55, 47, 54, 23, 83, 77, 9, 70, 68, 85, 86, 91, 41, 4, 61, 78, 31, 22, 76, 40, 17, 30, 98, 44, 25, 80, 73, 11, 28, 7, 99, 29, 57, 43, 10 };
        private static readonly int[,] boardOneLayout = {
            { 22, 13, 17, 11, 0 },
            { 8, 2, 23, 4, 24},
            { 21, 9, 14, 16, 7 },
            { 6, 10, 3, 18, 5 },
            { 1, 12, 20, 15, 19 }
        };
        private static readonly int[,] boardTwoLayout = {
            { 3, 15, 0, 2, 22 },
            { 9, 18, 13, 17, 5},
            { 19, 8, 7, 25, 23 },
            { 20, 11, 10, 24, 4 },
            { 14, 21, 16, 12, 6 }
        };
        private static readonly int[,] boardThreeLayout = {
            { 14, 21, 17, 24, 4 },
            { 10, 16, 15, 9, 19},
            { 18, 8, 23, 26, 20 },
            { 22, 11, 13, 6, 5 },
            { 2, 0, 12, 3, 7 }
        };
        private static Board testBoardOne = new(boardOneLayout);
        private static Board testBoardTwo = new(boardTwoLayout);
        private static Board testBoardThree = new(boardThreeLayout);
        private static List<Board> testBoardArray = new();
        private static List<Board> questionBoardList = new();

        private static int[] whichNumberOrder = questionNumberOrder;
        private static List<Board> whichBoardArray = questionBoardList;

        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            /// Go 5 numbers first from testNumberOrder, then 1x1
            /// Check each board to see if new number makes a winner (no diagonals)
            /// Once winner, add all the unmarked numbers on that board, and multiply by winning number
            /// TestInput answer should be: 188 * 24 = 4512 {board 3 wins}
            testBoardArray.Add(testBoardOne);
            testBoardArray.Add(testBoardTwo);
            testBoardArray.Add(testBoardThree);
            string[] lines = File.ReadAllLines(@"C:\Users\phuze\Dropbox\Programming\AdventOfCode_2021\4_Bingo\BoardList.txt");
            CreateBoardsFromStrings(ref lines);
            int currentNumberCallIndex = 5;
            for(int i = 0;i<5;i++)
            {
                MarkOffBoardNumbers(whichNumberOrder[i]);
            }

            int winnerScore = CheckBoardsForWinner();
            while(winnerScore == -1)
            {
                MarkOffBoardNumbers(whichNumberOrder[currentNumberCallIndex]);
                winnerScore = CheckBoardsForWinner();
                currentNumberCallIndex++;
            }
            Debug.WriteLine($"We have a winner with number: {whichNumberOrder[currentNumberCallIndex - 1]}!");
            Debug.WriteLine($"Complete Score (Sum*Winning#): {{{winnerScore*whichNumberOrder[currentNumberCallIndex-1]}}}");
        }

        public static void MarkOffBoardNumbers(int calledNumber)
        {
            foreach(Board b in whichBoardArray)
            {
                b.MarkOffNumber(calledNumber);
            }
        }

        public static int CheckBoardsForWinner()
        {
            int retVal = -1;
            foreach(Board b in whichBoardArray)
            {
                retVal = b.CheckForWinner();
                if (retVal != -1)
                    return retVal;
            }
            return retVal;
        }

        public static void CreateBoardsFromStrings(ref string[] boardFileText)
        {
            for (int i = 0;i<boardFileText.Length;i++)
            {
                boardFileText[i] = boardFileText[i].Replace("  ", " ", StringComparison.OrdinalIgnoreCase);
            }

            for(int i = 0;i<boardFileText.Length;i+=6)
            {
                int[] lineOne = boardFileText[i].Trim().Split(' ').Select(int.Parse).ToArray();
                int[] lineTwo = boardFileText[i + 1].Trim().Split(' ').Select(int.Parse).ToArray();
                int[] lineThree = boardFileText[i + 2].Trim().Split(' ').Select(int.Parse).ToArray();
                int[] lineFour = boardFileText[i + 3].Trim().Split(' ').Select(int.Parse).ToArray();
                int[] lineFive = boardFileText[i + 4].Trim().Split(' ').Select(int.Parse).ToArray();
                int[][] boardLayout = new int[][] { lineOne, lineTwo, lineThree, lineFour, lineFive };

                Board board = new Board(boardLayout);
                questionBoardList.Add(board);

                if (i + 6 > boardFileText.Length) return;
            }
        }
    }
}