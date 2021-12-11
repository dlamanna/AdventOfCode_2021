using System.Diagnostics;

namespace SevenSegmentSearch
{
    enum Identifier
    {
        Top,
        TopLeft,
        TopRight,
        Middle,
        BottomLeft,
        BottomRight,
        Bottom
    }

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
        public Dictionary<Identifier, string> PositionPossibilities { get; set; }

        public SegmentNumber()
        {
            Top = TopLeft = TopRight = Middle = BottomLeft = BottomRight = Bottom = "";
            PositionPossibilities = new();
            PositionPossibilities.Add(Identifier.Top, "abcdefg");
            PositionPossibilities.Add(Identifier.TopLeft, "abcdefg");
            PositionPossibilities.Add(Identifier.TopRight, "abcdefg");
            PositionPossibilities.Add(Identifier.Middle, "abcdefg");
            PositionPossibilities.Add(Identifier.BottomLeft, "abcdefg");
            PositionPossibilities.Add(Identifier.BottomRight, "abcdefg");
            PositionPossibilities.Add(Identifier.Bottom, "abcdefg");
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
            else if (filledArray[0] && filledArray[1] && filledArray[2] && filledArray[3] && filledArray[5] && filledArray[6])
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

        public void UpdateStrings()
        {
            if (Top.Equals("") && PositionPossibilities[Identifier.Top].Length == 1)
            {               
                Top = PositionPossibilities[Identifier.Top];
                Debug.WriteLine($"Figured out Top: {Top}");
                RemovePossibilitiesFromOtherPositions(Identifier.Top, Top);
            }
            if (TopLeft.Equals("") && PositionPossibilities[Identifier.TopLeft].Length == 1)
            {
                TopLeft = PositionPossibilities[Identifier.TopLeft];
                Debug.WriteLine($"Figured out TopLeft: {TopLeft}");
                RemovePossibilitiesFromOtherPositions(Identifier.TopLeft, TopLeft);
            }
            if (TopRight.Equals("") && PositionPossibilities[Identifier.TopRight].Length == 1)
            {
                TopRight = PositionPossibilities[Identifier.TopRight];
                Debug.WriteLine($"Figured out TopRight: {TopRight}");
                RemovePossibilitiesFromOtherPositions(Identifier.TopRight, TopRight);
            }
            if (Middle.Equals("") && PositionPossibilities[Identifier.Middle].Length == 1)
            {
                Middle = PositionPossibilities[Identifier.Middle];
                Debug.WriteLine($"Figured out Middle: {Middle}");
                RemovePossibilitiesFromOtherPositions(Identifier.Middle, Middle);
            }
            if (BottomLeft.Equals("") && PositionPossibilities[Identifier.BottomLeft].Length == 1)
            {
                BottomLeft = PositionPossibilities[Identifier.BottomLeft];
                Debug.WriteLine($"Figured out BottomLeft: {BottomLeft}");
                RemovePossibilitiesFromOtherPositions(Identifier.BottomLeft, BottomLeft);
            }
            if (BottomRight.Equals("") && PositionPossibilities[Identifier.BottomRight].Length == 1)
            {
                BottomRight = PositionPossibilities[Identifier.BottomRight];
                Debug.WriteLine($"Figured out BottomRight: {BottomRight}");
                RemovePossibilitiesFromOtherPositions(Identifier.BottomRight, BottomRight);
            }
            if (Bottom.Equals("") && PositionPossibilities[Identifier.Bottom].Length == 1)
            {
                Bottom = PositionPossibilities[Identifier.Bottom];
                Debug.WriteLine($"Figured out Bottom: {Bottom}");
                RemovePossibilitiesFromOtherPositions(Identifier.Bottom, Bottom);
            }
        }

        public void RemovePossibilitiesFromOtherPositions(Identifier identifier, string replaceMe)
        {
            bool anyChangesMade = false;
            if(Top.Equals("") &&
                identifier != Identifier.Top &&
                PositionPossibilities[Identifier.Top].Contains(replaceMe))
            {
                string updatedString = PositionPossibilities[Identifier.Top].Replace(replaceMe, string.Empty);
                PositionPossibilities[Identifier.Top] = updatedString;
                anyChangesMade = true;
            }
            if (TopLeft.Equals("") &&
                identifier != Identifier.TopLeft &&
                PositionPossibilities[Identifier.TopLeft].Contains(replaceMe))
            {
                string updatedString = PositionPossibilities[Identifier.TopLeft].Replace(replaceMe, string.Empty);
                PositionPossibilities[Identifier.TopLeft] = updatedString;
                anyChangesMade = true;
            }
            if (TopRight.Equals("") &&
                identifier != Identifier.TopRight &&
                PositionPossibilities[Identifier.TopRight].Contains(replaceMe))
            {
                string updatedString = PositionPossibilities[Identifier.TopRight].Replace(replaceMe, string.Empty);
                PositionPossibilities[Identifier.TopRight] = updatedString;
                anyChangesMade = true;
            }
            if (Middle.Equals("") &&
                identifier != Identifier.Middle &&
                PositionPossibilities[Identifier.Middle].Contains(replaceMe))
            {
                string updatedString = PositionPossibilities[Identifier.Middle].Replace(replaceMe, string.Empty);
                PositionPossibilities[Identifier.Middle] = updatedString;
                anyChangesMade = true;
            }
            if (BottomLeft.Equals("") &&
                identifier != Identifier.BottomLeft &&
                PositionPossibilities[Identifier.BottomLeft].Contains(replaceMe))
            {
                string updatedString = PositionPossibilities[Identifier.BottomLeft].Replace(replaceMe, string.Empty);
                PositionPossibilities[Identifier.BottomLeft] = updatedString;
                anyChangesMade = true;
            }
            if (BottomRight.Equals("") &&
                identifier != Identifier.BottomRight &&
                PositionPossibilities[Identifier.BottomRight].Contains(replaceMe))
            {
                string updatedString = PositionPossibilities[Identifier.BottomRight].Replace(replaceMe, string.Empty);
                PositionPossibilities[Identifier.BottomRight] = updatedString;
                anyChangesMade = true;
            }
            if (Bottom.Equals("") &&
                identifier != Identifier.Bottom &&
                PositionPossibilities[Identifier.Bottom].Contains(replaceMe))
            {
                string updatedString = PositionPossibilities[Identifier.Bottom].Replace(replaceMe, string.Empty);
                PositionPossibilities[Identifier.Bottom] = updatedString;
                anyChangesMade = true;
            }
            
            if(anyChangesMade)
                UpdateStrings();
        }

        public void RemoveAllPossibilitiesOtherThan(Identifier identifier, params char[] charsToRemove)
        {
            string updatedString = "";
            string possString = PositionPossibilities[identifier];
            int i = 0;
            do
            {
                possString = PositionPossibilities[identifier];
                bool foundLetter = false;
                for(int j = 0;j<charsToRemove.Length;j++)
                {
                    if (possString[i] == charsToRemove[j])
                    {
                        foundLetter = true;
                    }
                }
                if (!foundLetter)
                {
                    updatedString = possString.Replace("" + possString[i], "");
                    PositionPossibilities[identifier] = updatedString;
                    /*Debug.WriteLine($"Removing letter '{possString[i]}'\tupdatedString: {updatedString}\t" +
                        $"Position: {ConvertIdentifierToString(identifier)}");*/
                    continue;       //skip the increment
                }
                i++;
            } while (i < PositionPossibilities[identifier].Length);      
            UpdateStrings();
        }

        public void PrintPossibilities()
        {
            string outString = "";
            for (int i = 0; i < PositionPossibilities.Count; i++) 
            {
                outString = $"{outString}{ConvertIdentifierToString(PositionPossibilities.ElementAt(i).Key)}: {PositionPossibilities.ElementAt(i).Value}\n";               
            }
            Debug.WriteLine($"{outString}");
        }

        public void PositionString(string input)
        {
            if (input.Length == 2)                      // then we've found a 1
            {
                RemoveAllPossibilitiesOtherThan(Identifier.TopRight, input[0], input[1]);
                RemoveAllPossibilitiesOtherThan(Identifier.BottomRight, input[0], input[1]);
            }
            else if(input.Length == 3)                  // then we've found a 7
            {
                RemoveAllPossibilitiesOtherThan(Identifier.Top, input[0], input[1], input[2]);
                RemoveAllPossibilitiesOtherThan(Identifier.TopRight, input[0], input[1], input[2]);
                RemoveAllPossibilitiesOtherThan(Identifier.BottomRight, input[0], input[1], input[2]);
            }
            else if (input.Length == 4)                  // then we've found a 4
            {
                RemoveAllPossibilitiesOtherThan(Identifier.TopLeft, input[0], input[1], input[2], input[3]);
                RemoveAllPossibilitiesOtherThan(Identifier.TopRight, input[0], input[1], input[2], input[3]);
                RemoveAllPossibilitiesOtherThan(Identifier.Middle, input[0], input[1], input[2], input[3]);
                RemoveAllPossibilitiesOtherThan(Identifier.BottomRight, input[0], input[1], input[2], input[3]);
            }
            else if (input.Length == 7)                  
            {
                // then we've found an 8 which we learn nothing from since all spots are filled
            }
            else if (input.Length == 6)                  // then we've found a 0, 6, or 9
            {
                ///TODO: Finish this logic
                RemoveAllPossibilitiesOtherThan(Identifier.Top, input[0], input[1], input[2], input[3], input[4], input[5]);
                RemoveAllPossibilitiesOtherThan(Identifier.TopLeft, input[0], input[1], input[2], input[3], input[4], input[5]);
                RemoveAllPossibilitiesOtherThan(Identifier.BottomRight, input[0], input[1], input[2], input[3], input[4], input[5]);
                RemoveAllPossibilitiesOtherThan(Identifier.Bottom, input[0], input[1], input[2], input[3], input[4], input[5]);
                // Don't write top-right in this case {6}
                // Don't write middle in this case {0}
                // Don't write bottom-left in this case {9}
            }
            else if (input.Length == 5)                  // then we've found a 2, 3, or 5
            {
                RemoveAllPossibilitiesOtherThan(Identifier.Top, input[0], input[1], input[2], input[3], input[4]);
                RemoveAllPossibilitiesOtherThan(Identifier.Middle, input[0], input[1], input[2], input[3], input[4]);
                RemoveAllPossibilitiesOtherThan(Identifier.Bottom, input[0], input[1], input[2], input[3], input[4]);
                // Don't write top-left in this case {2,3}
                // Don't write top-right in this case {5}
                // Don't write bottom-left in this case {3,5}
                // Don't write bottom-right in this case {2}
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

        public string ConvertIdentifierToString(Identifier identifier)
        {
            switch(identifier)
            {
                case Identifier.Top:
                    return "Top";
                case Identifier.TopLeft:
                    return "TopLeft";
                case Identifier.TopRight:
                    return "TopRight";
                case Identifier.Middle:
                    return "Middle";
                case Identifier.BottomLeft:
                    return "BottomLeft";
                case Identifier.BottomRight:
                    return "BottomRight";
                case Identifier.Bottom:
                    return "Bottom";
            }
            return "";
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
