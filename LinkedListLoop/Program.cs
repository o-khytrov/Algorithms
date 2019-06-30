using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LinkedListLoop
{
    static partial class Program
    {

        static void Main()
        {
            LinkedList llist = new LinkedList();
            llist.Push(15);
            llist.Push(4);
            llist.Push(6);
            llist.Push(8);
            llist.Push(25);
            llist.Push(77);
         //   llist.Head.Next.Next.Next = llist.Head;
            if (LinkedList.DetectLoop(llist.Head))
            {
                Console.WriteLine("Loop detected");
            }
            else
            {
                Console.WriteLine("No loop");
            }
            llist.PrintMiddle();

            Console.ReadKey();
        }
    }
}
