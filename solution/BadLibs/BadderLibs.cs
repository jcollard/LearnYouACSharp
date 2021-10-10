namespace LearnYouACSharp
{
    using System;
    using System.IO;

    /// <summary>
    /// A bad game about words.
    /// </summary>
    public class BadderLibs
    {
        /// <summary>
        /// Executes a Game of BadLibs, asking the user to enter several words then displaying back to them the result.
        /// </summary>
        /// <param name="path">The path of the BadLib file to read.</param>
        public static void Play(string path)
        {
            // Declare local variables
            string text = File.ReadAllText(path);
            string finalText = string.Empty;
            bool inPrompt = false;

            foreach (char c in text)
            {
                if (c == '{')
                {
                    inPrompt = true;
                }
                else if (c == '}')
                {
                    inPrompt = false;
                    Console.WriteLine(": ");
                    finalText += Console.ReadLine();
                }
                else if (inPrompt)
                {
                    Console.Write(c);
                }
                else
                {
                    finalText += c;
                }
            }

            Console.WriteLine(finalText);
        }
    }
}