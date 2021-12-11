using System.Diagnostics;

namespace DumboOctopus
{
    internal static class Program
    {
        private static string[] testInput = {"5483143223","2745854711","5264556173","6141336146","6357385478",
                                            "4167524645","2176841721","6882881134","4846848554","5283751526"};
        private static string[] questionInput = {"4134384626","7114585257","1582536488","4865715538","5733423513",
                                            "8532144181","1288614583","2248711141","6415871681","7881531438"};
        private static string[] whichInput = questionInput;
        private static int[,] intInputArray = new int[10,10];
        private static int totalFlashes = 0;
        private static List<Coord> flashesThisRound = new();
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
            ConvertInputToInt();
            IncreaseAllEnergyByOne();
            for (int i = 0; i < 99; i++)
            {
                FlashStep();
            }
            Debug.WriteLine($"Total number of flashes after 100 steps: {totalFlashes}");
        }

        public static void ConvertInputToInt()
        {
            for(int i = 0;i<whichInput.Length;i++)
            {
                for(int j=  0;j< whichInput[i].Length;j++)
                {
                    intInputArray[i,j] = int.Parse("" + whichInput[i][j]);
                }
            }
        }

        public static void IncreaseAllEnergyByOne()
        {
            for(int i = 0;i<intInputArray.GetLength(0);i++) 
            { 
                for(int j=  0;j<intInputArray.GetLength(1);j++)
                {
                    intInputArray[i,j]++;
                }
            }
        }

        public static void FlashStep()
        {
            flashesThisRound.Clear();
            for (int i = 0; i < intInputArray.GetLength(0); i++)
            {
                for (int j = 0; j < intInputArray.GetLength(1); j++)
                {
                    intInputArray[i, j]++;
                    if(intInputArray[i, j] > 9)
                    {
                        FlashSpecificCell(i, j);
                    }
                }
            }
            ClearAllFlashedIndices();
        }

        public static void ClearAllFlashedIndices()
        {
            for(int i = 0;i<flashesThisRound.Count;i++)
            {
                int key = flashesThisRound[i].X;
                int value = flashesThisRound[i].Y;
                intInputArray[key, value] = 0;
            }
        }

        public static void FlashSpecificCell(int i, int j)
        {
            totalFlashes++;
            intInputArray[i, j] = 0;        //probably unnecessary since we're keeping track in a dict, but it's fine, we'll leave it
            if (flashesThisRound.Contains(new Coord(i,j)))
            {
                return;
            }
            flashesThisRound.Add(new Coord(i, j));
            if(i > 0)
            {
                IncrementAndFlash(i - 1, j);
                if (j < intInputArray.GetLength(1) - 1)
                {
                    IncrementAndFlash(i - 1, j + 1);
                }
                if(j > 0)
                {
                    IncrementAndFlash(i - 1, j - 1);
                }
            }
            if(j > 0)
            {
                IncrementAndFlash(i, j - 1);
                if (i < intInputArray.GetLength(0) - 1)
                {
                    IncrementAndFlash(i + 1, j - 1);
                }
                //already did i-1, j-1
            }
            if(i < intInputArray.GetLength(0)-1)
            {
                IncrementAndFlash(i + 1, j);
                //already did i+1, j-1
                if (j < intInputArray.GetLength(1) - 1)
                {
                    IncrementAndFlash(i + 1, j + 1);
                }
            }
            if (j < intInputArray.GetLength(1) - 1)
            {
                IncrementAndFlash(i, j + 1);
            }
        }

        public static void IncrementAndFlash(int i, int j)
        {
            intInputArray[i, j]++;
            if(intInputArray[i, j] > 9)
            {
                FlashSpecificCell(i, j);
            }
        }
    }
}