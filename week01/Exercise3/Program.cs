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
        foreach (int num in numbers)
            sum += num;

        Console.WriteLine($"The sum is: {sum}");
    }
}