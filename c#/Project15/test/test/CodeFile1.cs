using System;
using System.Collections.Concurrent;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static BlockingCollection<int> bc;

        static void seller()
        {
            for (int i = 0; i < 5; i++)
            {
                Thread.Sleep(3000);
                bc.Add(i);
                print();
                Thread.Sleep(6000);
            }
            bc.CompleteAdding();
        }

        static void print()
        {
            if (bc.IsCompleted)
            {
                Console.WriteLine("пустая");
            }
            foreach (var item in bc)
            {
                Console.WriteLine(item);
            }
        }

        static void consumer()
        {
            int i,b=0;
            while (b<10)
            {
                Thread.Sleep(3000);
                if (bc.TryTake(out i))
                {
                    Console.WriteLine("забрал товар: " + i);
                    print();
                    Thread.Sleep(3000);
                }
                else
                    Console.WriteLine("Ушел без товара");
                b++;
            }
        }
        static async void assmet()
        {
            await Task.Run(()=> ass());
        }
        static void ass()
        {
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine($"асинхронный вызов {i}");
                Thread.Sleep(2000);
            }
        }
        static void Main()
        {
            bc = new BlockingCollection<int>();
            assmet();
            Task Pr = new Task(seller);
            Task Cn = new Task(consumer);            
            Pr.Start();
            Cn.Start();
            Task.WaitAll(Cn, Pr);
              
        }
    }
}