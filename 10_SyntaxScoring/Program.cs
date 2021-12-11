using System.Diagnostics;

namespace SyntaxScoring
{
    internal static class Program
    {
        private static string testInput = @"[({(<(())[]>[[{[]{<()<>>
[(()[<>])]({[<{<<[]>>(
{([(<{}[<>[]}>{[]{[(<()>
(((({<>}<{<{<>}{[]{[]{}
[[<[([]))<([[{}[[()]]]
[{[{({}]{}}([{[{{{}}([]
{<[[]]>}<{[{[{[]{()[[[]
[<(<(<(<{}))><([]([]()
<{([([[(<>()){}]>(<<{{
<{([{{}}[<[[[<>{}]]]>[]]";
        private static Dictionary<char,int> scoringStore = new Dictionary<char,int>();
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
            string[] testStrings = testInput.Split("\r\n");
            scoringStore.Add(')', 3);
            scoringStore.Add(']', 57);
            scoringStore.Add('}', 1197);
            scoringStore.Add('>', 25137);
            int runningSum = 0;
            for(int i = 0;i<testStrings.Length;i++)
            {
                runningSum += ScoreString(testStrings[i]);               
            }
            Debug.WriteLine($"Sum of syntax errors: {runningSum}");
        }

        public static int ScoreString(string inString)
        {
            int openSquareBrackets = 0;
            int openCurlyBrackets = 0;
            int openParentheses = 0;
            int openAngleBrackets = 0;
            char chunkStarter = inString[0];
            Debug.WriteLine($"\tNew string, beginning analysis: {inString}");
            for (int i = 0; i < inString.Length; i++)
            {
                if (inString[i].Equals('['))
                {
                    openSquareBrackets++;
                }
                else if (inString[i].Equals('{'))
                {
                    openCurlyBrackets++;
                }
                else if (inString[i].Equals('('))
                {
                    openParentheses++;
                }
                else if (inString[i].Equals('<'))
                {
                    openAngleBrackets++;
                }
                else if (inString[i].Equals(']'))
                {
                    if(chunkStarter.Equals('[') && openSquareBrackets == 1)
                    if (openSquareBrackets <= 0)
                    {
                        return scoringStore[']'];
                    }
                    openSquareBrackets--;
                    Debug.WriteLine($"Closing ']' found, current score: {openSquareBrackets}");
                }
                else if (inString[i].Equals('}'))
                {
                    if (openCurlyBrackets <= 0)
                    {
                        return scoringStore['}'];
                    }
                    openCurlyBrackets--; 
                    Debug.WriteLine($"Closing '}}' found, current score: {openCurlyBrackets}");
                }
                else if (inString[i].Equals(')'))
                {
                    if (openParentheses <= 0)
                    {
                        return scoringStore[')'];
                    }
                    openParentheses--; 
                    Debug.WriteLine($"Closing ')' found, current score: {openParentheses}");
                }
                else if (inString[i].Equals('>'))
                {
                    if (openAngleBrackets <= 0)
                    {
                        return scoringStore['>'];
                    }
                    openAngleBrackets--; 
                    Debug.WriteLine($"Closing '>' found, current score: {openAngleBrackets}");
                }
            }
            return 0;
        }
    }
}