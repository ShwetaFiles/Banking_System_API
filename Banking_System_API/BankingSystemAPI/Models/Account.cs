using System;

namespace BankingSystemAPI.Models
{
    public class Account
    {
        public int AccountNumber { get; set; } // This should be the primary key
        public string Owner { get; set; } = string.Empty; // Not null
        public decimal Balance { get; set; } = 0; // Default 0
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow; // Auto-generated
    }
}
