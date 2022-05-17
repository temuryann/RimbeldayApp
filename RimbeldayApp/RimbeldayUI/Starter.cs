using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Use_Cases.User_Logic;

namespace RimbeldayApp.RimbeldayUI
{
    public class Starter
    {
        private readonly IUserManager userManager;

        public Starter()
        {
            userManager = new UserManager();
        }

        internal void MainMenu()
        {
            Console.WriteLine("(1) Registration / (2) Login / (ESC) Exit");
            ConsoleKey key;

            do
            {
                key = Console.ReadKey().Key;

                switch (key)
                {
                    case ConsoleKey.NumPad1:
                    case ConsoleKey.D1:
                        RegisterView();
                        break;

                    case ConsoleKey.NumPad2:
                    case ConsoleKey.D2:
                        LoginMenu();
                        break;

                    case ConsoleKey.Escape:
                        Environment.Exit(0);
                        break;
                }
            } while (true);
        }

        private void LoginMenu()
        {
            Console.Clear();
            string username;
            string password;

            do
            {
                Console.Clear();
                username = RimbeldayInputs.Input.Username("Please insert correct username");
                Console.WriteLine();
                Console.WriteLine("Please enter your password");
                password = RimbeldayInputs.Input.PassWriter();
            } while (!userManager.CanLogin(username, password));

            Console.Clear();
            Console.WriteLine("Successfully login");
            EmployeersView();
        }

        private void EmployeersView()
        {
            Console.WriteLine("(1) Add Finance Manager / (2) Add Sales Manager / (3) Add Receptions / (ESC) Exit");
            ConsoleKey key;

            do
            {
                key = Console.ReadKey().Key;

                switch (key)
                {
                    case ConsoleKey.NumPad1:
                    case ConsoleKey.D1:
                        ManagersView("Finance Manager");
                        break;

                    case ConsoleKey.NumPad2:
                    case ConsoleKey.D2:
                        ManagersView("Sales Manager");
                        break;

                    case ConsoleKey.NumPad3:
                    case ConsoleKey.D3:
                        ReceptionitView();
                        break;

                    case ConsoleKey.Escape:
                        MainMenu();
                        break;
                }
            } while (true);
        }

        private void ReceptionitView()
        {
            Console.Clear();
            Console.Clear();
            Console.WriteLine("Create receptionit");
            Console.WriteLine();

            string fullName = RimbeldayInputs.Input.Username("Please enter receptionit full name");
            double salary = RimbeldayInputs.Input.Salary();

            while (!userManager.AddRecption(fullName, (decimal)salary))
            {
                Console.Clear();
                fullName = RimbeldayInputs.Input.Username($"Please enter finance manager full name / {fullName} is already exist");
                salary = RimbeldayInputs.Input.Salary();
            }

            Console.Clear();
            Console.WriteLine("Receptionit was successfully added");
            EmployeersView();
        }

        private void ManagersView(string employeerType)
        {
            Console.Clear();
            Console.WriteLine($"Create {employeerType}");
            Console.WriteLine();

            string fullName = RimbeldayInputs.Input.Username($"Please enter {employeerType} full name");
            double salary = RimbeldayInputs.Input.Salary();
            int overTime = RimbeldayInputs.Input.OverTime();

            if (employeerType == "Finance Manager")
            {
                while (!userManager.AddFinanceManager(fullName, salary, overTime))
                {
                    Console.Clear();
                    fullName = RimbeldayInputs.Input.Username($"Please enter finance manager full name / {fullName} is already exist");
                    salary = RimbeldayInputs.Input.Salary();
                    overTime = RimbeldayInputs.Input.OverTime();
                }
            }
            else
            {
                while (!userManager.AddSalesManager(fullName, salary, overTime))
                {
                    Console.Clear();
                    fullName = RimbeldayInputs.Input.Username($"Please enter finance manager full name / {fullName} is already exist");
                    salary = RimbeldayInputs.Input.Salary();
                    overTime = RimbeldayInputs.Input.OverTime();
                }
            }
            

            Console.Clear();
            Console.WriteLine("Manager was successfully added");
            EmployeersView();
        }

        private void RegisterView()
        {
            Console.Clear();
            Console.WriteLine("Registration !");
            Console.WriteLine();
            string username = RimbeldayInputs.Input.Username("Please insert correct username");
            string password = PasswordConfirmation();

            if (userManager.CanRegister(username, password))
            {
                Console.Clear();
                Console.WriteLine("You was successfully registered !");
                Console.WriteLine();
                MainMenu();
            }
            else
            {
                Console.Clear();
                Console.WriteLine("You are already have account");
                Console.WriteLine();
                MainMenu();
            }
        }

        private string PasswordConfirmation()
        {
            Console.Clear();
            string password;
            string confirmPassword;

            do
            {
                Console.WriteLine("Please enter correct password");
                password = RimbeldayInputs.Input.PassWriter();
                Console.WriteLine();
                Console.WriteLine("Please confirm password");
                confirmPassword = RimbeldayInputs.Input.PassWriter();
            } while (password != confirmPassword);

            return password;
        }
    }
}
