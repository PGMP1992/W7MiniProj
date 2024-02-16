/* Project: MiniProject Week 7 Asset
 * author : Pedro Martinez
 * Date: 15/02/2024
 */

using static W7_MiniProject.Utils;

// Vars
bool exit = false;
bool validData = false;
string[] countries = { "1", "2", "3", "Q" }; // entry for country 
string sImput = "";
string scolor = "";

// Create Currency Objs
Currency c1 = new Currency("SWEDEN", "Swedish Krona", "SEK", 0.10);
Currency c2 = new Currency("SPAIN", "Euro", "EUR", 1.10);
Currency c3 = new Currency("USA", "Dollar", "USD", 1.00);

// Create Asset obj 
Asset as1 = new Asset("", "", "",0, Convert.ToDateTime("2018, 12, 29"), "SWEDEN");

// Create a list to save the objects 
List<Asset> listAssets = new List<Asset>();


// Enter Data

while (!exit)
{
    validData = true; // reset new entry  
    Console.WriteLine();
    MsgColor(" Please enter data | enter \"Q\" " + "to exit.", "b");

    while (!exit)
    {
        Console.Write("Type: ");
        as1.ProdType = CheckString(Console.ReadLine());
        if (as1.ProdType == "Q")
        {
            exit = true;
            validData = false;
            break;
        }
        else if (as1.ProdType.Length > 0)
        {
            break;
        }
    }

    while (!exit)
    {
        Console.Write("Brand: ");
        as1.Brand = CheckString(Console.ReadLine());
        if (as1.Brand == "Q")
        {
            exit = true;
            validData = false;
            break;
        }
        else if (as1.Brand.Length > 0)
        {
            break;
        }
    }

    while (!exit)
    {
        Console.Write("Model: ");
        as1.Model = CheckString(Console.ReadLine());
        if (as1.Model == "Q")
        {
            exit = true;
            validData = false;
            break;
        }
        else if (as1.Model.Length > 0)
        {
            break;
        }
    }

    while (!exit)
    {
        MsgColor("Enter 1 - Sweden, 2 - Spain, 3 - USA", "b");
        Console.Write("Country: "); // Currency Id 
        sImput = Console.ReadLine().Trim().ToUpper();

        if (countries.Contains(sImput))
        {
            if (sImput == "1")
            {
                as1.Country = "SWEDEN";
                break;
            }
            else if (sImput == "2")
            {
                as1.Country = "SPAIN";
                break;
            }
            else if (sImput == "3")
            {
                as1.Country = "USA";
                break;
            }
            else if (sImput == "Q")
            {
                validData = false;
                exit = true;
                break;
            }
        }
        else
        {
            MsgInvalidEntry();
        }
    }

    while (!exit)
    {
        try
        {
            Console.Write("Purchase Date: ");
            as1.PurchaseDate = Convert.ToDateTime(Console.ReadLine().Trim().ToUpper());
            break;
        }
        catch (Exception)
        {
            MsgInvalidEntry();
        }
    }

    while (!exit)
    {
        try
        {
            Console.Write("Price: ");
            as1.Price = Convert.ToInt32(Console.ReadLine().Trim().ToUpper());
            break;
        }
        catch (Exception)
        {
            MsgInvalidEntry();
        }
    }

    if (validData)
    {
        listAssets.Add(as1);
        as1.OnCreate();
        MsgColor("Asset entry succesfull! ", "y");
    }

} // While 

if (exit) // Show list
{
    // create lists to show if list not empty 
    if (listAssets.Count > 0)
    {
        PopulateAssets(listAssets); // Load extra data

        
        // Show List Sorted by Type =========================================
        
        List<Asset> sortByType = listAssets.OrderBy(p => p.ProdType).ToList();

        Console.WriteLine("");
        MsgColor(" Assets Sorted by Type:", "y");
        MsgColor("   Type ".PadRight(13) + " Brand ".PadRight(11) + " Model ".PadRight(13) +
                              " Country ".PadRight(11) + " Purchase Date ".PadRight(21) + " Price ", "g");
        int i = 0;
        
        foreach (Asset p in sortByType)
        {
            i++;
        
            if (p.Less3months ) // Show Red
            {
                scolor = "r";
            }

            else if ( p.Less6months && !p.Less3months)  // Show Yellow 
            {
                scolor = "y";
            }

            else // Show normal color 
            {
                scolor = "w";
            }

            MsgColor(i + ":" +
                              " " + p.ProdType.PadRight(10) +
                              " " + p.Brand.PadRight(10) +
                              " " + p.Model.PadRight(12) +
                              " " + p.Country.PadRight(10) +
                              " " + p.PurchaseDate.ToShortDateString().PadRight(20) +
                              " " + p.Price, scolor);

        }

        MsgColor( " Red => 3 months life left |   Yellow => 6 months life left", "b");

        
        //Sort List Sorted by Date =========================================

        List<Asset> sortByDate = listAssets.OrderBy(p => p.PurchaseDate).ToList();
        MsgColor(" Press any key to show Assets sorted by Date", "Blue");

        Console.ReadLine();
        MsgColor(" Assets Sorted by Date ", "y");
        MsgColor("   Type ".PadRight(13) + " Brand ".PadRight(11) + " Model ".PadRight(13) +
                          " Country ".PadRight(11) + " Purchase Date ".PadRight(21) + " Price ", "g");
        i = 0;

        foreach (Asset p in sortByDate)
        {
            i++;

            if (p.Less3months) // Show Red
            {
                scolor = "r";
            }

            else if (p.Less6months && !p.Less3months)  // Show Yellow 
            {
                scolor = "y";
            }

            else // Show normal color 
            {
                scolor = "w";
            }

            MsgColor(i + ":" +
                              " " + p.ProdType.PadRight(10) +
                              " " + p.Brand.PadRight(10) +
                              " " + p.Model.PadRight(12) +
                              " " + p.Country.PadRight(10) +
                              " " + p.PurchaseDate.ToShortDateString().PadRight(20) +
                              " " + p.Price, scolor);
        }

        MsgColor(" Red => 3 months life left |   Yellow => 6 months life left", "b");
    }
} //  if exit

// local Procedures

static void PopulateAssets (List<Asset> listAssets)
{
    // Create other Asset objects 
    Asset as2 = new Asset("Computer", "HP", "EliteBook", 1200.00, Convert.ToDateTime("2021-01-01"), "SWEDEN"); // 3 years 
    Asset as3 = new Asset("Phone", "Motorola", "Razor", 1200, Convert.ToDateTime("2021-03-01"), "SPAIN"); // 3 months
    Asset as4 = new Asset("Phone", "IPhone", "6", 970, Convert.ToDateTime("2021-06-01"), "USA"); // 6 months
    Asset as5 = new Asset("Computer", "HP", "EliteBook 2", 1200, Convert.ToDateTime("2021-09-01"), "USA");
    Asset as6 = new Asset("Phone", "Motorola", "Razor 2", 3000, Convert.ToDateTime("2021-12-01"), "SWEDEN");
    Asset as7 = new Asset("Phone", "IPhone", "8", 970, Convert.ToDateTime("2020, 09, 01"), "SPAIN");
    
    // Method to set Properies in Asset.
    // There must be a better way to do that on the constructor. Oh Well...Living and learning 
    //as3.OnCreate();
    //as4.OnCreate();
    //as5.OnCreate();
    //as6.OnCreate();
    //as7.OnCreate();

    // Populate listAssets;
    listAssets.Add(as2);
    listAssets.Add(as3);
    listAssets.Add(as4);
    listAssets.Add(as5);
    listAssets.Add(as6);
    listAssets.Add(as7);
}
