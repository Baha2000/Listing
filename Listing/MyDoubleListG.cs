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
                index = Math.Abs(index);
                index = CheckIndex(index);
                //if (index >= 0)
                //    index = CheckIndex(index);
                //else
                //    index = CheckIndex(-index);
                return myArray[index];
            }
            set
            {
                index = Math.Abs(index);
                if (index + 1 > Capacity)
                {
                    MasCopy(ref myArray, CheckCapacity(index + 1));
                }
                myArray[index] = value;
                Count = ++index;
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
            MasCopy(ref myArray, CheckCapacity());
            //CheckArray(1);
            InsertItem(value);
        }

        public void AddRange(IEnumerable<T> items)
        {
            MasCopy(ref myArray, CheckCapacity(items.Count()));
            //CheckArray(items.Count());
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
                {
                    i = 0;
                }
            }
        }

        //private void CheckArray(int length)
        //{
        //    myArray = MasCopy(ref myArray, CheckCapacity(length));
        //}

        //private T[] MasCopy(T[] sourceArray, int length)
        //{
        //    T[] destinationArray = new T[length];
        //
        //    if (length > Capacity)
        //    {
        //        Array.Copy(myArray, destinationArray, sourceArray.Length); //Если нужна копия для увеличения массива
        //        Capacity = length;
        //        sourceArray = new T[length];
        //    }
        //    else
        //        Array.Copy(sourceArray, destinationArray, length); //Если нужен чистый массив значений
        //
        //    return destinationArray;
        //}

        private void MasCopy(ref T[] sourceArray, int length)
        {
            if (length > Capacity)
            {
                Array.Resize<T>(ref sourceArray, length); //Если нужна копия для увеличения массива
                Capacity = length;
            }
            else
                throw new Exception("Неудачное расширение листа");
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

        private int CheckCapacity(int length = 1) //проверка на достаточную вместимость для вставки в лист
        {
            if (Count + length > Capacity)
            {
                if (length == 1)
                    return Capacity * Capacity;
                else
                    return Capacity + length * length;
            }
            return Capacity;
        }

        public IEnumerator GetEnumerator()
        {
            //return new MyEnumerator<T>(MasCopy(ref myArray, Count));
            T[] destinationArray = new T[Count];
            Array.Copy(myArray, destinationArray, Count);
            return new MyEnumerator<T>(destinationArray);
        }

    }
}
