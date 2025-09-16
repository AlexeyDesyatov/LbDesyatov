using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LbDesyatov1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] original = { 64, 34, 25, 12, 22, 11, 90 };

            Console.WriteLine("Исходный массив: ");
            for (int i = 0; i < original.Length; i++)
            {
                Console.Write(original[i]);
                if (i < original.Length - 1) Console.Write(", ");
            }
            Console.WriteLine();

            // Пузырьковая сортировка
            int[] bubbleArr = original.ToArray();
            BubbleSort(bubbleArr);

            Console.WriteLine("После пузырьковой: ");
            for (int i = 0; i < bubbleArr.Length; i++)
            {
                Console.Write(bubbleArr[i]);
                if (i < bubbleArr.Length - 1) Console.Write(", ");
            }
            Console.WriteLine();

            // Шейкерная сортировка
            int[] cocktailArr = original.ToArray();
            CocktailSort(cocktailArr);
            Console.WriteLine("После шейкерной: ");
            for (int i = 0; i < cocktailArr.Length; i++)
            {
                Console.Write(cocktailArr[i]);
                if (i < cocktailArr.Length - 1) Console.Write(", ");
            }
            Console.WriteLine();
            Console.ReadKey();
        }

        static void BubbleSort(int[] a)
        {
            for (int i = 0; i < a.Length; i++) 
            for (int j = 0; j < a.Length - 1; j++) 
                    if (a[j] > a[j + 1]) (a[j], a[j + 1]) = (a[j + 1], a[j]);
        }


        static void CocktailSort(int[] a)
        {
            for (int l = 0, r = a.Length - 1; l < r; l++, r--)
            {
                for (int i = l; i < r; i++) 
                    if (a[i] > a[i + 1]) (a[i], a[i + 1]) = (a[i + 1], a[i]);
                for (int i = r; i > l; i--) 
                    if (a[i] < a[i - 1]) (a[i], a[i - 1]) = (a[i - 1], a[i]);
            }
        }
    }
}
 