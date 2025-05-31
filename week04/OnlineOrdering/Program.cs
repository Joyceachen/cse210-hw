using System;

public class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Online Ordering System");
        Console.WriteLine("======================\n");

        // Create first order (Rwandan customer)
        Address address1 = new Address("Kigali", "Central", "Rwanda");
        Customer customer1 = new Customer("Umutoni Joan", address1);
        Order order1 = new Order(customer1);

        Product product1 = new Product("Travel bag", "TRAV-001", 899.99, 1);
        Product product2 = new Product("Hand bag", "HB-002", 29.99, 2);
        Product product3 = new Product("Purse", "PUR-003", 12.50, 3);

        order1.AddProduct(product1);
        order1.AddProduct(product2);
        order1.AddProduct(product3);

        // Display first order details
        Console.WriteLine("ORDER #1");
        Console.WriteLine("--------");
        Console.WriteLine(order1.GetPackingLabel());
        Console.WriteLine(order1.GetShippingLabel());
        Console.WriteLine($"Total Cost: ${order1.CalculateTotalCost():F2}");
        Console.WriteLine();

        // Create second order (International customer)
        Address address2 = new Address("Queens Avenue", "Nairobi", "Nairobi County", "Kenya");
        Customer customer2 = new Customer("Ndugu Joel", address2);
        Order order2 = new Order(customer2);

        Product product4 = new Product("Smartwatch", "WATCH-004", 649.99, 1);
        Product product5 = new Product("Wireless cable", "CABLE-005", 24.99, 1);
        Product product6 = new Product("Screen guard", "SCREEN-006", 9.99, 2);

        order2.AddProduct(product4);
        order2.AddProduct(product5);
        order2.AddProduct(product6);

        // Display second order details
        Console.WriteLine("ORDER #2");
        Console.WriteLine("--------");
        Console.WriteLine(order2.GetPackingLabel());
        Console.WriteLine(order2.GetShippingLabel());
        Console.WriteLine($"Total Cost: ${order2.CalculateTotalCost():F2}");
        Console.WriteLine();

        // Create third order (Rwandan customer with multiple products)
        Address address3 = new Address("Main Street", "Kigali", "Rwanda");
        Customer customer3 = new Customer("Niwamanya Kenneth", address3);
        Order order3 = new Order(customer3);

        Product product7 = new Product("Gaming Headset", "HEAD-007", 79.99, 1);
        Product product8 = new Product("Mechanical Keyboard", "KEY-008", 129.99, 1);

        order3.AddProduct(product7);
        order3.AddProduct(product8);

        // Display third order details
        Console.WriteLine("ORDER #3");
        Console.WriteLine("--------");
        Console.WriteLine(order3.GetPackingLabel());
        Console.WriteLine(order3.GetShippingLabel());
        Console.WriteLine($"Total Cost: ${order3.CalculateTotalCost():F2}");

        Console.WriteLine("\nProgram completed successfully!");
    }
}
