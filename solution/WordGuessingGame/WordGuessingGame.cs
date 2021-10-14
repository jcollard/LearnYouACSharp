namespace LearnYouACSharp
{
    using System;
    using System.Collections.Generic;

    public class WordGuessingGame
    {
        private string wordToGuess;
        private List<char> lettersGuessed;
        private int incorrectGuesses;

        public WordGuessingGame(string wordToGuess)
        {
            this.wordToGuess = wordToGuess.ToUpper();
            this.lettersGuessed = new List<char>();
            this.incorrectGuesses = 0;
        }

        public void DisplayGame()
        {
            Console.Clear();
            Console.WriteLine($"Word: {this.GetWord()}");
            Console.WriteLine($"Incorrect Guesses: {this.incorrectGuesses}");
            Console.WriteLine($"Letters Guessed: {this.GetGuessedLetters()}");
        }

        public string GetGuessedLetters()
        {
            string letters = string.Empty;
            foreach (char c in this.lettersGuessed)
            {
                letters += $" {c}";
            }
            return letters;
        }

        public string GetWord()
        {
            string word = string.Empty;
            foreach (char c in wordToGuess)
            {
                if (this.lettersGuessed.Contains(c))
                {
                    word += $"{c} ";
                }
                else
                {
                    word += "_ ";
                }
            }
            return word;
        }

        public bool IsGameWon()
        {
            foreach (char c in this.wordToGuess)
            {
                if (lettersGuessed.Contains(c) == false)
                {
                    return false;
                }
            }
            return true;
        }

        public char GetGuess()
        {
            Console.Write("Guess a letter: ");
            string input = Console.ReadLine();
            if (input.Length != 1)
            {
                Console.WriteLine("You must guess a single letter.");
                return this.GetGuess();
            }

            char guess = input[0];
            if (!char.IsLetter(guess))
            {
                Console.WriteLine($"{guess} is not a letter. You must guess a single letter.");
                return this.GetGuess();
            }

            return guess;
        }

        public bool CheckGuess(char playersGuess)
        {
            playersGuess = char.ToUpper(playersGuess);
            if (char.IsLetter(playersGuess) == false)
            {
                Console.Error.WriteLine("You can only guess letters.");
                return false;
            }

            if (this.lettersGuessed.Contains(playersGuess))
            {
                Console.Error.WriteLine($"You've already guessed {playersGuess}.");
                return false;
            }

            if (!this.wordToGuess.Contains(playersGuess))
            {
                Console.WriteLine($"Ouch! No {playersGuess}s!");
                this.incorrectGuesses++;
            }
            else
            {
                int count = this.CountLetter(playersGuess);
                if (count == 1)
                {
                    Console.WriteLine($"There is {count} {playersGuess}!");
                }
                else
                {
                    Console.WriteLine($"There are {count} {playersGuess}s!");
                }
            }

            this.lettersGuessed.Add(playersGuess);
            return true;
        }

        public int CountLetter(char playersGuess)
        {
            if (!char.IsLetter(playersGuess))
            {
                Console.Error.WriteLine($"Invalid guess: {playersGuess}.");
                return 0;
            }

            int count = 0;
            foreach (char c in this.wordToGuess)
            {
                if (c == playersGuess)
                {
                    count++;
                }
            }
            return count;
        }

        public void Play()
        {
            while (this.IsGameWon() == false)
            {
                this.DisplayGame();
                char guess = this.GetGuess();
                this.CheckGuess(guess);
                Console.WriteLine("Press Enter to Continue...");
                Console.ReadLine();
            }

            this.DisplayGame();
            Console.WriteLine("Congratulations! You won!");
        }

    }
}