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
            // var account = Bank.CreateAccount("test@test.com", accountType: TypeOfAccount.Savings, accountName: "My Savings");

            Console.WriteLine("******************");
            Console.WriteLine("Welcome to Bank");
            Console.WriteLine("******************");
            while (true)
            {
                Console.WriteLine("0.Exit");
                Console.WriteLine("1.Create an account");
                Console.WriteLine("2.Deposit");
                Console.WriteLine("3.Withdraw");
                Console.WriteLine("4.Print all accounts");
                Console.WriteLine("5.Print all transactions");

                Console.Write("Please choose one option from above:");
                var choice = Console.ReadLine();

                switch (choice)
                {
                    case "0":
                        Console.WriteLine("Thankyou for visting!");
                        return;
                    case "1":
                            Console.Write("Email Address:");
                            var emailAddress = Console.ReadLine();
                            Console.Write("Account Name:");
                            var accountName = Console.ReadLine();
                            var typeOfAccounts = Enum.GetNames(typeof(TypeOfAccount));
                            for (var i = 0; i < typeOfAccounts.Length; i++)
                            {
                                Console.WriteLine($"{i + 1}.{typeOfAccounts[i]}");
                            }
                            Console.Write("Type of account:");
                        try
                        {
                            var accountType = Convert.ToInt32(Console.ReadLine());
                            var account = Bank.CreateAccount(emailAddress, accountName, (TypeOfAccount)(accountType - 1));
                            Console.WriteLine($"AN:{account.AccountNumber}, Balance:{account.Balance}, TA:{account.AccountType}");
                        }
                        catch(FormatException)
                        {
                            Console.WriteLine("Account Type option is invalid.");
                        }
                        catch(ArgumentNullException ax)
                        {
                            Console.WriteLine($"Error - {ax.ParamName}, {ax.Message}");
                        }
                        catch(Exception ex)
                        {
                            Console.WriteLine($"Something went wrong:{ex.Message}");
                        }
                        break;
                    case "2":
                        PrintAllAccounts();
                        Console.Write("Account Number:");
                        var an = Convert.ToInt32(Console.ReadLine());
                        Console.Write("Amount to deposit:");
                        var amount = Convert.ToDecimal(Console.ReadLine());
                        Bank.Deposit(an, amount);
                        break;
                    case "3":
                        PrintAllAccounts();
                        Console.Write("Account Number:");
                        an = Convert.ToInt32(Console.ReadLine());
                        Console.Write("Amount to withdraw:");
                        amount = Convert.ToDecimal(Console.ReadLine());
                        Bank.Withdraw(an, amount);
                        break;
                    case "4":
                        PrintAllAccounts();
                        break;
                    case "5":
                        PrintAllAccounts();
                        Console.Write("Account Number:");
                        an = Convert.ToInt32(Console.ReadLine());
                        var transactions = Bank.GetAllTransactions(an);
                        foreach(var tran in transactions)
                        {
                            Console.WriteLine($"TranId:{tran.TransactionID}, TranType:{tran.TypeOfTransaction}" +
                                $"TranAmt:{tran.TransactionAmount}, TranDate:{tran.TransactionDate}");
                        }
                        break;
                    default:
                        Console.WriteLine("Invalid Choice! Please try again!!");
                        break;
                }
            }
        }

        private static void PrintAllAccounts()
        {
            Console.Write("Email Address:");
            var emailAddress = Console.ReadLine();
            var accounts = Bank.GetAllAccounts(emailAddress);
            foreach (var acnt in accounts)
            {
                Console.WriteLine($"AN:{acnt.AccountNumber}, Balance:{acnt.Balance}, TA:{acnt.AccountType}");
            }
        }
    }
}
