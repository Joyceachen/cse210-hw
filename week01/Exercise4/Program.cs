using System;

class Program
{
    static void Main()
    {
        List<int> numbers = new List<int>();
        int number;

        do
        {
            Console.Write("Enter a number (0 to quit): ");
            number = int.Parse(Console.ReadLine());

            if (number != 0)
                numbers.Add(number);
        } while (number != 0);

        int sum = 0;
        int max = int.MinValue;

        foreach (int num in numbers)
        {
            sum += num;
            if (num > max)
                max = num;
        }

        double average = (double)sum / numbers.Count;

        Console.WriteLine($"Sum: {sum}");
        Console.WriteLine($"Average: {average}");
        Console.WriteLine($"Max: {max}");
    }
}