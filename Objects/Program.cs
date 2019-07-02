using System;
using System.IO;
using System.Linq;

namespace Objects
{
    internal static class Program
    {
        private static void Main(string[] args)
        {
            Console.SetIn(new StreamReader(@"D:\Console.txt"));

            var T = Int32.Parse(Console.ReadLine());
            //Raghu cannot eat the dish more than 10cal
            for (int t = 0; t < T; t++)
            {
                var Arr = Console.ReadLine().Split(' ').Select(Int32.Parse).ToArray();
                var A = Arr[0]; // calories Raghu can eat per day
                var B = Arr[1]; // calories Sayan can eat per day
                var N = Arr[2];// number of dishes
                var dishes = Console.ReadLine().Split(' ').Select(Int32.Parse).OrderBy(x => x).ToArray();
                var rDishes = 0;
                var sDishes = 0;
                for (int i = 0; i < dishes.Length; i++)
                {
                    var dish = dishes[i];
                    if (A >= dish)
                    {
                        A -= dish;
                        rDishes++;
                    }
                    if (B >= dish)
                    {
                        B -= dish;
                        sDishes++;
                    }
                }
                if (rDishes > sDishes)
                {
                    Console.WriteLine("Raghu Won");
                }
                else if (rDishes < sDishes)
                {
                    Console.WriteLine("Sayan Won");
                }
                else
                {
                    Console.WriteLine("Tie");
                }
            }

            Console.ReadKey();
        }
    }
}