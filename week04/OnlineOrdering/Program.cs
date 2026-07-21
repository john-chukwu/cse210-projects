using System;

class Program
{
    static void Main(string[] args)
    {
        // First Order (USA)

        Address address1 = new Address(
            "123 Main Street",
            "Phoenix",
            "Arizona",
            "USA");

        Customer customer1 = new Customer("John Smith", address1);

        Order order1 = new Order(customer1);

        order1.AddProduct(new Product("Laptop", "P100", 850, 1));
        order1.AddProduct(new Product("Wireless Mouse", "P101", 25, 2));
        order1.AddProduct(new Product("Keyboard", "P102", 40, 1));

        // Second Order (International)

        Address address2 = new Address(
            "15 Aba Road",
            "Port Harcourt",
            "Rivers",
            "Nigeria");

        Customer customer2 = new Customer("Mary Johnson", address2);

        Order order2 = new Order(customer2);

        order2.AddProduct(new Product("Monitor", "P200", 220, 2));
        order2.AddProduct(new Product("USB Cable", "P201", 10, 5));
        order2.AddProduct(new Product("Headset", "P202", 65, 1));

        Console.WriteLine("====================================");
        Console.WriteLine(order1.GetPackingLabel());
        Console.WriteLine();
        Console.WriteLine(order1.GetShippingLabel());
        Console.WriteLine();
        Console.WriteLine($"Total Price: ${order1.CalculateTotalCost():F2}");

        Console.WriteLine();
        Console.WriteLine("====================================");
        Console.WriteLine(order2.GetPackingLabel());
        Console.WriteLine();
        Console.WriteLine(order2.GetShippingLabel());
        Console.WriteLine();
        Console.WriteLine($"Total Price: ${order2.CalculateTotalCost():F2}");
    }
}