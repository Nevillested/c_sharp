//ЭТАП 1
using System;

namespace C_sharp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Давай замерим скорость твоей печати. \r\nНапиши текст, который будет показан ниже. Если готов, жми enter");
            Console.ReadLine();
            int i = 1;
            do
            {
                Console.WriteLine("Шла Маша по Шоссе и сосала сушку.");
                DateTime startedAt = DateTime.Now;
                Console.ReadLine();
                TimeSpan span = DateTime.Now - startedAt;
                Console.WriteLine("Отлично, твоё время:");
                Console.WriteLine(span);
                Console.WriteLine("А теперь еще разок!\r\n");
            }
            while (i > 0);
        }
    }
}