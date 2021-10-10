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
            // BaddestLibs.Play("files");

            BadLibBuilder b = BadLibBuilder.FromStringWhile("The {Enter a color} Dragon is the {Enter a superlative} Dragon of all.");
            b.Play();

            // BadLibBuilder b = new BadLibBuilder();
            // b.AddComponent(new BadLibPhrase("The "));
            // b.AddComponent(new BadLibInput("Enter a color"));
            // b.AddComponent(new BadLibPhrase(" Dragon is the "));
            // b.AddComponent(new BadLibInput("Enter a superlative (ending in est)"));
            // b.AddComponent(new BadLibPhrase(" Dragon of all.\n"));

            // b.AddComponent(new BadLibPhrase("It has "));
            // b.AddComponent(new BadLibInput("Enter an adjective"));
            // b.AddComponent(new BadLibPhrase(" "));
            // b.AddComponent(new BadLibInput("Enter a body part (plural)"));
            // b.AddComponent(new BadLibPhrase(", and a "));
            // b.AddComponent(new BadLibInput("Enter a body part"));
            // b.AddComponent(new BadLibPhrase(" shaped like a "));
            // b.AddComponent(new BadLibInput("Enter a noun"));
            // b.AddComponent(new BadLibPhrase(".\n"));

            // b.AddComponent(new BadLibPhrase("It loves to eat "));
            // b.AddComponent(new BadLibInput("Enter an animal"));
            // b.AddComponent(new BadLibPhrase(", although it will feast on nearly anything.\n"));

            // b.AddComponent(new BadLibPhrase("It is "));
            // b.AddComponent(new BadLibInput("Enter an adjective"));
            // b.AddComponent(new BadLibPhrase(" and "));
            // b.AddComponent(new BadLibInput("Enter an adjective"));
            // b.AddComponent(new BadLibPhrase(".\n"));

            // b.AddComponent(new BadLibPhrase("You must be "));
            // b.AddComponent(new BadLibInput("Enter an ajdective"));
            // b.AddComponent(new BadLibPhrase(" around it, or you may end up as it's meal!"));

            // b.Play();

            // string path = Directory.GetCurrentDirectory();
            // Console.WriteLine($"{path}");
        }
    }
}
