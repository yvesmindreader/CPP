using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Collections.Generic;
using System.Linq;
namespace SortingCollection
{
    enum emAlgorithm
    {
        BubbleSorting = 1,
        QuickSorting,
        HeapSorting,
        SelectionSorting,
    }
    class Package
    {
        public string Company { get; set; }
        public double Weight { get; set; }
    }
    class Program
    {
        public static void ToArrayEx1()
        {
            List<Package> packages =
                new List<Package> 
                        { new Package { Company = "Coho Vineyard", Weight = 25.2 },
                          new Package { Company = "Lucerne Publishing", Weight = 18.7 },
                          new Package { Company = "Wingtip Toys", Weight = 6.0 },
                          new Package { Company = "Adventure Works", Weight = 33.8 } };

            string[] companies = packages.Select(pkg => pkg.Company).ToArray();

            foreach (string company in companies)
            {
                Console.WriteLine(company);
            }
        }
        static public void SerializeNow()
        {
            List<List<string>> ll = new List<List<string>>()
            {
                new List<string>(){"aaa", "bbb", "ccc"},
                new List<string>(){"ddd", "eee"},
                new List<string>(){"fff"},
            };
            FileStream fileStream = new FileStream("E:\\temp.dat", FileMode.Create);
            BinaryFormatter b = new BinaryFormatter();
            b.Serialize(fileStream, ll.Count);
            for (int i = 0; i < ll.Count; i++)
            {
                b.Serialize(fileStream, ll[i].Count);
                for (int j = 0; j < ll[i].Count; j++)
                {
                    b.Serialize(fileStream, ll[i][j]);
                }                
            }
            fileStream.Close();
        }
        static public void DeSerializeNow()
        {
            List<List<string>> ll = new List<List<string>>();
            int innercount, outercount;
            FileStream fileStream = new FileStream("E:\\temp.dat", FileMode.Open, FileAccess.Read, FileShare.Read);
            BinaryFormatter b = new BinaryFormatter();

            outercount = (int)b.Deserialize(fileStream);
            for (int i = 0; i < outercount; i++)
            {
                ll.Add(new List<string>());
                innercount = (int)b.Deserialize(fileStream);
                for (int j = 0; j < innercount; j++)
                {
                    ll[i].Add(b.Deserialize(fileStream) as string);                    
                }
            }
            fileStream.Close();
        }
        static void swap(ref int a, ref int b)
        {
            a ^= b;
            b ^= a;
            a ^= b;
        }
        static void PrintResult(int[] array)
        {
            foreach (var item in array)
            {
                Console.Write(item);
            }
            Console.ReadLine();
        }
        static void BubbleSort(int[] array, int size)
        {
            for (int i = 0; i < size; i++)
            {
                for (int j = i + 1; j < size; j++)
                {
                    if (array[i] > array[j])
                    {
                        swap(ref array[i], ref array[j]);
                    }
                }
            }
            PrintResult(array);
        }
        static void SelectionSort(int[] array, int size)
        {
            int min = 0;
            //第一次排序，找出最小的数
            for (int j = 0; j < size - 1; j++)
            {
                min = j;
                for (int i = j + 1; i < size; i++)
                {
                    if (array[i] < array[min])
                    {
                        min = i;
                    }
                }
                if (j != min)
                {
                    swap(ref array[j], ref array[min]);
                }
            }
            PrintResult(array);
        }
        static void HeapSort(int[] array, int size) 
        {
            int heapsize = size; 
            //建堆
            for (int i = size>>1; i >= 0; i--)
            {
                Max_heap(array, heapsize, i);
            }
            //排序，调整
            for (int i = heapsize-1; i >0; i--)
            {
                swap(ref array[i], ref array[0]);
                heapsize--;
                Max_heap(array, heapsize, 0);
            }
            PrintResult(array);
        }
        static void Max_heap(int[] array,int size, int i)
        {
            int max = i;
            int l = (i<<1) + 1;
            int r = l +1;
            if (i <= (array.Length >>1))
            {
                if (l < size && array[l] > array[i])
                {
                    max = l;
                }
                if (r < size && array[r] > array[max])
                {
                    max = r;
                }
                if (max != i)
                {
                    swap(ref array[i], ref array[max]);
                    Max_heap(array, size, max);
                }
            }
        }
        static void QuickSort(int[] array, int low, int high) 
        { 
            if (low < high)
            {
                int k = SortPartation(array, low, high);
                QuickSort(array, low, k -1);
                QuickSort(array, k + 1, high);
            }           
        }
        static int SortPartation(int[] array, int low, int high) 
        {
            int x = low;
            while (low < high)
            {
                while(low < high && array[high]>= array[x]) high--;
                array[low] = array[high];
                while(low < high && array[low] <= array[x]) low++;
                array[high] = array[low];                
            }
            array[low] = array[x];
            PrintResult(array);
            return low;
        }
        static void Main(string[] args)
        {
            int[] sortingArray = { 5, 3, 4, 1, 7, 2, 9, 0, 6, 8 };

            Console.WriteLine("Enter the sample no: \r\n\t#1 Bubble Sorting;\r\n\t#2 Quick Sorting; \r\n\t#3 Heap Sorting\r\n");
            PrintResult(sortingArray);
            emAlgorithm algNo = (emAlgorithm)(Console.Read() - '0');

            switch (algNo)
            {
                case emAlgorithm.BubbleSorting:
                    BubbleSort(sortingArray, sortingArray.Length);
                    break;
                case emAlgorithm.QuickSorting:
                    QuickSort(sortingArray, 0, sortingArray.Length - 1);
                    break;
                case emAlgorithm.HeapSorting:
                    HeapSort(sortingArray, sortingArray.Length);
                    break;
                case emAlgorithm.SelectionSorting:
                    SelectionSort(sortingArray, sortingArray.Length);
                    break;
                default:
                    break;
            }
            Console.ReadLine();
        }
    }


            

}
