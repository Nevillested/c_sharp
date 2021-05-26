//ЭТАП 4

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_sharp
{

class Program
    {
        public static Dictionary<string, string[]> dict = new Dictionary<string, string[]>(); //создаем словарь
        public static string keyy = "0";
        public static string[] options = new[] { "Шла Маша по Шоссе и сосала сушку.", "Бык тупогуб, тупогубенький бычок, у быка губа тупа.", "Во дворе трава, на траве дрова", "От топота копыт пыль по полю летит.", "Корабли лавировали, лавировали, да не вылавировали.", "Выдра в ведро от выдры нырнула. Выдра в ведре с водой утонула." }; //создание русского массива
        public static string[] options2 = new[] { "Two wrongs don't make a right.", "The pen is mightier than the sword.", "When in Rome, do as the Romans.", "The squeaky wheel gets the grease.", "When the going gets tough, the tough get going.", "No man is an island.", "Fortune favors the bold." }; //создание английского массива
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
        public static void vibor()
        {
            int x = 0;
            while (x < 1)
            {
                keyy = Console.ReadLine();
                if (keyy == "rus")
                {
                    dict.Add(keyy /*ключ*/, options); //добавляем элементы из массива в словарь
                    x = 2;
                }
                else if (keyy == "eng")
                {
                    dict.Add(keyy /*ключ*/, options2); //добавляем элементы из массива в словарь
                    x = 2;
                }
                else
                {
                    Console.WriteLine("Введите словарь: либо eng либо rus!"); // введите правильный ключ!
                }
            }
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Давай замерим скорость твоей печати. \r\nНапиши текст, который будет показан ниже. \r\nВыбери словарь (eng/rus):");
            vibor();
            do
            {
                Random rand = new Random(); //метод рандома
                int random = rand.Next(0, dict[keyy].Length); //метод рандома выбирает рандомный индекс наших текстов
                Console.WriteLine(dict[keyy][random]); // получаем значение
                DateTime startedAt = DateTime.Now;  //старт времени нашей писанины
                string stroka = Console.ReadLine(); // предложение ввести текст и присваивание тексту переменную stroka
                TimeSpan span = DateTime.Now - startedAt; //вычисляет время, за которое напечатан текст
                if (String.Compare(dict[keyy][random], stroka) == 0) //если ошибок нет, то...
                {
                    Console.WriteLine("Отлично, твоё время:" + (span) + "." + "Ошибок нет\r\n");
                }
                else //если ошибки есть, то...
                {
                    var s1 = dict[keyy][random];
                    var s2 = stroka;
                    Console.WriteLine("Количество ошибок: {0}", LevenshteinDistance(s1, s2) + ". Попробуйте снова\r\n");
                }
            }
            while (true);

        }
    }
}