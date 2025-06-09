using System;
using System.Collections.Generic;
using System.Threading;

class Program
{
    static void Main(string[] args)
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("Welcome to the Mindfulness Program!");
            Console.WriteLine("Choose an activity:");
            Console.WriteLine("1. Breathing Activity");
            Console.WriteLine("2. Reflection Activity");
            Console.WriteLine("3. Listing Activity");
            Console.WriteLine("4. Exit");
            Console.Write("Enter your choice: ");

            string choice = Console.ReadLine();

            Activity currentActivity = null;

            switch (choice)
            {
                case "1":
                    currentActivity = new BreathingActivity();
                    break;
                case "2":
                    currentActivity = new ReflectionActivity();
                    break;
                case "3":
                    currentActivity = new ListingActivity();
                    break;
                case "4":
                    Console.WriteLine("\nThank you for using the Mindfulness Program. Goodbye!");
                    Thread.Sleep(2000);
                    return;
                default:
                    Console.WriteLine("\nInvalid choice. Please try again.");
                    Thread.Sleep(2000);
                    continue;
            }

            if (currentActivity != null)
            {
                currentActivity.Run();
            }
        }
    }
}

// Activity.cs (Base Class)
public abstract class Activity
{
    protected string _name;
    protected string _description;
    protected int _duration;

    // Constructor for the base Activity class
    public Activity(string name, string description)
    {
        _name = name;
        _description = description;
    }

    // Displays a common starting message for all activities
    public void DisplayStartingMessage()
    {
        Console.Clear();
        Console.WriteLine($"Welcome to the {_name}.");
        Console.WriteLine($"\n{_description}");

        Console.Write("\nHow long, in seconds, would you like for your session? ");
        string input = Console.ReadLine();
        while (!int.TryParse(input, out _duration) || _duration <= 0)
        {
            Console.Write("Invalid input. Please enter a positive number of seconds: ");
            input = Console.ReadLine();
        }

        Console.Clear();
        Console.WriteLine("Get ready to begin...");
        ShowSpinner(5); // Pause for 5 seconds with a spinner
    }

    // Displays a common ending message for all activities
    public void DisplayEndingMessage()
    {
        Console.WriteLine("\nWell done!!");
        ShowSpinner(3); // Pause for 3 seconds with a spinner
        Console.WriteLine($"\nYou have completed another {_duration} seconds of the {_name}.");
        ShowSpinner(5); // Pause for 5 seconds with a spinner
    }

    // Displays a spinning animation
    public void ShowSpinner(int seconds)
    {
        List<string> spinner = new List<string> { "|", "/", "-", "\\" };
        DateTime endTime = DateTime.Now.AddSeconds(seconds);
        int i = 0;
        while (DateTime.Now < endTime)
        {
            Console.Write(spinner[i]);
            Thread.Sleep(200);
            Console.Write("\b \b"); // Erase the character
            i++;
            if (i >= spinner.Count)
            {
                i = 0;
            }
        }
        Console.Write(" "); // Ensure cursor is clear
    }

    // Displays a countdown timer
    public void ShowCountDown(int seconds)
    {
        for (int i = seconds; i > 0; i--)
        {
            Console.Write(i);
            Thread.Sleep(1000);
            if (i < 10) // Handle single digit vs double digit to clear correctly
            {
                Console.Write("\b \b");
            }
            else
            {
                Console.Write("\b\b  \b\b");
            }
        }
    }

    // Abstract method to be implemented by derived classes
    public abstract void Run();
}

// BreathingActivity.cs
public class BreathingActivity : Activity
{
    // Constructor for BreathingActivity
    public BreathingActivity() : base("Breathing Activity", "This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing.")
    {
    }

    // Implements the Run method for the breathing activity
    public override void Run()
    {
        DisplayStartingMessage();

        Console.WriteLine("\nBegin breathing...\n");

        DateTime startTime = DateTime.Now;
        DateTime endTime = startTime.AddSeconds(_duration);

        while (DateTime.Now < endTime)
        {
            Console.Write("Breathe in...");
            ShowCountDown(4); // Breathe in for 4 seconds
            Console.WriteLine(" "); // Move to next line after countdown

            if (DateTime.Now >= endTime) break; // Check if duration is met

            Console.Write("Breathe out...");
            ShowCountDown(6); // Breathe out for 6 seconds
            Console.WriteLine(" "); // Move to next line after countdown
        }

        DisplayEndingMessage();
    }
}

