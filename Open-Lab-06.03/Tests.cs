using System;
using System.Collections;
using System.Linq;
using NUnit.Framework;

namespace Open_Lab_06._03
{
    [TestFixture]
    public class Tests
    {

        private StringTools _tools;

        private const int RandSeed = 603603603;
        private const int RandTestCasesCount = 97;

        private const int RandStrMinSize = 10;
        private const int RandStrMaxSize = 100;

        [OneTimeSetUp]
        public void Init() => _tools = new StringTools();

        [TestCase("hello world", "68 65 6c 6c 6f 20 77 6f 72 6c 64")]
        [TestCase("Big Boi", "42 69 67 20 42 6f 69")]
        [TestCase("Marty Poppinson", "4d 61 72 74 79 20 50 6f 70 70 69 6e 73 6f 6e")]
        [TestCaseSource(nameof(GetRandom))]
        public void ConvertToHexTest(string input, string expected) =>
            Assert.That(_tools.ConvertToHex(input), Is.EqualTo(expected));

        private static IEnumerable GetRandom()
        {
            var rand = new Random(RandSeed);

            for (var t = 0; t < RandTestCasesCount; t++)
            {
                var arr = new char[rand.Next(RandStrMinSize, RandStrMaxSize + 1)];

                for (var i = 0; i < arr.Length; i++)
                    arr[i] = (char) rand.Next('0', 'z' + 1);

                yield return new TestCaseData(
                    new string(arr),
                    arr.Select(c => ((int) c).ToString("X").ToLower()).Aggregate((c1, c2) => $"{c1} {c2}")
                );
            }
        }

    }
}
