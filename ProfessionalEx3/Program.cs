//Завдання 3

//Створіть програму, яка може бути запущена лише в одному екземплярі (використовуючи іменований Mutex).
namespace ProfessionalEx3
{
    internal class Program
    {
        static Mutex mutex;
        static void Main(string[] args)
        {
            mutex= new Mutex(false, "MyMutex");
            for(int i=0;i<3;i++)
            {
                new Thread(SomeMethod).Start("New thread"+ i+1);
            }
            Console.ReadKey();
        }

        static void SomeMethod(object state)
        {
            mutex.WaitOne();
            string words = state as string;
            Console.WriteLine(words);
            Console.WriteLine(new string('-',80)); 
            Thread.Sleep(3000);
            mutex.ReleaseMutex();
        }
    }
}