//ЭТАП 3

using System;

namespace C_sharp
{
    class Program
    {
        static int Minimum(int a, int b, int c) => (a = a < b ? a : b) < c ? a : c; //получение минимального из трех расстояния Левенштейна
        static int LevenshteinDistance(string firstWord, string secondWord) //Итеративная реализация Левенштейна
        {
            var n = firstWord.Length + 1;
            var m = secondWord.Length + 1;
            var matrixD = new int[n, m];
            const int deletionCost = 1;
            const int insertionCost = 1;
            for (var i = 0; i < n; i++)
            {
                matrixD[i, 0] = i;
            }
            for (var j = 0; j < m; j++)
            {
                matrixD[0, j] = j;
            }
            for (var i = 1; i < n; i++)
            {
                for (var j = 1; j < m; j++)
                {
                    var substitutionCost = firstWord[i - 1] == secondWord[j - 1] ? 0 : 1;
                    matrixD[i, j] = Minimum(matrixD[i - 1, j] + deletionCost,
                                            matrixD[i, j - 1] + insertionCost,
                                            matrixD[i - 1, j - 1] + substitutionCost);
                }
            }
            return matrixD[n - 1, m - 1];
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Давай замерим скорость твоей печати. \r\nНапиши текст, который будет показан ниже. Если готов, жми enter");
            Console.ReadLine();
            string[] options = new[] { "Шла Маша по Шоссе и сосала сушку.", "Бык тупогуб, тупогубенький бычок, у быка губа тупа.", "Во дворе трава, на траве дрова", "От топота копыт пыль по полю летит.", "Корабли лавировали, лавировали, да не вылавировали.", "Выдра в ведро от выдры нырнула. Выдра в ведре с водой утонула." }; //наши тексты
            Random rand = new Random(); //метод рандома
            int i = 1;
            do
            {
                int random = rand.Next(0, options.Length); //метод рандома выбирает рандомный индекс наших текстов
                Console.WriteLine(options[random]); // печатает нам в консоль текст, который он рандомно выбрал
                DateTime startedAt = DateTime.Now;  //старт времени нашей писанины
                string stroka = Console.ReadLine(); // предложение ввести текст и присваивание тексту переменную stroka
                TimeSpan span = DateTime.Now - startedAt; //вычисляет время, за которое напечатан текст
                if (String.Compare(options[random], stroka) == 0)
                {
                    Console.WriteLine("Отлично, твоё время:" + (span) + "." + "Ошибок нет\r\n");
                }
                else
                {
                    var s1 = options[random];
                    var s2 = stroka;
                    Console.WriteLine("Количество ошибок: {0}", LevenshteinDistance(s1, s2) + ". Попробуйте снова\r\n");
                }
            }
            while (i > 0);


        }
    }
}