using System;

public class Account
{
    public string Username { get; private set; }
    public string CardId { get; private set; }
    public double Balance { get; private set; }

    public Account(string username, string cardId, double balance)
    {
        Username = username;
        CardId = cardId;
        Balance = balance;
    }

    public void Transfer(Account receiver, double amount)
    {
        if (amount <= 0 || amount > Balance)
        {
            Console.WriteLine("Invalid transfer amount.");
            return;
        }

        Balance -= amount;
        receiver.Balance += amount;
        Console.WriteLine($"Transferred {amount:C} to {receiver.Username} successfully.");
    }

    public void Deposit(double amount)
    {
        if (amount <= 0)
        {
            Console.WriteLine("Invalid deposit amount.");
            return;
        }

        Balance += amount;
        Console.WriteLine($"Deposited {amount:C} successfully. Current balance: {Balance:C}");
    }

    public void GetSalary(double amount)
    {
        if (amount <= 0)
        {
            Console.WriteLine("Invalid salary amount.");
            return;
        }

        Balance += amount;
        Console.WriteLine($"Received salary of {amount:C}. Current balance: {Balance:C}");
    }
}
