using System;
using System.Collections.Generic;
using System.Threading;

public class Activity
{
    protected string _name;
    protected string _description;
    protected int _duration;

    private List<string> _quotes;
    private Random _random;

    public Activity()
    {
        _name = "";
        _description = "";
        _duration = 0;

        _random = new Random();

        _quotes = new List<string>
        {
            "Every day is a fresh start.",
            "Small steps lead to big achievements.",
            "Believe in yourself and keep moving forward.",
            "Progress is better than perfection.",
            "Peace begins with one deep breath.",
            "You are stronger than you think.",
            "Focus on what you can control.",
            "Be present in this moment."
        };
    }

    public void DisplayStartingMessage()
    {
        Console.Clear();

        Console.WriteLine($"Welcome to the {_name} Activity.");
        Console.WriteLine();

        Console.WriteLine(_description);
        Console.WriteLine();

        Console.Write("How long, in seconds, would you like for your session? ");

        _duration = int.Parse(Console.ReadLine());

        Console.WriteLine();
        Console.WriteLine("Get ready...");
        ShowSpinner(3);
    }

    public void DisplayEndingMessage()
    {
        Console.WriteLine();
        Console.WriteLine("Well done!");
        ShowSpinner(3);

        Console.WriteLine();
        Console.WriteLine($"You have completed another {_duration} seconds of the {_name} Activity.");

        DisplayMotivationalQuote();

        Console.WriteLine();
        ShowSpinner(5);
    }

    public void ShowSpinner(int seconds)
    {
        List<string> spinner = new List<string>
        {
            "|",
            "/",
            "-",
            "\\"
        };

        DateTime endTime = DateTime.Now.AddSeconds(seconds);

        int i = 0;

        while (DateTime.Now < endTime)
        {
            Console.Write(spinner[i]);
            Thread.Sleep(250);
            Console.Write("\b \b");

            i++;

            if (i >= spinner.Count)
            {
                i = 0;
            }
        }
    }

    public void ShowCountDown(int seconds)
    {
        for (int i = seconds; i > 0; i--)
        {
            Console.Write(i);
            Thread.Sleep(1000);
            Console.Write("\b \b");
        }

        Console.WriteLine();
    }

    protected void DisplayMotivationalQuote()
    {
        Console.WriteLine();
        Console.WriteLine("🌟 Daily Inspiration 🌟");
        Console.WriteLine($"\"{_quotes[_random.Next(_quotes.Count)]}\"");
    }
}