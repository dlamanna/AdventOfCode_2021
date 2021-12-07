using System.Diagnostics;

namespace Sub
{
    internal static class Program
    {
        private static readonly string[] testInput = { "00100", "11110", "10110", "10111", "10101", "01111",
                                                        "00111", "11100", "10000", "11001","00010","01010"};
        private static readonly string[] questionInput = {"000011000110",
"100110100101",
"101100101001",
"001100010000",
"011000100100",
"110100101111",
"110110001001",
"010010100101",
"100111000010",
"001010110001",
"110111010001",
"110001011000",
"011110010100",
"001001010111",
"110010111111",
"111011010111",
"100010001011",
"010001100010",
"111110111111",
"001000101111",
"010111110110",
"000000001100",
"001000110101",
"111111010011",
"111010011100",
"111010010110",
"100110011000",
"110110000010",
"101101011101",
"111100000001",
"110000101011",
"000110111000",
"110101110000",
"110001100001",
"110101001101",
"100011011000",
"110101000111",
"100010100111",
"111101001100",
"000110000110",
"101011000100",
"011100100001",
"101110111010",
"110011011101",
"010111001101",
"110001001101",
"100000000101",
"010011100100",
"111001111111",
"101111111111",
"110000101010",
"000110100001",
"111100111000",
"000010000100",
"010100101001",
"000000111111",
"111100111011",
"000010100111",
"100101101110",
"101001110110",
"100101000111",
"111100101011",
"011101101000",
"101010110101",
"010011000100",
"111001101110",
"001110000110",
"000111001011",
"010110101011",
"100001011001",
"001111000111",
"110000111000",
"111111111011",
"100010110011",
"001011000100",
"100011101111",
"111101101000",
"111100111010",
"000110001100",
"010000110001",
"000101010101",
"110100011000",
"001100101111",
"110110101010",
"101111100111",
"011111110001",
"011000001100",
"110101100001",
"101010000111",
"101000001000",
"001101110100",
"100000111010",
"011101110000",
"011100100100",
"111000111010",
"100001111110",
"100001001111",
"011111110010",
"001110101011",
"111100011010",
"010100010111",
"000000110001",
"110100010001",
"110100111101",
"101110110000",
"111010101010",
"101100110001",
"010011011001",
"111000001001",
"100001110101",
"011001000110",
"010001100101",
"100111010101",
"100011011010",
"001101110011",
"100111101101",
"111000010010",
"011110110001",
"100110000010",
"000000100011",
"100010110100",
"101001010101",
"101001101100",
"000111111000",
"101010110100",
"010011000001",
"110110011101",
"111001010110",
"011100111101",
"001100010001",
"011101000001",
"001001101001",
"010111001011",
"111000000010",
"111011011101",
"101010011101",
"001001001110",
"001011100011",
"100100111111",
"101110101111",
"111001011101",
"000010001100",
"010110101010",
"001101000010",
"010011101110",
"110000001001",
"010111001111",
"100011000010",
"100000110010",
"100111110101",
"100111111011",
"010000000101",
"111000101101",
"010111001010",
"100100110101",
"100110000110",
"110010110111",
"000000111101",
"010110011100",
"100000101000",
"000110001111",
"001001110110",
"101010111001",
"101010100110",
"101101100111",
"001111010110",
"001001110100",
"011010011111",
"101100101010",
"001010011010",
"101111010100",
"100110100001",
"111001110101",
"110100001110",
"000011001100",
"001101011110",
"001011111010",
"101100011101",
"001111001110",
"111000111000",
"100111001010",
"010100111100",
"010100000111",
"010100101011",
"010100000001",
"100111000110",
"111011010000",
"100011011001",
"111001001110",
"000000010101",
"111001011110",
"010101011000",
"110010001001",
"100011000000",
"111100001100",
"001010000100",
"100000100110",
"100011110110",
"010010110001",
"011110000000",
"000000101000",
"010001011001",
"011010111010",
"011010101110",
"001101011011",
"111100111001",
"011011010110",
"111110100101",
"100001110001",
"010111011100",
"111100100001",
"110011100010",
"001010001011",
"100100111100",
"000010010001",
"101111010000",
"111000001101",
"000110001011",
"000101101001",
"001001011011",
"001001010010",
"011110111011",
"001001100001",
"110011001011",
"000011110000",
"001011011101",
"001010010010",
"011100111110",
"101000101000",
"110000011001",
"010001100001",
"011010100010",
"100101110010",
"111100001010",
"001110000010",
"011101000000",
"110100110011",
"010010011101",
"101001000100",
"110111110010",
"001100000011",
"000001110110",
"000101010010",
"100000011011",
"000000000010",
"011111000111",
"110010101011",
"100101101001",
"010110010101",
"000100101000",
"001011100010",
"001110100010",
"110111101001",
"101110110100",
"011100110101",
"011101100111",
"001100101100",
"111101000010",
"011110110100",
"111001100000",
"111110011000",
"001101001110",
"101000011111",
"110010010110",
"111011100011",
"110010111001",
"101111110111",
"101001100110",
"011010011010",
"000010100101",
"110110100001",
"000101001001",
"000001111111",
"010010111011",
"100010110111",
"110111011111",
"010001001101",
"000110110101",
"010010010100",
"101011001111",
"111000011110",
"110110010010",
"111110100110",
"100110000001",
"011111100001",
"001100010100",
"001101000101",
"011011100010",
"011110101111",
"001101110110",
"110101010110",
"000110101101",
"111010111000",
"011001011111",
"100011111101",
"110100111100",
"100111101100",
"001011001110",
"111000010100",
"001100000110",
"111011010101",
"000001001011",
"111100000000",
"010010111101",
"110011101010",
"011110111110",
"011111011110",
"111001001001",
"000100100111",
"001010010101",
"101011101101",
"110011010111",
"011000001000",
"111001000101",
"101001110011",
"011110110101",
"111101111011",
"111100101100",
"001010110100",
"101100111000",
"011011000000",
"101000100011",
"100001100110",
"001000011101",
"001110100000",
"011111111101",
"010001010111",
"001101001000",
"100101100100",
"000011010110",
"100000000100",
"011100011111",
"000010110011",
"100000100010",
"101100101110",
"100100000010",
"001001111001",
"011100110111",
"011111100011",
"010000101100",
"100101001101",
"000110010100",
"110101010010",
"100010100011",
"110101000001",
"010000000110",
"110110001011",
"100011001001",
"111111110000",
"111010000011",
"011001010101",
"011111101000",
"100010101111",
"010100100000",
"100110110100",
"101111010011",
"011101010001",
"100100001010",
"001110000000",
"001110000101",
"111010000010",
"101000010000",
"111101011111",
"001001110001",
"011001000100",
"000011101100",
"100010010111",
"110000101111",
"110010100100",
"100000011111",
"011100100011",
"000001101000",
"101010100001",
"010001100011",
"001010111110",
"111010111110",
"011011000100",
"001101100000",
"001101100011",
"111010011111",
"111110110010",
"010110100111",
"101011011010",
"110010011001",
"001011010010",
"000101100000",
"100000100011",
"000111100001",
"001111110101",
"000011101001",
"110101010100",
"111011010110",
"101111011000",
"001000100100",
"010110011001",
"110111000011",
"001010011000",
"110011000010",
"111101001000",
"000001010001",
"101011110111",
"011001100110",
"101101101101",
"100011010110",
"110001010000",
"110001010001",
"100011100110",
"111111011100",
"000101101000",
"110000111001",
"111100010011",
"101010110001",
"101100001011",
"110100110001",
"100110111011",
"011100100111",
"110001011111",
"011010100101",
"101011111100",
"111000010101",
"110110110100",
"111101100011",
"001110100101",
"100010111001",
"100010001001",
"100001010101",
"010011001100",
"000101010111",
"101100010100",
"000101000111",
"001111101100",
"111000001100",
"100110101101",
"000001100010",
"100010011011",
"011001000011",
"110000010100",
"010100001011",
"101011001110",
"000110110000",
"110011000110",
"101101111101",
"001001000111",
"001001011111",
"110100011011",
"101110010011",
"100001011000",
"010010110111",
"011001011000",
"011011101100",
"100110000100",
"001101110000",
"011011001101",
"111110001011",
"110111100101",
"101001010100",
"100101110101",
"100010000001",
"011110011010",
"000010011100",
"111011000101",
"100110001011",
"000101101011",
"011100100010",
"000010111000",
"000001100000",
"000100001000",
"110110101110",
"101000100110",
"100101010001",
"011010010100",
"000001111110",
"001100010110",
"001001101111",
"111010001011",
"100100101111",
"011100011011",
"100111011110",
"000010010101",
"011001110001",
"001011011000",
"011010100110",
"110011011111",
"001110011101",
"111101010001",
"101010111000",
"110000010110",
"110110001000",
"011000111001",
"111010100111",
"101011011110",
"001001011001",
"101011100111",
"111011110010",
"010100110101",
"101001111010",
"111110011111",
"110110010000",
"101101010101",
"000101111100",
"001110101010",
"111111111000",
"001001000100",
"111011011111",
"111000010001",
"111101100010",
"001000011100",
"100100000001",
"111101010011",
"001100011110",
"110000001100",
"000101011000",
"101000101111",
"100000101100",
"001010100001",
"001100111001",
"000110011011",
"000111100000",
"010001000001",
"010010111001",
"101111001101",
"110111011101",
"101010001110",
"101010100111",
"111101000001",
"101001011010",
"011111010100",
"100010111000",
"110111110001",
"001110111000",
"000010001111",
"110111001101",
"110110011110",
"000001001111",
"110100000000",
"100101011001",
"111101110001",
"001000000000",
"110110001010",
"010000101111",
"110000000100",
"111100110100",
"001110000011",
"101100111111",
"100101011110",
"010010101110",
"001011001001",
"011000101000",
"100000001010",
"010001110001",
"011001111001",
"111100001111",
"000111100011",
"110100100111",
"101101111011",
"101010111101",
"110000001011",
"011011010000",
"001000100000",
"101101001100",
"110111101000",
"111011101011",
"110011101100",
"000010010000",
"111100010100",
"000111011101",
"110110110011",
"100110100000",
"101010000110",
"101001110001",
"101110001101",
"100010111110",
"011001001001",
"011111111001",
"000101010110",
"010011110111",
"000000000011",
"001101001100",
"001001110101",
"010010101100",
"101100000110",
"010110011111",
"101000010110",
"011001011010",
"011111110000",
"101101111001",
"110011110110",
"101101101010",
"111111111110",
"011001110110",
"000010111101",
"100110110001",
"000111010001",
"000011001101",
"100110111111",
"101010011110",
"101010011011",
"110011010001",
"101001100000",
"111100000111",
"000111101000",
"011011010111",
"010111000011",
"000111100101",
"101111011111",
"101110011111",
"100010001000",
"101111000001",
"100101010101",
"101011110010",
"001010111111",
"010101010001",
"110101110110",
"000000111110",
"010001101000",
"111111001001",
"110111101111",
"100100110000",
"110111010010",
"111011000000",
"011100010001",
"001100100010",
"010110010011",
"111101010000",
"011010101011",
"100110010101",
"011100000110",
"001110011001",
"001010100000",
"101000000000",
"101011101110",
"111100110101",
"100111110100",
"011000110010",
"110011010011",
"101011011101",
"101001110111",
"011010111111",
"101011000010",
"001100110010",
"111100100111",
"100110111000",
"111111010010",
"010111010100",
"101000101010",
"011000011111",
"000001110100",
"101110111000",
"001001011000",
"011001100101",
"011111000000",
"110001101010",
"010000101110",
"000001110010",
"000000000101",
"001010111001",
"101101101001",
"110100100100",
"001000100011",
"010000000000",
"010111010101",
"011010001010",
"000101010011",
"101011001010",
"001010101101",
"101110001010",
"101101110000",
"001000010001",
"100001000001",
"010100000011",
"011111011010",
"001110011111",
"010000110000",
"100100010010",
"111011111101",
"010010010010",
"110010000000",
"011000111100",
"001110010101",
"100110011010",
"110101000011",
"110011000001",
"110101111000",
"111001011100",
"101010000100",
"001001110011",
"101011110101",
"101011010101",
"110011111000",
"100001011010",
"000010000111",
"001010110010",
"000110010000",
"101101101111",
"111010010000",
"011010000100",
"011110010101",
"011010011101",
"010001011010",
"001111101010",
"100001001000",
"010010110110",
"000001011101",
"001001101011",
"111001110010",
"101101100100",
"001000101110",
"000000010100",
"001010110000",
"011010101000",
"010001001001",
"100110111110",
"110111001010",
"111110000111",
"101111011110",
"001110110001",
"001101110001",
"111000000011",
"010000010001",
"011001111010",
"010100111111",
"111000000111",
"101011001100",
"111000100101",
"101001110100",
"101110100000",
"100011001110",
"010111101110",
"000100000100",
"110011110011",
"011110101010",
"101100001000",
"011010111101",
"111111111010",
"100000101011",
"001110101001",
"011100000111",
"010000101101",
"001101011000",
"011000101010",
"000100111001",
"110111100000",
"000111111101",
"111001011011",
"000011001110",
"011110010000",
"100010101110",
"111001110001",
"000101011010",
"110001100101",
"010011011000",
"000000100100",
"000101001101",
"111110011110",
"000010110110",
"101100001100",
"010111000111",
"000110010110",
"110110010100",
"111000110011",
"111011011100",
"011001000000",
"100101000110",
"100011010101",
"101011101111",
"010011111010",
"000110011100",
"111010010010",
"111010111100",
"010111100101",
"101101001101",
"010110100100",
"011100010101",
"000001100110",
"001000110110",
"011101000010",
"111100101111",
"110110001110",
"000011100010",
"101011000001",
"110100100000",
"001111111000",
"110111001111",
"000100111110",
"111100000110",
"010111010010",
"001000101001",
"000001010000",
"100010110010",
"101101110100",
"111101100001",
"000101111111",
"000101001110",
"110010001101",
"101000011001",
"111001001111",
"111000000000",
"000101110110",
"111001111001",
"010010010101",
"110011011000",
"011000001001",
"110001010010",
"101100110010",
"101011010011",
"000000110110",
"111000011000",
"101001101011",
"111100100100",
"111011111001",
"111101001110",
"101000001010",
"000111000101",
"110011010010",
"011101101001",
"111000110010",
"111010011010",
"110001011101",
"101000111100",
"100111011111",
"011000101101",
"011111101101",
"100001000111",
"010001101010",
"110100010000",
"110100011100",
"111001100001",
"001101010100",
"000101100110",
"001111001000",
"011001011100",
"000100011001",
"011100010010",
"101010101100",
"111011110101",
"101011000111",
"100111010100",
"111001100100",
"110011101011",
"010011000110",
"111101100101",
"101101011000",
"000101000100",
"010001001110",
"110000011110",
"100100100101",
"011000100000",
"010111010000",
"000101011001",
"110110101100",
"000011010000",
"010110100000",
"110010101101",
"111100111111",
"001101101001",
"000110000010",
"100101111101",
"101101010010",
"110111011000",
"000110000100",
"001000001001",
"010010101010",
"101111010101",
"010010000000",
"101011011111",
"111110010010",
"111000111011",
"000001011100",
"010101111111",
"011000101100",
"000001011001",
"100001011011",
"100001101110",
"110010000001",
"001011110100",
"011110010001",
"111100110000",
"101000111111",
"110000011011",
"011100111010",
"001010011101",
"100110001100",
"110011011010",
"111001000100",
"010100111110",
"010001110111",
"010011010010",
"000101001000",
"010011101010",
"000001110101",
"010101101101",
"010001100111",
"101001111111",
"111011011011",
"100001100011",
"101101111000",
"110011011001",
"001110110010",
"011101001101",
"010101010010",
"110001110001",
"010011010000",
"110000000111",
"011100110100",
"010000011000",
"011001111011",
"111010110010",
"101100010011",
"011011001000",
"111011101101",
"010000011101",
"000001010101",
"101011100011",
"010110111011",
"001100100000",
"111011100001",
"111111001000",
"111110110001",
"100001110000",
"010001001010",
"100111010011",
"000010000000",
"010011000010",
"110101110101",
"000110011110",
"011111111010",
"011010101101",
"110110000101",
"111000110000",
"111011000110",
"111101000011",
"101110010110",
"000001000111",
"001111111001",
"110101011001",
"111010110100",
"100000000011",
"010110110011",
"100011100111",
"001111101110",
"110010111000",
"001100111010",
"101010100101",
"000101110111",
"011001110010",
"010110001100",
"101010111111",
"010010011011",
"100110011111",
"100010010000",
"110100001000",
"001001000010",
"101010100100",
"100111001011",
"010100000000",
"100100100111",
"110001101011",
"011000110100",
"111000001000",
"011111110110",
"011111000101",
"000000011011",
"100111000111",
"010001110100",
"101000010001",
"010011100010",
"111010001010",
"101101110111",
"010100010101",
"000100001111",
"001110000001",
"000011110001",
"101000010101",
"111100100010",
"101100010110",
"000111001101",
"101100101111",
"110011101001",
"111110110101",
"000110011010",
"010100100010",
"111100010110",
"011110110110",
"101011101000",
"100001000010",
"001001101101",
"110111111101",
"111001110100",
"111001001000",
"011011100101",
"010111011110",
"111000011111",
"110111100100",
"010011110110",
"010000111011",
"100000001001",
"101110010101",
"100110111010",
"100001000000",
"110100110111"
    };
        private static int[]? sameBitCount;
        private static int[]? bitCount;
        private static string[]? whichDataInput;
        
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            //ApplicationConfiguration.Initialize();
            //Application.Run(new Form1());
            Question1();
            Question2();
        }

