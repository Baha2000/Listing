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
                if (index > Count - 1)
                    throw new Exception("Индекс больше, чем количество элементов в массиве");
                else
                    return myArray[index];
            }
        }
        public MyDoubleList(int Capacity) //Конструктор, для ввода пользователем вместимости массива вручную
        {
            this.Capacity = Capacity;
            myArray = new double[Capacity];
            Count = 0;
        }

        public MyDoubleList() //Дефолтный конструктор
        {
            Capacity = 1;
            myArray = new double[1];
            Count = 0;
        }

        public void Add(double value)
        {
            CheckArray();
            InsertItem(value);
        }

        public void AddRange(IEnumerable<double> items)
        {
            CheckArray(items.Count());
            foreach (double value in items)
            {
                InsertItem(value);
            }
        }

        public void Remove(int index)
        {
            if (index <= Count - 1)
            {
                for (int i = index; i < Count - 1; i++)
                {
                    myArray[i] = myArray[i + 1];
                }
                myArray[Count - 1] = 0;
                Count--;
            }
            else
                throw new Exception("Индекс больше, чем количество элементов в массиве");
        }

        public void Print()
        {
            for (int i = 0; i < Count; i++)
                Console.WriteLine(myArray[i]);
        }

        private void CheckArray(int length)
        {
            if (Count + length > Capacity) 
                myArray = MasCopy(ref myArray, Count + length);
        }

        private void CheckArray()
        {
            if (Count + 1 > Capacity)
                myArray = MasCopy(ref myArray, Count + 1);
        }

        private double[] MasCopy(ref double[] sourceArray, int length) // Передается ссылка на массив myArray для его дальнейшего пересоздания и вставки в него значений из return
        {
            double[] destinationArray = new double[length];

            if (length > Capacity)
            {
                System.Array.Copy(sourceArray, destinationArray, sourceArray.Length); //Если нужна копия для увеличения массива
                Capacity = length;
                sourceArray = new double[length];
            }
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
            return MasCopy(ref myArray, Count).GetEnumerator();
        }

    }
}
