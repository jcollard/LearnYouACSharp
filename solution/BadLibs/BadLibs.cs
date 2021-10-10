namespace LearnYouACSharp
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// A bad game about words.
    /// </summary>
    public class BadLibs
    {
        /// <summary>
        /// Executes a Game of BadLibs, asking the user to enter several words then displaying back to them the result.
        /// </summary>
        public static void Play()
        {
            // Declare local variables
            string color;
            string superlative;
            string adjective0;
            string bodyPartPlural;
            string bodyPart;
            string noun;
            string animal;
            string adjective1;
            string adjective2;
            string adjective3;

            // List<string> textComponents = new List<string>();

            // textComponents.Add("A blaha blah");
            // textComponents.Add(GetInput("Enter a color: "));

            // foreach(string compononent in textComponents){

            // }

            Console.WriteLine("Enter a color: ");
            color = Console.ReadLine();

            Console.WriteLine("Enter a superlative (ending in est): ");
            superlative = Console.ReadLine();

            Console.WriteLine("Enter an adjective: ");
            adjective0 = Console.ReadLine();

            Console.WriteLine("Enter a body part (plural): ");
            bodyPartPlural = Console.ReadLine();

            Console.WriteLine("Enter a body part (singular): ");
            bodyPart = Console.ReadLine();

            Console.WriteLine("Enter a noun: ");
            noun = Console.ReadLine();

            Console.WriteLine("Enter an animal: ");
            animal = Console.ReadLine();

            Console.WriteLine("Enter an adjective: ");
            adjective1 = Console.ReadLine();

            Console.WriteLine("Enter an adjective: ");
            adjective2 = Console.ReadLine();

            Console.WriteLine("Enter an adjective: ");
            adjective3 = Console.ReadLine();

            Console.WriteLine($"The {color} Dragon is the {superlative} Dragon of all.");
            Console.WriteLine($"It has {adjective0} {bodyPartPlural}, and a {bodyPart} shaped like a {noun}.");
            Console.WriteLine($"It loves to eat {animal}, although it will feast on nearly anything.");
            Console.WriteLine($"It is {adjective1} and {adjective2}.");
            Console.WriteLine($"You must be {adjective3} around it, or you may end upa s it's meal!");
        }
    }
}