        public static void Question1()
        {
            whichDataInput = questionInput;
            sameBitCount = new int[whichDataInput[0].Length];
            bitCount = new int[sameBitCount.Length];

            CountBitNum(0);

            string gammaString = GammaRate();
            string epsilonString = EpsilonRate();
            int gammaDecimal = Convert.ToInt32(gammaString, 2);
            int epsilonDecimal = Convert.ToInt32(epsilonString, 2);

            Debug.WriteLine($"{{1}} Gamma:\t{gammaString}\t{{{gammaDecimal}}}");
            Debug.WriteLine($"{{1}} Epsilon:\t{epsilonString}\t{{{epsilonDecimal}}}");
            Debug.WriteLine($"{{1}} Power Consumption (G*E):\t{gammaDecimal * epsilonDecimal}");
        }

        public static void Question2()
        {
            whichDataInput = questionInput;

            int oxygenRating = CalculateGasRating(1);
            int carbonRating = CalculateGasRating(0);
    
            Debug.WriteLine($"{{2}} Oxygen:\t{oxygenRating}");
            Debug.WriteLine($"{{2}} Carbon:\t{carbonRating}");
            Debug.WriteLine($"{{2}} Life Support (O2*CO2):\t{oxygenRating * carbonRating}");
        }

        public static void CountBitNum(int startingBit)
        {
            bitCount = new int[whichDataInput[0].Length];
            for (int i = 0; i < whichDataInput.Length; i++)
            {
                for (int j = startingBit; j < whichDataInput[i].Length; j++)
                {
                    if (whichDataInput[i][j].Equals('1'))
                    {
                        bitCount[j]++;
                    }
                }
            }
        }

