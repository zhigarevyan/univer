using System;

namespace Program1
{


     public class Array
    {
        public class Owner
        {
            string ID="kek";
            string Name="YAN";
            string Org="BSTU";
            string Date = "10.10.2019";
        }


        int[] Intarray;
        int length;
        public Array(int[] a, int len)
        {
            Intarray = a;
            length = len;
        }
        public void Fill()
        {
            Console.WriteLine("введите элементы массива");
            for (int i = 0; i < length; i++)
            {
                Intarray[i] = Convert.ToInt32(Console.ReadLine());
            }
        }
        public void Print()
        {
            for (int i = 0; i < this.length; i++)
            {
                Console.WriteLine($"{i} - {this.Intarray[i]}");
            }
        }

        public int[] Mass()
        {
            int[] ar = new int[this.length];
            return ar = this.Intarray;          
        }
        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
        public static Array operator *(Array arr1, Array arr2)
        {
            if (arr1.length != arr2.length)
            {
                throw new NotSupportedException();
            }
            var result = new Array(arr1.Intarray, arr1.length);
            for (int i = 0; i < arr1.length; i++)
            {
                result.Intarray[i] = arr1.Intarray[i] * arr2.Intarray[i];
            }
            return result;
        }

        public static bool operator true(Array ar)
        {
            for (int i = 0; i < ar.length; i++)
            {
                if (ar.Intarray[i] < 0)
                    return false;
            }
            return true;
        }
        public static bool operator false(Array ar)
        {
            for (int i = 0; i < ar.length; i++)
            {
               if (ar.Intarray[i] < 0)
                    return true;
            }
            return false;
        }

        public static explicit operator int(Array ar1)
        {
            return ar1.length;
        }

        public static bool operator ==(Array ar1, Array ar2)
        {
            for (int i = 0; i < ar1.length; i++)
            {
                if (ar1.Intarray[i] != ar2.Intarray[i])
                    return false;
            }
            return true;
        }

        public static bool operator !=(Array ar1, Array ar2)
        {
            for (int i = 0; i < ar1.length; i++)
            {
                if (ar1.Intarray[i] == ar2.Intarray[i])
                    return false;
            }
            return true;
        }

        public static bool operator <(Array ar1, Array ar2)
        {
            int sum1 = 0, sum2 = 0;
            for (int i = 0; i < ar1.length; i++)
            {
                sum1 += ar1.Intarray[i];
            }
            for (int i = 0; i < ar1.length; i++)
            {
                sum2 += ar1.Intarray[i];
            }
            if (sum1 < sum2)
                return true;
            else
                return false;
        }
        public static bool operator >(Array ar1, Array ar2)
        {
            int sum1 = 0, sum2 = 0;
            for (int i = 0; i < ar1.length; i++)
            {
                sum1 += ar1.Intarray[i];
            }
            for (int i = 0; i < ar1.length; i++)
            {
                sum2 += ar1.Intarray[i];
            }
            if (sum1 > sum2)
                return true;
            else
                return false;
        }


        

    }

    public static class StatisticOperation
    {

        public static int Sum(Array arr)
        {
            int sum = 0;
            int[] ar = arr.Mass();
            for (int i = 0; i < ar.Length; i++)
            {
                sum += ar[i];
            }
            return sum;
        }

        public static int Len(Array arr)
        {
            int[] ar = arr.Mass();
            return ar.Length;
        }

        public static int Razn(Array arr)
        {
            int min, max;
            int[] ar = arr.Mass();
            min = ar[0];
            max = ar[0];
            for (int i = 0; i < ar.Length; i++)
            {
                if (max > ar[i])
                    max = ar[i];
                if (min < ar[i])
                    min = ar[i];
            }
            return max - min;
        }
        public static bool WordFind(this string str, char c)
        {
            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] == c)
                    return true;
            }
            return false;
        }

        public static Array NegSkip(this Array arr)
        {
            int[] ar = arr.Mass();
            for (int i = 0; i < ar.Length; i++)
            {
                if (ar[i] < 0)
                    ar[i] *= -1;
            }
            Array ar1 = new Array(ar, ar.Length);
            return ar1;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            int[] a = new int[5];
            int[] b = new int[5];
            Array ar = new Array(a, a.Length);
            Array ar1 = new Array(b, b.Length);
            ar.Fill();
            ar1.Fill();
            Array ar2 = ar * ar1;
            ar2.Print();
            if (ar2)
            {
                Console.WriteLine("все элементы положительные");
            }
            else
                Console.WriteLine("есть отрицательный");

            Console.WriteLine((int)ar);

            if (ar == ar1)
            {
                Console.WriteLine("массивы равны");
            }
            else
                Console.WriteLine("не равны");


            
        }
            
    }
}