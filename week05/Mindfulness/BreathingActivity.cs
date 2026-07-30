using System;

public class BreathingActivity : Activity
{
    public BreathingActivity()
    {
        _name = "Breathing";
        _description = "This activity will help you relax by walking you through slow breathing. Clear your mind and focus on your breathing.";
    }

    public void Run()
    {
        DisplayStartingMessage();

        DateTime endTime = DateTime.Now.AddSeconds(_duration);

        while (DateTime.Now < endTime)
        {
            Console.WriteLine();
            Console.Write("Breathe in... ");
            ShowCountDown(4);

            if (DateTime.Now >= endTime)
            {
                break;
            }

            Console.WriteLine();
            Console.Write("Breathe out... ");
            ShowCountDown(6);
        }

        DisplayEndingMessage();
    }
}