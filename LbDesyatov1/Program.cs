using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace LbDesyatov1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine($"Напишите текст: ");
            string text = Console.ReadLine();


            Regex regex = new Regex(@"\bне\b");

            // Находим все совпадения
            MatchCollection matches = regex.Matches(text);

            // Выводим количество вхождений
            Console.WriteLine($"Количество вхождений предлога \"не\": {matches.Count}");


            Console.Read();

        }

    }
}
