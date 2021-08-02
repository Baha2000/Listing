using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Listing
{
    class MyDoubleListG<T>
    {
        public int Count { get; private set; }
        public int Capacity { get; private set; }

        private T[] myArray;
        public T this[int index]
        {
            get
            {
                if (index >= 0)
                    index = CheckIndex(index);
                else
                    throw new Exception("Недопустимый индекс");
                return myArray[index];
            }
        }

        public MyDoubleListG(int Capacity = 1) //Конструктор, для ввода пользователем вместимости массива вручнуюмне сейчас
        {
            this.Capacity = Capacity;
            myArray = new T[Capacity];
            Count = 0;
        }

        public void Add(T value)
        {
            CheckArray(1);
            InsertItem(value);
        }

        public void AddRange(IEnumerable<T> items)
        {
            CheckArray(items.Count());
            foreach (T value in items)
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
                myArray[Count - 1] = default;
                Count--;
            }
            else
                throw new Exception("Индекс больше, чем количество элементов в массиве");
        }

        public void Print()
        {
            for (int i = 0; i < Count; i++)
            {
                Console.WriteLine(myArray[i]);
                if (i + 1 == Count)
                    i = 0;
            }
        }

        private void CheckArray(int length)
        {
            myArray = MasCopy(ref myArray, CheckCapacity(length));
        }

        private T[] MasCopy(ref T[] sourceArray, int length) // Передается ссылка на массив myArray для его дальнейшего пересоздания и вставки в него значений из return
        {
            T[] destinationArray = new T[length];

            if (length > Capacity)
            {
                System.Array.Copy(sourceArray, destinationArray, sourceArray.Length); //Если нужна копия для увеличения массива
                Capacity = length;
                sourceArray = new T[length];
            }
            else
                System.Array.Copy(sourceArray, destinationArray, length); //Если нужен чистый массив значений
            return destinationArray;
        }

        private void InsertItem(T value)
        {
            myArray[Count] = value;
            Count++;
        }

        private int CheckIndex(int index) //рекурсия для получения индекса в закольцованном буфере
        {
            if (index > Count - 1)
                index = CheckIndex(index - Count);
            return index;
        }

        private int CheckCapacity(int length) //проверка на достаточную вместимость для вставки в лист
        {
            if (Count + length > Capacity)
            {
                if (length == 1)
                    return Capacity * Capacity;
                else
                    return Capacity + length * length;
            }
            return length;
        }

        public IEnumerator GetEnumerator()
        {
            return new MyEnumerator<T>(MasCopy(ref myArray, Count));
        }

    }
}
