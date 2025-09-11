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
            Console.Write("Количество нечетных чисел N =");
            int N = int.Parse(Console.ReadLine());
            int sum = 0;
            for (int i = 1; i <= N; i++)
            {             
                sum += i * 2 - 1;
            }
            Console.Write("Сумма первых целых N положительных нечетных чисел sum=");
            Console.WriteLine(sum);
            Console.Read();

        }
    }
}
