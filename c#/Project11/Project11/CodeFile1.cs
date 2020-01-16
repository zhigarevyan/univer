using System;
using System.Reflection;
using System.IO;

class Program
{
    static void Main(string[] agrs)
    {
        Person person = new Person("kek", 16);
        Reflector reflector = new Reflector();
        reflector.ClassContains(person);
        reflector.ClassContainsMethods(person);
        Console.WriteLine(new string('_',50));
        reflector.ClassContainsProperties(person);
        Console.WriteLine(new string('_', 50));
        reflector.ClassContainsInterfaces(person);
        Console.WriteLine(new string('_', 50));
        reflector.MethodContainsArg(person, typeof(int));
        Console.WriteLine(new string('_', 50));
        reflector.CallMethod(person, "kek");
    }


    class Reflector
    {
        public void ClassContains(object obj)
        {
            FileStream file = new FileStream("C:\\Users\\xiaom\\Desktop\\univer\\c#\\Project11\\ClassContains.txt", FileMode.Create);
            Type myType = Type.GetType(obj.GetType().ToString(), false, false);
            using (file)
            {
                foreach (MemberInfo mi in myType.GetMembers())
                {
                    byte[] arr = System.Text.Encoding.Default.GetBytes($"{mi.DeclaringType}  - {mi.MemberType} - {mi.Name}");
                    file.Write(arr, 0, arr.Length);
                }
            }
        }

        public void ClassContainsMethods(object obj)
        {
            Type myType = Type.GetType(obj.GetType().ToString(), false, false);
            foreach (MethodInfo method in myType.GetMethods())
            {
                Console.WriteLine($"{method.ReturnType.Name} - {method.Name}");
            }
        }

        public void ClassContainsProperties(object obj)
        {
            Type myType = Type.GetType(obj.GetType().ToString(), false, false);
            foreach (FieldInfo fi in myType.GetFields())
            {
                Console.WriteLine($"{fi.FieldType} - {fi.Name}");
            }
            foreach (PropertyInfo pi in myType.GetProperties())
            {
                Console.WriteLine($"{pi.PropertyType} - {pi.Name}");
            }
            FieldInfo[] fieldInfo = myType.GetFields();

        }

        public void ClassContainsInterfaces(object obj)
        {
            Type myType = Type.GetType(obj.GetType().ToString(), false, false);
            foreach (Type i in myType.GetInterfaces())
            {
                Console.WriteLine($"{i.Name }");
            }
        }

        public void MethodContainsArg(object obj, Type type)
        {
            Type myType = Type.GetType(obj.GetType().ToString(), false, false);
            foreach (MethodInfo method in myType.GetMethods())
            {
                ParameterInfo[] pi = method.GetParameters();
                for (int i = 0; i < pi.Length; i++)
                {
                    string a = pi[i].ParameterType.Name;
                    if (pi[i].ParameterType.Name == type.Name.ToString())
                    {
                        Console.WriteLine($"{method.Name}");
                    }
                }
            }
        }

        public void CallMethod(object obj, string methodname)
        {
            int arg;
            using (StreamReader sr = new StreamReader("C:\\Users\\xiaom\\Desktop\\univer\\c#\\Project11\\parameteres.txt"))
            {
                arg = Convert.ToInt32( sr.ReadToEnd());
            }
            Type myType = Type.GetType(obj.GetType().ToString(), false, false);
            foreach (MethodInfo method in myType.GetMethods())
            {
                if (method.Name == methodname)
                {
                    Console.WriteLine("sdfsd");
                    method.Invoke(obj, new object[] { arg });
                }

            }
        }
    }
    interface Iinterface
    {
        void lol();
    }
    class Person:Iinterface
    {
        public int field;
        public string name { get; set; }
        public int age { get; set; }

        public Person(string _name, int _age)
        {
            name = _name;
            age = _age;
        }
        public void kek(int  a)
        {
            Console.WriteLine(a);
        }
        public void kek1(int a)
        { }
        public void lol()
        { }
    }
}