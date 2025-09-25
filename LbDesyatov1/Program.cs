using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
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
        static void Main()
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

                byte[] array = System.Text.Encoding.Default.GetBytes(output);

                // запись массива байтов в файл
                fstream.Write(array, 0, array.Length);
                Console.WriteLine("Текст записан в файл");
 
            }
            // === ЧТЕНИЕ ИЗ ФАЙЛА И ВЫВОД НА ЭКРАН ===
            string fileContent;
            using (FileStream fs = File.OpenRead(filePath))
            {
                byte[] buffer = new byte[fs.Length];
                fs.Read(buffer, 0, buffer.Length);
                fileContent = Encoding.Default.GetString(buffer);
            }

            string[] lines = fileContent.Split(new[] { '\n' }, StringSplitOptions.RemoveEmptyEntries);
            foreach (string line in lines)
            {
                Console.WriteLine(line); // просто выводим каждую строку как есть
            }
            Console.WriteLine("=== Данные из файла ===");
            Console.WriteLine(fileContent);
            Console.WriteLine("========================");
            Console.WriteLine($"Файл сохранён по пути: {filePath}");
            Console.Read();
        }

    }
       
}

