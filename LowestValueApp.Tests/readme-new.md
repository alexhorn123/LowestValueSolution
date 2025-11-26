# LowestValueApp

A simple C# console application that finds the lowest integer in a list. Includes multiple usage modes (hardcoded list, manual input, random numbers, file input) and a test suite using xUnit.

🚀 Installation
Clone or download this repository:

```bash
git clone <your-repo-url>
cd LowestValueSolution
```
Ensure .NET SDK is installed This project targets .NET 9.0. Check your version:

```bash
dotnet --version
```
If needed, install the latest SDK from Microsoft .NET downloads.

Restore dependencies:

```bash
dotnet restore
```
▶️ Running the Application
From the solution root:

```bash
dotnet run --project LowestValueApp
```
You’ll see a menu:

```
=== Lowest Value Finder ===
Choose an option:
1. Use hardcoded list
2. Enter numbers manually
3. Generate random numbers
4. Load numbers from file
5. Exit
Selection:
```
Input Modes
Option 1 (Hardcoded list) → Uses a predefined list of numbers.

Option 2 (Manual input) → Type numbers separated by spaces.

Option 3 (Random list) → Generates 10 random numbers between -100 and 100.

Option 4 (File input) → Loads numbers from a file.

Default file: numbers.txt in the solution root.

Example contents:

```
42 7 19 -3 88
100
-25 50 75
0 -99 200
```
Press Enter at the prompt to use the default file.

Option 5 (Exit) → Closes the program.

🧪 Running Tests
The solution includes an xUnit test project (LowestValueApp.Tests) with coverage for:

Valid lists

Single element

Empty list (throws)

Null list (throws)

Large lists

Negative numbers

Run tests from the solution root:

```bash
dotnet test
```
Expected output:

```
Passed! 6 tests
```
📂 Project Structure
```
LowestValueSolution/
 ├── LowestValueSolution.sln
 ├── LowestValueApp/
 │    ├── Program.cs          # Console menu and entry point
 │    └── ValueFinder.cs      # Core logic for lowest value
 ├── LowestValueApp.Tests/
 │    └── ValueFinderTests.cs # xUnit test suite
 └── README.md
```
✅ Features
Menu-driven console app

Multiple input modes (hardcoded, manual, random, file)

Default file path support (numbers.txt)

Robust error handling

Automated test suite with xUnit