// ReflectionActivity.cs
public class ReflectionActivity : Activity
{
    private List<string> _prompts = new List<string>
    {
        "Think of a time when you stood up for someone else.",
        "Think of a time when you did something really difficult.",
        "Think of a time when you helped someone in need.",
        "Think of a time when you did something truly selfless."
    };

    private List<string> _questions = new List<string>
    {
        "Why was this experience meaningful to you?",
        "Have you ever done anything like this before?",
        "How did you get started?",
        "How did you feel when it was complete?",
        "What made this time different than other times when you were not as successful?",
        "What is your favorite thing about this experience?",
        "What could you learn from this experience that applies to other situations?",
        "What did you learn about yourself through this experience?",
        "How can you keep this experience in mind in the future?"
    };

    private List<int> _usedPrompts = new List<int>();
    private List<int> _usedQuestions = new List<int>();
    private Random _random = new Random();

    // Constructor for ReflectionActivity
    public ReflectionActivity() : base("Reflection Activity", "This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.")
    {
    }

    // Gets a random prompt, ensuring all are used before repeating
    private string GetRandomPrompt()
    {
        if (_usedPrompts.Count == _prompts.Count)
        {
            _usedPrompts.Clear(); // Reset if all prompts have been used
        }

        int index;
        do
        {
            index = _random.Next(_prompts.Count);
        } while (_usedPrompts.Contains(index));

        _usedPrompts.Add(index);
        return _prompts[index];
    }

    // Gets a random question, ensuring all are used before repeating
    private string GetRandomQuestion()
    {
        if (_usedQuestions.Count == _questions.Count)
        {
            _usedQuestions.Clear(); // Reset if all questions have been used
        }

        int index;
        do
        {
            index = _random.Next(_questions.Count);
        } while (_usedQuestions.Contains(index));

        _usedQuestions.Add(index);
        return _questions[index];
    }

    // Implements the Run method for the reflection activity
    public override void Run()
    {
        DisplayStartingMessage();

        Console.WriteLine("\nConsider the following prompt:");
        Console.WriteLine($"\n--- {GetRandomPrompt()} ---\n");
        Console.WriteLine("When you have thought about this, press enter to continue.");
        Console.ReadLine(); // Wait for user to press enter

        Console.WriteLine("Now ponder on each of the following questions as they relate to this experience.");
        Console.Write("You may begin in: ");
        ShowCountDown(5); // Give user a moment to prepare for questions

        Console.Clear(); // Clear the console after countdown

        DateTime startTime = DateTime.Now;
        DateTime endTime = startTime.AddSeconds(_duration);

        while (DateTime.Now < endTime)
        {
            Console.WriteLine($"> {GetRandomQuestion()}");
            ShowSpinner(8); // Pause for 8 seconds after each question
            Console.WriteLine(); // New line for next question
        }

        DisplayEndingMessage();
    }
}

// ListingActivity.cs
public class ListingActivity : Activity
{
    private List<string> _prompts = new List<string>
    {
        "Who are people that you appreciate?",
        "What are personal strengths of yours?",
        "Who are people that you have helped this week?",
        "When have you felt the Holy Ghost this month?",
        "Who are some of your personal heroes?"
    };

    private List<int> _usedPrompts = new List<int>();
    private Random _random = new Random();
    private int _count;

    // Constructor for ListingActivity
    public ListingActivity() : base("Listing Activity", "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.")
    {
    }

    // Gets a random prompt, ensuring all are used before repeating
    private string GetRandomPrompt()
    {
        if (_usedPrompts.Count == _prompts.Count)
        {
            _usedPrompts.Clear(); // Reset if all prompts have been used
        }

        int index;
        do
        {
            index = _random.Next(_prompts.Count);
        } while (_usedPrompts.Contains(index));

        _usedPrompts.Add(index);
        return _prompts[index];
    }

    // Implements the Run method for the listing activity
    public override void Run()
    {
        DisplayStartingMessage();

        Console.WriteLine("\nConsider the following prompt:");
        Console.WriteLine($"\n--- {GetRandomPrompt()} ---\n");
        Console.Write("You may begin in: ");
        ShowCountDown(5); // Countdown to begin thinking

        Console.WriteLine("\nStart listing items:");
        _count = 0;
        DateTime startTime = DateTime.Now;
        DateTime endTime = startTime.AddSeconds(_duration);

        // Continue accepting input until the duration is met
        while (DateTime.Now < endTime)
        {
            Console.Write("> ");
            string item = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(item))
            {
                _count++;
            }
            // If duration is met while user is typing, or after they press enter, break
            if (DateTime.Now >= endTime)
            {
                break;
            }
        }

        Console.WriteLine($"\nYou listed {_count} items.");

        DisplayEndingMessage();
    }
}
