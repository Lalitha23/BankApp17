using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var account = new Account
            {
                AccountName = "My Checking",
                AccountType = TypeOfAccount.Checkings,
                EmailAddress = "test@test.com"
            };


            account.Deposit(100.10M);
            Console.WriteLine($"{account.Balance}");
            Console.WriteLine($"AccountNumber:{account.AccountNumber}, " +
                $"EmailAddress:{account.EmailAddress}, Balance:{account.Balance}");
        }
    }
}
