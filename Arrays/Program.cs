using System;
using System.Collections.Generic;
using System.Linq;

namespace Arrays
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            var ar1 = new int[] { 1, 3, 5, 7, 9, 12, 15 };
            var ar2 = new int[] { 2, 4, 6, 8, 10, 14, 16, 18 };
            var arr3 = ar1.Merge(ar2);
            arr3.Print();
            Console.ReadKey();
        }
    }

    public static class ArrayExtensions
    {
        public static int FirstNonRepeatingInteger(this int[] input)
        {
            var h = new HashSet<int>();
            var h2 = new HashSet<int>();

            for (int i = 0; i < input.Length; i++)
            {
                if (!h.Contains(input[i]))
                {
                    h2.Add(input[i]);
                }
                else
                {
                    h2.Remove(input[i]);
                }
                h.Add(input[i]);
            }

            return h2.FirstOrDefault();
        }

        public static int FindNminimum(this int[] input, int n)
        {
            var retVal = input.OrderBy(x => x).Skip(n - 1).First();

            return retVal;
        }

        public static void Print(this int[] input)
        {
            Console.WriteLine(string.Join(" ", input));
        }

        public static int[] Merge(this int[] input, int[] arrayToMegre)

        {
            var retval = new int[input.Length + arrayToMegre.Length];
            int s = 0;
            for (int i = 0; i < retval.Length; i++)
            {
                if (i <= input.Length - 1 && i <= arrayToMegre.Length - 1)
                {
                    var min = Math.Min(input[i], arrayToMegre[i]);
                    var max = Math.Max(input[i], arrayToMegre[i]);
                    retval[s] = min;
                    s++;
                    retval[s] = max;
                }
                else
                {
                    if (arrayToMegre.Length > i)
                    {
                        retval[s] = arrayToMegre[i];
                    }

                    if (input.Length > i)
                    {
                        retval[s] = input[i];
                    }
                }
                s++;
            }
            return retval;
        }
    }
}