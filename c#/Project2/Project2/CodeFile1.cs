using System;
using System.Collections.Generic;
using System.Linq;


namespace ConsoleApplication1
{
    public partial class Student
    {
        public readonly string type = "Uchenik";
        public static int count = 0;
        public string name;
        public string Edu;
        public int Age;
        static Student()
        {
            Console.WriteLine("вы довабили первого студента");
        }

        public Student()
        {
            Name = "empty";
            Edu = "empty";
            Age = 0;
            count++;
        }

        public Student(string _name, string _edu, int _age)
        {
            if (_name is String)
                Name = _name;
            if (_edu is String)
                Edu = _edu;
            if (_age is Int32)
                Age = _age;
            count++;
        }

        public void print()
        {
            Console.WriteLine($"Name {Name}\n Edu {Edu} \n Age {Age}");
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }
            Student st = obj as Student;
            if (st as Student == null)
            {
                return false;
            }
            return st.Name == this.Name && st.Edu == this.Edu && st.Age == this.Age;
        }

        public override int GetHashCode()
        {
            int a = 5;
            return ++a;

        }
        public override string ToString()
        {

            return $"Name {Name}\n Edu {Edu} \n Age {Age}+ sos";
        }
        public Student(Student prevStudent)
        {
            Name = prevStudent.Name;
            Edu = prevStudent.Edu;
            Age = prevStudent.Age;
            count++;
        }
        ~Student()
        {
            Console.WriteLine("ученик исключен");
        }

        public static float polovina()
        {
            return count / 2;
        }

        public string Name
        {
            get
            {
                return name;
            }

            set
            {
                name = value;
            }
        }

        public void ageout(out int a)
        {
            a = Age;
        }

        public void changeage(ref int b)
        {
            Age = b;
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            int a = 16;
            string qwe = "sdfsd";
            Console.WriteLine(qwe.GetType());
            int b = 16;
            Student yan = new Student("yan", "bgtu", 18);
            Student non = new Student();
            Student yan1 = new Student(yan);
            Student qw1 = new Student("qwe", "wer", 1);
            Student qw2 = new Student("ccc", "dsf", 6);
            yan.print();
            non.print();
            yan1.print();
            Console.WriteLine(yan.Equals(yan1));
            Console.WriteLine(yan.Equals(non));
            Console.WriteLine(Student.count);
            Console.WriteLine(Student.polovina());
            Console.WriteLine(yan1.ToString());
            Console.WriteLine(yan1.type);
            yan.ageout(out a);
            Console.WriteLine(a);
            yan.changeage(ref b);
            yan.print();
            yan.part();
            var stud = new { name = "kek", edu = "lol", age = 10 };
            
            List<Student> list1 = new List<Student>();
            list1.Add(yan);
            list1.Add(qw1);
            list1.Add(yan1);
            list1.Add(qw2);
            string poisk = Console.ReadLine();
            foreach (var item in list1)
            {
                if (item.name == poisk)
                {
                    Console.WriteLine("pobeda");
                }
                else
                    Console.WriteLine("ne pobeda");
            }


            BuildCollection<Student> Col = new BuildCollection<Student>(10);
            Col.Add(yan);
            Col.Get(0);
            Col.Add(yan1);
            Col.Add(yan1);
            Console.WriteLine(Col.Count);
            Col.Remove(yan);
            Console.WriteLine(Col.Count);
            Console.WriteLine(Col.Contains(yan1)); 
            
        }        
    }    
}