        public static int CalculateGasRating(int prefNum)
        {   
            List<string> remainingSets = new(whichDataInput);
            string whichGas = prefNum == 1 ? "Oxygen" : "Carbon";
            int result = 0;
            string input;
            for (int bit = 0; bit < whichDataInput[0].Length; bit++)
            {
                if(prefNum == 1)
                    input = BitCommonality(bit, ref remainingSets, true);
                else
                    input = BitCommonality(bit, ref remainingSets, false);

                for (int i = 0; i < remainingSets.Count; i++)
                {
                    if (remainingSets.Count == 1)
                    {
                        // Stop, return result here if only one remains
                        Debug.WriteLine($"\tAdding {{{whichGas}}}: {remainingSets[0]}");
                        return Convert.ToInt32(remainingSets[0], 2);
                    }

                    if (!remainingSets[i][bit].Equals(input[0]))
                    {
                        Debug.WriteLine($"\tRemoving {{{whichGas}}}: {remainingSets[i]} because [{bit}] != '{input}'");
                        remainingSets.RemoveAt(i);
                        i--;
                    }
                }
            }

            for(int i = 0;i< remainingSets.Count; i++)
            {            
                Debug.WriteLine($"\tAdding {{{whichGas}}}: {remainingSets[i]}");
                result += Convert.ToInt32(remainingSets[i], 2);
            }

            return result;
        }

