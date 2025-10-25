using webapi.Enums;

namespace webapi.Model
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public string? UserId { get; set; }
        public double Limit { get; set; } 
    }
}
