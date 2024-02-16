﻿/* Project: MiniProject Week 7 Asset
 * Currency Class 
 * author : Pedro Martinez
 * Date: 15/02/2024
 */

class Currency
{
    public Currency(string country, string name, string shortName, double dollarRate)
    {
        Country = country;
        Name = name;
        ShortName = shortName;
        DollarRate = dollarRate;
    }

    // Properties
    public string Country { get; set; }
    public string Name { get; set; }
    public string ShortName { get; set; }
    public double DollarRate { get; set; }

    // Methods
    public double CurrentPrice(double price)
    {
        return price * DollarRate;
    }
}
