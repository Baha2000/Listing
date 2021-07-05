using System;
using System.Collections.Generic;

namespace Listing
{
    class Program
    {
        static void Main(string[] args)
        {
            var myList = new MyDoubleList();
            double[] array = new double[] { 222.0, 260.5, 289.6, 291.2 };
            double val;

            myList.Add(10.0);
            myList.Add(5.0);
            myList.Add(3.0);
            myList.Add(13.5);
            myList.Add(18.9);
            myList.Add(23.7);
            myList.Add(16.2);
            myList.AddRange(array);
            val = myList[3];
            myList.Remove(0);
            myList.Print();
            
            foreach (var value in myList)
            {
                Console.Write(value + " ");
            }
            Console.WriteLine(val);
            Console.ReadKey();
        }
    }
}
