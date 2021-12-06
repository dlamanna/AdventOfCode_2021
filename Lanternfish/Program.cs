using System.Diagnostics;

namespace Lanternfish
{
    internal static class Program
    {
        private static List<byte> testInput = new(){ 3, 4, 3, 1, 2 };
        private static List<byte> questionInput = new() { 2, 1, 1, 4, 4, 1, 3, 4, 2, 4, 2, 1, 1, 4, 3, 5, 1, 1, 5, 1, 1, 5, 4, 5, 4, 1, 5, 1, 3, 1, 4, 2, 3, 2, 1, 2, 5, 5, 2, 3, 1, 2, 3, 3, 1, 4, 3, 1, 1, 1, 1, 5, 2, 1, 1, 1, 5, 3, 3, 2, 1, 4, 1, 1, 1, 3, 1, 1, 5, 5, 1, 4, 4, 4, 4, 5, 1, 5, 1, 1, 5, 5, 2, 2, 5, 4, 1, 5, 4, 1, 4, 1, 1, 1, 1, 5, 3, 2, 4, 1, 1, 1, 4, 4, 1, 2, 1, 1, 5, 2, 1, 1, 1, 4, 4, 4, 4, 3, 3, 1, 1, 5, 1, 5, 2, 1, 4, 1, 2, 4, 4, 4, 4, 2, 2, 2, 4, 4, 4, 2, 1, 5, 5, 2, 1, 1, 1, 4, 4, 1, 4, 2, 3, 3, 3, 3, 3, 5, 4, 1, 5, 1, 4, 5, 5, 1, 1, 1, 4, 1, 2, 4, 4, 1, 2, 3, 3, 3, 3, 5, 1, 4, 2, 5, 5, 2, 1, 1, 1, 1, 3, 3, 1, 1, 2, 3, 2, 5, 4, 2, 1, 1, 2, 2, 2, 1, 3, 1, 5, 4, 1, 1, 5, 3, 3, 2, 2, 3, 1, 1, 1, 1, 2, 4, 2, 2, 5, 1, 2, 4, 2, 1, 1, 3, 2, 5, 5, 3, 1, 3, 3, 1, 4, 1, 1, 5, 5, 1, 5, 4, 1, 1, 1, 1, 2, 3, 3, 1, 2, 3, 1, 5, 1, 3, 1, 1, 3, 1, 1, 1, 1, 1, 1, 5, 1, 1, 5, 5, 2, 1, 1, 5, 2, 4, 5, 5, 1, 1, 5, 1, 5, 5, 1, 1, 3, 3, 1, 1, 3, 1 };
        private static List<System.Numerics.BigInteger> daysList = new() { 0,0,0,0,0,0,0,0,0,0 };
        private static List<byte> whichInput = questionInput;
        private static int daysToCount = 256;
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
            CreateDaysList();
            int dayCountEnd = 0;
            do
            {
                System.Numerics.BigInteger tempStore = daysList[8];
                daysList[8] = daysList[0];
                System.Numerics.BigInteger tempStore1 = daysList[7];
                daysList[7] = tempStore;
                tempStore = daysList[6];
                daysList[6] = tempStore1 + daysList[0];
                tempStore1 = daysList[5];
                daysList[5] = tempStore;
                tempStore = daysList[4];
                daysList[4] = tempStore1;
                tempStore1 = daysList[3];
                daysList[3] = tempStore;
                tempStore = daysList[2];
                daysList[2] = tempStore1;
                tempStore1 = daysList[1];
                daysList[1] = tempStore;
                daysList[0] = tempStore1;

                //Debug.WriteLine($"After {dayCountEnd} days: {string.Join(" ", whichInput)}");
                Debug.WriteLine($"After {dayCountEnd} days: {CountFish(ref daysList)}");
                dayCountEnd++;
            } while (dayCountEnd < daysToCount);

            System.Numerics.BigInteger numberOfFish = CountFish(ref daysList);
            Debug.WriteLine($"Number of lanternfish after {daysToCount} days: {numberOfFish}");
        }

        public static void CreateDaysList()
        {
            for (int i = 0; i < whichInput.Count; i++)
            {
                daysList[whichInput[i]]++;
            }
        }

        public static System.Numerics.BigInteger CountFish(ref List<System.Numerics.BigInteger> fishList)
        {
            System.Numerics.BigInteger sum = 0;
            for(int i = 0;i<fishList.Count;i++)
            {
                sum += fishList[i];
            }
            return sum;
        }
    }
}