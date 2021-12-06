using System.Diagnostics;

namespace Lanternfish
{
    internal static class Program
    {
        private static List<byte> testInput = new(){ 3, 4, 3, 1, 2 };
        private static List<byte> questionInput = new() { 2, 1, 1, 4, 4, 1, 3, 4, 2, 4, 2, 1, 1, 4, 3, 5, 1, 1, 5, 1, 1, 5, 4, 5, 4, 1, 5, 1, 3, 1, 4, 2, 3, 2, 1, 2, 5, 5, 2, 3, 1, 2, 3, 3, 1, 4, 3, 1, 1, 1, 1, 5, 2, 1, 1, 1, 5, 3, 3, 2, 1, 4, 1, 1, 1, 3, 1, 1, 5, 5, 1, 4, 4, 4, 4, 5, 1, 5, 1, 1, 5, 5, 2, 2, 5, 4, 1, 5, 4, 1, 4, 1, 1, 1, 1, 5, 3, 2, 4, 1, 1, 1, 4, 4, 1, 2, 1, 1, 5, 2, 1, 1, 1, 4, 4, 4, 4, 3, 3, 1, 1, 5, 1, 5, 2, 1, 4, 1, 2, 4, 4, 4, 4, 2, 2, 2, 4, 4, 4, 2, 1, 5, 5, 2, 1, 1, 1, 4, 4, 1, 4, 2, 3, 3, 3, 3, 3, 5, 4, 1, 5, 1, 4, 5, 5, 1, 1, 1, 4, 1, 2, 4, 4, 1, 2, 3, 3, 3, 3, 5, 1, 4, 2, 5, 5, 2, 1, 1, 1, 1, 3, 3, 1, 1, 2, 3, 2, 5, 4, 2, 1, 1, 2, 2, 2, 1, 3, 1, 5, 4, 1, 1, 5, 3, 3, 2, 2, 3, 1, 1, 1, 1, 2, 4, 2, 2, 5, 1, 2, 4, 2, 1, 1, 3, 2, 5, 5, 3, 1, 3, 3, 1, 4, 1, 1, 5, 5, 1, 5, 4, 1, 1, 1, 1, 2, 3, 3, 1, 2, 3, 1, 5, 1, 3, 1, 1, 3, 1, 1, 1, 1, 1, 1, 5, 1, 1, 5, 5, 2, 1, 1, 5, 2, 4, 5, 5, 1, 1, 5, 1, 5, 5, 1, 1, 3, 3, 1, 1, 3, 1 };
        private static List<byte> daysList = new List<byte>();
        private static List<byte> whichInput = questionInput;
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
                for (int i = 0; i < whichInput.Count; i++)
                {
                    if(whichInput[i] == 0)
                    {
                        whichInput[i] = 6;
                        whichInput.Add(9);
                    }
                    else
                    {
                        whichInput[i]--;
                    }
                }
                //Debug.WriteLine($"After {dayCountEnd} days: {string.Join(" ", whichInput)}");
                Debug.WriteLine($"After {dayCountEnd} days: {whichInput.Count}");
                dayCountEnd++;
            } while (dayCountEnd < 256);

            Debug.WriteLine($"Number of lanternfish after 256 days: {whichInput.Count}");
        }

        public static void CreateDaysList()
        {
            for (int i = 0; i < whichInput.Count; i++)
            {
                daysList[whichInput[i]]++;
            }
        }
    }
}