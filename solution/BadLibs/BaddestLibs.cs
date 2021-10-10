namespace LearnYouACSharp
{
    using System;
    using System.IO;

    /// <summary>
    /// A bad game about words.
    /// </summary>
    public class BaddestLibs
    {
        /// <summary>
        /// Executes a Game of BadLibs, asking the user to enter several words then displaying back to them the result.
        /// </summary>
        /// <param name="path">The path of the BadLib file to read.</param>
        public static void Play(string path)
        {
            // Declare local variables
            string[] files = Directory.GetFiles(path, "*.bad");

            Console.WriteLine("Available Bad Libs: ");
            for (int ix = 0; ix < files.Length; ix++)
            {
                string filename = files[ix];
                Console.WriteLine($"{ix}. {filename}");
            }

            Console.WriteLine("Select a number: ");
            int choice = int.Parse(Console.ReadLine());
            BadderLibs.Play(files[choice]);
        }
    }
}