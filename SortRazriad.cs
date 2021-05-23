using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EXAM3
{
    class SortRazriad
    {
        public SortRazriad()
        {
            int range = 2;
            
            Random random = new Random();
            int length = Convert.ToInt32(Console.ReadLine());
            int[] arr = new int[length];

            for (int i = 0; i < length; i++)
            {
                arr[i] = random.Next(0, 100);
                Console.WriteLine("{0} {1}", i, arr[i]);
            }

            List<List<int>> lists = new List<List<int>>(range);
            for (int i = 0; i < range; ++i)
                lists.Add(new List<int>());

            for (int step = 0; step < length; ++step)
            {
                for (int i = 0; i < arr.Length; ++i)
                {
                    int temp = (arr[i] % (int)Math.Pow(range, step + 1)) /(int)Math.Pow(range, step);
                    lists[temp].Add(arr[i]);
                }
                int k = 0;
                for (int i = 0; i < range; ++i)
                {
                    for (int j = 0; j < lists[i].Count; ++j)
                    {
                        arr[k++] = (int)lists[i][j];
                    }
                }
                for (int i = 0; i < range; ++i)
                    lists[i].Clear();
            }

            Console.WriteLine();
            
            for (int i = 0; i < length; i++)
            {
                Console.Write("{0} ", arr[i]);
            }
            Console.ReadLine();
        }
    }
}
