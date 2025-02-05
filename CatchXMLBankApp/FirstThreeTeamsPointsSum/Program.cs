using System;

namespace Program
{
    class Program
    {
        static void Main(string[] args)
        {
            // Массив очков, набранных каждой из 20 команд
            int[] points = { 35, 42, 28, 50, 37, 41, 33, 29, 45, 38, 40, 36, 39, 44, 30, 27, 32, 34, 31, 43 };

            // Сортируем массив очков в порядке убывания
            int[] sortedPoints = points.OrderByDescending(p => p).ToArray();

            // Суммируем очки первых трёх команд
            int topThreeSum = sortedPoints[0] + sortedPoints[1] + sortedPoints[2];

            // Выводим результат
            Console.WriteLine($"Сумма очков первых трёх команд: {topThreeSum}");
        }
    }
}
