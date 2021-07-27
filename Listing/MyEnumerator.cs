using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Listing
{
    class MyEnumerator<T> : IEnumerator
    {
        private int index;
        T[] myArray;

        public MyEnumerator(T[] myArray)
        {
            index = 0;
            this.myArray = myArray;
        }
        public object Current
        {
            get
            {
                if (!CheckIndex(index))
                    throw new Exception("Недопустимый индекс");
                return myArray[index];
            }
        }

        public bool MoveNext()
        {
            if (!CheckIndex(++index))
                Reset();
            return true;
        }

        public void Reset()
        {
            index = 0;
        }

        private bool CheckIndex(int index)
        {
            if (index > myArray.Length - 1 || index < 0)
                return false;
            return true;
        }
    }
}
