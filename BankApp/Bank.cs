using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp
{
    static class Bank
    {
        private static BankModel db = new BankModel();
       // private static List<Account> accounts = new List<Account>();

        public static Account CreateAccount(String emailAddress, string accountName = "Default Name", 
            TypeOfAccount accountType = TypeOfAccount.Checkings)
        {
            var account = new Account
            {
                EmailAddress = emailAddress,
                AccountName = accountName,
                AccountType = accountType
            };
            db.Accounts.Add(account);
            db.SaveChanges();
            return account;
        }

        public static List<Account> GetAllAccounts(string emailAddress)
        {

            return db.Accounts.Where(a => a.EmailAddress == emailAddress).ToList();
        }

        public static List<Transaction> GetAllTransactions(int accountNumber)
        {
            return db.Transactions.Where(t => t.AccountNumber == accountNumber).OrderByDescending(t => t.TransactionDate).ToList();
        }

        public static void Deposit(int accountNumber, decimal amount)
        {
            var account = db.Accounts.Where(a => a.AccountNumber == accountNumber).FirstOrDefault();
            if(account != null)
            {
                account.Deposit(amount);
                var transaction = new Transaction
                {
                    TransactionDate = DateTime.Now,
                    TypeOfTransaction = TransactionType.Credit,
                    TransactionAmount = amount,
                    Description = " Deposit from branch",
                    AccountNumber = account.AccountNumber
                };
                db.Transactions.Add(transaction);
                db.SaveChanges();
            }
        }

       // public static void Withdraw(int accountNumber, decimal amount)
       // {
       //     var account = db.Accounts.Where(a => a.AccountNumber == accountNumber).FirstOrDefault();
       //     if (account != null)
       //     {
       //         account.Withdraw(amount);
       //         db.SaveChanges();
      //      }
        
    }
}
