using System;

namespace SimpleConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            GetAppInfo();

            string userName = GetUserName();

            GreetUser(userName);

            int randomNumber = RandomNumber();

            bool correctAnswer = false;

            Console.WriteLine("Guess the correct number betweeen 1 and 10...");

            while(!correctAnswer)
            {
                string input = Console.ReadLine();

                int guess;

                bool isNumber = int.TryParse(input, out guess);

                if (!isNumber)
                {
                    PrintColorMessage(ConsoleColor.Yellow, "Please insert a number.");
                    continue;
                }

                if (guess < 1 || guess > 10)
                {
                    PrintColorMessage(ConsoleColor.Yellow, "Please insert a number between 1 and 10.");
                    continue;
                }

                if (guess < randomNumber)
                {
                    PrintColorMessage(ConsoleColor.Yellow, "The correct number is bigger.");
                    continue;
                }
                else if (guess > randomNumber)
                {
                    PrintColorMessage(ConsoleColor.Yellow, "The correct number is smaller.");
                    continue;
                }
                else
                {
                    correctAnswer = true;
                    PrintColorMessage(ConsoleColor.Red, "Congratulations! You've guessed the correct number!");
                }
            }
        }

        static void GetAppInfo()
        {
            string appName = "Guessing a number";
            int appVersion = 1;
            string appAuthor = "Jan Rebek";

            string info = $"[{appName}] Version: 0.0.{appVersion}, Author: {appAuthor}";

            PrintColorMessage(ConsoleColor.DarkGreen , info);

        }

        static string GetUserName()
        {
            Console.WriteLine("What's your name?");

            string inputUserName = Console.ReadLine();

            return inputUserName;
        }

        static void GreetUser(string userName)
        {

            string greet = $"Good luck {userName}, Let's start the game! ";

            PrintColorMessage(ConsoleColor.DarkBlue, greet);
        }

        static void PrintColorMessage(ConsoleColor color, string message)
        {
            Console.ForegroundColor = color;

            Console.WriteLine(message);

            Console.ResetColor();

        }

        static int RandomNumber()
        {
            Random rnd = new Random();

            int num = rnd.Next(1, 11);

            return num;
        }
    }
}
