using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;


namespace ConsoleApplication1
{
    public class BuildCollection<T> : ICollection<T> where T : Student
    {
        private T[] array;
        private int count;

        private T this[int index]
        {
            get
            {
                if (index > array.Length)
                {
                    throw new IndexOutOfRangeException();
                }
                return array[index];
            }
            set
            {
                if (index < 0 || index > array.Length)
                {
                    throw new IndexOutOfRangeException();
                }
                array[index] = value;
            }
        }

        public BuildCollection(int capacity)
        {
            array = new T[capacity];
            count = -1;
        }

        public IEnumerator<T> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public T Get(int index)
        {
            return this[index];
        }

        public void Add(T item)
        {
            if (item == null)
            {
                throw new ArgumentNullException();
            }
            this[++count] = item;
        }

        public void Clear()
        {
            count = -1;
        }

        public bool Contains(T item)
        {
            for (int i = 0; i < Count; i++)
            {
                if (this[i].Equals(item))
                {
                    return true;
                }
            }
            return false;
        }

        public void CopyTo(T[] arr, int arrayIndex)
        {
        
            throw new NotSupportedException();
        }



        public override string ToString()
        {
            return "kek" ;
        }
        public override bool Equals(object obj)
        {
            return true;
        }
        public override int GetHashCode()
        {
            return 122;
        }

        public bool Remove(T item)
        {
            for (int i = 0; i < Count; i++)
            {
                if (this[i].Equals(item))
                {
                    for (int k = i; k < count - 1; k++)
                    {
                        this[k] = this[k + 1];
                    }

                    count--;
                    return true;
                }
            }

            return false;
        }

        public int Count
        {
            get => count + 1;
        }
        public int Capacity
        {
            get => array.Length;
        }

        public bool IsReadOnly
        {
            get => false;
        }

        public bool IsEmpty()
        {
            if (count == -1)
            {
                return true;
            }

            return false;
        }
    }
}


