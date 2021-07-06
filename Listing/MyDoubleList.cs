using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Listing
{
    class MyDoubleList
    {
        public int Count { get; private set; }
        public int Capacity { get; private set; }

        private double[] myArray;
        public double this[int index]
        {
            get
            {
                if (index > Count)
                    return 0;
                else
                    return myArray[index];
            }
        }
        public MyDoubleList(int Capacity)
        {
            this.Capacity = Capacity;
            myArray = new double[Capacity];
            Count = 0;
        }

        public MyDoubleList()
        {
            Capacity = 1;
            myArray = new double[1];
            Count = 0;
        }

        public void Add(double value)
        {
            CheckCount();
            InsertItem(value);
        }

        public void AddRange(IEnumerable<double> items)
        {
            CheckCount(items.Count());

            foreach (double value in items)
            {
                InsertItem(value);
            }

        }

        public void Remove(int index)
        {
            if (index <= Count)
            {
                for (int i = index; i < Count - 1; i++)
                {
                    myArray[i] = myArray[i + 1];
                }
                myArray[Count - 1] = 0;
                Count--;
            }
        }

        public void Print()
        {
            for (int i = 0; i < Count; i++)
                Console.WriteLine(myArray[i]);
        }

        private void CheckCount(int length)
        {

            if (Count + length > Capacity)
            {
                myArray = MasCopy(myArray, Count + length);
                Capacity += length;
            }
        }

        private void CheckCount()
        {

            if (Count + 1 > Capacity)
            {
                myArray = MasCopy(myArray, Count + 1);
                Capacity++;
            }
        }

        private double[] MasCopy(double[] sourceArray, int length)
        {
            double[] destinationArray = new double[length]; 

            if (length > Capacity)
                System.Array.Copy(sourceArray, destinationArray, sourceArray.Length); //Если нужна копия для увеличения массива
            else
                System.Array.Copy(sourceArray, destinationArray, length); //Если нужен чистый массив значений
            return destinationArray;
        }

        private void InsertItem(double value)
        {
            myArray[Count] = value;
            Count++;
        }

        public IEnumerator GetEnumerator()
        {
            myArray = MasCopy(myArray, Count);
            return myArray.GetEnumerator();
        }

    }
}
