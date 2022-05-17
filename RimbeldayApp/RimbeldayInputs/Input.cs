using System;

namespace RimbeldayApp.RimbeldayInputs
{
    public static class Input
    {
        internal static string Username(string info)
        {
            string username;

            do
            {
                Console.WriteLine($"{info}");
                username = Console.ReadLine();
            } while (string.IsNullOrWhiteSpace(username));

            return username;
        }

        internal static string PassWriter()
        {
            string password = string.Empty;
            ConsoleKey key;

            do
            {
                ConsoleKeyInfo keyInfo = Console.ReadKey(intercept: true);
                key = keyInfo.Key;

                if (key == ConsoleKey.Backspace && password.Length > 0)
                {
                    Console.Write("\b \b");
                    password = password.Remove(password.Length - 1);
                }
                else if (!char.IsControl(keyInfo.KeyChar))
                {
                    Console.Write("*");
                    password += keyInfo.KeyChar;
                }

            } while (key != ConsoleKey.Enter);

            return password;
        }

        internal static double Salary()
        {
            double salary;

            do
            {
                Console.WriteLine("Please enter correct salary employeer");
            } while (!double.TryParse(Console.ReadLine(), out salary));

            return salary;
        }

        internal static int OverTime()
        {
            int overTime;

            do
            {
                Console.WriteLine("Please enter correct overtime employeer");
            } while (!int.TryParse(Console.ReadLine(), out overTime));

            return overTime;
        }
    }
}
