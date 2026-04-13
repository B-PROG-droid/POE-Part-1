using System;

public class DisplayHelper  
{
    
    public static void ShowLogo()
    {
        Console.ForegroundColor = ConsoleColor.Cyan; 
        Console.WriteLine(@"
  ╔══════════════════════════════════════════════════════════════════╗
  ║   ___      _              ___          _                        ║
  ║  / __|_  _| |__  ___ _ _| _ ) ___  __| |_                     ║
  ║ | (__| || | '_ \/ -_) '_| _ \/ _ \/ _|  _|                    ║
  ║  \___|\_, |_.__/\___|_| |___/\___/\__|\__|                     ║
  ║       |__/   Cybersecurity Awareness Bot  v2.0                  ║
  ╚══════════════════════════════════════════════════════════════════╝
");
        Console.ResetColor();

        ShowWelcomeBanner(); 
    }

 
    public static void ShowWelcomeBanner()
    {
        Console.ForegroundColor = ConsoleColor.DarkCyan;
        Console.WriteLine("  ┌─────────────────────────────────────────────────────────────┐");
        Console.WriteLine("  │   Stay informed. Stay protected. Type 'help' to start.      │");
        Console.WriteLine("  └─────────────────────────────────────────────────────────────┘");
        Console.ResetColor();
        Console.WriteLine();
    }
}