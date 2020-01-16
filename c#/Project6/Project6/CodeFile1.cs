using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Threading.Tasks;

namespace Program
{
    public class ArrayOutofindexExeption : Exception
    {
        public ArrayOutofindexExeption() { }

        public ArrayOutofindexExeption(string message) : base(message) { }

    }

    public class OutOfRangeExeption : Exception
    {
        public OutOfRangeExeption() { }

        public OutOfRangeExeption(string message) : base(message) { }

    }
    public class WrongAnimalExeption : Exception
    {
        public WrongAnimalExeption() { }

        public WrongAnimalExeption(string message) : base(message) { }

    }

    public class DivisionByZeroExeption : Exception
    {
        public DivisionByZeroExeption() { }

        public DivisionByZeroExeption(string message) : base(message) { }

    }


    class Workwithenum
    {
        public enum Animalenum
        {
            Shark = 1,
            Parrot,
            Lion,
            Tiger,
            Owl
        }

        public Animal Addanimal(string _type, int weight, int date, Animalenum en)
        {
            switch (en)
            {
                case Animalenum.Shark:
                    {
                        Shark newshark = new Shark(_type, weight, date);
                        return newshark;
                    }
                case Animalenum.Parrot:
                    {
                        Parrot newParrot = new Parrot(_type, weight, date);
                        return newParrot;
                    }
                case Animalenum.Lion:
                    {
                        Lion newLion = new Lion(_type, weight, date);
                        return newLion;
                    }
                case Animalenum.Tiger:
                    {
                        Tiger newTiger = new Tiger(_type, weight, date);
                        return newTiger;
                    }
                case Animalenum.Owl:
                    {
                        Owl newOwl = new Owl(_type, weight, date);
                        return newOwl;
                    }
                default: { break; }
            }
            return null;
        }
    }
    public struct Animalstruct
    {
        public string type;
        public int weight;
        public int date;
        public Animalstruct(string _type, int _weight, int _date)
        {
            this.type = _type;
            this.weight = _weight;
            this.date = _date;
        }
        public void Printstruct()
        {
            Console.WriteLine($"тип:{type} вес:{weight} год:{date}");
        }
    }

    public class Zoo
    {
        List<Animal> zoo = new List<Animal>();
        public Animal[] getZoo()
        {
            Animal[] arrayzoo = new Animal[zoo.Count];
            int i = 0;
            foreach (var item in zoo)
            {
                arrayzoo[i] = item;
                i++;
            }
            return arrayzoo;
        }
        public void Addtozoo(Animal animal)
        {
            try
            {
                zoo.Add(animal);
            }
            catch
            {
                throw new WrongAnimalExeption("Вставьте корректный объект");   
            }
        }

        public void Deletefromzoo(Animal animal)
        {
            try
            {
                if (zoo.Remove(animal))
                {
                    Console.WriteLine("Успешно удалено");
                }
                else
                {
                    Console.WriteLine("Такого объекта нет");
                }
            }
            catch
            {
                throw new WrongAnimalExeption("Вставьте корректный объект");
            }

        }

        public void Printzoo()
        {
            foreach (var item in zoo)
            {
                Console.WriteLine(item.Print());
            }
        }

        public void Findweight(Animal animal)
        {
            int count = 0, sum = 0;
                Type type = animal.GetType();
                foreach (var item in zoo)
                {
                    Type _type = item.GetType();
                    if (_type == type)
                    {
                        count++;
                        sum += item.Getweight();
                    }
                }
            if (count == 0)
            { throw new DivisionByZeroExeption("Произошло деление на ноль"); }
                Console.WriteLine(sum / count);
                
            
            
        }
    }

