/* Project: MiniProject Week 7 Asset
 * author : Pedro Martinez
 * Date: 15/02/2024
 */

class Asset : Product // Child
{
    //Constructors 
    public Asset(string prodType, string brand, string model, double price, DateTime purchaseDate,  
        string country, string shortname, double dollarRate) : 
        base (prodType, brand, model, price, country, shortname, dollarRate)
    {
        ProdType = prodType;
        Brand = brand;  
        Model = model;
        Price = price;
        PurchaseDate = purchaseDate;
        Country = country;
        ShortName = shortname;
        DollarRate = dollarRate;

        OnCreate();
    }

    //Properties
    public DateTime PurchaseDate { get; set; }
    public bool Less6months { get; set; }
    public bool Less3months { get; set; }
    public double LocalPrice { get; set; }

    
    // Methods

    // Initialise Properties
    public void OnCreate()
    {
        Check3Months();
        Check6Months();
        SetLocalPrice();
    }

    // Check if 6 months left in Asset Life 
    public bool Check6Months()
    {
        // 3 years - 180 days
        if ( DateTime.Now <= PurchaseDate.AddDays( (365*3) -180 ))
        {
            Less6months = false;
        }
        else
        {
            Less6months = true;
        }
        return Less6months;
    }

    // Check if 3 months left in Asset Life
    public bool Check3Months()
    {
        // 3 years - 90 days
        if (DateTime.Now <= PurchaseDate.AddDays(365 * 3 - 90 )) 
        {
            
            Less3months = false;
        }
        else
        {
            Less3months = true;
        }
        return Less3months;
    }

    
    // Iitialise Currency Properties
    public void SetLocalPrice() 
    { 
        if (Country == "SWEDEN" )
        {
            LocalPrice = Price * 10;
            ShortName = "SEK";
        }
        if (Country == "SPAIN")
        {
            LocalPrice = Price * 1.10;
            ShortName = "EUR";
        }
        if (Country == "USA")
        {
            LocalPrice = Price;
            ShortName = "USD";
        }
    }

}