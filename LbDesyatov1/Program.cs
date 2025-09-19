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
            Console.WriteLine($"Пункт назначения: - {dist}, Номер рейса - {number} кг, Тип самаолета - {plane} кг");
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

            for (int i = 1; i < PlaneList.Length; i++)
            {
                Console.WriteLine($"Багаж {i}");
                input1 = Console.ReadLine();
                input2 = int.Parse(Console.ReadLine());
                input3 = Console.ReadLine();
                PlaneList[i] = new Aeroflot(input1, input2, input3);

            }

            string filePath = @"C:\Users\avd55\Desktop\Note.txt";
            string output ="";
            for (int i = 0; i < PlaneList.Length; i++)
            {
                output += PlaneList[i].dist + "|" + PlaneList[i].number + "|" + PlaneList[i].plane + "\n";
            }

            using (FileStream fstream = new FileStream(filePath, FileMode.OpenOrCreate))
            {
                // преобразуем строку в байты 

                byte[] array = System.Text.Encoding.Default.GetBytes(output);

                // запись массива байтов в файл
                fstream.Write(array, 0, array.Length);
                Console.WriteLine("Текст записан в файл");

 
            }


        }
    }   
}

