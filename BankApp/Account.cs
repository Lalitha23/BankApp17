using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp
{
    public enum TypeOfAccount
    {
        Checkings,
        Savings,
        CD,
        Loan
    }
    /// <summary>
    /// This is bank account
    /// </summary>
    public class Account
    {
        #region statics
       // private static int lastAccountNumber = 0;
        #endregion

        #region Constructor
        public Account()
        {
           
        }
        #endregion

        #region Properties
        [Key]
        public int AccountNumber { get; private set; }
        [StringLength(50, ErrorMessage = "Email address should be 50 charaters in lenght")]
        [Required]
        public string EmailAddress { get; set; }
        public string AccountName { get; set; }
        [Required]
        public TypeOfAccount AccountType { get; set; }
        public decimal Balance { get; private set; }
        #endregion

        #region Methods
        /// <summary>
        /// Deposit money into account
        /// </summary>
        /// <param name="amount"></param>

        public void Deposit(decimal amount)
        {
            Balance += amount;
        }

        public void Withdraw(decimal amount)
        {
            Balance -= amount;
        }

        #endregion
    }
}
