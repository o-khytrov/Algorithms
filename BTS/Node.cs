using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace BTS
{
    public class Node
    {
        public Node Left { get; set; }
        public Node Right { get; set; }
        public int Value { get; set; }
        public int Level { get; set; }
        public NodeType Type { get; set; }
        public Point Point { get; set; }

        public static Node Insert(Node root, int value, Point point, int level = 0, NodeType nodeType = NodeType.Root)
        {
            var offset = level * 25;
            level++;
            if (root == null)
            {
                root = new Node();
                root.Value = value;

                root.Level = level;
                root.Type = nodeType;
                root.Point = point;
            }
            else if (root.Value > value)
            {
                point = new Point { X = point.X - (100 - offset), Y = point.Y + 100 };
                root.Left = Node.Insert(root.Left, value, point, level, NodeType.Left);
            }
            else
            {
                point = new Point { X = (point.X + (100 - offset)), Y = point.Y + 100 };
                root.Right = Node.Insert(root.Right, value, point, level, NodeType.Right);
            }
            return root;
        }

        private static Node BuildTree(int[] values, int min, int max, Point point, int level = 0, NodeType nodeType = NodeType.Root)
        {
            if (min == max)
            {
                return null;
            }
            var offset = level * 25;
            level++;
            int median = min + (max - min) / 2;
            var leftPoint = new Point { X = point.X - (100 - offset), Y = point.Y + 100 };
            var rightPoint = new Point { X = (point.X + (100 - offset)), Y = point.Y + 100 };
            return new Node()
            {
                Point= point,
                Value = values[median],
                Left = BuildTree(values, min, median, leftPoint, level + 1, NodeType.Left),
                Right = BuildTree(values, median + 1, max, rightPoint, level + 1, NodeType.Right)
            };
        }

        public static Node constructBalancedTree(IEnumerable<int> values, Point startPoint)
        {
            return BuildTree(
                values.OrderBy(x => x).ToArray(), 0, values.Count(), startPoint);
        }

    }
}