using System;
using System.IO;
using System.Diagnostics;

public class AudioPlayer  
{
    private string audioPath;

    public AudioPlayer(string audioPath)
    {
        this.audioPath = audioPath;
    }

    public static void PlayGreeting()
    {
        try
        {
            string audioPath = "C:\\Users\\Student\\source\\repos\\Part 1 POE\\Part 1 POE\\voice greeter.wav";

            if (File.Exists(audioPath))
            {
                var player = new AudioPlayer(audioPath);
                player.PlaySync();
            }
            else
            {
                Console.WriteLine("[Voice greeting file not found]");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"[Could not play audio: {ex.Message}]");
        }
    }

    public void PlaySync()
    {
        string escapedPath = audioPath.Replace("'", "''");

        var process = new Process();
        process.StartInfo.FileName = "powershell";
        process.StartInfo.Arguments = $"-c \"(New-Object Media.SoundPlayer '{escapedPath}').PlaySync()\"";
        process.StartInfo.CreateNoWindow = true;
        process.StartInfo.UseShellExecute = false;
        process.Start();
        process.WaitForExit();
    }
}