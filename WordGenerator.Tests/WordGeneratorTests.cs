using NUnit.Framework;
using System;
using System.Linq;

namespace WordGenerator.Tests
{
    public class Tests
    {
        [TestCase(1)]
        [TestCase(2)]
        [TestCase(3)]
        [TestCase(4)]
        [TestCase(5)]
        public void WordGeneratorWithAlphabet_WordsCountIsValid(int maxLength)
        {
            string letters = "abcdefdhigklmnopqrstuvwxyz";
            long expectedCount = (long)Math.Pow(letters.Length, maxLength);
            var words = new Business.WordGenerator(letters, maxLength).Generate();
            var wordsArray = words.ToArray();
            Assert.AreEqual(wordsArray.Length, expectedCount);
        }

        [TestCase("abc", 3)]
        public void WordGeneratorWithLetters_WordsAreCorrect(string letters, int maxLength)
        {
            string[] expected = new string[]
            {
                "aaa", "aab", "aac",
                "aba", "abb", "abc",
                "aca", "acb", "acc",
                "baa", "bab", "bac",
                "bba", "bbb", "bbc",
                "bca", "bcb", "bcc",
                "caa", "cab", "cac",
                "cba", "cbb", "cbc",
                "cca", "ccb", "ccc"
            };
            var actual = new Business.WordGenerator(letters, maxLength).Generate();
            CollectionAssert.AreEquivalent(expected, actual);
        }
    }
}