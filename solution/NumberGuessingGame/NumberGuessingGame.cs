namespace LearnYouACSharp
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// A number Guessing Game.
    /// </summary>
    public class NumberGuessingGame
    {
        /// <summary>
        /// Executes a Guessing Game in which a player must guess a randomly
        /// generated number between the specified values.
        /// </summary>
        /// <param name="minNumber">The minimum value that the game may generate.</param>
        /// <param name="maxNumber">The maximum value that the game may generate.</param>
        public static void Play(int minNumber, int maxNumber)
        {
            // Declare local variables
            Random randomGenerator;
            int incorrectGuesses; // Tracks the number of incorrect guesses the player has made.
            int randomNumber; // Keeps track of the number the player is trying to guess.
            int playerGuess; // The most recent guess that the player has made.

            // Initialize local variables
            randomGenerator = new Random();
            incorrectGuesses = 0;
            randomNumber = randomGenerator.Next(minNumber, maxNumber + 1);

            // Start Game
            Console.WriteLine("Guessing Game:");
            Console.WriteLine($"I'm thinking of a number between {minNumber} and {maxNumber}.");
            playerGuess = GetGuess(minNumber, maxNumber);

            // Loop until the player guesses the correct number.
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

            // Display the result of the game
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
            // Declare local variables
            int guess; // Stores the players guess

            // Get the users guess.
            Console.WriteLine($"Enter a guess between {lowest} and {highest}: ");
            guess = int.Parse(Console.ReadLine());

            // If the guess is out of bounds, make the player guess again.
            if (guess < lowest || guess > highest)
            {
                Console.WriteLine("Invalid guess!");
                return GetGuess(lowest, highest);
            }

            return guess;
        }
    }
}