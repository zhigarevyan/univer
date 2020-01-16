using System;
using System.Collections.Generic;
using System.Collections;
using System.Collections.ObjectModel;
using System.Collections.Specialized;


namespace Program
{
    class Program
    {
        static void Main(string[] args)
        {
            ArrayList array = new ArrayList();
            Random rnd = new Random();
            string str = "I love c#";
            Student stud = new Student("vasya");
            array.Add(rnd.Next());
            array.Add(rnd.Next());
            array.Add(rnd.Next());
            array.Add(rnd.Next());
            array.Add(rnd.Next());
            array.Add(str);
            array.Add(stud);
            foreach (var item in array)
            {
                Console.WriteLine(item);
            }
            array.Remove(stud);
            foreach (var item in array)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine(array.Count);
            foreach (var item in array)
            {
                //array.Contains()
                if (item == str)
                    Console.WriteLine(item);
            }
            

            HashSet<int> hash = new HashSet<int>();
            for (int i = 0; i < 10; i++)
            {
                hash.Add(i);
            }
            foreach (var item in hash)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("введите n");
            int n = Convert.ToInt32(Console.ReadLine());
            int m = 0;
            int[] l = new int[hash.Count];
            foreach (var item in hash)
            {
                l[m] = item;
                m++;
            }
            for (int i = 0; i < n; i++)
            {
                hash.Remove(l[i]);    
            }
            foreach (var item in hash)
            {
                Console.WriteLine(item);
            }
            List<int> list = new List<int>();
            foreach (var item in hash)
            {
                list.Add(item);
            }
            foreach (var item in list)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("+___________________");
            List<Student> listst = new List<Student>();
            HashSet<Student> hashst = new HashSet<Student>();
            Student s1 = new Student("s1");
            Student s2 = new Student("s2");
            Student s3 = new Student("s3");
            Student s4 = new Student("s4");
            listst.Add(s1);
            listst.Add(s2);
            listst.Add(s3);
            listst.Add(s4);
            foreach (var item in listst)
            {
                Console.WriteLine(item);
                hashst.Add(item);
            }
            foreach (var item in hashst)
            {
                Console.WriteLine(item);
            }
            if (hashst.Contains(s1))
            {
                Console.WriteLine("содержит");
            }

            




        }
    }

    class Student
    {
        string name;

        public Student(string _name)
        {
            name = _name;
        }
        public override string ToString()
        {
            Console.WriteLine(name);
            return "";
        }


    }
}