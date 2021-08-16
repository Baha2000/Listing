using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Channels;

namespace Listing
{
    class Program
    {
        static void Main(string[] args)
        {
            //var myList = new MyDoubleList();
            //var myList2 = new MyDoubleList(30);
            //double[] array = new double[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15};
            //double val, val2;
            //
            //myList.AddRange(array);      
            //
            //val = myList[11];
            //
            //myList.Remove(4);
            //myList.Print();
            //myList.Remove(8);
            //
            //foreach (var value in myList)
            //{
            //    Console.Write(value + " ");
            //}
            //Console.WriteLine();
            //Console.WriteLine(val);
            //Console.WriteLine();
            //Console.WriteLine(myList.Count);
            //Console.WriteLine(myList.Capacity);
            //Console.WriteLine("***************************************");
            //
            //myList2.AddRange(array);
            //
            //val2 = myList2[14];
            //
            //myList2.Remove(5);
            //myList2.Print();
            //myList2.Remove(4);
            //
            //foreach (var value in myList2)
            //{
            //    Console.Write(value + " ");
            //}
            //Console.WriteLine();
            //Console.WriteLine(val2);
            //Console.WriteLine();
            //Console.WriteLine(myList2.Count);
            //Console.WriteLine(myList2.Capacity);
            //
            //myList2.AddRange(array);
            //myList2.AddRange(array);
            //myList2.AddRange(array);
            //myList2.Remove(57);
            //myList2.Print();
//снизу норм
            // var myList = new MyDoubleListG<string>();
            // var myList2 = new MyDoubleListG<double>(30);
            // string[] array = new string[] { "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o"};
            // double[] array2 = new double[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 };
            // string val;
            // double val2;
            //
            // myList.AddRange(array);
            // myList[58] = "nice";
            // val = myList[-58];
            // Console.WriteLine(val);
            // Console.ReadKey();
            //
            // myList.Remove(4);
            // //myList.Print();
            // myList.Remove(8);
            //
            // foreach (var value in myList)
            // {
            //     Console.Write(value + " ");
            // }
            // Console.WriteLine();
            // Console.WriteLine(val);
            // Console.WriteLine();
            // Console.WriteLine(myList.Count);
            // Console.WriteLine(myList.Capacity);
            // Console.WriteLine("***************************************");
            //
            // myList2.AddRange(array2);
            //
            // val2 = myList2[14];
            //
            // myList2.Remove(5);
            // myList2.Print();
            // myList2.Remove(4);
            //
            // foreach (var value in myList2)
            // {
            //     Console.Write(value + " ");
            // }
            // Console.WriteLine();
            // Console.WriteLine(val2);
            // Console.WriteLine();
            // Console.WriteLine(myList2.Count);
            // Console.WriteLine(myList2.Capacity);
            //
            // myList2.AddRange(array2);
            // myList2.AddRange(array2);
            // myList2.AddRange(array2);
            // myList2.Remove(57);
            // myList2.Print();
            //
            // Console.ReadKey();
            
            //var myList2 = new MyDoubleListG<int>(30);
            //foreach (var value in myList2.Range(1, 15))
            //{
            //    Console.WriteLine(value);
            //}
            //Console.WriteLine(myList2.Range(1, 10));
            //ЛИНК тест + экстеншен
            //инт лист -> стринг -> экран -> обратно в инт + рандом число -> только четные -> сортировка туда сюда и шафл
            var myList = new List<int>();
            var rand = new Random();

            for (int i = 0; i < 10000; i++)
            {
                myList.Add(rand.Next(0, 1000));
            }

            var myList2 = from i1 in myList select i1.ToString();
            

             myList2.Select(i1 => i1).ToList().ForEach(Console.Write);
            
             myList = myList.Select(i1 => i1 + rand.Next(1, 101)).ToList();
             Console.WriteLine("\n-------------------------------------------------------------------------------------");
             myList.Where(i => i % 2 == 0).Select(i => i).ToList().ForEach(i => Console.Write($"{i} "));
             Console.WriteLine("\n-------------------------------------------------------------------------------------");
             myList.Where(i => i % 2 == 0).OrderBy(i => i).Select(i => i).ToList().ForEach(i => Console.Write($"{i} "));
             Console.WriteLine("\n-------------------------------------------------------------------------------------");
             myList.Where(i => i % 2 == 0).OrderByDescending(i => i).Select(i => i).ToList().ForEach(i => Console.Write($"{i} "));
             Console.WriteLine("\n-------------------------------------------------------------------------------------");
             Console.WriteLine(myList.Select(i => i).Count());
             Console.WriteLine(myList.Select(i => i).Distinct().Count());
             Console.WriteLine("\n-------------------------------------------------------------------------------------");
             myList = myList.OrderBy(i => rand.Next()).ToList();
             myList.Select(i => i).ToList().ForEach(i => Console.Write($"{i} "));
             myList.Select(i => i).ForEach(i => Console.WriteLine($"{i} "));
        }
    }
    
    public static class EnumerableExtension
    {
        public static void ForEach<T>(this IEnumerable<T> enumerable, Action<T> action)
        {
            foreach (var value in enumerable)
            {
                action(value);
            }
        }
    }
}
//extention method посмотреть, делегаты, фанк, экшн, предикат
