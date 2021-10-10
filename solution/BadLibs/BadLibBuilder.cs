namespace LearnYouACSharp
{
    using System;
    using System.Collections.Generic;
    using System.IO;

    /// <summary>
    /// A bad game about words.
    /// </summary>
    public class BadLibBuilder
    {
        /// <summary>
        /// Contains the Bad Lib output thus far.
        /// </summary>
        private List<BadLibComponent> components;

        public BadLibBuilder()
        {
            this.components = new List<BadLibComponent>();
        }

        public void AddComponent(BadLibComponent component)
        {
            this.components.Add(component);
        }

        public void Play()
        {
            string result = string.Empty;
            foreach (BadLibComponent component in this.components)
            {
                result += component.GetString();
            }

            Console.Clear();
            Console.WriteLine(result);
        }

        public void Save(string path)
        {
            string result = string.Empty;
            foreach (BadLibComponent component in this.components)
            {
                result += component.Save();
            }

            File.WriteAllText(path, result);
        }

        public static BadLibBuilder FromStringForEach(string badLib)
        {
            BadLibBuilder builder = new BadLibBuilder();
            string currentPhrase = string.Empty;

            foreach (char c in badLib)
            {
                if (c == '{')
                {
                    builder.AddComponent(new BadLibPhrase(currentPhrase));
                    currentPhrase = string.Empty;
                }
                else if (c == '}')
                {
                    builder.AddComponent(new BadLibInput(currentPhrase));
                    currentPhrase = string.Empty;
                }
                else
                {
                    currentPhrase += c;
                }
            }

            builder.AddComponent(new BadLibPhrase(currentPhrase));
            return builder;
        }

        public static BadLibBuilder FromStringWhile(string badLib)
        {
            BadLibBuilder builder = new BadLibBuilder();

            while (badLib.Length > 0)
            {
                int startInput = badLib.IndexOf("{");

                if (startInput == -1)
                {
                    // There are no user inputs, add the remaining string
                    builder.AddComponent(new BadLibPhrase(badLib));
                    badLib = string.Empty;
                }
                else if (startInput == 0)
                {
                    // The user input is the next think to process
                    int endInput = badLib.IndexOf("}");
                    string prompt = badLib.Substring(startInput + 1, endInput - 1);
                    builder.AddComponent(new BadLibInput(prompt));
                    badLib = badLib.Substring(endInput + 1);
                }
                else
                {
                    // Find the end of the phrase and add it to the builder
                    string phrase = badLib.Substring(0, startInput);
                    builder.AddComponent(new BadLibPhrase(phrase));
                    badLib = badLib.Substring(startInput);
                }
            }

            return builder;
        }
    }

    public interface BadLibComponent
    {
        public string GetString();

        public string Save();
    }

    public class BadLibPhrase : BadLibComponent
    {
        private string phrase;

        public BadLibPhrase(string phrase)
        {
            this.phrase = phrase;
        }

        public string GetString()
        {
            return this.phrase;
        }

        public string Save()
        {
            return this.phrase;
        }
    }

    public class BadLibInput : BadLibComponent
    {
        private string prompt;

        public BadLibInput(string prompt)
        {
            this.prompt = prompt;
        }

        public string GetString()
        {
            Console.Write($"{prompt}: ");
            Console.Out.Flush();
            return Console.ReadLine();
        }

        public string Save()
        {
            return "{" + this.prompt + "}";
        }
    }

}