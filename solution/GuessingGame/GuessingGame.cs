namespace LearnYouACSharp.GuessingGame
{
    using System;

    /// <summary>
    /// A number Guessing Game.
    /// </summary>
    public class GuessingGame
    {
        /// <summary>
        /// Executes a Guessing Game in which a player must guess a randomly
        /// generated number between the specified values.
        /// </summary>
        /// <param name="minNumber">The minimum value that the game may generate.</param>
        /// <param name="maxNumber">The maximum value that the game may generate.</param>
        public static void Run(int minNumber, int maxNumber)
        {
            Random randomGenerator;
            int incorrectGuesses, randomNumber, playerGuess;
            randomGenerator = new Random();
            incorrectGuesses = 0;
            randomNumber = randomGenerator.Next(minNumber, maxNumber + 1);
            Console.WriteLine("Guessing Game:");
            Console.WriteLine($"I'm thinking of a number between {minNumber} and {maxNumber}.");
            playerGuess = GetGuess(minNumber, maxNumber);
            while (playerGuess != randomNumber)
            {
                incorrectGuesses++;
                if (playerGuess > randomNumber)
                {
                    Console.WriteLine("Your guess is too high.");
                }
                else if (playerGuess < randomNumber)
                {
                    Console.WriteLine("Your guess is too low.");
                }

                playerGuess = GetGuess(minNumber, maxNumber);
            }

            Console.WriteLine("You guessed my number!");
            if (incorrectGuesses > 0)
            {
                Console.WriteLine($"You guessed incorrectly {incorrectGuesses} times.");
            }
            else
            {
                Console.WriteLine("You guessed correct on the first try! Are you psychic!?");
            }
        }

        /// <summary>
        /// Prompts the user to enter a value between the specified lowest and highest value.
        /// </summary>
        /// <param name="lowest">The lowest possible guess.</param>
        /// <param name="highest">The highest possible guess.</param>
        /// <returns>The players guess.</returns>
        public static int GetGuess(int lowest, int highest)
        {
            Console.WriteLine($"Enter a guess between {lowest} and {highest}: ");
            int guess = int.Parse(Console.ReadLine());
            if (guess < lowest || guess > highest)
            {
                Console.WriteLine("Invalid guess!");
                return GetGuess(lowest, highest);
            }

            return guess;
        }
    }
}