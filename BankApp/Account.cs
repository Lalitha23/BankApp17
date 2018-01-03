using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp
{
    /// <summary>
    /// This is bank account
    /// </summary>
    class Account
    {
        #region Properties
        public int AccountNumber { get; set; }
        public string EmailAddress { get; set; }
        public string AccountName { get; set; }
        public string AccountType { get; set; }
        public decimal Balance { get; set; }
        #endregion
    }
}
