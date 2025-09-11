using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LbDesyatov1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var numbers = new List<int>();

            Console.WriteLine("Введите положительные целые числа. Введите 0 для завершения:");

            while (true)
            {
                var line = Console.ReadLine();

                // Проверка на пустую строку
                if (string.IsNullOrWhiteSpace(line))
                {
                    Console.WriteLine("Пустой ввод. Введите число или 0 для завершения.");
                    continue;
                }

                if (!int.TryParse(line, out int num))
                {
                    Console.WriteLine("Неверный ввод. Введите целое положительное число или 0 для завершения.");
                    continue;
                }

                if (num == 0)
                {
                    // Завершение ввода
                    break;
                }

                if (num < 0)
                {
                    Console.WriteLine("Отрицательное число недопустимо. Введите положительное число или 0.");
                    continue;
                }

                // num > 0 — корректное положительное число
                numbers.Add(num);
            }

            if (numbers.Count == 0)
            {
                Console.WriteLine("Вы не ввели ни одного положительного числа.");
            }
            else
            {
                Console.WriteLine($"Минимальное число: {numbers.Min()}");
            }

            Console.WriteLine("Нажмите Enter для завершения.");
            Console.ReadLine();

        }
    }
}
