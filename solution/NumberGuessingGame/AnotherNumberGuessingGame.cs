namespace LearnYouACSharp
{
    using System;

    /// <summary>
    /// A number Guessing Game.
    /// </summary>
    public class AnotherNumberGuessingGame
    {
        private readonly Random randomGenerator;
        private readonly int minNumber;
        private readonly int maxNumber;

        /// <summary>
        /// Initializes a new instance of the <see cref="AnotherNumberGuessingGame"/> class
        /// specifying the range of values that can be guessed.
        /// </summary>
        /// <param name="minNumber">The minimum value that could be generated.</param>
        /// <param name="maxNumber">The maximum value that could be generated.</param>
        public AnotherNumberGuessingGame(int minNumber, int maxNumber)
        {
            this.randomGenerator = new Random();
            this.minNumber = minNumber;
            this.maxNumber = maxNumber;
        }

        /// <summary>
        /// Plays this guessing game.
        /// </summary>
        public void Play()
        {
            int incorrectGuesses;
            int playerGuess;
            int randomNumber;

            randomNumber = this.randomGenerator.Next(this.minNumber, this.maxNumber);
            incorrectGuesses = 0;

            Console.WriteLine("Guessing Game: ");
            Console.WriteLine($"I'm thinking of a number between {this.minNumber} and {this.maxNumber}.");
            playerGuess = this.GetGuess();

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

                playerGuess = this.GetGuess();
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
        /// Asks the user to make a guess and validates the guess.
        /// </summary>
        /// <returns>The players guess.</returns>
        private int GetGuess()
        {
            // Declare local variables
            int guess; // Stores the players guess

            // Get the users guess.
            Console.WriteLine($"Enter a guess between {this.minNumber} and {this.maxNumber}: ");
            guess = int.Parse(Console.ReadLine());

            // If the guess is out of bounds, make the player guess again.
            if (guess < this.minNumber || guess > this.maxNumber)
            {
                Console.WriteLine("Invalid guess!");
                return this.GetGuess();
            }

            return guess;
        }
    }
}