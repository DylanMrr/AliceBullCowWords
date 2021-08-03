using System;
using System.Collections.Generic;
using System.Text;

namespace Function
{
    public class Solution
    {
        private Config _config;

        public Solution()
        {
            _config = new Config().Read();
        }

        public (string, int) TakeRandom()
        {
            var r = new Random();
            int id = r.Next(0, _config.ConfigPairs.Count);
            return (_config.ConfigPairs[id], id);
        }

        public (bool isAnswer, int bulls, int cows) Get(string word, string guessedWord)
        {
            int bulls = 0;
            int cows = 0;

            if (word.Length != guessedWord.Length)
            {
                throw new Exception($"Количество букв в слове должно равняться {guessedWord.Length}!");
            }

            if (word == guessedWord)
            {
                return (true, bulls, cows);
            }

            for (int i = 0; i < guessedWord.Length; i++)
            {
                if (guessedWord.Contains(word[i]))
                {
                    if (guessedWord[i] == word[i])
                    {
                        bulls++;
                    }
                    else
                    {
                        cows++;
                    }
                }
            }

            return (false, bulls, cows);
        }
    }
}
