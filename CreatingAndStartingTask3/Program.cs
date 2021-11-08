using System;
using System.Threading;
using System.Threading.Tasks;

namespace CreatingAndStartingTask3
{
    class Program
    {
        static void Main(string[] args)
        {
            var task1 = Task.Factory.StartNew(() =>
            {
                Thread.Sleep(2000);
                Console.WriteLine($"Task 1 completed on Task:{Task.CurrentId}");
            });
            Console.WriteLine($"Before task1.Wait() on Task:{Task.CurrentId}");
            // task1 tamamlanana kadar main thread bekleyecek.
            task1.Wait();
            Console.WriteLine($"After task1.Wait() on Task:{Task.CurrentId}");


            var task2 = Task.Factory.StartNew(() =>
            {
                Thread.Sleep(3000);
                Console.WriteLine($"Task 2 completed on Task:{Task.CurrentId}");
            });


            var task3 = Task.Factory.StartNew(() =>
            {
                Thread.Sleep(5000);
                Console.WriteLine($"Task 3 completed on Task:{Task.CurrentId}");
            });
            Console.WriteLine($"Before Task.WaitAll(task2,task3) on Task:{Task.CurrentId}");
            // task2 ve task3 tamamlanana kadar main thread bekleyecek.
            Task.WaitAll(task2, task3);
            Console.WriteLine($"After Task.WaitAll(task2,task3) on Task:{Task.CurrentId}");


            var task4 = Task.Factory.StartNew(() =>
            {
                Thread.Sleep(1500);
                Console.WriteLine($"Task 4 completed on Task:{Task.CurrentId}");
            });

            var task5 = Task.Factory.StartNew(() =>
            {
                Thread.Sleep(1000);
                Console.WriteLine($"Task 5 completed on Task:{Task.CurrentId}");
            });
            // task4 veya task5 ten herhangi biri tamamlanana kadar main thread bekleyecek.
            Task.WaitAny(task4, task5);

            Console.WriteLine($"End of program on Task:{Task.CurrentId}");
            Console.ReadKey();

        }
    }
}
