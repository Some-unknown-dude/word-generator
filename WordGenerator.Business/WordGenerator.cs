namespace WordGenerator.Business
{
    public class WordGenerator
    {
        private readonly string _letters;
        private readonly int _maxLength;
        private readonly char[] _word;

        public WordGenerator(string letters, int maxLength)
        {
            _letters = letters; 
            _maxLength = maxLength;
            _word = new string(' ', _maxLength).ToCharArray(); //whitespace represents a zero letter, which is plays the same role as a zero before number
        }

        public IEnumerable<string> Generate()
        {
            return GetAllWords(0);
        }

        private IEnumerable<string> GetAllWords(int depth)
        {
            if (depth == _maxLength)
            {
                yield return new string(_word);
                yield break;
            }

            for (int i = 0; i < _letters.Length; ++i)
            {
                _word[depth] = _letters[i];
                foreach (var s in GetAllWords(depth + 1))
                {
                    yield return s;
                }
            }
        }
    }
}
