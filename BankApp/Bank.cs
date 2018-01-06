using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp
{
    static class Bank
    {
        private static List<Account> accounts = new List<Account>();

        public static Account CreateAccount(String emailAddress, string accountName = "Default Name", 
            TypeOfAccount accountType = TypeOfAccount.Checkings)
        {
            var account = new Account
            {
                EmailAddress = emailAddress,
                AccountName = accountName,
                AccountType = accountType
            };
            accounts.Add(account);
            return account;
        }

        public static List<Account> GetAllAccounts()
        {

            return accounts;
        }

        public static void Deposit(int accountNumber, decimal amount)
        {
            var account = accounts.Where(a => a.AccountNumber == accountNumber).FirstOrDefault();
            if(account != null)
            {
                account.Deposit(amount);
            }
        }
    }
}
