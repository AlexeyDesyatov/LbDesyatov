using System;
using System.IO;
using System.Xml.Serialization;
using System.Text;

namespace LbDesyatov1
{

    public class Aeroflot
    {

        public string dist { get; set; }
        public int number { get; set; }
        public string plane { get; set; }

        //\\\конструктор без параметров
        public Aeroflot()
        {
            dist = string.Empty;
            plane = string.Empty;
        }
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

            // СЕРИАЛИЗАЦИЯ В XML 

            XmlSerializer serializer = new XmlSerializer(typeof(Aeroflot[]));
            using (FileStream fs = new FileStream(xmlPath, FileMode.Create))
            {
                serializer.Serialize(fs, PlaneList);
            }
            Console.WriteLine("Данные записаны в XML-файл.");

            //  ДЕСЕРИАЛИЗАЦИЯ ИЗ XML 
            Aeroflot[] loadedFlights;
            using (FileStream fs = new FileStream(xmlPath, FileMode.Open))
            {
                loadedFlights = (Aeroflot[])serializer.Deserialize(fs);
            }

            // ВЫВОД ВСЕХ РЕЙСОВ 
            Console.WriteLine("\nВсе рейсы:");
            for (int i = 0; i < loadedFlights.Length; i++)
            {
                Console.WriteLine($"Рейс-{i + 1}");
                loadedFlights[i].PrintInfo();
                Console.WriteLine();
            }

            // Сортировка
            Console.Write("\nВведите тип самолёта для поиска: ");
            string planeType = Console.ReadLine();

            // Поиск по типу самолета
            Aeroflot[] matchingFlights = new Aeroflot[loadedFlights.Length];
            int count = 0;

            for (int i = 0; i < loadedFlights.Length; i++)
            {
                if (string.Equals(loadedFlights[i].plane, planeType, StringComparison.OrdinalIgnoreCase))
                {
                    matchingFlights[count] = loadedFlights[i];
                    count++;
                }
            }
            {
                // Обрезаем до реального количества
                Aeroflot[] filteredFlights = new Aeroflot[count];
                for (int i = 0; i < count; i++)
                {
                    filteredFlights[i] = matchingFlights[i];
                }

                // Сортировка по алфавиту пункта назначения (пузырьком)
                for (int i = 0; i < count - 1; i++)
                {
                    for (int j = i + 1; j < count; j++)
                    {
                        if (string.Compare(filteredFlights[i].dist, filteredFlights[j].dist, StringComparison.OrdinalIgnoreCase) > 0)
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