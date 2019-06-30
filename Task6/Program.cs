namespace Task6
{
    public class Node
    {
        public int Value { get; set; }
        public Node Left { get; set; }
        public Node Right { get; set; }

        public static Node Insert(Node node, int value)
        {
            if (node == null)
            {
                node = new Node();
                node.Value = value;
            }
            else
            {
                if (node.Value > value)
                {
                    node.Left = Insert(node.Left, value);
                }
                else
                {
                    node.Right = Insert(node.Right, value);
                }
            }
            return node;
        }
    }

    internal class Program
    {
        private static Node ToBinaryTree(int[] input)
        {
            Node root = null;

            for (int i = 0; i < input.Length; i++)
            {
                root = Node.Insert(root, input[i]);
            }
            return root;
        }

        private static void Main(string[] args)
        {
            var array = new int[] { 20, 17, 30, 21, 45, 2, 18 };
            var bt = ToBinaryTree(array);
        }
    }
}