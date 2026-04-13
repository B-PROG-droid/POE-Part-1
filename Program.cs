using System;

class Program
{
    static void Main(string[] args)
    {
        // Console setup
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        Console.Title = "CyberBot SA - Cybersecurity Awareness Assistant";
        Console.BackgroundColor = ConsoleColor.Black;
        Console.Clear();

        // Show logo and welcome banner
        DisplayHelper.ShowLogo();

        // Play voice greeting
        AudioPlayer.PlayGreeting();

        // Launch chatbot
        Chatbot bot = new Chatbot();
        bot.Start();
    }
}