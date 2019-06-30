using System;
using System.Diagnostics;
using System.Drawing;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Algorithms
{
    public partial class Form1 : Form
    {
        private static Stopwatch Stopwatch { get; set; }
        public int[] array { get; set; }
        public Random rnd { get; set; }
        public int MaxNumber { get; set; }
        public int ArraySize { get; set; }
        public IProgress<bool> Progress { get; set; }
        private Graphics g;
        private Bitmap DrawArea;

        public Form1()
        {
            InitializeComponent();
            Stopwatch = new Stopwatch();
            rnd = new Random();
            ArraySize = pictureBox.Size.Width;
            MaxNumber = pictureBox.Size.Height;
            DrawArea = new Bitmap(pictureBox.Size.Width, pictureBox.Size.Height);
            pictureBox.Image = DrawArea;
            array = new int[ArraySize];
            var progress = new Progress<bool>();
            progress.ProgressChanged += (_, progInfo) => VisualizeArray();

            Progress = progress;

            g = Graphics.FromImage(DrawArea);
        }

        private void VisualizeArray()
        {
            g.Clear(Color.White);
            Pen mypen = new Pen(Brushes.Black);
            var temp = array;
            for (int i = 0; i < temp.Length; i++)
            {
                g.DrawLine(mypen, new Point(i, temp[i]), new Point(i, MaxNumber));
            }

            pictureBox.Image = DrawArea;
        }

        private void btn_generate_Click(object sender, EventArgs e)
        {
            GenerateRandomArray();
            VisualizeArray();
        }

        private void GenerateRandomArray()
        {
            for (int i = 0; i < ArraySize; i++)
            {
                array[i] = rnd.Next(0, MaxNumber);
            }
        }

        private void btn_sort_Click(object sender, EventArgs e)
        {
            var menuItems = new MenuItem[]{
                    new MenuItem("BubbleSort", (o, args) => { Sort(BubbleSort); }),
                    new MenuItem("Quick Sort", (o, args) => { Sort(QuickSort); }),
                };

            var buttonMenu = new ContextMenu(menuItems);

            var point = ((Button)sender).Location;
            buttonMenu.Show((Button)sender, new System.Drawing.Point(0, 20));
        }

        private void StartTimer()
        {
            timer.Start();
            Stopwatch.Reset();
            Stopwatch.Start();
        }

        private void Sort(Action action)
        {
            StartTimer();
            Task.Run(() =>
            {
                action.Invoke();
            }).ContinueWith((x) =>
            {
                StopTimer();
                VisualizeArray();
                MessageBox.Show("Sorting completed");
            }, TaskScheduler.FromCurrentSynchronizationContext());
        }

        private void StopTimer()
        {
            timer.Stop();
            Stopwatch.Stop();
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            lblTimer.Text = Stopwatch.Elapsed.ToString(@"h\:mm\:ss\.fff");
        }

        private void BubbleSort()
        {
            long swaps = 0;
            bool swapped = false;
            do
            {
                swapped = false;
                for (int i = 0; i < array.Length - 1; i++)
                {
                    if (array[i] > array[i + 1])
                    {
                        int temp = array[i + 1];
                        array[i + 1] = array[i];
                        array[i] = temp;
                        swapped = true;
                        swaps++;
                        if (swaps % 100 == 0)
                        {
                            VisualizeArray();
                            Thread.Sleep(12);
                        }
                    }
                }
            } while (swapped == true);
        }

        private static int Partition(int[] numbers, int left, int right, int pivotIndex)
        {
            int pivotValue = numbers[pivotIndex];
            int temp = numbers[right];
            numbers[right] = numbers[pivotIndex];
            int newPivot = left;
            for (int i = left; i < right; i++)
            {
                if (numbers[i] <= pivotValue)
                {
                    temp = numbers[newPivot];
                    numbers[newPivot] = numbers[i];
                    numbers[i] = temp;
                    newPivot++;
                }
            }
            temp = numbers[right];
            numbers[right] = numbers[newPivot];
            numbers[newPivot] = temp;
            return newPivot;
        }

        private void QuickSortr(int[] numbers, int left, int right, int pass = 0)
        {
            pass++;
            VisualizeArray();
            Thread.Sleep(12);
            if (right > left)
            {
                int pivotindex = left + (right - left) / 2;
                pivotindex = Partition(numbers, left, right, pivotindex);
                QuickSortr(numbers, left, pivotindex - 1, pass);
                QuickSortr(numbers, pivotindex + 1, right, pass);
            }
        }

        private void QuickSort()
        {
            QuickSortr(array, 0, array.Length - 1);
        }
    }
}