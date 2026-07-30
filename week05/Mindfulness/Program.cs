using System;

// Creativity and Exceeding Requirements:
//
// 1. A random motivational quote is displayed after each activity.
// 2. The program keeps track of how many Breathing, Reflecting,
//    and Listing activities are completed during the current
//    session. When the user quits, a session summary displays
//    the number of each activity completed and the total number
//    of activities performed.
class Program
{
    static void Main(string[] args)
    {
        int breathingCount = 0;
        int reflectingCount = 0;
        int listingCount = 0;

        string choice = "";

        while (choice != "4")
        {
            Console.Clear();

            Console.WriteLine("Menu Options:");
            Console.WriteLine("  1. Start Breathing Activity");
            Console.WriteLine("  2. Start Reflecting Activity");
            Console.WriteLine("  3. Start Listing Activity");
            Console.WriteLine("  4. Quit");
            Console.Write("Select a choice from the menu: ");

            choice = Console.ReadLine();

            Console.Clear();

            switch (choice)
            {
                case "1":
                    BreathingActivity breathing = new BreathingActivity();
                    breathing.Run();
                    breathingCount++;
                    break;

                case "2":
                    ReflectingActivity reflecting = new ReflectingActivity();
                    reflecting.Run();
                    reflectingCount++;
                    break;

                case "3":
                    ListingActivity listing = new ListingActivity();
                    listing.Run();
                    listingCount++;
                    break;

                case "4":
                    Console.WriteLine("Session Summary");
                    Console.WriteLine("--------------------------");
                    Console.WriteLine($"Breathing Activities : {breathingCount}");
                    Console.WriteLine($"Reflecting Activities: {reflectingCount}");
                    Console.WriteLine($"Listing Activities   : {listingCount}");
                    Console.WriteLine();
                    Console.WriteLine($"Total Activities Completed: {breathingCount + reflectingCount + listingCount}");
                    Console.WriteLine();
                    Console.WriteLine("Thank you for using the Mindfulness Program!");
                    break;

                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }

            if (choice != "4")
            {
                Console.WriteLine();
                Console.WriteLine("Press Enter to return to the menu...");
                Console.ReadLine();
            }
        }
    }
}