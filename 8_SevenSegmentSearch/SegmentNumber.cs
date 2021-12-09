using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SevenSegmentSearch
{
    internal class SegmentNumber
    {
        /*   dddd
            e    a
            e    a
             ffff
            g    b
            g    b
             cccc
         */
        public string Top { get; set; }
        public string TopLeft { get; set; }
        public string TopRight { get; set; }
        public string Middle { get; set; }
        public string BottomLeft { get; set; }
        public string BottomRight { get; set; }
        public string Bottom { get; set; }

        public SegmentNumber()
        {
            Top = TopLeft = TopRight = Middle = BottomLeft = BottomRight = Bottom = "";
        }

        public int DecodeString(string[] input)
        {
            string retString = "";
            for(int i = 0;i<input.Length;i++)
            {
                bool[] filledArray = new bool[] { false, false, false, false, false, false, false };
                for(int j = 0;j<input[i].Length;j++)
                {
                    if (Top.Equals("" + input[i][j]))
                    {
                        filledArray[0] = true;
                        continue;
                    }
                    else if(TopLeft.Equals("" + input[i][j]))
                    {
                        filledArray[1] = true;
                        continue;
                    }
                    else if (TopRight.Equals("" + input[i][j]))
                    {
                        filledArray[2] = true;
                        continue;
                    }
                    else if (Middle.Equals("" + input[i][j]))
                    {
                        filledArray[3] = true;
                        continue;
                    }
                    else if (BottomLeft.Equals("" + input[i][j]))
                    {
                        filledArray[4] = true;
                        continue;
                    }
                    else if (BottomRight.Equals("" + input[i][j]))
                    {
                        filledArray[5] = true;
                        continue;
                    }
                    else if (Bottom.Equals("" + input[i][j]))
                    {
                        filledArray[6] = true;
                        continue;
                    }                   
                }

                string strNum = ClassifyNumber(ref filledArray);
                retString = retString + strNum;              
                Debug.WriteLine($"{input[i]}: {strNum}");
            }

            int outInt = int.Parse(retString);
            return outInt;
        }

        public string ClassifyNumber(ref bool[] filledArray)
        {
            Print();
            if (filledArray[0] && filledArray[1] && filledArray[2] && filledArray[3] && filledArray[4] && filledArray[5] && filledArray[6])
            {
                return "8";
            }
            else if (filledArray[0] && filledArray[1] && filledArray[2] && filledArray[4] && filledArray[5] && filledArray[6])
            {
                return "0";
            }       
            else if (filledArray[0] && filledArray[1] && filledArray[3] && filledArray[4] && filledArray[5] && filledArray[6])
            {
                return "6";
            }     
            else if (filledArray[0] && filledArray[1] && filledArray[2] && filledArray[3] && filledArray[4] && filledArray[6])
            {
                return "9";
            }
            else if (filledArray[0] && filledArray[2] && filledArray[3] && filledArray[4] && filledArray[6])
            {
                return "2";
            }
            else if (filledArray[0] && filledArray[2] && filledArray[3] && filledArray[5] && filledArray[6])
            {
                return "3";
            }
            else if (filledArray[0] && filledArray[1] && filledArray[3] && filledArray[5] && filledArray[6])
            {
                return "5";
            }
            else if (filledArray[1] && filledArray[2] && filledArray[3] && filledArray[5])
            {
                return "4";
            }
            else if (filledArray[0] && filledArray[2] && filledArray[5])
            {
                return "7";
            }
            else if (filledArray[2] && filledArray[5])
            {
                return "1";
            }
            else
            {
                Debug.WriteLine($"SegmentNumber::ClassifyNumber - Error, can't classify number\n" +
                    $"[{filledArray[0]}] [{filledArray[1]}] [{filledArray[2]}] [{filledArray[3]}] [{filledArray[4]}] " +
                    $"[{filledArray[5]}] [{filledArray[6]}]");
                //Print();
                return "";
            }
        }

        public void PositionString(string input)
        {
            ///TODO: Need to re-write this so that we can distinguish
            ///between segments that are in random order (current implementation is assuming linear order)
            ///idea: create hashmap list attached to Segment number to combine known strings to their #...
            ///so, if we find a 1 and a 7, we can tell which number is the top segment by which letter not in 1
            ///3 will contain 1 (way to differentiate 3 from 2,5)
            ///6 will not contain 1 (way to differentiate 6 from 0,9)
            if (input.Length == 2)                      // then we've found a 1
            {
                TopRight = "" + input[0];
                BottomRight = "" + input[1];
            }
            else if(input.Length == 3)                  // then we've found a 7
            {
                Top = "" + input[0];
                TopRight = "" + input[1];
                BottomRight = "" + input[2];
            }
            else if (input.Length == 4)                  // then we've found a 4
            {
                TopLeft = "" + input[0];
                TopRight = "" + input[1];
                Middle = "" + input[2];
                BottomRight = "" + input[3];
            }
            else if (input.Length == 7)                  
            {
                // then we've found an 8 which we learn nothing from since all spots are filled
            }
            else if (input.Length == 6)                  // then we've found a 0, 6, or 9
            {
                Top = "" + input[0];              
                TopLeft = "" + input[1];
                // Don't write top-right in this case {6}
                // Don't write middle in this case {0}
                // Don't write bottom-left in this case {9}
                BottomRight = "" + input[^2];
                Bottom = "" + input[^1];
            }
            else if (input.Length == 5)                  // then we've found a 2, 3, or 5
            {
                Top = "" + input[0];
                // Don't write top-left in this case {2,3}
                // Don't write top-right in this case {5}
                Middle = "" + input[2];
                // Don't write bottom-left in this case {3,5}
                // Don't write bottom-right in this case {2}
                Bottom = "" + input[^1];
            }
        }

        public bool IsComplete()
        {
            if(!Top.Equals("") && !TopLeft.Equals("") && !TopRight.Equals("") && !Middle.Equals("")
                && !BottomLeft.Equals("") && !BottomRight.Equals("") && !Bottom.Equals(""))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void Print()
        {
            if (IsComplete())
            {
                string printString = $" {Top}{Top}{Top}{Top}\n" +
                                     $"{TopLeft}    {TopRight}\n" +
                                     $"{TopLeft}    {TopRight}\n" +
                                     $" {Middle}{Middle}{Middle}{Middle}\n" +
                                     $"{BottomLeft}    {BottomRight}\n" +
                                     $"{BottomLeft}    {BottomRight}\n" +
                                     $" {Bottom}{Bottom}{Bottom}{Bottom}";
                Debug.WriteLine(printString);
            }
            else
            {
                Debug.WriteLine($"### Trying to print an incomplete SegmentNumber");
            }
        }
    }
}
