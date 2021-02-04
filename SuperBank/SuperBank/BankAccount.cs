using System;
using System.Collections.Generic;
using System.Text;

namespace SuperBank
{
    public class BankAccount
    {
        public string Number { get; } //Can get a number but once assigned cannot resign another number
        public string OwnerName { get; set; }
        public decimal Balance { 
            get {
                decimal balance = 0; //Starts with 0
                foreach (var item in allTransactions) //Loops through the balance checking for any Transactions made 
                {
                    balance += item.Amount; //Which then would add the amount of money withdrawn from the account
                }
                return balance; //Shows the final balance after withdrawl

            }
        }

        private static int accountNumberSeed = 1234567890; //This number should always be secured hence being private

        private List<Transactions> allTransactions = new List<Transactions>();

        public BankAccount(string name, decimal initialBalance, string note)
        {
            this.OwnerName = name;

            MakeDeposit(initialBalance, DateTime.Now, note);

            this.Number = accountNumberSeed.ToString();
            accountNumberSeed++; //Gives a new Account Number to different users
        }

        public void MakeDeposit(decimal amount, DateTime date, string note)
        {
                if (amount <= 0) //Cannot deposit negative money
                {
                    throw new ArgumentOutOfRangeException(nameof(amount), "Amount of deposit must be positive"); //Stops the program because you cannot input negative money 
                } //ArguementOutOfRange is executed when the amount is less than zero (basically saying you cannot do that/cannot deposit a negative value) 
            var deposit = new Transactions(amount, date, note); //Amount will be added to the balance along with the time
            allTransactions.Add(deposit);
        }

        public void MakeWithdrawal(decimal amount, DateTime date, string note)
        {
                if (amount <= 0) //Exception, if you cannot take out negative money
                {
                    throw new ArgumentOutOfRangeException(nameof(amount), "Amount of withdrawal must be positive");
                }
                if (Balance - amount < 0) //If the asked amount is has a higher than the balance, it wouldnt confirm the withdrawl
                {
                    throw new InvalidOperationException("Not sufficient funds for this withdrawal");
                } //InvalidOperationException is basically telling you that you cannot take something that you do not have 
            var withdrawal = new Transactions(-amount, date, note); //Amount will be taken away from your balance along with when you have withdrawn the money for proof
            allTransactions.Add(withdrawal);
        }

        public string GetAccountHistory()
        {
            var report = new StringBuilder(); //Formats a string that contains one line for each transaction

            //HEADER
            report.AppendLine("Date\t\tAmount\t\tNote");
            foreach (var item in allTransactions) //Loops through each transaction made 
            {
                report.AppendLine($"{item.Date.ToShortDateString()}\t ${item.Amount}\t\t {item.Note}"); //Reports the Date, Amount and Item
            }
            return report.ToString(); //Makes them into a string which then returns to the console
        }
    }
}
