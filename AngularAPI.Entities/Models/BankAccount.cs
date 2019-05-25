using System;
using System.ComponentModel.DataAnnotations;

namespace AngularAPI.Entities.Models
{
    public class BankAccount
    {
        [Key]
        public int BankAccountNumber { get; set; }
        public int ID { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public int ClientNumber { get; set; }
        public string AccountName { get; set; }
        public decimal AccountBalance { get; set; }
    }
}
