using System;

public class Address
{
    private string _streetAddress;
    private string _city;
    private string _stateProvince;
    private string _country;
    private string v1;
    private string v2;
    private string v3;

    public Address(string streetAddress, string city, string stateProvince, string country)
    {
        _streetAddress = streetAddress;
        _city = city;
        _stateProvince = stateProvince;
        _country = country;
    }

    public Address(string v1, string v2, string v3)
    {
        _streetAddress = v1;
        _city = v2;
        _stateProvince = v3;
        _country = ""; // or set to a default value if needed
    }

    public string GetStreetAddress() 
    { 
        return _streetAddress; 
    }
    
    public void SetStreetAddress(string streetAddress) 
    { 
        _streetAddress = streetAddress; 
    }

    public string GetCity() 
    { 
        return _city; 
    }
    
    public void SetCity(string city) 
    { 
        _city = city; 
    }

    public string GetStateProvince() 
    { 
        return _stateProvince; 
    }
    
    public void SetStateProvince(string stateProvince) 
    { 
        _stateProvince = stateProvince; 
    }

    public string GetCountry() 
    { 
        return _country; 
    }
    
    public void SetCountry(string country) 
    { 
        _country = country; 
    }

    // Check if address is in Rwanda
    public bool IsInRwanda()
    {
        return _country.ToUpper() == "Rwanda" || 
               _country.ToUpper() == "RW" || 
               _country.ToUpper() == "REPUBLIC OF Rwanda";
    }

    // Return formatted address string
    public string GetFullAddress()
    {
        return $"{_streetAddress}\n{_city}, {_stateProvince}\n{_country}";
    }
}
