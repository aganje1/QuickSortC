using Microsoft.CodeAnalysis.Formatting;
using Nest;
using System;
using System.Runtime.Serialization;

namespace SerialQuickSort
{
    class Program
    {
        public const int N = 1000000;

        /// <summary>
        /// Populates array with random numbers from 0 - 1000
        /// </summary>
        /// <param name="arr"></param>
        /// <returns></returns>
        public static int NumberGenerator(int[] arr)
        {
            Random rand = new Random();
            int i;

            for (i = 0; i < N - 1; i++)
            {
                arr[i] = rand.Next(0, 1001);
            }
            return arr[i];
        }

        /// <summary>
        ///  Swaps the index values. 
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        public static void Swap(int[] numbers, int left, int right)
        {
            var temp = numbers[left];
            numbers[left] = numbers[right];
            numbers[right] = temp;
        }

        /// <summary>
        /// Partitions and sorts arrays.
        /// </summary>
        /// <param name="arr"></param>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static int Partition(int[] arr, int left, int right)
        {
            int index = left;
            int pivot = arr[right];

            for (int i = left; i < right; i++)
            {               
                if (arr[i] <= pivot)
                {
                    Swap(arr, index, i);
                    index++;
                }
            }
            Swap(arr, index, right);
            return index;
        }

        /// <summary>
        /// Recursive method to check left and right pivot values and then sort with Partition call.
        /// </summary>
        /// <param name="arr"></param>
        /// <param name="left"></param>
        /// <param name="right"></param>
        public static void QuickSort(int[] arr, int left, int right)
        {

            if (left < right)
            {
                int partitionIndex = Partition(arr, left, right);
                QuickSort(arr, left, partitionIndex - 1);
                QuickSort(arr, partitionIndex + 1, right);
            }
        }

        public static void PrintArray(int[] arr)
        {
            foreach (var index in arr)
            {
                Console.WriteLine(index);
            }

        }

        static void Main(string[] args)
        {
            int[] arr = new int[N]; 
            NumberGenerator(arr);

            var watch = new System.Diagnostics.Stopwatch();
            watch.Start();

            QuickSort(arr, 0, N - 1);

            watch.Stop();

            Console.WriteLine($"QuickSort Execution Time: {watch.ElapsedMilliseconds} ms.");

            Console.WriteLine("Would you like to print sorted array? Type Y/N.");
            string printVar = Console.ReadLine();
            if (printVar == "Y" || printVar == "y")
            {
                PrintArray(arr);
            }

            Console.WriteLine("Would you like to know size of Array? Type Y/N.");
            string arraySize = Console.ReadLine();
            if (arraySize == "Y" || arraySize == "y")
            {
                int byteLength = Buffer.ByteLength(arr);

                // Display the array name, type, Length, and ByteLength.
                Console.WriteLine("Array Size  Bytes in Array");
                Console.WriteLine(arr.Length + " " + byteLength);
            }


        }
    }
}