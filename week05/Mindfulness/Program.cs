using System;

namespace MindfulnessProgram
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Mindfulness Program!");
            
            while (true)
            {
                Console.WriteLine("\nMenu Options:");
                Console.WriteLine("  1. Start breathing activity");
                Console.WriteLine("  2. Start reflecting activity");
                Console.WriteLine("  3. Start listing activity");
                Console.WriteLine("  4. Start gratitude activity");
                Console.WriteLine("  5. Quit");
                Console.Write("Select a choice from the menu: ");
                
                string choice = Console.ReadLine();
                
                switch (choice)
                {
                    case "1":
                        BreathingActivity breathingActivity = new BreathingActivity();
                        breathingActivity.Run();
                        break;
                    case "2":
                        ReflectionActivity reflectionActivity = new ReflectionActivity();
                        reflectionActivity.Run();
                        break;
                    case "3":
                        ListingActivity listingActivity = new ListingActivity();
                        listingActivity.Run();
                        break;
                    case "4":
                        GratitudeActivity gratitudeActivity = new GratitudeActivity();
                        gratitudeActivity.Run();
                        break;
                    case "5":
                        Console.WriteLine("Thank you for using the Mindfulness Program. Have a peaceful day!");
                        return;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
        }
    }
}