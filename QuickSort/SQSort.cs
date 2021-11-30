using System;

namespace QuickSort
{
    public static partial class QuickSort
    {
        // длина массива для использования InsertionSort вместо SequentialQuickSort
        public static int threshold = 150;

        // сортировка вставками 
        //  в котором элементы входной последовательности просматриваются по одному,
        // и каждый новый поступивший элемент размещается в подходящее место среди ранее упорядоченных элементов
        public static void InsertionSort<T>(T[] array, int from, int to) where T : IComparable<T>
        {
            for (int i = from + 1; i < to; i++)
            {
                var a = array[i];
                int j = i - 1;
                
                 while (j >= from && array[j].CompareTo(a) != -1)
                {
                    array[j + 1] = array[j];
                    j--;
                }

                array[j + 1] = a;
            }
        }
        // метод для обмена местами
        static void Swap<T>(T[] array, int i, int j) where T : IComparable<T>
        {
            var temp = array[i];
            array[i] = array[j];
            array[j] = temp;
        }

        // метод для поиска новой опороной точки и разделения элементов по отрезкам
        static int Partition<T>(T[] array, int from, int to, int pivot) where T : IComparable<T>
        {
            var arrayPivot = array[pivot]; 
            // перемещаем опорную точку в конец, после этого она не используется
            Swap(array, pivot, to - 1); 
            var newPivot = from; 
            for (int i = from; i < to - 1; i++) 
            {
                if (array[i].CompareTo(arrayPivot) == -1)
                {
                    Swap(array, newPivot, i);
                    newPivot++;
                }
            }

            Swap(array, newPivot, to - 1); 
            return newPivot;
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
                pivot = Partition(array, from, to, pivot);
                SerialQuickSort(array, from, pivot);
                SerialQuickSort(array, pivot + 1, to);
            }
        }

      
    }
}