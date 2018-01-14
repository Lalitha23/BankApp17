using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp
{ 
    public enum TransactionType
    {
    Credit,
    Debit
    }

    public class Transaction
    {
        [Key]
        public int TransactionID { get; set; }
        [Required]
        public DateTime TransactionDate { get; set; }
        public string Description { get; set; }
        [Required]
        public decimal TransactionAmount { get; set; }
        [Required]
        public TransactionType TypeOfTransaction { get; set; }

        [ForeignKey("Account")]
        [Required]
        public int AccountNumber { get; set; }
        public virtual Account Account { get; set; }
    }
}
