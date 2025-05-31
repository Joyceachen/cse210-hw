using System;
using System.Collections.Generic;
using System.Linq;

namespace ScriptureMemorizer
{
    public class Scripture
    {
        private Reference _reference;
        private List<Word> _words;

        public Scripture(Reference reference, string text)
        {
            _reference = reference;
            _words = new List<Word>();

            string[] wordArray = text.Split(' ');
            foreach (string word in wordArray)
            {
                _words.Add(new Word(word));
            }
        }

        public void HideRandomWords(int numberToHide)
        {
            Random random = new Random();
            List<Word> visibleWords = _words.Where(w => !w.IsHidden()).ToList();

            int wordsToHide = Math.Min(numberToHide, visibleWords.Count);

            for (int i = 0; i < wordsToHide; i++)
            {
                if (visibleWords.Count > 0)
                {
                    int randomIndex = random.Next(visibleWords.Count);
                    visibleWords[randomIndex].Hide();
                    visibleWords.RemoveAt(randomIndex);
                }
            }
        }

        public string GetDisplayText()
        {
            string result = _reference.GetDisplayText() + " ";

            foreach (Word word in _words)
            {
                result += word.GetDisplayText() + " ";
            }

            return result.Trim();
        }

        public bool IsCompletelyHidden()
        {
            foreach (Word word in _words)
            {
                if (!word.IsHidden())
                {
                    return false;
                }
            }
            return true;
        }
    }
}
