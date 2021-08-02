using System;
using System.Collections.Generic;

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

            var myList = new MyDoubleListG<string>();
            var myList2 = new MyDoubleListG<double>(30);
            string[] array = new string[] { "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o"};
            double[] array2 = new double[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 };
            string val;
            double val2;
            
            myList.AddRange(array);
            myList[58] = "nice";
            val = myList[-58];
            Console.WriteLine(val);
            Console.ReadKey();

            myList.Remove(4);
            //myList.Print();
            myList.Remove(8);
            
            foreach (var value in myList)
            {
                Console.Write(value + " ");
            }
            Console.WriteLine();
            Console.WriteLine(val);
            Console.WriteLine();
            Console.WriteLine(myList.Count);
            Console.WriteLine(myList.Capacity);
            Console.WriteLine("***************************************");
            
            myList2.AddRange(array2);
            
            val2 = myList2[14];
            
            myList2.Remove(5);
            myList2.Print();
            myList2.Remove(4);
            
            foreach (var value in myList2)
            {
                Console.Write(value + " ");
            }
            Console.WriteLine();
            Console.WriteLine(val2);
            Console.WriteLine();
            Console.WriteLine(myList2.Count);
            Console.WriteLine(myList2.Capacity);
            
            myList2.AddRange(array2);
            myList2.AddRange(array2);
            myList2.AddRange(array2);
            myList2.Remove(57);
            myList2.Print();

            Console.ReadKey();
        }
    }
}
