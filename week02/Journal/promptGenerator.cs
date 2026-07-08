using System;
using System.Collections.Generic;

public class PromptGenerator
{
    public List<string> _prompts = new List<string>()
    {
        "Who was the most interesting person I interacted with today?",
        "What was the best part of my day?",
        "How did I help someone today?",
        "What made me smile today?",
        "What challenge did I overcome today?",
        "What am I grateful for today?",
        "What did I learn today?",
        "How did I improve myself today?",
        "What is one goal for tomorrow?",
        "What was the happiest moment of today?"
    };

    private Random _random = new Random();

    public string GetRandomPrompt()
    {
        int index = _random.Next(_prompts.Count);
        return _prompts[index];
    }
}