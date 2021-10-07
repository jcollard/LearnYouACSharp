namespace LearnYouACSharp
{
    using System;

    /// <summary>
    /// Defines the game Rock Paper Scissors.
    /// </summary>
    public class RockPaperScissors
    {
        /// <summary>
        /// Plays Rock, Paper, Scissors the specified number of rounds.
        /// </summary>
        /// <param name="rounds">The number of rounds to play.</param>
        public static void Play(int rounds)
        {
            // Declare local variables
            int roundsPlayed; // Tracks the number of rounds that have been played
            string playersChoice; // Tracks the choice the player made
            string computersChoice; // Tracks the choice the computer made
            int playerWins; // Tracks the number of rounds the player has won
            int computerWins; // Tracks the number of rounds the computer has won

            // Initialize variables
            roundsPlayed = 0;
            playerWins = 0;
            computerWins = 0;

            while (roundsPlayed < rounds)
            {
                Console.WriteLine();
                Console.WriteLine("=-=-=-=-=-=-=-=-=-=");
                Console.WriteLine($"Round {roundsPlayed + 1}:");
                Console.WriteLine("=-=-=-=-=-=-=-=-=-=");
                playersChoice = GetPlayersChoice();
                computersChoice = GetComputersChoice();

                Console.WriteLine($"The computer chose {computersChoice}");

                if (CheckWin(playersChoice, computersChoice))
                {
                    Console.WriteLine($"{playersChoice} beats {computersChoice}!");
                    Console.WriteLine("You won the round.");
                    playerWins++;
                }
                else if (CheckWin(computersChoice, playersChoice))
                {
                    Console.WriteLine($"{computersChoice} beats {playersChoice}!");
                    Console.WriteLine("You lost the round.");
                    computerWins++;
                }
                else
                {
                    Console.WriteLine("It's a tie!");
                }

                roundsPlayed++;
            }

            PrintResults(playerWins, computerWins, roundsPlayed - playerWins - computerWins);
        }

        /// <summary>
        /// Given the number of times each player won and the number of ties, prints the results of the game.
        /// </summary>
        /// <param name="playerWins">The number of times the player won.</param>
        /// <param name="computerWins">The number of times the computer won.</param>
        /// <param name="ties">The number of times the game was a tie.</param>
        public static void PrintResults(int playerWins, int computerWins, int ties)
        {
            Console.WriteLine("Results:");
            Console.WriteLine($"You won {playerWins} times.");
            Console.WriteLine($"The computer won {computerWins} times.");
            Console.WriteLine($"There were {ties} ties.");

            if (computerWins > playerWins)
            {
                Console.WriteLine("The computer wins!");
            }
            else if (playerWins > computerWins)
            {
                Console.WriteLine("You win!");
            }
            else
            {
                Console.WriteLine("It's a tie!");
            }
        }

        /// <summary>
        /// Prompts the player to choose Rock, Paper, or Scissors.
        /// </summary>
        /// <returns>The value chosen by the player.</returns>
        public static string GetPlayersChoice()
        {
            string userChoice;
            Console.WriteLine("Choose Rock, Paper, or Scissors: ");
            userChoice = Console.ReadLine().Trim().ToUpper();
            if (!userChoice.Equals("ROCK") && !userChoice.Equals("PAPER") && !userChoice.Equals("SCISSORS"))
            {
                Console.WriteLine("Invalid input!");
                return GetPlayersChoice();
            }

            return userChoice;
        }

        /// <summary>
        /// Randomly generates a choice for the computer.
        /// </summary>
        /// <returns>One of: ROCK, PAPER, or SCISSORS.</returns>
        public static string GetComputersChoice()
        {
            Random randomGenerator;
            randomGenerator = new Random();
            int choice = randomGenerator.Next(3);
            if (choice == 0)
            {
                return "ROCK";
            }
            else if (choice == 1)
            {
                return "PAPER";
            }
            else if (choice == 2)
            {
                return "SCISSORS";
            }
            else
            {
                Console.Error.WriteLine("An error occurred!");
                return "UH-OH";
            }
        }

        /// <summary>
        /// Given two players choices, determine if the first player wins the round.
        /// </summary>
        /// <param name="player1Choice">The first players choice.</param>
        /// <param name="player2Choice">The second players choice.</param>
        /// <returns>true if the first player wins and false otherwise.</returns>
        public static bool CheckWin(string player1Choice, string player2Choice)
        {
            if (player1Choice.Equals("ROCK") && player2Choice.Equals("SCISSORS"))
            {
                return true;
            }
            else if (player1Choice.Equals("PAPER") && player2Choice.Equals("ROCK"))
            {
                return true;
            }
            else if (player1Choice.Equals("SCISSORS") && player2Choice.Equals("PAPER"))
            {
                return true;
            }

            return false;
        }
    }
}