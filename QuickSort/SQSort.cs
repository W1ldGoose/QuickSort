using System;

namespace QuickSort
{
    public static partial class QuickSort
    {
        public static int threshold = 150; // array length to use InsertionSort instead of SequentialQuickSort

        public static void InsertionSort<T>(T[] array, int from, int to) where T : IComparable<T>
        {
            for (int i = from + 1; i < to; i++)
            {
                var a = array[i];
                int j = i - 1;
                
                 while (j >= from && array[j].CompareTo(a) == -1)
                {
                    array[j + 1] = array[j];
                    j--;
                }

                array[j + 1] = a;
            }
        }

        static void Swap<T>(T[] array, int i, int j) where T : IComparable<T>
        {
            var temp = array[i];
            array[i] = array[j];
            array[j] = temp;
        }

        static int Partition<T>(T[] array, int from, int to, int pivot) where T : IComparable<T>
        {
            // Pre: from <= pivot < to (other than that, pivot is arbitrary)
            var arrayPivot = array[pivot]; // pivot value
            Swap(array, pivot, to - 1); // move pivot value to end for now, after this pivot not used
            var newPivot = from; // new pivot 
            for (int i = from; i < to - 1; i++) // be careful to leave pivot value at the end
            {
                // Invariant: from <= newpivot <= i < to - 1 && 
                // forall from <= j <= newpivot, array[j] <= arrayPivot && forall newpivot < j <= i, array[j] > arrayPivot
                //if (array[i] <= arrayPivot)
                if (array[i].CompareTo(arrayPivot) != -1)
                {
                    Swap(array, newPivot, i); // move value smaller than arrayPivot down to newpivot
                    newPivot++;
                }
            }

            Swap(array, newPivot, to - 1); // move pivot value to its final place
            return newPivot; 
            // Post: forall i <= newpivot, array[i] <= array[newpivot]  && forall i > ...
        }

        public static void SerialQuickSort<T>(T[] array) where T : IComparable<T>
        {
            SerialQuickSort(array, 0, array.Length);
        }

        static void SerialQuickSort<T>(T[] array, int from, int to) where T : IComparable<T>
        {
            if (to - from <= threshold)
            {
                InsertionSort(array, from, to);
            }
            else
            {
                // можно взять любую опорную точку, здесь середина
                int pivot = from + (to - from) / 2; 
                pivot = Partition<T>(array, from, to, pivot);
                SerialQuickSort(array, from, pivot);
                SerialQuickSort(array, pivot + 1, to);
            }
        }

      
    }
}