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

        double[] Mas;
        double[] TempMas;
        public double this[int index]
        {
            get
            {
                if (index > Count)
                    return 0;
                else
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
                //TempMas = new double[Capacity];
                //Mas.CopyTo(TempMas, 0);
                TempMas = MasCopy(Mas, Capacity);
                Mas = MasCopy(TempMas, Count + length);
                //Mas = new double[Count + length];
                //TempMas.CopyTo(Mas, 0);
                Capacity += length;
            }
        }

        private void CheckCount()
        {

            if (Count + 1 > Capacity)
            {
                //TempMas = new double[Capacity];
                //Mas.CopyTo(TempMas, 0);
                TempMas = MasCopy(Mas, Capacity);
                Mas = MasCopy(TempMas, Count + 1);
                //Mas = new double[Count + 1];
                //TempMas.CopyTo(Mas, 0);
                Capacity++;
            }
        }

        private double[] MasCopy(double[] MasCopy, int length)
        {
            double[] MasPaste = new double[length];
            if (length > Capacity)
                Array.Copy(MasCopy, MasPaste, MasCopy.Length);
            else
                Array.Copy(MasCopy, MasPaste, length);
            
            //TempMas = new double[length];
            //Mas.CopyTo(TempMas, 0);
            //return TempMas;
            return MasPaste;
        }

        private void InsertItem(double value)
        {
            Mas[Count] = value;
            Count++;
        }

        public IEnumerator GetEnumerator()
        {
            Mas = MasCopy(Mas, Count);
            return Mas.GetEnumerator();
        }

    }
}
