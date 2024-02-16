/* Project: MiniProject Week 7 Asset
 * author : Pedro Martinez
 * Date: 15/02/2024
 */

class Asset : Product // Child
{
   //Constructors 
   public Asset(
       string prodType,
       string brand,
       string model,
       double price) : base(prodType, brand, model, price)
   {
     
   }

    public Asset(
        string prodType,
        string brand,
        string model,
        double price,
        DateTime purchaseDate,
        string country) 
        : this(prodType, brand, model, price)
    {
        this.PurchaseDate = purchaseDate;
                this.Country = country;
        OnCreate();
       }

    //Properties
    public string Country { get; set; }
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
        int life = 365 * 3;

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
        //Console.WriteLine(" Life: = " + PurchaseDate.AddDays(365 * 3));
        //Console.WriteLine(" Life - 3 months = " + PurchaseDate.AddDays(365 * 3 - 90));
        //Console.WriteLine(Less3months);
        return Less3months;
    }

    
    public void SetLocalPrice() 
    { 
        if (Country == "SWEDEN" )
        {
            LocalPrice = LocalPrice * 10;
        }
        if (Country == "SPAIN")
        {
            LocalPrice = LocalPrice * 10.10;
        }
        if (Country == "USA")
        {
            LocalPrice = Price;
        }
    }

}