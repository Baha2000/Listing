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
        int Count;
        int Capacity;
        double[] Mas;
        double[] TempMas;
        public double this[int index]
        {
            get
            {
                return Mas[index];
            }
        }
        public MyDoubleList(int Capacity)
        {
            this.Capacity = Capacity;
            Mas = new double[Capacity];
            Count = 0;
        }

        public MyDoubleList()
        {
            Capacity = 1;
            Mas = new double[1];
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
                    Mas[i] = Mas[i + 1];
                }
                Mas[Count - 1] = 0;
                Count--;
            }
        }

        public void Print()
        {
            for (int i = 0; i < Count; i++)
                Console.WriteLine(Mas[i]);
        }

        private void CheckCount(int length)
        {

            if (Count + length > Capacity)
            {
                TempMas = new double[Capacity];
                Mas.CopyTo(TempMas, 0);
                Mas = new double[Count + length];
                TempMas.CopyTo(Mas, 0);
                Capacity += length;
            }
        }

        private void CheckCount()
        {

            if (Count + 1 > Capacity)
            {
                TempMas = new double[Capacity];
                Mas.CopyTo(TempMas, 0);
                Mas = new double[Count + 1];
                TempMas.CopyTo(Mas, 0);
                Capacity++;
            }
        }

        private void InsertItem(double value)
        {
            Mas[Count] = value;
            Count++;
        }

        public IEnumerator GetEnumerator()
        {
            return Mas.GetEnumerator();
        }
    }
}
