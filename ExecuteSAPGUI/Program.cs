using System;
using System.IO;
using System.Diagnostics;

class Program
{
    static void Main(string[] args)
    {
        CopyFiles();
        try
        {
            string command = "dir"; // Example command
            ExecuteCommand(command);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error executing command: {ex.Message}");
        }
        Console.ReadLine(); // Optional: to keep console window open
    }

    static void CopyFiles()
    {
        // Source and destination file paths
        string sourceFilePath = @"C:\path\to\source\file.txt";
        string destinationFilePath = @"D:\path\to\destination\file.txt";

        // Copy file
        try
        {
            File.Copy(sourceFilePath, destinationFilePath, true); // true for overwrite if destination file exists
            Console.WriteLine("File copied successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error copying file: {ex.Message}");
        }


    }
    static void ExecuteCommand(string command)
    {
        ProcessStartInfo procStartInfo = new ProcessStartInfo("cmd", "/c " + command)
        {
            RedirectStandardOutput = true,
            UseShellExecute = false,
            CreateNoWindow = true
        };

        Process proc = new Process { StartInfo = procStartInfo };

        proc.Start();
        string result = proc.StandardOutput.ReadToEnd();
        Console.WriteLine(result);
        proc.WaitForExit();
    }
}