    public class ZooController
    {
        public void YearSort(Zoo zoo)
        {
            Animal[] animalarray = zoo.getZoo();
            Animal temp;
            for (int i = 0; i < animalarray.Length - 1; i++)
            {
                for (int j = i + 1; j < animalarray.Length; j++)
                {
                    if (animalarray[i].Yearofbirth > animalarray[j].Yearofbirth)
                    {
                        temp = animalarray[i];
                        animalarray[i] = animalarray[j];
                        animalarray[j] = temp;
                    }
                }
            }
            foreach (var item in animalarray)
            {
                Console.WriteLine(item.Print());
            }
        }

        public void SameWeightCount(Zoo zoo, int weight)
        {
            Animal[] animals = zoo.getZoo();
            int count = 0;
            for (int i = 0; i < animals.Length; i++)
            {
                int a = animals[i].Weight;
                if (animals[i].Weight == weight)
                {
                    count++;
                }
            }
            Console.WriteLine($"В зоопарке {count} животных с весом {weight} ");
        }
    }
    interface IPrint
    {
        string Print();
    }
    public abstract class Animal : IPrint
    {
        string typeofanimal;
        int weight;
        int yearofbirth;

        public int Weight
        {
            get { return weight; }
            set { weight = value; }
        }
        public int Yearofbirth
        {
            get { return yearofbirth; }
            set { yearofbirth = value; }
        }
        public Animal(string type, int weight, int year)
        {
            this.typeofanimal = this.typeofanimal + " " + type;
            this.weight = weight;
            this.yearofbirth = year;
        }
        public int Getweight()
        {
            return weight;
        }

        public int Getyearofbirth()
        {
            return yearofbirth;
        }
        public string Print()
        {
            return typeofanimal + " " + "Животное Вес: " + weight + " Год рождения: " + yearofbirth;
        }

    }

    public abstract class Milk : Animal
    {
        string typeofmilk;

        public Milk(string type, int _weight, int _year) : base("Млекопитающее " + type, _weight, _year)
        {
            this.typeofmilk = this.typeofmilk + " " + type;
        }

        new public string Print()
        {
            return typeofmilk + " " + base.Print();
        }
    }

    public abstract class Fish : Animal
    {
        string typeoffish;
        public Fish(string type, int _weight, int _year) : base("Рыба " + type, _weight, _year)
        {
            this.typeoffish = this.typeoffish + " " + type;
        }

        new public string Print()
        {
            return typeoffish + " " + base.Print();
        }
    }

    public abstract class Bird : Animal
    {
        string typeofbird;
        public Bird(string type, int _weight, int _year) : base("Птица " + type, _weight, _year)
        {
            this.typeofbird = this.typeofbird + " " + type;
        }
        new public string Print()
        {
            return typeofbird + " " + base.Print();
        }
    }

    public class Shark : Fish
    {
        string typeofshark;
        public Shark(string type, int weight, int year) : base("Акула " + type, weight, year)
        {
            this.typeofshark = type;
        }
        new public string Print()
        {
            return " Тип: " + typeofshark + " " + base.Print();
        }
    }

    public class Lion : Milk
    {
        string typeoflion;
        public Lion(string type, int weight, int year) : base("Лев " + type, weight, year)
        {
            this.typeoflion = type;
        }
        new public string Print()
        {
            return " Тип: " + this.typeoflion + " " + base.Print();
        }
    }

    public class Tiger : Milk
    {
        string typeoftiger;

        public Tiger(string type, int weight, int year) : base("Тигр " + type, weight, year)
        {
            this.typeoftiger = type;
        }
        new public string Print()
        {
            return " Тип: " + typeoftiger + " " + base.Print();
        }
    }

    sealed public partial class Crocodile : Animal
    {
        string typeofcrocodile;
        public Crocodile(string type, int weight, int year) : base("Крокодил " + type, weight, year)
        {
            this.typeofcrocodile = this.typeofcrocodile + " " + type;
        }
        new public string Print()
        {
            return " Тип: " + typeofcrocodile + " " + base.Print();
        }
    }
    public class Owl : Bird
    {
        string typeofowl;

