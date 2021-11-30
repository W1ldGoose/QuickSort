using System;

namespace QuickSort
{
    class Program
    {
        public static void FillArray(int[] unsortedArray)
        {
            Random rand = new Random();
            for (int i = 0; i < unsortedArray.Length; i++)
            {
                unsortedArray[i] = rand.Next(0, 100000);
            }
        }

        public static int[] testArr = new int[100];

        static void Main(string[] args)
        {
            FillArray(testArr);
            QuickSort.SerialQuickSort(testArr);
            foreach (var i in testArr)
            {
                Console.Write(i+" ");
            }
        }
    }
}