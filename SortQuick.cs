using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EXAM3
{
    public class SortQuick
    {
        static void Swap(ref int x, ref int y)
        {
            var t = x;
            x = y;
            y = t;
        }

        //метод возвращающий индекс опорного элемента   
        static int Partition(int[] array, int minIndex, int maxIndex)
        {
            var pivot = minIndex - 1;
            for (var i = minIndex; i < maxIndex; i++)
            {
                if (array[i] < array[maxIndex])
                {
                    pivot++;
                    Console.Write("p {0}\n", pivot);
                    Console.Write("swap {0} {1}\n", array[pivot], array[i]);
                    Swap(ref array[pivot], ref array[i]);
                }
            }

            pivot++;
            Console.Write("p {0}\n", pivot);
            Console.Write("swapF {0} {1}\n", array[pivot], array[maxIndex]);
            Swap(ref array[pivot], ref array[maxIndex]);
            return pivot;
        }

        //быстрая сортировка
        static int[] QuickSort(int[] array, int minIndex, int maxIndex)
        {
            if (minIndex >= maxIndex)
            {
                return array;
            }

            var pivotIndex = Partition(array, minIndex, maxIndex);
            QuickSort(array, minIndex, pivotIndex - 1);
            QuickSort(array, pivotIndex + 1, maxIndex);

            return array;
        }

        static int[] QuickSort(int[] array)
        {
            return QuickSort(array, 0, array.Length - 1);
        }

        public SortQuick()
        {
            Sort2();

            Random random = new Random();
            //Console.Write("N = ");
            //var len = Convert.ToInt32(Console.ReadLine());
            //var a = new int[len];
            //for (var i = 0; i < a.Length; ++i)
            //{
                //a[i] = random.Next(0, 100);
                //Console.Write("a[{0}] = {1}\n", i, a[i]);
                //Convert.ToInt32(Console.ReadLine());
            //}

            //Console.WriteLine("Упорядоченный массив: {0}", string.Join(", ", QuickSort(a)));

            Console.ReadLine();
        }

        static public void swap(ref int a, ref int b)
        {
            var t = a;
            a = b;
            b = t;
        }

        static public int Part(int[] array, int imin, int imax)
        {
            int p = imin - 1;
            for (int i = imin; i < imax; i++)
            {
                if(array[i] < array[imax])
                {
                    p++;
                    swap(ref array[i], ref array[p]);
                }
            }
            p++;
            swap(ref array[imax], ref array[p]);
            return p;
        }

        static public int[] Qsort(int[] array, int imin, int imax)
        {
            if(imin >= imax)
            {
                return array;
            }

            int p = Part(array, imin, imax);

            Qsort(array, imin, p - 1);
            Qsort(array, p+1, imax);
            return array;
        }
        static public int[] Qsort(int[] array)
        {
            return Qsort(array, 0, array.Length - 1);
        }
        private static void Sort2()
        {
            Random random = new Random();
            int N = Convert.ToInt32(Console.ReadLine());
            int[] array = new int[N];

            for (int i = 0; i < N; i++)
            {
                array[i] = random.Next(0, 100);
                Console.WriteLine("{0} {1}", i, array[i]);
            }
            Console.WriteLine();
            array = Qsort(array);

            for (int i = 0; i < N; i++)
            {
                Console.Write("{0} ", array[i]);
            }

        }
    }
}