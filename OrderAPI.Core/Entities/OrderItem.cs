namespace OrderApi.Domain.Entities
{
    public class OrderItem
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }

        // Additional properties specific to your order item entity

        public decimal GetTotalPrice()
        {
            if (Quantity <= 0)
            {
                throw new InvalidOperationException("Quantity must be greater than zero.");
            }

            if (Product == null)
            {
                throw new InvalidOperationException("Product must be specified.");
            }

            if (Product.Price < 0)
            {
                throw new InvalidOperationException("Product price must be non-negative.");
            }

            return Quantity * Product.Price;
        }

        // Navigation property to access the associated product
        public Product Product { get; set; }
    }
}
