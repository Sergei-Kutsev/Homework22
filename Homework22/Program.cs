using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Homework22
{
    //Сформировать массив случайных целых чисел (размер  задается пользователем). Вычислить сумму чисел массива и максимальное число в массиве.
    //Реализовать  решение  задачи  с  использованием  механизма  задач продолжения.

    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите желаемый размер массива: ");
            int N = Convert.ToInt32(Console.ReadLine());
            int Sum = 0;
            Object Max = new Object();
            int[] array = new int[N];
            Random random = new Random();

            for (int i = 0; i < N; i++)
            {
                array[i] = random.Next(0, 50);
                Console.Write($"{array[i]} ");
            }
            Console.WriteLine();

            int GetSum()
            {
                for (int i = 0; i < N; i++)
                    Sum += array[i];
                Console.WriteLine($"Сумма = {Sum}.");
                return Sum;
            }

            object GetMax(Task task)
            {
                int MaxInt = 0;
                for (int i = 0; i < N; i++)
                    if (MaxInt < array[i])
                        MaxInt = array[i];
                Max = MaxInt;
                Console.WriteLine($"Mаксимальное число = {Max}.");
                return Max;
            }

            Func<int> func1 = new Func<int>(GetSum);
            Task<int> task1 = new Task<int>(func1);

            Func<Task,object> funcTask = new Func<Task,object>(GetMax);
            Task<object> task2 = task1.ContinueWith<object>(funcTask);
            
            task1.Start();
            Console.ReadKey();
        }
    }
}

