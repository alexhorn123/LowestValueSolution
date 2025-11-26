using System;
using System.Collections.Generic;
using System.IO;

namespace LowestValueApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var finder = new ValueFinder();
            bool exit = false;

            while (!exit)
            {
                Console.Clear();
                Console.WriteLine("=== Lowest Value Finder ===");
                Console.WriteLine("Choose an option:");
                Console.WriteLine("1. Use hardcoded list");
                Console.WriteLine("2. Enter numbers manually");
                Console.WriteLine("3. Generate random numbers");
                Console.WriteLine("4. Load numbers from file");
                Console.WriteLine("5. Exit");
                Console.Write("Selection: ");

                string choice = Console.ReadLine();

                try
                {
                    switch (choice)
                    {
                        case "1":
                            RunHardcodedList(finder);
                            break;
                        case "2":
                            RunManualInput(finder);
                            break;
                        case "3":
                            RunRandomList(finder);
                            break;
                        case "4":
                            RunFileInput(finder);
                            break;
                        case "5":
                            exit = true;
                            break;
                        default:
                            Console.WriteLine("Invalid choice. Try again.");
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }

                if (!exit)
                {
                    Console.WriteLine("\nPress any key to return to menu...");
                    Console.ReadKey();
                }
            }
        }

        static void RunHardcodedList(ValueFinder finder)
        {
            var numbers = new List<int> { 42, 7, 19, -3, 88 };
            int lowest = finder.GetLowestValue(numbers);
            Console.WriteLine($"Lowest value (hardcoded list): {lowest}");
        }

        static void RunManualInput(ValueFinder finder)
        {
            Console.WriteLine("Enter numbers separated by spaces:");
            string input = Console.ReadLine();

            var numbers = new List<int>();
            foreach (var s in input.Split(' ', StringSplitOptions.RemoveEmptyEntries))
            {
                if (int.TryParse(s, out int num))
                    numbers.Add(num);
            }

            int lowest = finder.GetLowestValue(numbers);
            Console.WriteLine($"Lowest value (manual input): {lowest}");
        }

        static void RunRandomList(ValueFinder finder)
        {
            var rand = new Random();
            var numbers = new List<int>();
            for (int i = 0; i < 10; i++)
            {
                numbers.Add(rand.Next(-100, 100));
            }

            Console.WriteLine("Generated numbers: " + string.Join(", ", numbers));
            int lowest = finder.GetLowestValue(numbers);
            Console.WriteLine($"Lowest value (random list): {lowest}");
        }

static void RunFileInput(ValueFinder finder)
{
    Console.WriteLine("Enter the path to your file (default: numbers.txt):");
    string path = Console.ReadLine();

    // If user presses Enter, default to numbers.txt
    if (string.IsNullOrWhiteSpace(path))
    {
        path = "numbers.txt";
    }

    if (!File.Exists(path))
    {
        Console.WriteLine($"File not found: {path}");
        return;
    }

    var numbers = new List<int>();
    foreach (var line in File.ReadAllLines(path))
    {
        foreach (var s in line.Split(' ', StringSplitOptions.RemoveEmptyEntries))
        {
            if (int.TryParse(s, out int num))
                numbers.Add(num);
        }
    }

    Console.WriteLine("Loaded numbers: " + string.Join(", ", numbers));
    int lowest = finder.GetLowestValue(numbers);
    Console.WriteLine($"Lowest value (file input): {lowest}");
}

    }
}
