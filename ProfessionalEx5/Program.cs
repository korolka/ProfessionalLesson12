//Завдання 5

//Створіть Semaphore, що контролює доступу до ресурсу з кількох потоків. Організуйте впорядкований висновок інформації про отримання доступу до спеціального файлу *.log.
namespace ProfessionalEx5
{
    internal class Program
    {
        static Semaphore semaphore;
        static void Main(string[] args)
        {
            semaphore = new Semaphore(1, 4, "Mysemaphore");

            for(int i=0; i<10; i++)
            {
                new Thread(Method).Start();
                //Thread.Sleep(1000);
            }
        }

        static void Method(object state)
        {
            semaphore.WaitOne();
            StreamWriter streamWriter = new StreamWriter("result.log",true);
            streamWriter.WriteLine($"Semaphore catch method; ThreadID : {Thread.CurrentThread.ManagedThreadId}");
            streamWriter.WriteLine($"Semaphore let go method; ThreadID : {Thread.CurrentThread.ManagedThreadId}");
            streamWriter.WriteLine(new string('-',80));   
            streamWriter.Close();
            Console.WriteLine($"Semaphore catch method; ThreadID : {Thread.CurrentThread.ManagedThreadId}");
            Console.WriteLine($"Semaphore let go method; ThreadID : {Thread.CurrentThread.ManagedThreadId}");
            semaphore.Release();
        }

        
    }
}