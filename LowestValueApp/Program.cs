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

                string? choice = Console.ReadLine();

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
            string? input = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(input))
            {
                Console.WriteLine("❌ No input provided.");
                return;
            }

            var numbers = new List<int>();

            foreach (var token in input.Split(' ', StringSplitOptions.RemoveEmptyEntries))
            {
                if (int.TryParse(token, out int value))
                {
                    numbers.Add(value);
                }
                else
                {
                    Console.WriteLine($"⚠️ Ignoring non-numeric value: '{token}'");
                }
            }

            if (numbers.Count == 0)
            {
                Console.WriteLine("❌ No valid numbers entered.");
            }
            else
            {
                int lowest = finder.GetLowestValue(numbers);
                Console.WriteLine($"Lowest value: {lowest}");
            }
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
            string? path = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(path))
            {
                path = "numbers.txt";
            }

            if (!File.Exists(path))
            {
                Console.WriteLine($"❌ File not found: {path}");
                return;
            }

            // Read entire file and split on any whitespace (spaces, tabs, newlines)
            var content = File.ReadAllText(path);
            var tokens = content.Split((char[])null, StringSplitOptions.RemoveEmptyEntries);

            var numbers = new List<int>();

            foreach (var token in tokens)
            {
                if (int.TryParse(token, out int num))
                {
                    numbers.Add(num);
                }
                else
                {
                    Console.WriteLine($"⚠️ Ignoring non-numeric value: '{token}'");
                }
            }

            if (numbers.Count == 0)
            {
                Console.WriteLine("❌ No valid numbers found in file.");
            }
            else
            {
                Console.WriteLine("Loaded numbers: " + string.Join(", ", numbers));
                int lowest = finder.GetLowestValue(numbers);
                Console.WriteLine($"Lowest value (file input): {lowest}");
            }
        }
    }
}
