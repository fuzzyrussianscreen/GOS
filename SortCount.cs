using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EXAM3
{
    class SortCount
    {
        static int[] BasicCountingSort(int[] array, int k)
        {
            var count = new int[k + 1];
            for (var i = 0; i < array.Length; i++)
            {
                count[array[i]]++;
            }

            var index = 0;
            for (var i = 0; i < count.Length; i++)
            {
                for (var j = 0; j < count[i]; j++)
                {
                    array[index] = i;
                    index++;
                }
            }
            return array;
        }


        public SortCount()
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

            array = BasicCountingSort(array, 100);

            for (int i = 0; i < N; i++)
            {
                Console.Write("{0} ", array[i]);
            }
        }
    }
}
