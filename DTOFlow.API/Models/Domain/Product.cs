namespace DTOFlow.API.Models.Domain
{
    public class Product
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int StockQuantity { get; set; }
        public string Supplier { get; set; } // Sensitive info
        public decimal ProductionCost { get; set; } // Sensitive info
    }
}
