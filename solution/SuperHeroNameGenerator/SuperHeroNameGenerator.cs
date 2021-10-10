namespace LearnYouACSharp
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Generates a Super Hero Name.
    /// </summary>
    public class SuperHeroNameGenerator
    {
        /// <summary>
        /// TODO: Add a comment.
        /// </summary>
        public static void GenerateName()
        {
            // Declare local variables
            List<string> adjective0 = new List<string>();
            List<string> adjective1 = new List<string>();
            List<string> noun = new List<string>();
            Random random = new Random();
            string part0, part1, part2;

            adjective0.Add("Amazing");
            adjective0.Add("Brilliant");
            adjective0.Add("Awesome");

            adjective1.Add("Giant");
            adjective1.Add("Tiny");
            adjective1.Add("Shrinking");

            noun.Add("Man");
            noun.Add("Moth");
            noun.Add("Goat");

            part0 = adjective0[random.Next(adjective0.Count)];
            part1 = adjective1[random.Next(adjective1.Count)];
            part2 = noun[random.Next(noun.Count)];

            Console.WriteLine($"{part0} {part1} {part2}");
        }
    }
}