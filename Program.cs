using System;
using System.Collections.Generic;

class BankAccount
{
    public string AccountNumber { get; }
    public string AccountHolder { get; set; }
    public decimal Balance { get; private set; }

    public BankAccount(string accountNumber, string accountHolder, decimal initialBalance)
    {
        AccountNumber = accountNumber;
        AccountHolder = accountHolder;
        Balance = initialBalance;
    }

    public void Deposit(decimal amount)
    {
        Balance += amount;
        Console.WriteLine($"Deposited {amount:C}. New balance: {Balance:C}");
    }

    public void Withdraw(decimal amount)
    {
        if (amount > Balance)
        {
            Console.WriteLine("Insufficient funds!");
        }
        else
        {
            Balance -= amount;
            Console.WriteLine($"Withdrawn {amount:C}. New balance: {Balance:C}");
        }
    }

    public void InquireBalance()
    {
        Console.WriteLine($"Account Number: {AccountNumber}");
        Console.WriteLine($"Account Holder: {AccountHolder}");
        Console.WriteLine($"Balance: {Balance:C}");
    }
}

class Bank
{
    private List<BankAccount> accounts = new List<BankAccount>();

    public void CreateAccount(string accountNumber, string accountHolder, decimal initialBalance)
    {
        // Check if the account number is unique
        if (FindAccount(accountNumber) == null)
        {
            BankAccount account = new BankAccount(accountNumber, accountHolder, initialBalance);
            accounts.Add(account);
            Console.WriteLine("Account created successfully.");
        }
        else
        {
            Console.WriteLine("Account number is not unique. Please choose a different account number.");
        }
    }

    public void Deposit(string accountNumber, decimal amount)
    {
        BankAccount account = FindAccount(accountNumber);
        if (account != null)
        {
            account.Deposit(amount);
        }
    }

    public void Withdraw(string accountNumber, decimal amount)
    {
        BankAccount account = FindAccount(accountNumber);
        if (account != null)
        {
            account.Withdraw(amount);
        }
    }

    public void InquireBalance(string accountNumber)
    {
        BankAccount account = FindAccount(accountNumber);
        if (account != null)
        {
            account.InquireBalance();
        }
    }

    private BankAccount FindAccount(string accountNumber)
    {
        return accounts.Find(account => account.AccountNumber == accountNumber);
    }
}

class Program
{
    static void Main()
    {
        Bank bank = new Bank();

        while (true)
        {
            Console.WriteLine("Bank Account Management System");
            Console.WriteLine("1. Create Account");
            Console.WriteLine("2. Deposit");
            Console.WriteLine("3. Withdraw");
            Console.WriteLine("4. Inquire Balance");
            Console.WriteLine("5. Exit");

            Console.Write("Enter your choice: ");
            int choice = Convert.ToInt32(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    Console.Write("Enter account number: ");
                    string accNumber = Console.ReadLine();

                    Console.Write("Enter account holder name: ");
                    string accHolder = Console.ReadLine();

                    Console.Write("Enter initial balance: ");
                    decimal initialBalance = Convert.ToDecimal(Console.ReadLine());

                    bank.CreateAccount(accNumber, accHolder, initialBalance);
                    break;

                case 2:
                    Console.Write("Enter account number: ");
                    string depositAccNumber = Console.ReadLine();

                    Console.Write("Enter deposit amount: ");
                    decimal depositAmount = Convert.ToDecimal(Console.ReadLine());

                    bank.Deposit(depositAccNumber, depositAmount);
                    break;

                case 3:
                    Console.Write("Enter account number: ");
                    string withdrawAccNumber = Console.ReadLine();

                    Console.Write("Enter withdrawal amount: ");
                    decimal withdrawAmount = Convert.ToDecimal(Console.ReadLine());

                    bank.Withdraw(withdrawAccNumber, withdrawAmount);
                    break;

                case 4:
                    Console.Write("Enter account number: ");
                    string inquireAccNumber = Console.ReadLine();

                    bank.InquireBalance(inquireAccNumber);
                    break;

                case 5:
                    Environment.Exit(0);
                    break;

                default:
                    Console.WriteLine("Invalid choice. Please enter a valid option.");
                    break;
            }

            Console.WriteLine(); // Add a newline for better readability
        }
    }
}
