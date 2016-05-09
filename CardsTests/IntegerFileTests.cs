using System;
using System.Collections.Generic;
using Cards;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CardsTests
{
    [TestClass]
    public class IntegerFileTests
    {
        //WARNING: These tests won't actually pass unless the file paths are fixed. Hard to know where this is running on another machine
        // Files are here: \Cards\CardsTests\test_fixtures
        // In production I'd probably mock out the file reading for unit tests, but that's more work than the rest of the code written here

        [TestMethod]
        public void PrimeFactorization_WithFileOfInts_PrintsPrimeFactorsOut()
        {
            List<List<int>> expected = SetupExpectedFactorization();
            List<List<int>> actual = IntegerFile.PrintPrimeFactorization(@"C:\ints.txt");

            for (var i = 0; i < expected.Count; i++)
            {
                Assert.AreEqual(string.Join(",", expected[i]), string.Join(",", actual[i]));
            }
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException),
        "File not formatted correctly, ensure each line contains a single integer.")]
        public void PrimeFactorization_WithFileOfGarbage_ThrowsError()
        {
            IntegerFile.PrintPrimeFactorization(@"C:\badints.txt");

            Assert.AreEqual("1", Console.Out.ToString());
        }
        
        [TestMethod]
        [ExpectedException(typeof(ArgumentException),
        "File path invalid.")]
        public void PrimeFactorization_WithBadPath_ThrowsError()
        {
            IntegerFile.PrintPrimeFactorization(@"Cjfjasd;;;;;;??!?!");

            Assert.AreEqual("Invalid path.", Console.Out.ToString());
        }

        private List<List<int>> SetupExpectedFactorization()
        {
            List<List<int>> expected = new List<List<int>>();
            expected.Add(new List<int> { 1 });
            expected.Add(new List<int> { 2 });
            expected.Add(new List<int> { 3 });
            expected.Add(new List<int> { 2, 2 });
            expected.Add(new List<int> { 5 });
            expected.Add(new List<int> { 2, 3 });
            expected.Add(new List<int> { 7 });
            expected.Add(new List<int> { 2, 2, 2 });
            expected.Add(new List<int> { 3, 3 });
            expected.Add(new List<int> { 0 });
            expected.Add(new List<int> { 2, 5 });
            expected.Add(new List<int> { 11 });
            expected.Add(new List<int> { 13 });
            expected.Add(new List<int> { 2, 2, 2, 3, 5, 5 });
            expected.Add(new List<int> { 2, 2, 2, 2, 3, 3, 3 });
            expected.Add(new List<int> { 3, 11 });
            expected.Add(new List<int> { 2, 3947 });
            expected.Add(new List<int> { 2 });
            expected.Add(new List<int> { 2, 2 });
            expected.Add(new List<int> { 7 });
            expected.Add(new List<int> { 2, 2, 3, 23, 29 });
            expected.Add(new List<int> { 3, 3, 97 });

            return expected;
        }
    }
}
