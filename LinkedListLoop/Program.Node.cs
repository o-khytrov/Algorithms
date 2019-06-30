namespace LinkedListLoop
{
    public class Node
    {
        public int Data { get; set; }
        public Node Next { get; set; }

        public Node(int d)
        {
            Data = d;
            Next = null;
        }
    }
}
