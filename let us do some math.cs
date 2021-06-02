using System;

namespace NumericAnalysis
{

    public class IntegralCalculus
    {
        static public void Main(String[] args)
        {
            Console.WriteLine("Введите x1");
            double x1 = Convert.ToDouble(Console.ReadLine()); //получаем x1 и переводим из стринги в дабл. А можно сделать Console.WriteLine+Console.ReadLine+Convert всё в одну строку? Слишком много кода получается
            Console.WriteLine("Введите x2");
            double x2 = Convert.ToDouble(Console.ReadLine()); //получаем x2 и переводим из стринги в дабл А можно сделать Console.WriteLine+Console.ReadLine+Convert всё в одну строку? Слишком много кода получается
            Console.WriteLine("Введите погрешность");
            double precision = Convert.ToDouble(Console.ReadLine()); //получаем погрешность и переводим из стринги в дабл. А можно сделать Console.WriteLine+Console.ReadLine+Convert всё в одну строку? Слишком много кода получается

            Console.WriteLine(Calculate(Math.Sin, x1, x2, precision)); //вызываем наш метод с нашими параметрами
            Console.ReadLine(); 

        }
        static public double Calculate(Func<double, double> func, double x1, double x2, double precision) //метод нахождения площади
        {
            double part = 2; //количество частей трапеции
            double h = (x2 - x1) / part; //высота трапеции
            double integer = 0.5 * (x1 + x2) * h; //площадь трапеции
            double temp = 0; //промежуточная площадь
            double sum = 0; //итоговая суммарная площадь

            do
            {
                integer = temp;
                h = (x2-x1)/part;
                for (int i=0;i<(part/2); i++)
                    sum=sum+func((2 * i + 1)*h+x1);
                integer =h*sum;
                part=part * 2;
            }
            while(Math.Abs(integer-temp)>precision); // Math.Abs - модуль разницы


            return integer;

        }
    }
}










