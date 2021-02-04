using System;

namespace SuperBank
{
    class Program
    {
        static void Main(string[] args)
        {
            var account = new BankAccount("Anoosh", 10000, "Starting Amount");
            Console.WriteLine($"Account {account.Number} was created for {account.OwnerName} with {account.Balance}.");

            account.MakeWithdrawal(500, DateTime.Now, "PS5");
            account.MakeWithdrawal(200, DateTime.Now, "PS5 Controller x2");
            account.MakeWithdrawal(998, DateTime.Now, "iPhone 12 Pro");

        Console.WriteLine(account.GetAccountHistory());
            Console.WriteLine("Remaining Balance: " + "$" + account.Balance);
        }
    }
}
