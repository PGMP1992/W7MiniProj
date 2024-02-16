/* Project: MiniProject Week 7 Asset
 * author : Pedro Martinez
 * Date: 15/02/2024
 */

// ============ Classes =======================

class Product  //Parent
{
    public Product(string prodType, string brand, string model, double price)
    {
        ProdType = prodType;
        Brand = brand;
        Model = model;
        Price = price;
    }

    //Properties
    public string ProdType { get; set; }
    public string Brand { get; set; }
    public string Model { get; set; }
    public double Price { get; set; }

    // Methods
}
