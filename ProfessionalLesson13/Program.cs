//Завдання 2

//Перетворіть приклад блокування подій таким чином, щоб замість ручної обробки використовувалася автоматична.
using System.Text;

namespace ProfessionalLesson13
{
    internal class Program
    {
        static AutoResetEvent auto = new AutoResetEvent(false);

        static void Main()
        {
            Console.OutputEncoding = Encoding.Unicode;
            new Thread(Function1).Start();
            new Thread(Function2).Start();

            Thread.Sleep(500);  // Дамо час запуститися вторинним потокам.

            Console.WriteLine("Натисніть будь-яку клавішу для переведення AutoResetEvent у сигнальний стан.\n");
            Console.ReadKey();
            auto.Set(); // Надсилає сигнал усім потокам.
            Thread.Sleep(500);
            Console.WriteLine("Натисніть будь-яку клавішу для переведення AutoResetEvent у сигнальний стан.\n");
            Console.ReadKey();
            auto.Set();
            // Delay
            Console.ReadKey();
        }

        static void Function1()
        {
            Console.WriteLine("Потік 1 запущений та очікує сигналу.");
            auto.WaitOne(); // Зупинка виконання вторинного потоку 1.
            Console.WriteLine("Потік 1 завершується.");
        }

        static void Function2()
        {
            Console.WriteLine("Потік 2 запущений та очікує сигналу.");
            auto.WaitOne(); // Зупинення виконання вторинного потоку 2.
            Console.WriteLine("Потік 2 завершується.");
        }
    }
}