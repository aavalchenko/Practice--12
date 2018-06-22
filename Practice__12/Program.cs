using System;
using System.Collections.Generic;

namespace Practice__12
{
    static class Program
    {
        private static Random Random = new Random();
        private static Double n = 100.0;
        static void Main(string[] args)
        {
            Console.WriteLine("Сортировка простыми вставками:");
            Console.WriteLine("Количество сравнений и количество перемещений равно: " + EasyEnterSort(Array(n).ToUp()).String());
            Console.WriteLine("Количество сравнений и количество перемещений равно: " + EasyEnterSort(Array(n).ToDown()).String());
            Console.WriteLine("Количество сравнений и количество перемещений равно: " + EasyEnterSort(Array(n).ToRandom()).String());
            Console.WriteLine("\nСортировка корзинами:");
            Console.WriteLine("Количество сравнений и количество перемещений равно: " + BucketSort(Array(n).ToUp()).String());
            Console.WriteLine("Количество сравнений и количество перемещений равно: " + BucketSort(Array(n).ToDown()).String());
            Console.WriteLine("Количество сравнений и количество перемещений равно: " + BucketSort(Array(n).ToRandom()).String());
            Console.ReadKey();
        }

        private static Double[] Array(Double n) => new Double[(Int32)n];
        private static Double[] ToUp(this Double[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = i / n;
            }

            return array;
        }
        private static Double[] ToDown(this Double[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = (array.Length - i - 1) / n;
            }

            return array;
        }
        private static Double[] ToRandom(this Double[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = Math.Round(Random.NextDouble(), 3);
            }

            return array;
        }

        private static void Swap(ref Double left, ref Double right, ref Int32[] count)
        {
            Double temp = left;
            left = right;
            right = temp;
            count[0]++;
        }
        private static Int32[] EasyEnterSort(Double[] array)
        {
            Int32[] count = new Int32[2] { 0, 0 };
            for (int i = 1; i < array.Length; i++)
            for (int j = i; j > 0; j--)
            {
                count[1]++;
                if (array[j - 1] > array[j])
                {
                    Swap(ref array[j - 1], ref array[j], ref count);
                }
            }

            Console.WriteLine("Отсортированный простыми вставками массив: " + array.String());
            return count;
        }
        private static Int32[] BucketSort(Double[] array)
        {
            List<Double>[] bucket = new List<Double>[array.Length];
            Int32 j = 0;
            Int32[] count = new Int32[2] {0, 0};
            for (int i = 0; i < array.Length; i++)
            {
                bucket[i] = new List<Double>(0);
            }
            for (int i = 0; i < array.Length; i++)
            {
                bucket[(Int32)Math.Truncate(array[i] * n)].Add(array[i]);
                count[1]++;
            }
            foreach (List<double> doubles in bucket)
            {
                doubles.Sort();
                foreach (double digit in doubles)
                {
                    count[1]++;
                    if (array[j] != digit)
                    {
                        array[j] = digit;
                        count[0]++;
                    }
                    j++;
                }
            }
            Console.WriteLine("Отсортированный блочной сортировкой массив: " + array.String());
            return count;
        }

        private static string String(this Double[] array)
        {
            string output = "";
            foreach (Double digit in array)
            {
                output += digit + " ";
            }
            return output;
        }
        private static string String(this Int32[] array)
        {
            string output = "";
            foreach (Int32 digit in array)
            {
                output += digit + " ";
            }
            return output;
        }
    }
}
