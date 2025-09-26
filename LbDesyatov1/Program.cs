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
            string input1;
            int input2;
            string input3;

            Aeroflot[] PlaneList = new Aeroflot[2];

            Console.WriteLine("Исходный массив:");

            for (int i = 0; i < PlaneList.Length; i++)
            {
                Console.WriteLine($"Пункт {i}");
                input1 = Console.ReadLine();
                Console.WriteLine($"Номер {i}");
                input2 = int.Parse(Console.ReadLine());
                Console.WriteLine($"Тип {i}");
                input3 = Console.ReadLine();
                PlaneList[i] = new Aeroflot(input1, input2, input3);

            }

            string filePath = @"C:\Users\avd55\Desktop\Note.txt";
            string output ="";
            for (int i = 0; i < PlaneList.Length; i++)
            {
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
            // === ЧТЕНИЕ ИЗ ФАЙЛА И ВЫВОД НА ЭКРАН ===
            
            using (StreamReader reader = new StreamReader(filePath, Encoding.UTF8))
            {
                string text = await reader.ReadToEndAsync();
                Console.WriteLine(text);

            }
            Console.Write("\nВведите тип самолёта для поиска: ");
            string searchPlane = Console.ReadLine();

            // Читаем весь файл
            string fileContent;
            using (StreamReader reader = new StreamReader(filePath, Encoding.UTF8))
            {
                fileContent = await reader.ReadToEndAsync();
            }


            string pattern =
                @"Город:\s*(?<city>.+?)\r?\n" +
                @"Номер рейса:\s*(?<number>\d+)\r?\n" +
                $@"Тип самолета:\s*{Regex.Escape(searchPlane)}";

            var matches = Regex.Matches(fileContent, pattern, RegexOptions.Multiline);

            if (matches.Count > 0)
            {
                Console.WriteLine($"\nНайдены рейсы для самолёта '{searchPlane}':");
                foreach (Match match in matches)
                {
                    string city = match.Groups["city"].Value;
                    string number = match.Groups["number"].Value;
                    Console.WriteLine($"Пункт назначения: {city}, Номер рейса: {number}");
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

