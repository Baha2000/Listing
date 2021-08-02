using System;
using System.Collections;
using System.Collections.Generic;

namespace Listing
{
    class MyEnumerator<T> : IEnumerator<T>
    {
        private int index;
        private T[] myArray;

        public MyEnumerator(T[] myArray)
        {
            index = 0;
            this.myArray = myArray;
        }

        public void Dispose()
        {
        }

        public T Current => myArray[index];

        object IEnumerator.Current
        {
            get
            {
                if (!CheckIndex(index))
                    throw new Exception("Недопустимый индекс");
                return Current;
            }
        }

        public bool MoveNext()
        {
            if (!CheckIndex(++index))
                Reset();
            return true;
        }

        public void Reset() => index = 0;

        private bool CheckIndex(int index)
        {
            if (index > myArray.Length - 1 || index < 0)
                return false;
            return true;
        }
    }
}
