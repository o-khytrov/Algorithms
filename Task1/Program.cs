using System;

namespace Task1
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>

        private static void Main()
        {
            var a = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            a.Print();
            var startIndex = 3;
            var count = 4;
            Console.WriteLine($"removing {count} items starting from at indxex {startIndex} ");
            var a2 = a.RemoveSequence(startIndex, count);
            a2.Print();
            Console.ReadKey();
        }
    }

    public static class Extensions
    {
        public static int[] RemoveSequence(this int[] input, int startingIndex, int count)
        {
            var retVal = new int[input.Length - count];
            int j = 0;
            for (int i = 0; i < input.Length; i++)
            {
                if (i < startingIndex || i >= startingIndex + count)
                {
                    retVal[j] = input[i];
                    j++;
                }
            }

            return retVal;
        }

        public static void Print(this int[] input)
        {
            Console.WriteLine(string.Join(" ", input));
        }
    }
}