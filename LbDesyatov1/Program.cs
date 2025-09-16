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
            Console.WriteLine("=== Задача 8.16: Сумма максимальных элементов строк матрицы ===\n");

            // Ввод размеров матрицы
            Console.Write("Введите количество строк (n): ");
            int n = int.Parse(Console.ReadLine());
            Console.Write("Введите количество столбцов (m): ");
            int m = int.Parse(Console.ReadLine());

            // Объявление матрицы
            double[,] matrix = new double[n, m];
            Random rnd = new Random(); 

            Console.WriteLine("\nИсходная матрица:");

            // Заполнение матрицы случайными числами и вывод
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    matrix[i, j] = Math.Round((rnd.Next(-50, 50) + rnd.NextDouble()), 2); 
                    Console.Write($"{matrix[i, j],8} ");
                }
                Console.WriteLine();
            }

            // Инициализация суммы максимальных элементов строк
            double sumMax = 0;

            // Проход по каждой строке
            for (int i = 0; i < n; i++)
            {
                // Предполагаем, что первый элемент строки — максимальный
                double rowMax = matrix[i, 0];

                // Поиск максимального элемента в текущей строке
                for (int j = 1; j < m; j++)
                {
                    if (matrix[i, j] > rowMax)
                    {
                        rowMax = matrix[i, j];
                    }
                }

                // Добавляем найденный максимум строки к общей сумме
                sumMax += rowMax;
                Console.WriteLine($"Максимум в строке {i + 1}: {rowMax}");
            }

            // Вывод результата
            Console.WriteLine($"\nСумма наибольших значений элементов всех строк: {sumMax:F2}");

            Console.WriteLine("\nНажмите любую клавишу для выхода...");
            Console.ReadKey();
        }
    }
}
