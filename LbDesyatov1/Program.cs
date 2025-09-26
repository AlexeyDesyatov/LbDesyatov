using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace LbDesyatov1
{
    struct Aeroflot
    {
        public string dist;
        public int number;
        public string plane;

        // Конструктор
        public Aeroflot(string name, int count, string type)
        {
            dist = name;
            number = count;
            plane = type;
        }

        // Метод для вывода информации о багаже
        public void PrintInfo()
        {
            Console.WriteLine($"Пункт назначения: - {dist}, Номер рейса - {number}, Тип самаолета - {plane}");
        }
    }

    class Program
    {
        static async Task Main()
        {
            // Создаем массив

            Aeroflot[] PlaneList = new Aeroflot[7];

            Console.WriteLine("Исходный массив:");

            Console.WriteLine("Введите 7 строк в формате: Пункт,Номер,Тип (например: Москва,100,Boeing)");
            for (int i = 0; i < PlaneList.Length; i++)
            {
                string line = Console.ReadLine();
                string[] parts = line.Split(',');
                PlaneList[i] = new Aeroflot(parts[0], int.Parse(parts[1]), parts[2]);
            }

            string filePath = @"C:\Users\avd55\Desktop\Note.txt";
            string output ="";
            for (int i = 0; i < PlaneList.Length; i++)
            {
                output += $"Рейс-{i + 1}\n";
                output += $"Город: {PlaneList[i].dist}\n";
                output += $"Номер рейса: {PlaneList[i].number}\n";
                output += $"Тип самолета: {PlaneList[i].plane}\n";
                output += "\n"; 
            }

            using (FileStream fstream = new FileStream(filePath, FileMode.OpenOrCreate))
            {
                // преобразуем строку в байты 

                byte[] array = System.Text.Encoding.UTF8.GetBytes(output);

                // запись массива байтов в файл
                fstream.Write(array, 0, array.Length);
                Console.WriteLine("Текст записан в файл");
 
            }
            // ЧТЕНИЕ ИЗ ФАЙЛА

            string text;
            using (StreamReader reader = new StreamReader(filePath, Encoding.UTF8))
            {
                text = await reader.ReadToEndAsync();
                Console.WriteLine(text);

            }
            Console.Write("\nВведите тип самолёта для поиска: ");
            string searchPlane = Console.ReadLine();

            string pattern =
                @"Город:\s*(?<city>.+?)\r?\n" +
                @"Номер рейса:\s*(?<number>\d+)\r?\n" +
                $@"Тип самолета:\s*{searchPlane}";

            var matches = Regex.Matches(text, pattern, RegexOptions.Multiline);

            if (matches.Count > 0)
            {
                Console.WriteLine($"\nНайдены рейсы для самолёта '{searchPlane}':");
                var flights = new (string city, string number)[matches.Count];
                for (int i = 0; i < matches.Count; i++)
                {
                    flights[i] = (
                        matches[i].Groups["city"].Value,
                        matches[i].Groups["number"].Value
                    );
                }

                // Сортируем по городу (алфавит)
                Array.Sort(flights, (a, b) => string.Compare(a.city, b.city, StringComparison.Ordinal));

                // Выводим
                foreach (var trip in flights)
                {
                    Console.WriteLine($"Пункт назначения: {trip.city}, Номер рейса: {trip.number}");
                }
            }
            else
            {
                Console.WriteLine($"\nРейсов для самолёта '{searchPlane}' не найдено.");
            }

            Console.WriteLine("\nНажмите любую клавишу для выхода...");
            Console.ReadKey();



        }

    }
       
}

