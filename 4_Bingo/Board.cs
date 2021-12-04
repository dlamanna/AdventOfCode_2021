using System.Diagnostics;

namespace _4_Bingo
{
    public class Board
    {    
        public int[,] BoardLayout { get; set; }
        public readonly int boardSize = 25;

        public Board()
        {

        }
        public Board(int[] singleLineLayout)
        {
            if(singleLineLayout.Length != boardSize)
            {
                Debug.WriteLine($"You have a messed up board, input.length == {singleLineLayout.Length}");
                return;
            }


            for(int i = 0;i < singleLineLayout.Length;i++)
            {
                ///TODO: Finish constructor here
            }
        }
        public Board(int[,] fullBoardLayout)
        {
            BoardLayout = fullBoardLayout;
        }
        public Board(int[][] fullBoardLayout)
        {
            BoardLayout = new int[5,5];
            for(int i = 0;i<fullBoardLayout.Length;i++)
            {
                for(int j = 0;j<fullBoardLayout[i].Length;j++)
                {
                    BoardLayout[i, j] = fullBoardLayout[i][j];
                }
            }
        }

        public void MarkOffNumber(int calledNumber)
        {
            for(int x = 0;x<5;x++)
            {
                for (int y = 0; y < 5; y++)
                {
                    if (BoardLayout[x,y] == calledNumber)
                    {
                        BoardLayout[x,y] = -1;
                    }
                }
            }
        }

        public void PrintBoard()
        {
            string printString = "";
            for(int i = 0;i<5;i++)
            {
                for(int j = 0;j<5;j++)
                {
                    printString = $"{printString}{BoardLayout[i,j]} ";
                }
                printString = $"{printString}\n";
            }
            Debug.WriteLine(printString);
        }

        public int CheckForWinner()
        {
            for (int i = 0; i < 5; i++)
            {
                int columnNumber = i;
                int rowNumber = i;
                int[] column = Enumerable.Range(0, BoardLayout.GetLength(0))
                    .Select(x => BoardLayout[x, columnNumber])
                    .ToArray();
                int[] row = Enumerable.Range(0, BoardLayout.GetLength(1))
                    .Select(x => BoardLayout[rowNumber, x])
                    .ToArray();
                if (column.Sum() == -5 || row.Sum() == -5)
                {
                    int correctAnswer = SumCompleteBoard();
                    Debug.WriteLine("Winning Board:\n");
                    PrintBoard();
                    return correctAnswer;
                }
                else
                {
                    Debug.WriteLine("Not Winner:\n");
                    PrintBoard();
                }
            }

            return -1;
        }

        public int SumCompleteBoard()
        {
            int sum = 0;
            for (int x = 0; x < 5; x++)
            {
                for (int y = 0; y < 5; y++)
                {
                    if (BoardLayout[x, y] != -1)
                    {
                        sum += BoardLayout[x, y];
                    }
                }
            }
            return sum;
        }
    }
}