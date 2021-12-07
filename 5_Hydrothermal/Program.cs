using System.Diagnostics;

namespace Hydrothermal
{
    internal static class Program
    {
        private static List<Vector> testVectorList = new();
        private static List<Vector> questionVectorList = new();
        private static int gridSize = 1000000;
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            testVectorList.Add(new Vector(0, 9, 5, 9));
            testVectorList.Add(new Vector(8, 0, 0, 8));
            testVectorList.Add(new Vector(9, 4, 3, 4));
            testVectorList.Add(new Vector(2, 2, 2, 1));
            testVectorList.Add(new Vector(7, 0, 7, 4));
            testVectorList.Add(new Vector(6, 4, 2, 0));
            testVectorList.Add(new Vector(0, 9, 2, 9));
            testVectorList.Add(new Vector(3, 4, 1, 4));
            testVectorList.Add(new Vector(0, 0, 8, 8));
            testVectorList.Add(new Vector(5, 5, 8, 2));
            string[] lines = File.ReadAllLines(@"C:\Users\phuze\Dropbox\Programming\AdventOfCode_2021\5_Hydrothermal\VentInput.txt");
            GetVectorInputFromFile(ref lines);

            Question1();
        }

        public static void Question1()
        {
            int howManyOverlaps = ExpandVector(ref questionVectorList);
            Debug.WriteLine($"Number of overlaps detected: {howManyOverlaps}");
        }

        public static void GetVectorInputFromFile(ref string[] lines)
        {
            for(int i = 0;i<lines.Length;i++)
            {
                string[] splitLines = lines[i].Trim().Split(" -> ");
                if(splitLines.Length != 2)
                {
                    Debug.WriteLine($"Looks like we got some messed up input: {lines[i]}");
                }
                else
                {
                    string[] firstVector = splitLines[0].Split(',');
                    string[] secondVector = splitLines[1].Split(',');
                    Vector tempVec = new Vector(int.Parse(firstVector[0]),int.Parse(firstVector[1]),
                                                int.Parse(secondVector[0]),int.Parse(secondVector[1]));
                    questionVectorList.Add(tempVec);
                }
            }
        }

        public static int ExpandVector(ref List<Vector> vectors)
        {
            HashSet<Coordinate> coordinateHash = new();
            HashSet<Coordinate> duplicateHash = new();
            for (int i = 0;i<vectors.Count;i++)
            {
                // Only add straight lines
                if(vectors[i].IsStraight)
                {
                    List<Coordinate> supplementalList = vectors[i].ExpandVectors();
                    foreach(Coordinate v in supplementalList)
                    {
                        //Debug.WriteLine($"Saving Coordinate: {{{v.X},{v.Y}}}");
                        if(coordinateHash.Contains(v))
                        {
                            if(!duplicateHash.Contains(v))
                            {
                                duplicateHash.Add(v);
                            }
                            // else we dont save to anything because we don't care about 2+ intersections
                        }
                        else
                        {
                            coordinateHash.Add(v);
                        }                  
                    }
                }
            }
            return duplicateHash.Count;
        }
    }
}