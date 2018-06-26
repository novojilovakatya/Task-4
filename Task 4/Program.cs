using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_4
{
    class Program
    {

        /// <summary>
        /// Проверка ввода дробных чисел
        /// </summary>
        /// <returns>Целое дробных</returns>
        public static double ReadDoubly()
        {
            double k = 0; bool ok;
            do
            {
                ok = double.TryParse(Console.ReadLine(), out k);
                if (!ok || k < 0) Console.WriteLine("Неправильный ввод. Ожидалось дробное положительное число. Пожалуйста, повторите ввод");
            }
            while (!ok || k < 0);
            return k;
        }

        /// <summary>
        /// Вычисление функции при заданном значении
        /// </summary>
        /// <param name="x">Заданное значение</param>
        /// <returns>Результат</returns>
        static double f(double x)
        {
            return x * x - 1.3 * Math.Log(x + 0.5) - 2.8 * x + 1.15;
        }

        /// <summary>
        /// Метод хорд
        /// </summary>
        /// <param name="prev">Предыдущее значение</param>
        /// <param name="cur">Текущее значение</param>
        /// <param name="e">Точность</param>
        /// <returns>Результат</returns>
        static double MethodHord(double prev, double cur, double e)
        {
            double next = 0;
            do
            {
                double x = next;
                next = cur - f(cur) * (prev - cur) / (f(prev) - f(cur));
                prev = cur;
                cur = x;
            } while (Math.Abs(next - cur) > e);
            return next;
        }

        static void Main(string[] args)
        {
            // Границы
            double x0 = 2.1;
            double x1 = 2.5;
            // Ввод точности
            Console.Write("e = ");
            double e = ReadDoubly();
            // Нахождение результата
            double x = MethodHord(x0, x1, e);
            // Вывод
            Console.WriteLine(x);
            Console.ReadLine();
        }
    }
}
