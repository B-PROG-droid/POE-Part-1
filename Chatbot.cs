using System;
using System.Threading;

public class Chatbot
{
    private string userName;

    public void Start()
    {
        AudioPlayer.PlayGreeting(); // 🔊 Voice greeting
        DisplayWelcomeBanner();
        GetUserName();
        StartConversation();
    }

    private void DisplayWelcomeBanner()
    {
        Console.ForegroundColor = ConsoleColor.Cyan;
        
        Console.WriteLine("                  WELCOME TO CYBERBOT              ");
       
        Console.ResetColor();
    }

    private void GetUserName()
    {
        while (true)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            TypeText("  Please enter your name to get started: ");
            Console.ResetColor();

            string input = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(input))
            {
                ShowError("Name cannot be empty. Please try again.");
            }
            else
            {
                userName = input.Trim();
                break;
            }
        }

        Console.ForegroundColor = ConsoleColor.Green;
        TypeText($"\n  Hello, {userName}! Great to have you here.\n");
        TypeText("  I'm CyberBot SA, your cybersecurity assistant.\n");
        TypeText("  Think of me as your digital bodyguard — I’ve got you covered online.\n\n");
        Console.ResetColor();
    }

    private void StartConversation()
    {
        bool running = true;

        ShowDivider("Type your question below, or type 'help' for options or 'exit' to quit.");

        while (running)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write($"  {userName}: ");
            Console.ResetColor();

            string input = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(input))
            {
                ShowError("Input cannot be empty. Please type something.");
                continue;
            }

            input = input.Trim().ToLower();

            // 🔴 Exit
            if (input == "exit")
            {
                Console.ForegroundColor = ConsoleColor.Green;
                TypeText($"\n  Goodbye, {userName}! Stay safe online 👋\n");
                Console.ResetColor();
                break;
            }

            // 🟢 Help Menu
            if (input == "help")
            {
                ShowHelpMenu();
                continue;
            }

            // 🟣 Emotion detection
            if (input.Contains("scared") || input.Contains("worried") || input.Contains("hacked"))
            {
                Console.ForegroundColor = ConsoleColor.Magenta;
                TypeText("\n  CyberBot: I understand your concern. Let's make sure you're protected.\n");
                Console.ResetColor();
            }

            // ⏳ Thinking animation
            ShowThinking();

            // 🤖 Get response
            string response = ResponseEngine.GetResponse(input);

            Console.ForegroundColor = ConsoleColor.Cyan;
            TypeText($"\n  CyberBot: {response}\n");
            Console.ResetColor();
        }
    }

    // =========================
    // 🔧 Helper Methods
    // =========================

    private void ShowHelpMenu()
    {
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("\n  ================= HELP MENU =================");
        Console.WriteLine("  - 'password'  → Learn how to create strong passwords");
        Console.WriteLine("  - 'phishing'  → Learn about scams and fake emails");
        Console.WriteLine("  - 'privacy'   → Tips to protect your personal data");
        Console.WriteLine("  - 'exit'      → Quit the application");
        Console.WriteLine("  =============================================\n");
        Console.ResetColor();
    }

    private void ShowDivider(string message)
    {
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("  ============================================================");
        Console.WriteLine($"  {message}");
        Console.WriteLine("  ============================================================\n");
        Console.ResetColor();
    }

    private void ShowError(string message)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine($"  [{message}]\n");
        Console.ResetColor();
    }

    private void ShowThinking()
    {
        Console.ForegroundColor = ConsoleColor.DarkGray;
        Console.Write("\n  CyberBot is thinking");
        for (int i = 0; i < 3; i++)
        {
            Thread.Sleep(300);
            Console.Write(".");
        }
        Console.WriteLine();
        Console.ResetColor();
    }

    // Typing effect
    public static void TypeText(string message, int delay = 20)
    {
        foreach (char c in message)
        {
            Console.Write(c);
            Thread.Sleep(delay);
        }
    }
}