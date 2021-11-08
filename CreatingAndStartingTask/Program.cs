using System;
using System.Threading.Tasks;

namespace CreatingAndStartingTask
{
    class Program
    {
        static void DoWork(string message)
        {
            for (int i = 0; i < 1000; i++)
            {
                Console.Write(message);
            }
        }


        static void Main(string[] args)
        {
            // Yeni bir task instance ı oluşturup. Action parametresine gönderdiğimiz DoWork methodunu anında çalıştırır.
            // StartNew methodu aslında iki iş yapar hem bir Task instance ı oluşturup geri döndürür hemde oluşturduğu instance üzerindeki Start methodunu çalıştırır.
            Task.Factory.StartNew(() =>
            {
                DoWork("T1");
                Console.WriteLine($"DoWork Completed for T1 on Task:{Task.CurrentId}");
            });

            // Instance ı kendimiz oluşturduğumuzda, action parametresindeki methodu çalıştırmaz. 
            // Oluşturduğumuz instancetaki Start methodunu tetiklediğimizde DoWork çalışacaktır.
            var task = new Task(() =>
            {
                DoWork("T2");
                Console.WriteLine($"DoWork Completed for T2 on Task:{Task.CurrentId}");
            });
            Console.WriteLine($"Main Thread Log 1 on Task:{Task.CurrentId}");
            // Task constructor' ı içerisinde tanımladığımız alttaki satırdan sonra çalışacaktır.
            task.Start();
            Console.WriteLine($"Main Thread Log 2 on Task:{Task.CurrentId}");
            Console.ReadKey();

        }
    }
}
