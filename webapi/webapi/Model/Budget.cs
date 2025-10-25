namespace webapi.Model
{
    public class Budget
    {
        public int Id { get; set; }
        public string UserId { get; set; } = null!;
        public decimal MonthlyLimit { get; set; }
        public List<Category> Categories { get; set; } = new();
        public List<Transaction> Transactions { get; set; } = new();
    }
}
