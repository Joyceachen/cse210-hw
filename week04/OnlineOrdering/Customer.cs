using System;

public class Customer
{
    private string _name;
    private Address _address;

    public Customer(string name, Address address)
    {
        _name = name;
        _address = address;
    }

    // Getters and Setters
    public string GetName() 
    { 
        return _name; 
    }
    
    public void SetName(string name) 
    { 
        _name = name; 
    }

    public Address GetAddress() 
    { 
        return _address; 
    }
    
    public void SetAddress(Address address) 
    { 
        _address = address; 
    }

    // Check if the customer lives in Rwanda
    public bool LivesInRwanda()
    {
        return _address.IsInRwanda();
    }
}
