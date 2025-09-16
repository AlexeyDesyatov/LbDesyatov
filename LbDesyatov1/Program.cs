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
            string text = @"Иванов И.И. – 195 см – 75 кг
Петров П.П. – 195 см – 85 кг
Сидоров С.С. – 178 см – 70 кг
Васечкин В.В. – 192 см – 80 кг";

            // Регулярное выражение для корректного захвата ФАМИЛИИ и РОСТА
            // ^(\w+) - Начало строки, захватываем одно или более словесных символов (Фамилия) в группу 1
            // .*? – - Любые символы (ленивый режим) до первого тире
            // \s*(\d+)\s*см – - Захватываем цифры роста в группу 2, затем "см –"
            string pattern = @"^(\w+).*?–\s*(\d+)\s*см\s*–";

            // Находим все совпадения, игнорируя регистр и обрабатывая многострочный текст
            MatchCollection matches = Regex.Matches(text, pattern, RegexOptions.Multiline | RegexOptions.IgnoreCase);

            Console.WriteLine("Фамилии лиц, чей рост превышает 190 см:");

            foreach (Match match in matches)
            {
                // Группа 1: Фамилия
                string lastName = match.Groups[1].Value;
                // Группа 2: Рост (преобразуем в число)
                int height = int.Parse(match.Groups[2].Value);

                // Проверяем условие: рост > 190 см
                if (height > 190)
                {
                    Console.WriteLine(lastName); // Выводим ТОЛЬКО фамилию
                }
            }
            Console.Read();
        }
    }
}