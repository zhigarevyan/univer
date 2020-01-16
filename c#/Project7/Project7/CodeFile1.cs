
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
namespace Program1
{
    interface ISumarise<T>
    {
        void AddItem(T item);
        void DeleteItem(T item);
        void ViewItem();
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

    public class CollectionType<T>: ISumarise<T>  where T : Animal // struct
    {

        List<T> list = new List<T>();

        public void AddItem(T item)
        {
            list.Add(item);
        }

        public void DeleteItem(T item)
        {
            list.Remove(item);
        }

        public void ViewItem()
        {
            foreach (var item in list)
            {
                Console.WriteLine(item.Print());  
            }
        }

    }



    class Program
    {
        static void Main(string[] args)
        {
            //CollectionType<int> intcol = new CollectionType<int>();
            //intcol.AddItem(5);
            //intcol.AddItem(6);
            //intcol.AddItem(7);
            //intcol.AddItem(8);
            //intcol.ViewItem();
            //intcol.DeleteItem(5);
            //intcol.ViewItem();
            //CollectionType<double> doublecol = new CollectionType<double>();
            //doublecol.AddItem(1.1);
            //doublecol.AddItem(1.2);
            //doublecol.AddItem(1.3);
            //doublecol.AddItem(1.4);
            //doublecol.ViewItem();
            //doublecol.DeleteItem(1.4);
            //doublecol.ViewItem();
            Lion big = new Lion("Большой лев", 50, 2001);
            Tiger usur = new Tiger("Усурийский", 45, 2002);
            Parrot ara = new Parrot("Ара", 13, 2007);
            Parrot ara1 = new Parrot("Ара", 7, 2007);
            Parrot ara2 = new Parrot("Ара", 7, 2004);
            Shark white = new Shark("Белая", 100, 1998);
            CollectionType<Animal> animalcol = new CollectionType<Animal>();
            animalcol.AddItem(big);
            animalcol.AddItem(usur);
            animalcol.AddItem(ara);
            animalcol.AddItem(ara1);
            animalcol.AddItem(ara2);
            animalcol.AddItem(white);
            animalcol.ViewItem();
            animalcol.DeleteItem(ara1);
            animalcol.ViewItem();
        }

    }
}