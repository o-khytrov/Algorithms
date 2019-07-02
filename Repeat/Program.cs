using System;
using System.Collections.Generic;
using System.Linq;

namespace Repeat
{
    public class Node
    {
        public Node Right { get; set; }
        public Node Left { get; set; }
        public int Value { get; set; }

        public int Level { get; set; }

        public static Node BuildTree(int[] input, int min, int max, int level = 0)
        {
            if (min == max)
            {
                return null;
            }
            int median = min + (max - min) / 2;
            level++;
            return new Node
            {
                Level = level,
                Value = input[median],
                Left = BuildTree(input, min, median, level),
                Right = BuildTree(input, median + 1, max, level)
            };
        }
    }

    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        public static void BFS(Node root)
        {
            var queue = new Queue<Node>();
            queue.Enqueue(root);
            while (queue.Any())
            {
                var currentNode = queue.Dequeue();

                if (currentNode.Left != null)
                {
                    queue.Enqueue(currentNode.Left);
                }
                if (currentNode.Right != null)
                {
                    queue.Enqueue(currentNode.Right);
                }
                currentNode.Print();
            }
        }

        public static void DFS(Node root)
        {
            var stak = new Stack<Node>();
            stak.Push(root);
            while (stak.Any())
            {
                var currentNode = stak.Pop();
                if (currentNode.Right != null)
                {
                    stak.Push(currentNode.Right);
                }
                if (currentNode.Left != null)
                {
                    stak.Push(currentNode.Left);
                }
                
                currentNode.Print();
            }
        }
        public static void DFSNR(Node root)
        {
            if (root == null)
            {
                return;
            }
            root.Print();
            DFSNR(root.Left);
            DFSNR(root.Right);
        }
        private static void Main()
        {
            var input = new int[] { 8, 6, 2, 4, 11, 2, 27, 12 };

            var tree = Node.BuildTree(input.OrderBy(x => x).ToArray(), 0, input.Length);
            BFS(tree);
            Console.WriteLine();
            DFS(tree);
            Console.WriteLine();
            DFSNR(tree);
            Console.ReadKey();
        }
    }

    public static class Extensions
    {
        public static int[] BubbleSort(this int[] input)
        {
            var swapped = false;
            do
            {
                for (int i = 0; i < input.Length - 1; i++)
                {
                    swapped = false;
                    if (input[i] > input[i + 1])
                    {
                        var max = input[i];
                        var min = input[i + 1];
                        input[i] = min;
                        input[i + 1] = max;
                        swapped = true;
                        break;
                    }
                }
            } while (swapped);

            return input;
        }

        public static void Print(this int[] input)
        {
            System.Console.WriteLine(string.Join(" ", input));
        }

        public static void Print(this Node node)
        {
            Console.WriteLine($"Level: {node.Level}; Value: {node.Value}");
        }
    }
}