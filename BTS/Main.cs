using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BTS
{
    public partial class Main : Form
    {
        private Graphics g;
        public Node Tree { get; set; }
        private Bitmap DrawArea;
        private int MiddlePoint;
        public int NodeWidth { get { return 40; } }
        private void VisualizeTree(Node node)
        {
            var queue = new Queue<Node>();
            queue.Enqueue(node);
            while (queue.Any())
            {
                var currentNode = queue.Dequeue();
                DrawNode(currentNode);
                if (currentNode.Right != null)
                {
                    DrawLine(currentNode.Point, currentNode.Right.Point);
                    queue.Enqueue(currentNode.Right);
                }
                if (currentNode.Left != null)
                {
                    DrawLine(currentNode.Point, currentNode.Left.Point);
                    queue.Enqueue(currentNode.Left);
                }
            }
        }

        private void BreadthFirstTraversal(Node node)
        {
            var queue = new Queue<Node>();
            queue.Enqueue(node);
            while (queue.Any())
            {
                var currentNode = queue.Dequeue();
                if (currentNode.Right != null)
                {
                    queue.Enqueue(currentNode.Right);
                }
                if (currentNode.Left != null)
                {
                    queue.Enqueue(currentNode.Left);
                }
                Thread.Sleep(1000);
                Highlight(currentNode);
            }
        }

        private void DepthFirstTraversal(Node node)
        {
            if (node == null)
            {
                return;
            }
            Thread.Sleep(1000);
            Highlight(node);
            DepthFirstTraversal(node.Left);
            DepthFirstTraversal(node.Right);
        }

        private void DepthFirstTraversalNonRecursive(Node node)
        {
            if (node == null)
            {
                return;
            }

            var stack = new Stack<Node>();
            stack.Push(node);
            while (stack.Any())
            {
                var currentNode = stack.Pop();
                if (currentNode.Right != null)
                {
                    stack.Push(currentNode.Right);
                }
                if (currentNode.Left != null)
                {
                    stack.Push(currentNode.Left);
                }

                Thread.Sleep(1000);
                Highlight(currentNode);
            }
        }

        public Main()
        {
            InitializeComponent();
            SetTree();
        }

        private void SetTree()
        {
            DrawArea = new Bitmap(pictureBox.Size.Width, pictureBox.Size.Height);
            MiddlePoint = pictureBox.Width / 2;
            pictureBox.Image = DrawArea;
            g = Graphics.FromImage(DrawArea);
            // Node root = null;
            var arr = new int[] { 20, 17, 30, 21, 45, 2, 18 };
           
            var root = Node.constructBalancedTree(arr, new Point() { X = MiddlePoint, Y = 20 });
            VisualizeTree(root);
            Tree = root;
        }

        private void DrawLine(Point p1, Point p2)
        {
            Pen mypen = new Pen(Brushes.Black);
            g.DrawLine(mypen, p1, p2);
            pictureBox.Image = DrawArea;
        }

        private void DrawNode(Node node)
        {
            var p = node.Point;
            Pen mypen = new Pen(Brushes.Black);
            SolidBrush drawBrush = new SolidBrush(Color.White);
            Font drawFont = new Font("Arial", 10);
            g.DrawEllipse(mypen, p.X - 10, p.Y - 10, NodeWidth, NodeWidth);
            g.FillEllipse(Brushes.Black, p.X - 10, p.Y - 10, NodeWidth, NodeWidth);
            g.DrawString(node.Value.ToString(), drawFont, drawBrush, p.X, p.Y);

            pictureBox.Image = DrawArea;
        }

        private void Highlight(Node node)
        {
            var p = node.Point;
            Pen mypen = new Pen(Brushes.Red);

            SolidBrush drawBrush = new SolidBrush(Color.Black);
            Font drawFont = new Font("Arial", 10);
            g.DrawEllipse(mypen, p.X - 10, p.Y - 10, NodeWidth, NodeWidth);
            g.FillEllipse(Brushes.Red, p.X - 10, p.Y - 10, NodeWidth, NodeWidth);

            g.DrawString(node.Value.ToString(), drawFont, drawBrush, p.X, p.Y);

            pictureBox.Image = DrawArea;
        }

        private void button1_Click(object sender, System.EventArgs e)
        {
            var t = Task.Factory.StartNew(() => { BreadthFirstTraversal(Tree); });
        }

        private void btn_dft_Click(object sender, System.EventArgs e)
        {
            var t = Task.Factory.StartNew(() => { DepthFirstTraversal(Tree); });
        }

        private void btn_reset_Click(object sender, System.EventArgs e)
        {
            SetTree();
        }

        private void btn_dfs_nr_Click(object sender, System.EventArgs e)
        {
            var t = Task.Factory.StartNew(() => { DepthFirstTraversalNonRecursive(Tree); });
        }

        private void Main_ResizeEnd(object sender, EventArgs e)
        {
            SetTree();
        }

        private void Main_Resize(object sender, EventArgs e)
        {
            SetTree();
        }
    }
}