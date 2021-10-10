namespace LearnYouACSharp
{
    using System;
    using System.IO;

    /// <summary>
    /// This class contains the entry point for this project.
    /// </summary>
    public class Program
    {
        /// <summary>
        /// This method is the Entry point for this project.
        /// </summary>
        public static void Main()
        {
            // GuessingGame.Play(0, 100);
            // RockPaperScissors.Play(5);
            // BadLibs.Play();
            // SuperHeroNameGenerator.GenerateName();
            // BadderLibs.Play("files/Dragon.bad");
            BaddestLibs.Play("files");

            // string path = Directory.GetCurrentDirectory();
            // Console.WriteLine($"{path}");
        }
    }
}
