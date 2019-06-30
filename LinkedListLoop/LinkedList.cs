using System.Collections.Generic;

namespace LinkedListLoop
{
    public class LinkedList
    {
        public Node Head { get; set; }

        public void Push(int new_data)
        {
            var newNode = new Node(new_data);
            newNode.Next = Head;
            Head = newNode;
        }

        public void PrintMiddle()
        {
            Node slow = Head;
            Node fast = Head;

            if (Head != null)
            {
                while (fast != null && fast.Next != null)
                {
                    fast = fast.Next.Next;
                    slow = slow.Next;
                }
                System.Console.WriteLine($"The middle element is {slow.Data}");
            }
        }

        public static bool DetectLoop(Node h)
        {
            HashSet<Node> s = new HashSet<Node>();
            while (h != null)
            {
                if (s.Contains(h))
                {
                    return true;
                }
                s.Add(h);
                h = h.Next;
            }

            return false;
        }
    }
}
