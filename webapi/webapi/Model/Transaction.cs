using Microsoft.AspNetCore.Identity;
using webapi.Enums;

namespace webapi.Model
{
    public class Transaction
    {
        public int Id { get; set; }
        public string? Description { get; set; }
        public decimal Amount { get; set; }
        public DateTime TransactionDate { get; set; }
        public Category Category { get; set; }
        public TransactionType type { get; set; }
        public bool isRecurring { get; set; }
        public RecurrenceType? Recurrence { get; set; }
        public string UserId { get; set; } = null!;
    }
}
