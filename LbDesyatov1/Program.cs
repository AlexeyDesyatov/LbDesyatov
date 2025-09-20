using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LbDesyatov1
{
    internal class Program
    {
        public static string SolveQuadratic(double a, double b, double c)
        {
            if (a == 0)
                return "Ошибка: коэффициент 'a' не может быть нулём (это не квадратное уравнение).";

            double discriminant = b * b - 4 * a * c;

            if (discriminant > 0)
            {
                double x1 = (-b + Math.Sqrt(discriminant)) / (2 * a);
                double x2 = (-b - Math.Sqrt(discriminant)) / (2 * a);
                return $"Уравнение имеет два корня:\nx1 = {x1}\nx2 = {x2}";
            }
            else if (discriminant == 0)
            {
                double x = -b / (2 * a);
                return $"Уравнение имеет один корень:\nx = {x}";
            }
            else
            {
                return "Уравнение не имеет действительных корней (дискриминант < 0).";
            }
        }

        static void Main()
        {
            Console.WriteLine("=== Решение квадратного уравнения ax2 + bx + c = 0 ===\n");

            // Тест 1: Два корня
            Console.WriteLine("Тест 1: x2 - 5x + 6 = 0");
            Console.WriteLine(SolveQuadratic(1, -5, 6));
            Console.WriteLine();

            // Тест 2: Один корень
            Console.WriteLine("Тест 2: x2 - 4x + 4 = 0");
            Console.WriteLine(SolveQuadratic(1, -4, 4));
            Console.WriteLine();

            // Тест 3: Нет действительных корней
            Console.WriteLine("Тест 3: x2 + x + 1 = 0");
            Console.WriteLine(SolveQuadratic(1, 1, 1));
            Console.WriteLine();

            // Тест 4: Ошибка — a = 0
            Console.WriteLine("Тест 4: 0x2 + 2x + 3 = 0");
            Console.WriteLine(SolveQuadratic(0, 2, 3));
            Console.WriteLine();
            Console.Read();

  
        }
    }
}