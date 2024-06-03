using System;
using System.Security.Principal;

public static class Menu
{
    public static void ShowMainMenu()
    {
        Console.WriteLine("Welcome to the Bank Console App!");

        while (true)
        {
            Console.WriteLine("1. Log in");
            Console.WriteLine("2. Exit");
            Console.Write("Please select an option: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Login();
                    break;
                case "2":
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    break;
            }
        }
    }

    private static void Login()
    {
        Console.Write("Enter your username: ");
        string username = Console.ReadLine();

        Account account = Database.GetAccountByUsername(username);

        if (account == null)
        {
            Console.WriteLine("Account not found. Creating a new account.");
            CreateAccount(username);
        }
        else
        {
            ShowAccountMenu(account);
        }
    }

    private static void CreateAccount(string username)
    {
        Console.Write("Enter your card ID: ");
        string cardId = Console.ReadLine();
        Console.Write("Enter your initial balance: ");
        double balance = double.Parse(Console.ReadLine());

        Account newAccount = new Account(username, cardId, balance);
        Database.AddAccount(newAccount);

        Console.WriteLine("Account created successfully.");
        ShowAccountMenu(newAccount);
    }

    private static void ShowAccountMenu(Account account)
    {
        Console.WriteLine($"Welcome, {account.Username}!");
        Console.WriteLine($"Card ID: {account.CardId}");
        Console.WriteLine($"Balance: {account.Balance:C}");

        while (true)
        {
            Console.WriteLine("1. Transfer money");
            Console.WriteLine("2. Deposit money");
            Console.WriteLine("3. Get salary");
            Console.WriteLine("4. Log out");
            Console.Write("Please select an option: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    TransferMoney(account);
                    break;
                case "2":
                    DepositMoney(account);
                    break;
                case "3":
                    GetSalary(account);
                    break;
                case "4":
                    return;
                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    break;
            }
        }
    }

    private static void TransferMoney(Account sender)
    {
        Console.Write("Enter recipient's username: ");
        string recipientUsername = Console.ReadLine();
        Account recipient = Database.GetAccountByUsername(recipientUsername);

        if (recipient == null)
        {
            Console.WriteLine("Recipient account not found.");
            return;
        }

        Console.Write("Enter amount to transfer: ");
        double amount = double.Parse(Console.ReadLine());

        sender.Transfer(recipient, amount);
    }

    private static void DepositMoney(Account account)
    {
        Console.Write("Enter amount to deposit: ");
        double amount = double.Parse(Console.ReadLine());
        account.Deposit(amount);
    }

    private static void GetSalary(Account account)
    {
        Console.Write("Enter salary amount: ");
        double amount = double.Parse(Console.ReadLine());
        account.GetSalary(amount);
    }
}
