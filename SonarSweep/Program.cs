using System.Diagnostics;

namespace SonarSweep
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            //ApplicationConfiguration.Initialize();
            //Application.Run(new Form1());
            int[] sweepArray = new int[] { 199, 200, 208, 210, 200,
                                            207, 240, 269, 260, 263 };
            int increasingCount = 0;
            for(int i = 0;i<sweepArray.Length-1;i++)
            {
                if(sweepArray[i] < sweepArray[i+1])
                {
                    increasingCount++;
                }
            }

            Debug.WriteLine($"Number of increases from previous index: {increasingCount}");
        }
    }
}