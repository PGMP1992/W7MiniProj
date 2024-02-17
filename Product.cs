/* Project: MiniProject Week 7 Asset
 * Currency Class 
 * author : Pedro Martinez
 * Date: 15/02/2024
 */

class Product : Currency
    {
    // Constructors
    public Product(string prodType, string brand, string model, double price)
    {
        ProdType = prodType;
        Brand = brand;
        Model = model;
        Price = price;
    }

    public Product(string prodType, string brand, string model, double price, 
        string country, string shortname, double dollarRate)
    {
        ProdType = prodType;
        Brand = brand;
        Model = model; 
        Price = price;
        Country = country;
        //Name = name;
        ShortName = shortname;
        DollarRate = dollarRate;
    }

    //Properties
    public string ProdType { get; set; }
    public string Brand { get; set; }
    public string Model { get; set; }
    public double Price { get; set; } 

            // Methods
    }
