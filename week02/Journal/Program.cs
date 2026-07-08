using System;

/*
Creativity:
This program exceeds the core requirements by including
10 journal prompts instead of the required minimum of 5.
*/

class Program
{
    static void Main(string[] args)
    {
        Journal journal = new Journal();
        PromptGenerator promptGenerator = new PromptGenerator();

        int choice = 0;

        while (choice != 5)
        {
            Console.WriteLine();
            Console.WriteLine("Journal Menu");
            Console.WriteLine("1. Write");
            Console.WriteLine("2. Display");
            Console.WriteLine("3. Load");
            Console.WriteLine("4. Save");
            Console.WriteLine("5. Quit");
            Console.Write("Select an option: ");

            choice = int.Parse(Console.ReadLine());

            if (choice == 1)
            {
                string prompt = promptGenerator.GetRandomPrompt();

                Console.WriteLine();
                Console.WriteLine(prompt);
                Console.Write("> ");

                string response = Console.ReadLine();

                Entry entry = new Entry();

                entry._date = DateTime.Now.ToShortDateString();
                entry._promptText = prompt;
                entry._entryText = response;

                journal.AddEntry(entry);
            }

            else if (choice == 2)
            {
                Console.WriteLine();
                journal.DisplayAll();
            }

            else if (choice == 3)
            {
                Console.Write("Filename: ");
                string filename = Console.ReadLine();

                journal.LoadFromFile(filename);

                Console.WriteLine("Journal loaded successfully.");
            }

            else if (choice == 4)
            {
                Console.Write("Filename: ");
                string filename = Console.ReadLine();

                journal.SaveToFile(filename);

                Console.WriteLine("Journal saved successfully.");
            }

            else if (choice == 5)
            {
                Console.WriteLine("Goodbye!");
            }

            else
            {
                Console.WriteLine("Invalid option.");
            }
        }
    }
}