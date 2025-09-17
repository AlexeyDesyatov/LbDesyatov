using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LbDesyatov1
{
    internal class Program
    {
        static double pow(double x, int n)
        {
            // Базовый случай: если n = 0, возвращаем 1
            if (n == 0)
                return 1;

            // Если n < 0, используем правило: x^n = 1 / x^|n|
            if (n < 0)
                return 1 / pow(x, -n);

            // Если n > 0, используем рекурсию: x^n = x * x^(n-1)
            return x * pow(x, n - 1);
        }

        static void Main()
        {
            // Примеры использования
            Console.WriteLine($"2^3 = {pow(2, 3)}");     // 8
            Console.WriteLine($"2^-2 = {pow(2, -2)}");   // 0.25
            Console.WriteLine($"5^0 = {pow(5, 0)}");     // 1
            Console.WriteLine($"3^-1 = {pow(3, -1)}");   // ~0.333...
            Console.Read();
        }
            
    }
}