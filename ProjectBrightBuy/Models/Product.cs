using SQLite;

namespace BrightBuy.Models
{
    public class Product
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string ProductName { get; set; }
        public string ProductType { get; set; }
        public decimal Price { get; set; }
    }
}