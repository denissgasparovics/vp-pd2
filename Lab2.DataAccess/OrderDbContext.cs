using Microsoft.EntityFrameworkCore;

namespace Lab2.DataAccess
{
    public class OrderDbContext : DbContext
    {
        public DbSet<Order> Orders { get; set; }

        public DbSet<OrderItem> OrderItems { get; set; }

        public DbSet<Customer> Customers { get; set; }

        public OrderDbContext()
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseSqlServer("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Documents\\Work\\Lab2\\Lab2.DataAccess\\OrderDb.mdf;Integrated Security=True");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Order>().HasData(
                new Order
                {
                    Id = 1,
                    OrderNumber = "ORD-001",
                    OrderDate = new DateTime(2026, 10, 1),
                    Status = OrderStatus.Shipped,
                    CustomerId = 1
                },
                new Order
                {
                    Id = 2,
                    OrderNumber = "ORD-002",
                    OrderDate = new DateTime(2026, 10, 3),
                    Status = OrderStatus.Delivered,
                    CustomerId = 2
                });

            modelBuilder.Entity<OrderItem>().HasData(
                new OrderItem 
                { 
                    Id = 1, OrderId = 1, 
                    ProductName = "Laptop", 
                    Quantity = 1, 
                    UnitPrice = 999.99m 
                },
                new OrderItem 
                { 
                    Id = 2, 
                    OrderId = 1, 
                    ProductName = "Mouse", 
                    Quantity = 2, 
                    UnitPrice = 19.90m 
                },
                new OrderItem 
                { 
                    Id = 3, 
                    OrderId = 2, 
                    ProductName = "Keyboard", 
                    Quantity = 1, 
                    UnitPrice = 59.00m 
                },
                new OrderItem 
                { 
                    Id = 4, 
                    OrderId = 2, 
                    ProductName = "Monitor", 
                    Quantity = 2, 
                    UnitPrice = 189.50m 
                });

            modelBuilder.Entity<Customer>().HasData(
                new Customer
                {
                    Id = 1,
                    Name = "John Smith",
                    Email = "john.smith@gmail.com"
                },
                new Customer
                {
                    Id = 2,
                    Name = "Anna Brown",
                    Email = "anna.brown@gmail.com"
                });
        }

    }
}
