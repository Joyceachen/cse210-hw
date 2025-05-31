using System;
using System.Collections.Generic;
using System.Text;

public class Order
{
    private List<Product> _products;
    private Customer _customer;

    public Order(Customer customer)
    {
        _customer = customer;
        _products = new List<Product>();
    }

    // Getters and Setters
    public Customer GetCustomer() 
    { 
        return _customer; 
    }
    
    public void SetCustomer(Customer customer) 
    { 
        _customer = customer; 
    }

    public List<Product> GetProducts() 
    { 
        return _products; 
    }

    // Add product to order
    public void AddProduct(Product product)
    {
        _products.Add(product);
    }

    // Calculate total cost including shipping
    public double CalculateTotalCost()
    {
        double subtotal = 0;
        
        // Sum up all product costs
        foreach (Product product in _products)
        {
            subtotal += product.GetTotalCost();
        }

        // Add shipping cost
        double shippingCost = _customer.LivesInRwanda() ? 5.0 : 35.0;

        return subtotal + shippingCost;
    }

    // Generate packing label with product names and IDs
    public string GetPackingLabel()
    {
        StringBuilder label = new StringBuilder();
        label.AppendLine("PACKING LABEL:");
        label.AppendLine("==============");
        
        foreach (Product product in _products)
        {
            label.AppendLine($"Name: {product.GetName()}, ID: {product.GetProductId()}");
        }
        
        return label.ToString();
    }

    public string GetShippingLabel()
    {
        StringBuilder label = new StringBuilder();
        label.AppendLine("SHIPPING LABEL:");
        label.AppendLine("===============");
        label.AppendLine($"{_customer.GetName()}");
        label.AppendLine($"{_customer.GetAddress().GetFullAddress()}");
        
        return label.ToString();
    }
}
