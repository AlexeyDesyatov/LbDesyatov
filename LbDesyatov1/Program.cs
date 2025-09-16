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
            Console.WriteLine("Введите текст (несколько предложений):");
            string input = Console.ReadLine();
            string temp;

            // Разбиваем текст на слова по пробелам
            string[] words = input.Split(' ');
            char[] letter = input.ToCharArray();
            string newletter = "";

            for (int i = 0; i < input.Length; i++)
            {
                // Меняем местами слова i и i+1
                if (i < input.Length - 1)
                {
                    if ((input[i] == 'ж' || input[i] == 'ш') && input[i + 1] == 'ы')
                    {
                        newletter += input[i];
                        newletter += 'и';
                        i++;
                        continue;
                    }

                    if ((input[i] == 'ч' || input[i] == 'щ') && input[i + 1] == 'я')
                    {
                        newletter += input[i];
                        newletter += 'а';
                        i++;
                        continue;
                    }
                    if ((input[i] == 'ч' || input[i] == 'щ') && input[i + 1] == 'ю')
                    {
                        newletter += input[i];
                        newletter += 'у';
                        i++;
                        continue;
                    }
                }
                newletter += input[i];

            }
            // Меняем местами каждые два соседних слова
            for (int i = 0; i < words.Length - 1; i += 2)
            {
                // Меняем местами слова i и i+1

                temp = words[i];
                words[i] = words[i + 1];
                words[i + 1] = temp;
            }

            // Собираем результат обратно в строку
            string result = string.Join(" ", words);

            Console.WriteLine("\nРезультат:");
            Console.WriteLine("\nМеняем местами слова:");
            Console.WriteLine(result);
            Console.WriteLine("\nПроверка правописания:");
            Console.WriteLine(newletter);
            Console.ReadKey(); // Ждём нажатия клавиши
        }
    }
}
