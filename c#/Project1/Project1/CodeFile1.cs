using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
public class Program
{
    private const int V = 0;

    public static void Main()
    {
        int a = 2;
        char c = 'h';
        string lol2 = "";
        string lol3 = null;
        string lol = "Yan";
        string lol1 = "zhigarev";
        object o = a;
        object ca = c;
        object kek = lol;
        System.Int16 nomer = 6;
        System.Int32 oo = nomer;
        Console.WriteLine($"a = {(int)o}  \n c = {(char)ca} \n  my name = {lol} \n");
        string ooi = string.Format("my name is {0}", lol);
        Console.WriteLine(ooi);
        Console.WriteLine(ca.GetType());
        Console.WriteLine($"{lol.CompareTo(lol1)}   {lol.Contains(lol1)}    {lol1.Substring(0,3)}    {lol.Insert(3,lol1)}");

        Console.WriteLine(string.IsNullOrEmpty(lol2));
        Console.WriteLine(string.IsNullOrEmpty(lol3));
        
        
        Console.WriteLine(Myfun((2,5)));

        checke();
        checke1();
    }
    public static int Myfun((int, int) s)
    {
       return s.Item1+s.Item2;
    }
    public static void checke()
    {
        checked
        {
            System.Int16 a1 = 32767;
            Console.WriteLine(a1);
        }
    }
    public static void checke1()
    {
        unchecked
        {
            System.Int16 a1 = 32767;
            Console.WriteLine(a1++);
        }
    }
}