        public static string BitCommonality(int whichBit, ref List<string> remainingSets, bool mostCommon)
        {
            int zeroCount = 0;
            int oneCount = 0;
            for(int i = 0;i<remainingSets.Count;i++)
            {
                if (remainingSets[i][whichBit].Equals('0'))
                    zeroCount++;
                else
                    oneCount++;
            }

            Debug.WriteLine($"\t\t[{whichBit}] {zeroCount}x0,{oneCount}x1");
            if(mostCommon)
            {
                return oneCount >= zeroCount ? "1" : "0"; 
            }
            else
            {
                return zeroCount <= oneCount ? "0" : "1";
            }
        }

        public static string GammaRate()
        {
            string byteString = "";
            sameBitCount = new int[bitCount.Length];
            for(int i = 0;i<bitCount.Length;i++)
            {
                if (bitCount[i] == whichDataInput.Length / 2)
                {
                    sameBitCount[i] = 1;
                }

                if (bitCount[i] >= whichDataInput.Length/2)
                {
                    byteString = $"{byteString}1";
                }
                else
                {
                    byteString = $"{byteString}0";
                }
            }
            Debug.WriteLine($"{{-}} Gamma:\t{byteString}");
            Debug.WriteLine($"{{-}} EqualBits:\t{string.Join("", sameBitCount)}");
            return byteString;
        }

        public static string EpsilonRate()
        {
            string byteString = "";
            for (int i = 0; i < bitCount.Length; i++)
            {
                if (bitCount[i] == whichDataInput.Length / 2) 
                {
                    sameBitCount[i] = 0;
                }

                if (bitCount[i] >= whichDataInput.Length / 2)
                {
                    byteString = $"{byteString}0";
                }
                else
                {
                    byteString = $"{byteString}1";
                }
            }
            Debug.WriteLine($"{{-}} Epsilon:\t{byteString}");
            Debug.WriteLine($"{{-}} EqualBits:\t{string.Join("",sameBitCount)}");
            return byteString;
        }
    }
}