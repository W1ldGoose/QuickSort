using System;
using System.Threading.Tasks;

namespace QuickSort
{
    public static partial class QuickSort
    {
        public static void ParallelQuickSort<T>(T[] array) where T : IComparable<T>
        {
            ParallelQuickSort(array, 0, array.Length,
                (int) Math.Log(Environment.ProcessorCount, 2) + 4);
        }

        static void ParallelQuickSort<T>(T[] array, int from, int to, int depthRemaining) where T : IComparable<T>
        {
            if (to - from <= threshold)
            {
                InsertionSort(array, from, to);
            }
            else
            {
                
                int pivot = from + (to - from) / 2;
                pivot = Partition(array, from, to, pivot);
                if (depthRemaining > 0)
                {
                    Parallel.Invoke(
                        () => ParallelQuickSort(array, from, pivot, depthRemaining - 1),
                        () => ParallelQuickSort(array, pivot + 1, to, depthRemaining - 1));
                }
                else
                {
                    ParallelQuickSort(array, from, pivot, 0);
                    ParallelQuickSort(array, pivot + 1, to, 0);
                }
            }
        }
    }
}