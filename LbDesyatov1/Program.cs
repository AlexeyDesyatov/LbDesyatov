using System;
using System.IO;
using System.Text.Json;

namespace LbDesyatov1
{
    public class Aeroflot
    {
        public string dist { get; set; } = string.Empty;
        public int number { get; set; }
        public string plane { get; set; } = string.Empty;

        // Конструктор без параметров — обязателен для десериализации
        public Aeroflot() { }

        // Основной конструктор
        public Aeroflot(string name, int count, string type)
        {
            dist = name;
            number = count;
            plane = type;
        }

        public void PrintInfo()
        {
            Console.WriteLine($"Пункт назначения: {dist}, Номер рейса: {number}, Тип самолета: {plane}");
        }
    }

    class Program
    {
        static void Main()
        {
            const int SIZE = 7;
            Aeroflot[] PlaneList = new Aeroflot[SIZE];

            Console.WriteLine("Исходный массив:");
            Console.WriteLine("Введите 7 строк в формате: Пункт,Номер,Тип (например: Москва,100,Boeing)");

            for (int i = 0; i < SIZE; i++)
            {
                string line = Console.ReadLine();
                string[] parts = line.Split(',');
                if (parts.Length < 3)
                {
                    Console.WriteLine("Неверный формат. Используется пустой рейс.");
                    PlaneList[i] = new Aeroflot();
                }
                else
                {
                    PlaneList[i] = new Aeroflot(parts[0], int.Parse(parts[1]), parts[2]);
                }
            }

            string jsonPath = @"C:\Users\avd55\Desktop\Note.json";

            // СЕРИАЛИЗАЦИЯ В JSON 
            string jsonString = JsonSerializer.Serialize(PlaneList);
            File.WriteAllText(jsonPath, jsonString);
            Console.WriteLine($"Данные записаны в JSON-файл: {jsonPath}");

            // ДЕСЕРИАЛИЗАЦИЯ ИЗ JSON 
            string loadedJson = File.ReadAllText(jsonPath);
            Aeroflot[] loadedFlights = JsonSerializer.Deserialize<Aeroflot[]>(loadedJson);

            // ВЫВОД ВСЕХ РЕЙСОВ 
            Console.WriteLine("\nВсе рейсы:");
            for (int i = 0; i < loadedFlights.Length; i++)
            {
                Console.WriteLine($"Рейс-{i + 1}");
                loadedFlights[i].PrintInfo();
                Console.WriteLine();
            }

            // ПОИСК И СОРТИРОВКА 
            Console.Write("\nВведите тип самолёта для поиска: ");
            string planeType = Console.ReadLine();

            // Собираем подходящие рейсы
            Aeroflot[] matchingFlights = new Aeroflot[loadedFlights.Length];
            int count = 0;

            for (int i = 0; i < loadedFlights.Length; i++)
            {
                if (string.Equals(loadedFlights[i].plane, planeType))
                {
                    matchingFlights[count] = loadedFlights[i];
                    count++;
                }
            }

            if (count == 0)
            {
                Console.WriteLine($"Рейсов с типом самолёта '{planeType}' не найдено.");
            }
            else
            {
                // Обрезаем до реального количества
                Aeroflot[] filteredFlights = new Aeroflot[count];
                Array.Copy(matchingFlights, filteredFlights, count);

                // Сортировка по алфавиту пункта назначения 
                for (int i = 0; i < count - 1; i++)
                {
                    for (int j = i + 1; j < count; j++)
                    {
                        if (string.Compare(filteredFlights[i].dist, filteredFlights[j].dist) > 0)
                        {
                            Aeroflot temp = filteredFlights[i];
                            filteredFlights[i] = filteredFlights[j];
                            filteredFlights[j] = temp;
                        }
                    }
                }

                Console.WriteLine($"\nРейсы для самолёта типа '{planeType}', отсортированные по пункту назначения:");
                for (int i = 0; i < count; i++)
                {
                    filteredFlights[i].PrintInfo();
                }
            }

            Console.WriteLine("\nНажмите любую клавишу для выхода...");
            Console.ReadKey();
        }
    }
}