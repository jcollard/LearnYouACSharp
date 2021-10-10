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
        private List<IBadLibComponent> components;

        public BadLibBuilder()
        {
            this.components = new List<IBadLibComponent>();
        }

        public void AddComponent(IBadLibComponent component)
        {
            this.components.Add(component);
        }

        public void Play()
        {
            string result = string.Empty;
            foreach (IBadLibComponent component in this.components)
            {
                result += component.GetString();
            }

            Console.Clear();
            Console.WriteLine(result);
        }

        public void Save(string path)
        {
            string result = string.Empty;
            foreach (IBadLibComponent component in this.components)
            {
                result += component.Save();
            }

            File.WriteAllText(path, result);
        }
    }

    public interface IBadLibComponent
    {
        public string GetString();

        public string Save();
    }

    public class BadLibPhrase : IBadLibComponent
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

    public class BadLibInput : IBadLibComponent
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

    public interface IBadLibLoader
    {

        public BadLibBuilder FromString(string toLoad);

    }

    public class BadLibLoaderForEach : IBadLibLoader
    {
        public BadLibBuilder FromString(string toLoad)
        {
            BadLibBuilder builder = new BadLibBuilder();
            string currentPhrase = string.Empty;

            foreach (char c in toLoad)
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
    }

    public class BadLibLoaderWhile : IBadLibLoader
    {

        public BadLibBuilder FromString(string toLoad)
        {
            BadLibBuilder builder = new BadLibBuilder();

            while (toLoad.Length > 0)
            {
                int startInput = toLoad.IndexOf("{");

                if (startInput == -1)
                {
                    // There are no user inputs, add the remaining string
                    builder.AddComponent(new BadLibPhrase(toLoad));
                    toLoad = string.Empty;
                }
                else if (startInput == 0)
                {
                    // The user input is the next think to process
                    int endInput = toLoad.IndexOf("}");
                    string prompt = toLoad.Substring(startInput + 1, endInput - 1);
                    builder.AddComponent(new BadLibInput(prompt));
                    toLoad = toLoad.Substring(endInput + 1);
                }
                else
                {
                    // Find the end of the phrase and add it to the builder
                    string phrase = toLoad.Substring(0, startInput);
                    builder.AddComponent(new BadLibPhrase(phrase));
                    toLoad = toLoad.Substring(startInput);
                }
            }

            return builder;
        }

    }

    public class BadLibLoaderTestable : IBadLibLoader
    {

        private string badLibText;

        public BadLibBuilder FromString(string toLoad)
        {
            BadLibBuilder builder = new BadLibBuilder();
            this.badLibText = toLoad;
            while (this.badLibText.Length > 0)
            {
                IBadLibComponent component = this.GetNextComponent();
                builder.AddComponent(component);
            }

            return builder;
        }

        public IBadLibComponent GetNextComponent()
        {
            if (this.IsPhraseNext(this.badLibText))
            {
                return this.NextPhrase();
            }
            else if (this.IsInputNext(this.badLibText))
            {
                return this.NextInput();
            }

            throw new InvalidOperationException($"Could not determine next BadLibComponent for string '{this.badLibText}'");
        }

        public BadLibPhrase NextPhrase()
        {
            int endOfPhrase = this.badLibText.IndexOf('{');
            string phrase;
            if (endOfPhrase == -1)
            {
                phrase = this.badLibText;
                this.badLibText = string.Empty;
                return new BadLibPhrase(phrase);
            }

            phrase = this.badLibText.Substring(0, endOfPhrase);
            this.badLibText = this.badLibText.Substring(endOfPhrase);
            return new BadLibPhrase(phrase);
        }

        public BadLibInput NextInput()
        {
            int endInput = this.badLibText.IndexOf("}");
            string prompt = this.badLibText.Substring(1, endInput - 1);
            this.badLibText = this.badLibText.Substring(endInput + 1);
            return new BadLibInput(prompt);
        }

        public bool IsPhraseNext(string badLibText)
        {
            return !this.badLibText.StartsWith('{');
        }

        public bool IsInputNext(string badLibText)
        {
            return this.badLibText.StartsWith('{');
        }
    }
}