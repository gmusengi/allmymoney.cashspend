using System;
using System.ComponentModel.DataAnnotations;

namespace allmymoney.cashspend.Models
{
    public class CashSpendEntry
    {
        [Key]
        public int CashSpendEntryId { get; set; }
        public DateTime EntryDate { get; set; }
        public decimal Amount { get; set; }
        public string Description { get; set; }
    }
}