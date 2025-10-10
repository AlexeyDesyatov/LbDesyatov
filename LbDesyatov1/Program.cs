using System;
using System.IO;
using System.Xml.Serialization;
using System.Text;

namespace LbDesyatov1
{

    public class Aeroflot
    {
        // XmlSerializer сериализует только public свойства (не поля!)
        public string dist { get; set; }
        public int number { get; set; }
        public string plane { get; set; }

        //конструктор без параметров
        public Aeroflot() { }

        // Ваш конструктор
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
                PlaneList[i] = new Aeroflot(parts[0], int.Parse(parts[1]), parts[2]);
            }

            string xmlPath = @"C:\Users\avd55\Desktop\Note.xml";

            // === СЕРИАЛИЗАЦИЯ В XML ===
            // Передаем в конструктор тип класса Person и получаем поток куда сохраняем в файл

            XmlSerializer serializer = new XmlSerializer(typeof(Aeroflot[]));
            using (FileStream fs = new FileStream(xmlPath, FileMode.OpenOrCreate))
            {
                serializer.Serialize(fs, PlaneList);
            }
            Console.WriteLine("Данные записаны в XML-файл.");

            // === ДЕСЕРИАЛИЗАЦИЯ ИЗ XML ===
            Aeroflot[] loadedFlights;
            using (FileStream fs = new FileStream(xmlPath, FileMode.Open))
            {
                loadedFlights = (Aeroflot[])serializer.Deserialize(fs);
            }

            // === ВЫВОД ВСЕХ РЕЙСОВ ===
            Console.WriteLine("\nВсе рейсы:");
            for (int i = 0; i < loadedFlights.Length; i++)
            {
                Console.WriteLine($"Рейс-{i + 1}");
                loadedFlights[i].PrintInfo();
                Console.WriteLine();
            }

            // === ПОИСК ПО ТИПУ САМОЛЁТА ===
            Console.Write("\nВведите тип самолёта для поиска: ");
            string searchPlane = Console.ReadLine();

            // Собираем найденные рейсы
            Aeroflot[] foundFlights = new Aeroflot[loadedFlights.Length];
            int foundCount = 0;

            foreach (var flight in loadedFlights)
            {
                if (flight.plane == searchPlane)
                {
                    foundFlights[foundCount] = flight;
                    foundCount++;
                }
            }

            if (foundCount == 0)
            {
                Console.WriteLine($"\nРейсов для самолёта '{searchPlane}' не найдено.");
            }
            else
            {
                // Обрезаем массив до нужного размера
                Array.Resize(ref foundFlights, foundCount);

                // Сортируем по пункту назначения (алфавит)
                Array.Sort(foundFlights, (a, b) => string.Compare(a.dist, b.dist, StringComparison.Ordinal));

                Console.WriteLine($"\nНайдены рейсы для самолёта '{searchPlane}':");
                foreach (var f in foundFlights)
                {
                    Console.WriteLine($"Пункт назначения: {f.dist}, Номер рейса: {f.number}");
                }
            }

            Console.WriteLine("\nНажмите любую клавишу для выхода...");
            Console.ReadKey();
        }
    }
}