using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LbDesyatov1
{
    struct Baggage
    {
        public int itemCount;
        public double totalWeight;

        // Конструктор
        public Baggage(int count, double weight)
        {
            itemCount = count;
            totalWeight = weight;
        }

        // Метод для вывода информации о багаже
        public void PrintInfo()
        {
            double avgWeightPerItem = totalWeight / itemCount;
            Console.WriteLine($"Багаж: вещей - {itemCount}, общий вес - {totalWeight} кг, средний вес одной вещи - {avgWeightPerItem:F2} кг");
        }
    }

    class Program
    {
        static void Main()
        {
            // Создаем массив
            Baggage[] baggageList = new Baggage[10]
            {
            new Baggage(2, 13.0),
            new Baggage(3, 15.6),
            new Baggage(1, 10.5),
            new Baggage(4, 22.0),
            new Baggage(2, 8.0),
            new Baggage(5, 25.0),
            new Baggage(3, 12.0),
            new Baggage(1, 3.7),
            new Baggage(2, 9.0),
            new Baggage(3, 16.0)
            };

            // Вычисляем общий средний вес одной вещи по всему списку
            double totalItems = 0;
            double totalWeight = 0;

            foreach (Baggage baggage in baggageList)
            {
                totalItems += baggage.itemCount;
                totalWeight += baggage.totalWeight;
            }

            double globalAverageWeight = totalWeight / totalItems;
            Console.WriteLine($"Общий средний вес одной вещи по всему списку: {globalAverageWeight:F2} кг");
            Console.WriteLine();

            // Шаг 2: Находим багаж
            Console.WriteLine("Багаж, соответствующий условию (разница <= 0.3 кг):");

            for (int i = 0; i < baggageList.Length; i++)
            {

                double localAverage = baggageList[i].totalWeight / baggageList[i].itemCount;
                double difference = Math.Abs(localAverage - globalAverageWeight);

                if (difference <= 0.3)
                {
                    Console.WriteLine($"Пассажир {i + 1}:");
                    baggageList[i].PrintInfo();
                    Console.WriteLine($"  Разница от общего среднего: {difference:F2} кг");
                    Console.WriteLine();
                }

            }

            Console.ReadLine();
        }
    }

}