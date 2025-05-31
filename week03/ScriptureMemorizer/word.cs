namespace ScriptureMemorizer
{
    public class Word
    {
        private string _text;
        private bool _isHidden;

        public Word(string text)
        {
            _text = text;
            _isHidden = false;
        }

        public void Hide()
        {
            _isHidden = true;
        }

        public void Show()
        {
            _isHidden = false;
        }

        public bool IsHidden()
        {
            return _isHidden;
        }

        public string GetDisplayText()
        {
            if (_isHidden)
            {
                string underscores = "";
                for (int i = 0; i < _text.Length; i++)
                {
                    if (char.IsLetter(_text[i]))
                    {
                        underscores += "_";
                    }
                    else
                    {
                        underscores += _text[i];
                    }
                }
                return underscores;
            }
            else
            {
                return _text;
            }
        }
    }
}