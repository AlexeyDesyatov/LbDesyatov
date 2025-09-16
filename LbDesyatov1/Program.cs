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

            // 1. Создаем массив и заполняем его случайными числами
            Random rnd = new Random();
            int[] array = new int[10];

            Console.WriteLine("Исходный массив:");
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = rnd.Next(1, 100); // Случайные числа от 1 до 99
                Console.Write(array[i] + " ");
            }
            Console.WriteLine();

            // 2. Находим минимальный и максимальный элементы
            int min = array[0];
            int max = array[0];
            for (int i = 1; i < array.Length; i++)
            {
                if (array[i] < min) min = array[i];
                if (array[i] > max) max = array[i];
            }

            Console.WriteLine($"Минимальный элемент: {min}");
            Console.WriteLine($"Максимальный элемент: {max}");

            // 3. Считаем сумму всех элементов, кроме одного min и одного max
            int sum = 0;

            for (int i = 0; i < array.Length; i++)
            {
                sum += array[i];               
            }
            sum = sum - min - max;

            // 4. Вычисляем среднее арифметическое.
            // Количество учтенных элементов = длина массива - 2 (исключили min и max)
            double average = sum / (array.Length - 2);

            // 5. Выводим результат
            Console.WriteLine($"Среднее арифметическое без учета min и max: {average}");
            Console.Read();
            
        }
    }
}