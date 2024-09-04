using System;
using System.Collections.Generic;

// Class representing a bank account
class BankAccount
{
    // Properties for the bank account
    public string AccountNumber { get; } // Account number (read-only)
    public string AccountHolder { get; set; } // Account holder's name
    public decimal Balance { get; private set; } // Account balance (private set, can only be modified within this class)

    // Constructor to initialize a new bank account
    public BankAccount(string accountNumber, string accountHolder, decimal initialBalance)
    {
        AccountNumber = accountNumber; // Set account number
        AccountHolder = accountHolder; // Set account holder
        Balance = initialBalance; // Set initial balance
    }

    // Method to deposit money into the account
    public void Deposit(decimal amount)
    {
        Balance += amount; // Increase the balance by the deposit amount
        Console.WriteLine($"Deposited {amount:C}. New balance: {Balance:C}"); // Display confirmation message with new balance
    }

    // Method to withdraw money from the account
    public void Withdraw(decimal amount)
    {
        if (amount > Balance) // Check if there are sufficient funds
        {
            Console.WriteLine("Insufficient funds!"); // Display error if funds are insufficient
        }
        else
        {
            Balance -= amount; // Deduct the amount from the balance
            Console.WriteLine($"Withdrawn {amount:C}. New balance: {Balance:C}"); // Display confirmation message with new balance
        }
    }

    // Method to inquire and display the current balance
    public void InquireBalance()
    {
        // Display account details and balance
        Console.WriteLine($"Account Number: {AccountNumber}");
        Console.WriteLine($"Account Holder: {AccountHolder}");
        Console.WriteLine($"Balance: {Balance:C}");
    }
}

// Class representing a bank that manages multiple accounts
class Bank
{
    // List to store multiple bank accounts
    private List<BankAccount> accounts = new List<BankAccount>();

    // Method to create a new bank account
    public void CreateAccount(string accountNumber, string accountHolder, decimal initialBalance)
    {
        // Check if the account number is unique
        if (FindAccount(accountNumber) == null)
        {
            // If unique, create a new account and add it to the list
            BankAccount account = new BankAccount(accountNumber, accountHolder, initialBalance);
            accounts.Add(account);
            Console.WriteLine("Account created successfully.");
        }
        else
        {
            // If not unique, display an error message
            Console.WriteLine("Account number is not unique. Please choose a different account number.");
        }
    }

    // Method to deposit money into an account
    public void Deposit(string accountNumber, decimal amount)
    {
        BankAccount account = FindAccount(accountNumber); // Find the account by account number
        if (account != null) // Check if the account exists
        {
            account.Deposit(amount); // Call the Deposit method of the found account
        }
    }

    // Method to withdraw money from an account
    public void Withdraw(string accountNumber, decimal amount)
    {
        BankAccount account = FindAccount(accountNumber); // Find the account by account number
        if (account != null) // Check if the account exists
        {
            account.Withdraw(amount); // Call the Withdraw method of the found account
        }
    }

    // Method to inquire the balance of an account
    public void InquireBalance(string accountNumber)
    {
        BankAccount account = FindAccount(accountNumber); // Find the account by account number
        if (account != null) // Check if the account exists
        {
            account.InquireBalance(); // Call the InquireBalance method of the found account
        }
    }

    // Private helper method to find an account by account number
    private BankAccount FindAccount(string accountNumber)
    {
        // Use LINQ to find the account with the matching account number
        return accounts.Find(account => account.AccountNumber == accountNumber);
    }
}

// Main program class to run the bank account management system
class Program
{
    static void Main()
    {
        Bank bank = new Bank(); // Create a new Bank object

        // Infinite loop to display menu and process user input
        while (true)
        {
            // Display menu options
            Console.WriteLine("Bank Account Management System");
            Console.WriteLine("1. Create Account");
            Console.WriteLine("2. Deposit");
            Console.WriteLine("3. Withdraw");
            Console.WriteLine("4. Inquire Balance");
            Console.WriteLine("5. Exit");

            Console.Write("Enter your choice: "); // Prompt user for input
            int choice = Convert.ToInt32(Console.ReadLine()); // Read user input and convert to integer

            // Process user choice using a switch statement
            switch (choice)
            {
                case 1:
                    // Create a new account
                    Console.Write("Enter account number: ");
                    string accNumber = Console.ReadLine(); // Read account number from user

                    Console.Write("Enter account holder name: ");
                    string accHolder = Console.ReadLine(); // Read account holder name from user

                    Console.Write("Enter initial balance: ");
                    decimal initialBalance = Convert.ToDecimal(Console.ReadLine()); // Read initial balance from user

                    bank.CreateAccount(accNumber, accHolder, initialBalance); // Create a new account
                    break;

                case 2:
                    // Deposit money into an account
                    Console.Write("Enter account number: ");
                    string depositAccNumber = Console.ReadLine(); // Read account number from user

                    Console.Write("Enter deposit amount: ");
                    decimal depositAmount = Convert.ToDecimal(Console.ReadLine()); // Read deposit amount from user

                    bank.Deposit(depositAccNumber, depositAmount); // Deposit the specified amount
                    break;

                case 3:
                    // Withdraw money from an account
                    Console.Write("Enter account number: ");
                    string withdrawAccNumber = Console.ReadLine(); // Read account number from user

                    Console.Write("Enter withdrawal amount: ");
                    decimal withdrawAmount = Convert.ToDecimal(Console.ReadLine()); // Read withdrawal amount from user

                    bank.Withdraw(withdrawAccNumber, withdrawAmount); // Withdraw the specified amount
                    break;

                case 4:
                    // Inquire balance of an account
                    Console.Write("Enter account number: ");
                    string inquireAccNumber = Console.ReadLine(); // Read account number from user

                    bank.InquireBalance(inquireAccNumber); // Inquire balance
                    break;

                case 5:
                    // Exit the program
                    Environment.Exit(0); // Terminate the program
                    break;

                default:
                    // Handle invalid input
                    Console.WriteLine("Invalid choice. Please enter a valid option.");
                    break;
            }

            Console.WriteLine(); // Add a newline for better readability
        }
    }
}
