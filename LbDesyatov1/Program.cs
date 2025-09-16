using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LbDesyatov1
{
    internal class Program
    {
        static double GetGeo(double b1, double q, int n)
        {
            return b1 * Math.Pow(q, n - 1);
        }

        static double GetSumGeo(double b1, double q, int n)
        {
            if (q == 1)
                return b1 * n;
            return b1 * (Math.Pow(q, n) - 1) / (q - 1);
        }

        static void Main(string[] args)
        {
            Console.WriteLine("=== Геометрическая прогрессия ===");

            Console.Write("Введите первый член (b1): ");
            double b1 = double.Parse(Console.ReadLine());

            Console.Write("Введите знаменатель (q): ");
            double q = double.Parse(Console.ReadLine());

            Console.Write("Введите количество членов (n): ");
            int n = int.Parse(Console.ReadLine());

            double nthTerm = GetGeo(b1, q, n);
            double sum = GetSumGeo(b1, q, n);

            Console.WriteLine($"\n{n}-й член прогрессии: {nthTerm}");
            Console.WriteLine($"Сумма первых {n} членов: {sum}");

            Console.WriteLine("\nНажмите любую клавишу...");
            Console.ReadKey();
        }
    }

}