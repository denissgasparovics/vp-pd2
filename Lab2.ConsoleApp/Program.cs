using Lab2.DataAccess;

namespace Lab2.ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using var db = new OrderDbContext();

            var deliveredOrders = db.Orders
                .Where(o => o.Status == OrderStatus.Delivered)
                .ToList();

            Console.WriteLine("Delivered orders:");

            foreach (var order in deliveredOrders)
            {
                Console.WriteLine(
                    $"{order.OrderNumber} | {order.OrderDate:d} | {order.Status}"
                );
            }

            var orderByNumber = db.Orders
                .FirstOrDefault(o => o.OrderNumber == "ORD-001");

            if (orderByNumber != null)
            {
                Console.WriteLine("\nFound order:");

                Console.WriteLine(
                    $"{orderByNumber.OrderNumber} | " +
                    $"{orderByNumber.OrderDate:d} | " +
                    $"{orderByNumber.Status}"
                );
            }
            else
            {
                Console.WriteLine("\nOrder not found.");
            }

            var newOrder = new Order
            {
                OrderNumber = "ORD-003",
                OrderDate = DateTime.Now,
                Status = OrderStatus.Shipped,
                CustomerId = 1,
            };

            db.Orders.Add(newOrder);
            db.SaveChanges();

            Console.WriteLine(
                $"\nAdded order: {newOrder.OrderNumber}"
            );

            var orderToUpdate = db.Orders
                .FirstOrDefault(o => o.OrderNumber == "ORD-001");

            if (orderToUpdate != null)
            {
                orderToUpdate.Status = OrderStatus.Delivered;

                db.SaveChanges();

                Console.WriteLine(
                    $"Updated order: {orderToUpdate.OrderNumber}"
                );
            }
            else
            {
                Console.WriteLine("Order to update not found.");
            }

            var orderToDelete = db.Orders
                .FirstOrDefault(o => o.OrderNumber == "ORD-003");

            if (orderToDelete != null)
            {
                db.Orders.Remove(orderToDelete);
                db.SaveChanges();

                Console.WriteLine(
                    $"Deleted order: {orderToDelete.OrderNumber}"
                );
            }
            else
            {
                Console.WriteLine("Order to delete not found.");
            }
        }
    }
}
