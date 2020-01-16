using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
class Program
{
    static void Main(string[] args)
    {
        string[] mounths = { "январь", "февраль", "март", "апрель", "май", "июнь", "июль", "август", "сентябрь", "октябрь", "ноябрь", "декабрь" };
        int n = Convert.ToInt32(Console.ReadLine());
        var mounthN = from mounth in mounths
                      where mounth.Length == n
                      select mounth;
        foreach (var item in mounthN)
            Console.WriteLine(item);
        Console.WriteLine(new string('_', 25));
        var mounthLZ = from mounth in mounths
                       where mounth == "июнь" || mounth == "июнь" || mounth == "август" || mounth == "декабрь" || mounth == "январь" || mounth == "февраль"
                       select mounth;
        foreach (var item in mounthLZ)
            Console.WriteLine(item);
        Console.WriteLine(new string('_', 25));
        var mounthAlf = from mounth in mounths
                        orderby mounth
                        select mounth;
        foreach (var item in mounthAlf)
            Console.WriteLine(item);
        Console.WriteLine(new string('_', 25));
        var mounthCount = from mounth in mounths
                          where mounth.Length >= 4 && mounth.Contains("а")
                          select mounth;
        foreach (var item in mounthCount)
            Console.WriteLine(item);
        Console.WriteLine(new string('_', 25));
        List<Figure> figures = new List<Figure>()
        {
        new Figure("Kvadr", 4, 4),
        new Figure("Kvadr", 7, 7),
        new Figure("Kvadr", 3, 3),
        new Figure("Pryam", 4, 5),
        new Figure("Pryam", 6, 5),
        new Figure("Pryam", 6, 3),
        new Figure("Pryam", 6, 8),
        new Figure("Kvadr", 5, 5),
        new Figure("Romb", 4, 4),
        };




        Console.WriteLine(new string('_', 25));
        var figuresByType = from figure in figures
                            group figure by figure.type
                           into g
                            select new { Type = g.Key, Count = g.Count() };
        foreach (var group in figuresByType)
            Console.WriteLine($"{group.Type} : {group.Count}");
        Console.WriteLine(new string('_', 25));
        var KvbyArea = from figure in figures
                           where figure.type == "Kvadr"
                           select figure.Area;
        int Kvmax = KvbyArea.Max();
        int Kvmin = KvbyArea.Min();
        Console.WriteLine("Квадрат max - "+Kvmax+"\nКвадрат min - "+Kvmin);
        Console.WriteLine(new string('_', 25));
        int x = Convert.ToInt32(Console.ReadLine());
        Figure[] kvmas = figures.Where(fig => fig.A < x && fig.B==fig.A).ToArray();
        for(int i = 0; i < kvmas.Length;i++)
            Console.WriteLine("Квадрат - " + kvmas[i].A);
        Console.WriteLine(new string('_', 25));
        var Rect = figures.Where(fig => fig.type == "Pryam").OrderBy(fig=>fig.Area);

        foreach(var item in Rect)
            Console.WriteLine("Прямоугольник "+ item.Area);
        Console.WriteLine(new string('_', 25));
        Figure f1 = new Figure("kek ", 4, 3);
        Figure[] arr = figures.Where(fig => fig.A > 5).Prepend(f1).Skip(2).Where(fig => fig.Area > 10).ToArray();
        foreach (var item in arr)
        {
            Console.WriteLine("тип - "+item.type+ " стороны :" + item.A + " ,"+item.B +", площадь "+ item.Area);
        }

        Console.WriteLine(new string('_', 25));
        List<FigureType> figtype = new List<FigureType>()
        {
            new FigureType { type = "Kvadr", count =5 },
            new FigureType { type = "Pryam", count =4 }
        };

        var result = from fig in figures
                     join ft in figtype on fig.type equals ft.type
                     select new { Type = fig.type, Area = fig.Area, Count = ft.count };

        foreach (var item in result)
            Console.WriteLine($"{item.Type} - {item.Area} ({item.Count})");

        Console.WriteLine(new string('_', 25));
    }
    


    class Figure
    {
        public string type { get; set; }
        int a;
        int b;
        int area;

        public int A { get { return a; } set { a = value; } }
        public int B { get { return b; } set { b = value; } }
        public int Area { get { return area; } set { area = value; } }

        public Figure(string _type, int _a, int _b)
        {
            this.type = _type;
            this.a = _a;
            this.b = _b;
            this.area =a*b;
        }
    }

    class FigureType
    {
        public string type { get; set; }
        public int count { get; set; }


    }
    class Player
    {
        public string Name { get; set; }
        public string Team { get; set; }
    }
    class Team
    {
        public string Name { get; set; }
        public string Country { get; set; }
    }

}