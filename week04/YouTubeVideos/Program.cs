using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<Video> videos = new List<Video>();

        // Video 1
        Video video1 = new Video(
            "Learn C# in 20 Minutes",
            "Code Academy",
            1200);

        video1.AddComment(new Comment("John", "Excellent tutorial!"));
        video1.AddComment(new Comment("Mary", "Very easy to follow."));
        video1.AddComment(new Comment("David", "Thanks for sharing."));
        video1.AddComment(new Comment("Grace", "Helped me complete my assignment."));

        videos.Add(video1);

        // Video 2
        Video video2 = new Video(
            "Object-Oriented Programming Explained",
            "Tech World",
            1450);

        video2.AddComment(new Comment("Samuel", "Great explanation."));
        video2.AddComment(new Comment("Joy", "Encapsulation finally makes sense."));
        video2.AddComment(new Comment("Daniel", "Please make more videos."));
        video2.AddComment(new Comment("Faith", "Subscribed!"));

        videos.Add(video2);

        // Video 3
        Video video3 = new Video(
            "Introduction to Data Structures",
            "Programming Hub",
            1800);

        video3.AddComment(new Comment("Michael", "Very informative."));
        video3.AddComment(new Comment("Sarah", "Loved the examples."));
        video3.AddComment(new Comment("Peter", "Clear and concise."));
        video3.AddComment(new Comment("Linda", "Awesome content!"));

        videos.Add(video3);

        // Video 4
        Video video4 = new Video(
            "Git and GitHub for Beginners",
            "Dev Master",
            1500);

        video4.AddComment(new Comment("Chris", "This was exactly what I needed."));
        video4.AddComment(new Comment("Janet", "Git finally makes sense."));
        video4.AddComment(new Comment("Paul", "Excellent presentation."));
        video4.AddComment(new Comment("Sophia", "Highly recommended."));

        videos.Add(video4);

        // Display all videos
        foreach (Video video in videos)
        {
            Console.WriteLine("----------------------------------------");
            Console.WriteLine($"Title: {video.GetTitle()}");
            Console.WriteLine($"Author: {video.GetAuthor()}");
            Console.WriteLine($"Length: {video.GetLength()} seconds");
            Console.WriteLine($"Number of Comments: {video.GetCommentCount()}");

            Console.WriteLine("\nComments:");

            foreach (Comment comment in video.GetComments())
            {
                Console.WriteLine($"{comment.GetName()}: {comment.GetText()}");
            }

            Console.WriteLine();
        }
    }
}