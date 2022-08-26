using System;
using System.Collections.Generic;

#pragma warning disable CA1304

namespace AnagramTask
{
    public class Anagram
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Anagram"/> class.
        /// </summary>
        /// <param name="sourceWord">Source word.</param>
        /// <exception cref="ArgumentNullException">Thrown when source word is null.</exception>
        /// <exception cref="ArgumentException">Thrown when  source word is empty.</exception>
        private readonly string anagram = null;

        public Anagram(string sourceWord)
        {
            if (sourceWord is null)
            {
                throw new ArgumentNullException(nameof(sourceWord));
            }

            if (sourceWord.Length == 0)
            {
                throw new ArgumentException($"{sourceWord}");
            }

            this.anagram = sourceWord;
        }

        public bool IsAnagram(string variable)
        {
            if (variable is null)
            {
                throw new ArgumentNullException(nameof(variable));
            }

            if (this.anagram.ToLower() == variable.ToLower() || this.anagram.Length != variable.Length)
            {
                return false;
            }

            var a = this.anagram.ToString().ToLower().ToCharArray();
            var b = variable.ToString().ToLower().ToCharArray();
            Array.Sort(a);
            Array.Sort(b);
            for (int i = 0; i < a.Length; i++)
            {
                if (a[i] != b[i])
                {
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// From the list of possible anagrams selects the correct subset.
        /// </summary>
        /// <param name="candidates">A list of possible anagrams.</param>
        /// <returns>The correct sublist of anagrams.</returns>
        /// <exception cref="ArgumentNullException">Thrown when candidates list is null.</exception>
        public string[] FindAnagrams(string[] candidates)
        {
            if (candidates is null)
            {
                throw new ArgumentNullException(nameof(candidates));
            }

            List<string> arr = new List<string>();
            for (int i = 0; i < candidates.Length; i++)
            {
                if (this.IsAnagram(candidates[i]))
                {
                    arr.Add(candidates[i]);
                }
            }

            return arr.ToArray();
        }
    }
}
