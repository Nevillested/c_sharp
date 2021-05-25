//ЭТАП 2

using System;

namespace C_sharp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Давай замерим скорость твоей печати. \r\nНапиши текст, который будет показан ниже. Если готов, жми enter");
            Console.ReadLine();
            string[] options = new[] { "Шла Маша по Шоссе и сосала сушку.", "Бык тупогуб, тупогубенький бычок, у быка губа тупа.", "Во дворе трава, на траве дрова", "От топота копыт пыль по полю летит.", "Корабли лавировали, лавировали, да не вылавировали.", "Выдра в ведро от выдры нырнула. Выдра в ведре с водой утонула." };
            Random rand = new Random();
            int i = 1;
            do
            {
                int random = rand.Next(0, options.Length);
                Console.WriteLine(options[random]);
                DateTime startedAt = DateTime.Now;
                Console.ReadLine();
                TimeSpan span = DateTime.Now - startedAt;
                Console.WriteLine("Отлично, твоё время:");
                Console.WriteLine(span);
            }
            while (true);
        }
    }
}