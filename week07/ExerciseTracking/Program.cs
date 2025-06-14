using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        Running runningActivity = new Running(new DateTime(2025, 11, 3), 30, 3.0);
        Cycling cyclingActivity = new Cycling(new DateTime(2026, 11, 3), 30, 15.0);
        Swimming swimmingActivity = new Swimming(new DateTime(2023, 11, 3), 30, 20);

        List<Activity> activities = new List<Activity>();
        activities.Add(runningActivity);
        activities.Add(cyclingActivity);
        activities.Add(swimmingActivity);

        Console.WriteLine("Exercise Tracking Summary:");
        Console.WriteLine("========================");

        foreach (Activity activity in activities)
        {
            Console.WriteLine(activity.GetSummary());
        }
    }
}
// By Joyce Achen