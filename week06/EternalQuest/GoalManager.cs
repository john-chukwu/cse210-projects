using System;
using System.Collections.Generic;
using System.IO;
public class GoalManager
{
    private List<Goal> _goals;
    private int _score;

    public GoalManager()
    {
        _goals = new List<Goal>();
        _score = 0;
    }

    public void Start()
    {
        int choice = 0;

        while (choice != 6)
        {
            Console.Clear();

            DisplayPlayerInfo();

            Console.WriteLine();
            Console.WriteLine("Menu Options:");
            Console.WriteLine("  1. Create New Goal");
            Console.WriteLine("  2. List Goals");
            Console.WriteLine("  3. Save Goals");
            Console.WriteLine("  4. Load Goals");
            Console.WriteLine("  5. Record Event");
            Console.WriteLine("  6. Quit");
            Console.WriteLine("  7. Delete Goal");

            Console.Write("\nSelect a choice from the menu: ");
            choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    CreateGoal();
                    break;

                case 2:
                    ListGoalDetails();
                    break;

                case 3:
                    SaveGoals();
                    break;

                case 4:
                    LoadGoals();
                    break;

                case 5:
                    RecordEvent();
                    break;

                case 6:
                    Console.WriteLine("Goodbye!");
                    return;   // Exit Start()

                case 7:
                    DeleteGoal();
                    break;

                default:
                    Console.WriteLine("Invalid choice.");
                    Pause();
                    break;
            }
        }
    }

    public void DisplayPlayerInfo()
    {
        Console.WriteLine($"You have {_score} points.");
    }

    public void ListGoalNames()
    {
        if (_goals.Count == 0)
        {
            Console.WriteLine("No goals available.");
        }
        else
        {
            for (int i = 0; i < _goals.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {_goals[i].GetShortName()}");
            }
        }

        Pause();
    }

    public void ListGoalDetails()
    {
        Console.WriteLine();

        if (_goals.Count == 0)
        {
            Console.WriteLine("No goals available.");
        }
        else
        {
            for (int i = 0; i < _goals.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {_goals[i].GetDetailsString()}");
            }
        }

        Pause();
    }

    public void CreateGoal()
    {
        Console.Clear();

        Console.WriteLine("The types of Goals are:");
        Console.WriteLine("  1. Simple Goal");
        Console.WriteLine("  2. Eternal Goal");
        Console.WriteLine("  3. Checklist Goal");

        Console.Write("\nWhich type of goal would you like to create? ");
        int choice = int.Parse(Console.ReadLine());

        Console.Write("What is the name of your goal? ");
        string name = Console.ReadLine();

        Console.Write("What is a short description of it? ");
        string description = Console.ReadLine();

        Console.Write("How many points is it worth? ");
        int points = int.Parse(Console.ReadLine());

        Goal goal = null;

        switch (choice)
        {
            case 1:
                goal = new SimpleGoal(name, description, points);
                break;

            case 2:
                goal = new EternalGoal(name, description, points);
                break;

            case 3:
                Console.Write("How many times does this goal need to be accomplished? ");
                int target = int.Parse(Console.ReadLine());

                Console.Write("What is the bonus for accomplishing it? ");
                int bonus = int.Parse(Console.ReadLine());

                goal = new ChecklistGoal(name, description, points, target, bonus);
                break;

            default:
                Console.WriteLine("Invalid choice.");
                Pause();
                return;
        }

        _goals.Add(goal);

        Console.WriteLine("\nGoal created successfully!");

        Pause();
    }

    public void RecordEvent()
    {
        Console.Clear();

        if (_goals.Count == 0)
        {
            Console.WriteLine("No goals available.");

            Pause();
            return;
        }

        Console.WriteLine("The goals are:");

        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_goals[i].GetShortName()}");
        }

        Console.Write("\nWhich goal did you accomplish? ");

        int choice = int.Parse(Console.ReadLine());

        if (choice < 1 || choice > _goals.Count)
        {
            Console.WriteLine("Invalid goal.");

            Pause();
            return;
        }

        int earned = _goals[choice - 1].RecordEvent();

        _score += earned;

        Console.WriteLine($"\nCongratulations! You earned {earned} points!");
        Console.WriteLine($"You now have {_score} points.");

        Pause();
    }

    public void SaveGoals()
    {
        Console.Clear();

        Console.Write("Enter filename: ");
        string filename = Console.ReadLine();

        using (StreamWriter output = new StreamWriter(filename))
        {
            output.WriteLine(_score);

            foreach (Goal goal in _goals)
            {
                output.WriteLine(goal.GetStringRepresentation());
            }
        }

        Console.WriteLine("\nGoals saved successfully.");

        Pause();
    }

    public void LoadGoals()
    {
        Console.Clear();

        Console.Write("Enter filename: ");
        string filename = Console.ReadLine();

        if (!File.Exists(filename))
        {
            Console.WriteLine("File not found.");
            Pause();
            return;
        }

        _goals.Clear();

        string[] lines = File.ReadAllLines(filename);

        _score = int.Parse(lines[0]);

        for (int i = 1; i < lines.Length; i++)
        {
            string line = lines[i];

            string[] parts = line.Split(':');

            string type = parts[0];

            string[] values = parts[1].Split(',');

            if (type == "SimpleGoal")
            {
                _goals.Add(
                    new SimpleGoal(
                        values[0],
                        values[1],
                        int.Parse(values[2]),
                        bool.Parse(values[3])
                    ));
            }

            else if (type == "EternalGoal")
            {
                _goals.Add(
                    new EternalGoal(
                        values[0],
                        values[1],
                        int.Parse(values[2])
                    ));
            }

            else if (type == "ChecklistGoal")
            {
                _goals.Add(
                    new ChecklistGoal(
                        values[0],
                        values[1],
                        int.Parse(values[2]),
                        int.Parse(values[4]),
                        int.Parse(values[3]),
                        int.Parse(values[5])
                    ));
            }
        }

        Console.WriteLine("\nGoals loaded successfully.");

        Pause();
    }

    public void DeleteGoal()
    {
        Console.Clear();

        if (_goals.Count == 0)
        {
            Console.WriteLine("There are no goals to delete.");
            Pause();
            return;
        }

        Console.WriteLine("Current Goals:");

        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_goals[i].GetDetailsString()}");
        }

        Console.Write("\nEnter the number of the goal to delete: ");

        int choice = int.Parse(Console.ReadLine());

        if (choice < 1 || choice > _goals.Count)
        {
            Console.WriteLine("Invalid goal number.");
            Pause();
            return;
        }

        string deletedGoal = _goals[choice - 1].GetShortName();

        _goals.RemoveAt(choice - 1);

        Console.WriteLine($"\nGoal \"{deletedGoal}\" has been deleted successfully.");

        Pause();
    }

    private void Pause()
    {
        Console.WriteLine();
        Console.Write("Press Enter to continue...");
        Console.ReadLine();
    }
}