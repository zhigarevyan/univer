using System;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Collections.Generic;
using System.Threading;
using System.Collections.Concurrent;

class Program
{

    static void Main(string[] args)
    {
        CancellationTokenSource ct = new CancellationTokenSource();
        CancellationToken token = ct.Token;
        Console.WriteLine("Введите N ");
        int Count = Convert.ToInt32(Console.ReadLine());
        Task<List<int>> t1 = new Task<List<int>>(() =>
        {
            List<int> Eratosfen = new List<int>();
            if (Eratosfen.Count != 0)
            {
                Eratosfen.Clear();
            }
            for (int i = 2; i < Count; i++)
            {
                Eratosfen.Add(i);
            }
            return Eratosfen;
        }
        );
        Task<List<int>> t2 = new Task<List<int>>(() =>
        {
            List<int> Eratosfen = t1.Result;
            for (int i = 2; Eratosfen[0] * i < Count; i++)
            {
                Eratosfen.Remove(Eratosfen[0] * i);
            }
            return Eratosfen;
        }
        );
        Task<List<int>> t3 = new Task<List<int>>(() =>
        {
            if (token.IsCancellationRequested)
            {
                Console.WriteLine("Прервали токеном");

            }
            List<int> Eratosfen = t1.Result;
            for (int i = 1; Eratosfen[i] * Eratosfen[i] < Count; i++)
            {
                for (int j = 2; j < Eratosfen.Count; j++)
                    Eratosfen.Remove(Eratosfen[i] * j);
            }
            return Eratosfen;
        }
        );

        Stopwatch sw = new Stopwatch();
        sw.Start();
        t1.Start();
        Console.WriteLine("Id - " + t1.Id + ", Status - " + t1.Status);
        t1.Wait();
        Console.WriteLine("Id - " + t1.Id + ", Status - " + t1.Status);
        t2.Start();
        t2.Wait();
        ct.Cancel();
        t3.Start();
        t3.Wait();
        sw.Stop();
        Console.WriteLine(sw.ElapsedMilliseconds + " ms");
        List<int> list = t3.Result;
        foreach (var item in list)
        {
            Console.WriteLine(item);
        }

        Console.WriteLine("Введите a ");
        int a = Convert.ToInt32(Console.ReadLine());

        Task<int> t4 = new Task<int>(() =>
       {
           return a;
       }
        );

        Task t5 = t4.ContinueWith(MethodContinueWith);
        t4.Start();
        t5.Wait();

        FillArr(0);
        Console.WriteLine(new string('_', 50));
        int[] arr = new int[1000000];
        Parallel.Invoke(
            () =>
            {
                Stopwatch stopwatch = new Stopwatch();                
                stopwatch.Start();
                for (int i = 0; i < 1000000; i++)
                {
                    arr[i] = i;
                }
                stopwatch.Stop();
                Console.WriteLine("Time in MS 1 " + stopwatch.ElapsedMilliseconds);
            },
            () => FillArr(1000000)
            );
        Console.WriteLine(new string('_', 50));
        ConcurrentBag<int> array = new ConcurrentBag<int>();

        Parallel.For(0, 100, i => array.Add(i));
        Parallel.ForEach(array, i => Console.WriteLine(i));

        Console.WriteLine(new string('_', 50));

    }



    static void FillArr(int a)
    {
        Stopwatch stopwatch = new Stopwatch();
        int[] arr = new int[a];
        stopwatch.Start();
        for (int i = 0; i < a; i++)
        {
            arr[i] = i;
        }
        stopwatch.Stop();
        Console.WriteLine($"Time in MS " + stopwatch.ElapsedMilliseconds);
    }
    static void MethodContinueWith(Task<int> t)
    {
        Console.WriteLine($"Квадрат {t.Result * t.Result}  куб  {t.Result * t.Result * t.Result} 4 степень {t.Result * t.Result * t.Result * t.Result}");
    }
}



