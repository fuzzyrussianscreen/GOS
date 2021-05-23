using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EXAM3
{
    class SortGnome
    {
        static void Swap(ref int item1, ref int item2)
        {
            var temp = item1;
            item1 = item2;
            item2 = temp;
        }

        //Гномья сортировка
        static int[] GnomeSort(int[] unsortedArray)
        {
            var index = 1;
            var nextIndex = index + 1;

            while (index < unsortedArray.Length)
            {
                if (unsortedArray[index - 1] < unsortedArray[index])
                {
                    index = nextIndex;
                    nextIndex++;
                }
                else
                {
                    Swap(ref unsortedArray[index - 1], ref unsortedArray[index]);
                    index--;
                    if (index == 0)
                    {
                        index = nextIndex;
                        nextIndex++;
                    }
                }
            }

            return unsortedArray;
        }

        public SortGnome()
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

            array = GnomeSort(array);

            for (int i = 0; i < N; i++)
            {
                Console.Write("{0} ", array[i]);
            }
        }
    }
}
