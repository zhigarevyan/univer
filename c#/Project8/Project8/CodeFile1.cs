using System;

namespace Program
{
    class Director
    {
        public delegate void Salary(int amount, Worker person);
        public event Salary Up;
        public event Salary Down;

        public void Upsalary(int amount, Worker person)
        {
            Up?.Invoke(amount, person);
        }
        public void Downsalary(int amount, Worker person)
        {
            Down?.Invoke(amount, person);
        }
    }

    class Worker
    {
        private int salary;

        public Worker(int amount)
        {
            salary = amount;
        }
        public int Salary
        {
            get
            {
                return salary;
            }
            set 
            {
                salary = value;
            }
        }
        public void Print()
        {
            Console.WriteLine("зарплата сейчас - {0}", salary);   
        }
    }



    class Program
    {
        public static void znaki(string str)
        {
            string newstr="";
            string newstr1 = "";
            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] != ',')
                {
                    if (str[i] != '.')
                    {
                        if (str[i] != ':')
                        {
                            newstr += str[i];
                        }
                    }
                }

            }
            Console.WriteLine(newstr);
        }

        public static void probeli(string str)
        {
            string newstr = "";
            for (int i = 0; i < str.Length; i++)
            {
                if (i < str.Length - 1)
                {
                    if (str[i] != ' ' && str[i + 1] != ' ')
                    {
                        newstr += str[i];
                    }
                }
            }
            Console.WriteLine(newstr);
        }

        public static void upercase(string str)
        {
            Console.WriteLine(str.ToUpper());
        }

        public static void lowercase(string str)
        {
            Console.WriteLine(str.ToLower());
        }

        public static void upperlower(string str)
        {
            string newstr = "";
            string newstr1 = "";
            for (int i = 0; i < str.Length; i++)
            {
                if (i % 2 != 0)
                {
                    newstr1 += str[i];
                    newstr1 = newstr1.ToUpper();
                    newstr += newstr1;
                    newstr1 = "";
                }
                else 
                {
                    newstr1 += str[i];
                    newstr1 = newstr1.ToLower();
                    newstr += newstr1;
                    newstr1 = "";
                }
            }
            Console.WriteLine(newstr);
        }

        private static void UpsalaryMethod(int amount, Worker person)
        {
            person.Salary += amount;
        }
        private static void DownsalaryMethod(int amount, Worker person)
        {
            person.Salary -= amount;
        }
        static void Main(string[] args)
        {
            Worker w1 = new Worker(100);
            Worker w2 = new Worker(100);
            Director Boss = new Director();
            Boss.Up += UpsalaryMethod;
            Boss.Down += DownsalaryMethod;
            Boss.Upsalary(20, w1);
            w1.Print();
            Boss.Downsalary(100, w2);
            w2.Print();
            Action<string> act;
            act = lowercase;
            act += upercase;
            act += upperlower;
            act += znaki;
            act += probeli;
            string str = "ere,FEr.sDSFf ssDSf grs   sasdf sfe, sef  ehd";
            act(str);
        }
    }
}