using Microsoft.EntityFrameworkCore;
using OrderApi.Domain.Entities;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }
    public ApplicationDbContext() { }
    public DbSet<Product> Products { get; set; }
    public DbSet<OrderItem> OrderItems { get; set; }

    public DbSet<Customer> Customers { get; set; }

    // Add methods for CRUD operations for Product and OrderItem entities
    public async Task<int> AddProductAsync(Product product)
    {
        if (product == null)
        {
            throw new ArgumentNullException(nameof(product));
        }

        Products.Add(product);
        await SaveChangesAsync();
        return product.Id;
    }

    public async Task<Product> GetProductByIdAsync(int productId)
    {
        return await Products.FirstOrDefaultAsync(p => p.Id == productId);
    }

    public async Task<int> AddOrderItemAsync(OrderItem orderItem)
    {
        if (orderItem == null)
        {
            throw new ArgumentNullException(nameof(orderItem));
        }

        OrderItems.Add(orderItem);
        await SaveChangesAsync();
        return orderItem.Id;
    }

    public async Task<OrderItem> GetOrderItemByIdAsync(int orderItemId)
    {
        return await OrderItems.FirstOrDefaultAsync(oi => oi.Id == orderItemId);
    }

    // Add other methods for CRUD operations as needed

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Configure the Order entity
        modelBuilder.Entity<Order>(order =>
        {
            order.HasKey(o => o.Id);
            order.Property(o => o.CustomerId)
                .IsRequired();
            order.Property(o => o.OrderDate)
                .IsRequired();

            // Configure the Order entity
            // Configure the Order entity
            modelBuilder.Entity<Order>(order =>
            {
                order.HasKey(o => o.Id);
                order.Property(o => o.CustomerId)
                    .IsRequired();
                order.Property(o => o.OrderDate)
                    .IsRequired();

                // Define the one-to-many relationship between Order and OrderItem
                order.HasMany(o => o.OrderItems)
                    .WithOne()
                    .IsRequired() // Add this line if OrderItems are required for an order
                    .OnDelete(DeleteBehavior.Cascade); // Add this line to enable cascade delete if needed

                order.ToTable("Orders"); // Specify the table name for Orders
            });



            order.ToTable("Orders"); // Specify the table name for Orders
        });

        // Configure the OrderItem entity
        modelBuilder.Entity<OrderItem>(orderItem =>
        {
            orderItem.HasKey(oi => oi.Id);
            orderItem.Property(oi => oi.ProductId)
                .IsRequired();
            orderItem.Property(oi => oi.Quantity)
                .IsRequired();

            // Define the many-to-one relationship between OrderItem and Product
            orderItem.HasOne(oi => oi.Product)
                .WithMany()
                .HasForeignKey(oi => oi.ProductId);

            orderItem.ToTable("OrderItems"); // Specify the table name for OrderItems
        });

        // Configure the Product entity
        modelBuilder.Entity<Product>(product =>
        {
            product.HasKey(p => p.Id);
            product.Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(100);
            product.Property(p => p.Description)
                .HasMaxLength(500);
            product.Property(p => p.Price)
                .IsRequired()
                .HasColumnType("decimal(18, 2)"); 
            product.Property(p => p.StockQuantity)
                .IsRequired();
            product.Property(p => p.Category)
                .HasMaxLength(50);
            product.Property(p => p.Manufacturer)
                .HasMaxLength(50);

            // Specify custom table name for Products
            product.ToTable("Products");
        });

         // Configure the Customer entity
        modelBuilder.Entity<Customer>(customer =>
        {
            customer.HasKey(c => c.Id);
            customer.Property(c => c.FirstName)
                .IsRequired()
                .HasMaxLength(100);
            customer.Property(c => c.LastName)
                .IsRequired()
                .HasMaxLength(100);
            customer.Property(c => c.Email)
                .IsRequired()
                .HasMaxLength(255)
                .IsUnicode(false); // Use Unicode false for email
            customer.Property(c => c.RegistrationDate)
                .IsRequired();
            customer.Property(c => c.IsActive)
                .IsRequired();

            // Specify custom table name for Customers
            customer.ToTable("Customers");
        });

        // Define relationships between entities
        // Configure the one-to-many relationship between Customer and Order
        modelBuilder.Entity<Customer>()
            .HasMany(c => c.Orders)
            .WithOne()
            .HasForeignKey(o => o.CustomerId)
            .OnDelete(DeleteBehavior.Cascade);

        // Additional configurations for other entities can be added here
    }


}
