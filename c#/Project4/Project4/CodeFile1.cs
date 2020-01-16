using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Program
{
    interface IPrint
    {
        string Print();
    }
    public abstract class Animal : IPrint
    {
        string typeofanimal;
        public Animal(string type)
        {
            this.typeofanimal = type;
        }

        public string Print()
        {
            return typeofanimal + " " + "Животное";
        }

    }

    public abstract class Milk : Animal
    {
        string typeofmilk;
        public Milk(string type) : base("Млекопитающее")
        {
            this.typeofmilk = type;
        }

        new public string Print()
        {
            return typeofmilk + " " + base.Print();
        }
    }

    public abstract class Fish : Animal
    {
        string typeoffish;
        public Fish(string type) : base("Рыба")
        {
            this.typeoffish = type;
        }

        new public string Print()
        {
            return typeoffish + " " + base.Print();
        }
    }

    public abstract class Bird : Animal
    {
        string typeofbird;
        public Bird(string type) : base("Птица")
        {
            this.typeofbird = type;
        }
        new public string Print()
        {
            return typeofbird + " " + base.Print();
        }
    }

    public class Shark : Fish
    {
        string typeofshark;

        public Shark(string type) : base("Акула")
        {
            this.typeofshark = type;
        }
        new public string Print()
        {
            return typeofshark + " " + base.Print();
        }
    }

    public class Lion : Milk
    {
        string typeoflion;
        public Lion(string type) : base("Лев")
        {
            this.typeoflion = type;
        }

        new public string Print()
        {
            return this.typeoflion + " " + base.Print();
        }
    }

    public class Tiger : Milk
    {
        string typeoftiger;
        public Tiger(string type) : base("Тигр")
        {
            this.typeoftiger = type;
        }
        new public string Print()
        {
            return typeoftiger + " " + base.Print();
        }
    }

    sealed public class Crocodile : Animal
    {
        string typeofcrocodile;
        public Crocodile(string type) : base("Крокодил")
        {
            this.typeofcrocodile = type;
        }
        new public string Print()
        {
            return typeofcrocodile + " " + base.Print();
        }
    }
    public class Owl : Bird
    {
        string typeofowl;
        public Owl(string type) : base("Сова")
        {
            typeofowl = type;
        }
        new public string Print()
        {
            return typeofowl + " " + base.Print();
        }
    }

    public class Parrot : Bird
    {
        string typeofparrot;
        public Parrot(string type) : base("Попугай")
        {
            typeofparrot = type;
        }

        new public string Print()
        {
            return typeofparrot + " " + base.Print();
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
            Lion big = new Lion("Большой лев");
            Tiger usur = new Tiger("Усурийский");
            Parrot ara = new Parrot("Ара");
            Shark white = new Shark("Белая");
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

            
        }
    }
}