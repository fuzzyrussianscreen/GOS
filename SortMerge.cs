using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EXAM3
{
    class SortMerge
    {
        //метод для слияния массивов
        static void Merge(int[] array, int lowIndex, int middleIndex, int highIndex)
        {
            //Console.WriteLine("{0} {1} {2}", lowIndex, middleIndex, highIndex);

            var left = lowIndex;
            var right = middleIndex + 1;
            var tempArray = new int[highIndex - lowIndex + 1];
            var index = 0;

            while ((left <= middleIndex) && (right <= highIndex))
            {
                if (array[left] < array[right])
                {
                    tempArray[index] = array[left];
                    left++;
                }
                else
                {
                    tempArray[index] = array[right];
                    right++;
                }

                index++;
            }

            //Console.WriteLine("{0} {1} {2} {3} {4}", index, left, middleIndex, right, highIndex);
            Console.WriteLine("массив до: {0}", string.Join(" ", tempArray));
            for (var i = left; i <= middleIndex; i++)
            {
                tempArray[index] = array[i];
                index++;
            }

            for (var i = right; i <= highIndex; i++)
            {
                tempArray[index] = array[i];
                index++;
            }
            Console.WriteLine("массив после: {0}", string.Join(" ", tempArray));
            for (var i = 0; i < tempArray.Length; i++)
            {
                array[lowIndex + i] = tempArray[i];
            }
        }

        //сортировка слиянием
        static int[] MergeSort(int[] array, int lowIndex, int highIndex)
        {
            if (lowIndex < highIndex)
            {
                var middleIndex = (lowIndex + highIndex) / 2;
                MergeSort(array, lowIndex, middleIndex);
                MergeSort(array, middleIndex + 1, highIndex);
                Merge(array, lowIndex, middleIndex, highIndex);
            }

            return array;
        }

        static int[] MergeSort(int[] array)
        {
            return MergeSort(array, 0, array.Length - 1);
        }

        public SortMerge()
        {
            Random random = new Random();
            Console.WriteLine("Сортировка слиянием");
            int N = Convert.ToInt32( Console.ReadLine());
            var array = new int[N];
            for (int i = 0; i < N; i++)
            {
                array[i] = random.Next(0,100);
                Console.Write("{0} ", array[i]);
            }
            Console.WriteLine();
            Console.WriteLine("Упорядоченный массив: {0}", string.Join(" ", MergeSort(array)));

            Console.ReadLine();
        }

        
    }
}
