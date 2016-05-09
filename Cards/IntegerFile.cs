using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cards
{
    public static class IntegerFile
    {
        public static List<List<int>> PrintPrimeFactorization(string filePath)
        {
            var output = new List<List<int>>();

            try
            {
                string[] lines = System.IO.File.ReadAllLines(filePath);
                int[] integers = Array.ConvertAll(lines, int.Parse);


                foreach (int num in integers)
                {
                    List<int> factors = PrimeDecomposition(num);
                    output.Add(factors);

                    Console.WriteLine(string.Join(",", factors));
                }
            }
            catch (System.ArgumentException ex)
            {
                throw new System.ArgumentException("File path invalid.", ex);
            }
            catch (System.FormatException ex)
            {
                throw new System.ArgumentException("File not formatted correctly, ensure each line contains a single integer.", ex);
            }

            return output;
        }

        private static List<int> PrimeDecomposition(int number)
        {
            var factors = new List<int>();

            for (int i = 2; i <= number; i++)
            {
                while (number % i == 0) 
                {
                    factors.Add(i);
                    number /= i;
                }
            }

            if (factors.Count == 0)
            {
                factors.Add(number);
            }

            return factors;
        }
    }
}