        public Owl(string type, int weight, int year) : base("Сова " + type, weight, year)
        {
            typeofowl = type;
        }
        new public string Print()
        {
            return " Тип: " + typeofowl + " " + base.Print();
        }
    }

    public class Parrot : Bird
    {
        string typeofparrot;
        public Parrot(string type, int weight, int year) : base("Попугай " + type, weight, year)
        {
            typeofparrot = type;
        }

        new public string Print()
        {
            return " Тип: " + typeofparrot + " " + base.Print();
        }
    }

    public class Printer
    {
        public virtual void IamPrinting(Animal an)
        {
            Console.WriteLine(an.GetType());
            Console.WriteLine(an.Print());
        }
    }

    public class Copyier
    {
        public Animal Copy(Animal a)
        {
            if (a is Milk)
            {
                Milk an = a as Milk;
                Console.WriteLine(an.Print());
                return an;
            }
            if (a is Fish)
            {
                Fish an = (Fish)a;
                Console.WriteLine(an.Print());
                return an;
            }
            if (a is Bird)
            {
                Bird an = (Bird)a;
                Console.WriteLine(an.Print());
                return an;
            }
            return null;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Lion big = new Lion("Большой лев", 50, 2001);
            Tiger usur = new Tiger("Усурийский", 45, 2002);
            Parrot ara = new Parrot("Ара", 13, 2007);
            Parrot ara1 = new Parrot("Ара", 7, 2007);
            Parrot ara2 = new Parrot("Ара", 7, 2004);
            Shark white = new Shark("Белая", 100, 1998);
            Console.WriteLine(big.Print());
            List<Animal> animals = new List<Animal>();
            animals.Add(big);
            animals.Add(usur);
            animals.Add(ara);
            animals.Add(white);
            Printer pr = new Printer();
            pr.IamPrinting(big);
            for (int i = 0; i < animals.Count; i++)
            {
                pr.IamPrinting(animals[i]);
            }
            Console.WriteLine(new string('_', 50));
            // --------------------------------------------------------------------------------------
            Workwithenum newenum = new Workwithenum();
            Animal newanimal = newenum.Addanimal("Новая акула", 110, 1999, Workwithenum.Animalenum.Shark);
            pr.IamPrinting(newanimal);
            Console.WriteLine(new string('_', 50));
            // --------------------------------------------------------------------------------------
            Animalstruct newstruct = new Animalstruct("Тигр", 54, 2001);
            newstruct.Printstruct();
            Console.WriteLine(new string('_', 50));
            // --------------------------------------------------------------------------------------
            Zoo zoo = new Zoo();
            zoo.Addtozoo(ara);
            zoo.Addtozoo(ara1);
            zoo.Addtozoo(ara2);
            zoo.Addtozoo(usur);
            zoo.Printzoo();
            zoo.Deletefromzoo(usur);
            zoo.Printzoo();
            zoo.Findweight(ara);
            zoo.Addtozoo(usur);
            zoo.Addtozoo(white);
            zoo.Addtozoo(big);
            Console.WriteLine(new string('_', 50));
            // --------------------------------------------------------------------------------------
            ZooController zoocontrol = new ZooController();
            zoocontrol.YearSort(zoo);
            Console.WriteLine(new string('_', 50));
            zoocontrol.SameWeightCount(zoo, 7);
            Console.WriteLine(new string('_', 50));
            // --------------------------------------------------------------------------------------

            try
            {
                Owl an = new Owl("sdf", 3, 4);
                zoo.Findweight(an);
                Owl an1 = null;
                zoo.Findweight(an1);
                int[] arr = new int[5];
                for (int i = 0; i < arr.Length + 1; i++)
                {
                    arr[i] = Convert.ToInt32(Console.ReadLine());
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message + "+" + e.StackTrace + "." + e.TargetSite);
            }
            finally
            {
                Console.WriteLine("КОнец");
            }
      
        }
    }
}