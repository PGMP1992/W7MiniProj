/* Project: MiniProject Week 7 Asset
 * author : Pedro Martinez
 * Date: 16/02/2024
 */

using static W7_MiniProject.Utils;

// Vars
bool exit = false;
bool exitProgram = false;
bool validData = false;
bool populateList = true;

string[] countries = { "1", "2", "3", "Q" }; // entry for country 

string sImput = "",
       sType = "",
       sBrand = "",
       sModel = "",
       sCountry = "",
       sShortName = "";

double dPrice = 0.00,
       dlocalPrice = 0.00;

DateTime dt = Convert.ToDateTime("01-01-2021");

// Create a list to save Asset objects 
List<Asset> listAssets = new List<Asset>();

while (! exitProgram)  // Enter Data
{
    while (!exit)
    {
        validData = true; // reset new entry  
        Console.WriteLine();
        MsgColor(" Please enter data | enter \"Q\" " + "to exit.", "b");

        while (!exit)
        {
            Console.Write("Type: ");
            sType = CheckString(Console.ReadLine());
            
            if (sType == "Q")
            {
                exit = true;
                exitProgram = true;
                validData = false;
                break;
            }
            else if (sType.Length > 0)
            {
                break;
            }
        }

        while (!exit)
        {
            Console.Write("Brand: ");
            sBrand = CheckString(Console.ReadLine());
            if (sBrand == "Q")
            {
                exit = true;
                exitProgram = true;
                validData = false;
                break;
            }

            else if (sBrand.Length > 0)
            {
                break;
            }
        }

        while (!exit)
        {
            Console.Write("Model: ");
            sModel = CheckString(Console.ReadLine());
            if (sModel == "Q")
            {
                exit = true;
                exitProgram = true;
                validData = false;
                break;
            }
            else if (sModel.Length > 0)
            {
                break;
            }
        }

        while (!exit)
        {
            MsgColor("Enter 1 - Sweden, 2 - Spain, 3 - USA", "b");
            Console.Write("Country: "); // Currency Id 
            sImput = CheckString(Console.ReadLine());

            if (countries.Contains(sImput))
            {
                if (sImput == "1")
                {
                    sCountry = "SWEDEN";
                    sShortName = "SEK";
                    dlocalPrice = dPrice * 10;
                    break;
                }
                else if (sImput == "2")
                {
                    sCountry = "SPAIN";
                    sShortName = "EUR";
                    dlocalPrice = dPrice * 1.10;
                    break;
                }
                else if (sImput == "3")
                {
                    sCountry = "USA";
                    sShortName = "USD";
                    dlocalPrice = Convert.ToDouble(sImput);
                    break;
                }
                else if (sImput == "Q")
                {
                    exit = true;
                    exitProgram = true;
                    validData = false;
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
                Console.Write("Purchase Date DD/MM/YYYY: ");
                sImput = Console.ReadLine().Trim().ToUpper();
                if (sImput == "Q")
                {
                    exit = true;
                    exitProgram = true;
                    validData = false;
                    break;
                }
                dt = Convert.ToDateTime(sImput); 
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
                sImput = Console.ReadLine().Trim().ToUpper();
                if (sImput == "Q")
                {
                    exit = true;
                    exitProgram = true;
                    validData = false;
                    break;
                }
                dPrice = Convert.ToDouble(sImput);
                break;
            }
            catch (Exception)
            {
                MsgInvalidEntry();
            }
        }

        if (validData) // Add Asset Obj in list
        {
            listAssets.Add( new Asset( sType, sBrand, sModel, dPrice, dt, sCountry, sShortName, dlocalPrice));
            MsgColor("Asset entry succesfull! ", "y");
        }

    } // While ! exit

    if (exit) // Show list
    {
        // create lists to show if list not empty 
        if (listAssets.Count > 0)
        {
            if (populateList)  // Load extra data
            { 
                PopulateAssets(listAssets);
                populateList = false;
            }

             //Sort List by Office and  Purchase
             
            IEnumerable<Asset> query = 
                        from p in listAssets
                        orderby p.Country,p.PurchaseDate
                        select p;

            //List<Asset> sortCountry = listAssets.OrderBy(p => p.Country + p.PurchaseDate ).ToList();

            MsgColor(" Assets Sorted by Office and Purchase Date ", "y");
            ShowList(query);
            Console.WriteLine("");

            while (exit)
            {
                MsgColor("Would you like to enter more assets ? (Y/N)", "b");
                sImput = CheckString(Console.ReadLine());
                if (sImput == "Y")
                {
                    exitProgram = false;
                    exit = false;
                    break;
                }
                else if (sImput == "N")
                {
                    exitProgram = true;
                    exit = true;
                    break;
                }
            } //while exit
        
        } // if count > 0 

    } //  if exit

} // while ! exitProgram; 


// local Procedures

static void PopulateAssets (List<Asset> list) // Add extra Entries to List
{
    // Create other Asset objects 
    list.Add(new Asset("Computer", "HP", "EliteBook", 1200.00, Convert.ToDateTime("2021-12-01"), "SWEDEN", "SEK" , 10)) ; // 3 years 
    list.Add(new Asset("Phone", "Motorola", "Razor 2", 3000,   Convert.ToDateTime("2021-09-01"), "SWEDEN", "SEK", 10));
    list.Add(new Asset("Phone", "IPhone", "6", 970,            Convert.ToDateTime("2021-06-01"), "USA", "USD", 1)); // 6 months
    list.Add(new Asset("Computer", "HP", "EliteBook 2", 1200,  Convert.ToDateTime("2021-09-01"), "USA", "USD", 1));
    list.Add(new Asset("Phone", "Motorola", "Razor", 1200,     Convert.ToDateTime("2018-09-01"), "SPAIN", "EUR", 1.10)); // 3 months
    list.Add(new Asset("Phone", "IPhone", "8", 970,            Convert.ToDateTime("2019-03-01"), "SPAIN", "EUR", 1.10));
}


static void ShowList(IEnumerable<Asset> aquery)
{
    MsgColor("   Type ".PadRight(13) + " Brand ".PadRight(11) + " Model ".PadRight(13) +
                          " Country ".PadRight(11) + " Purchase Date ".PadRight(16) +
                          " Price USD".PadRight(12) + "Local Price", "g");
    int i = 0;
    string scolor = "";
    
    foreach (Asset p in aquery)
    {
        i++;

        if (p.Less3months) { scolor = "r"; } // Show Red if life 3 months
        else if (p.Less6months && !p.Less3months) { scolor = "y"; } // Show Yellow if life 6 months 
        else { scolor = "w"; } // Show normal color

        MsgColor(i + ":" +
                      " " + p.ProdType.PadRight(10) +
                      " " + p.Brand.PadRight(10) +
                      " " + p.Model.PadRight(12) +
                      " " + p.Country.PadRight(10) +
                      " " + p.PurchaseDate.ToShortDateString().PadRight(15) +
                      " " + p.Price.ToString().PadRight(10) +
                      " " + p.ShortName.PadRight(2) +
                      " " + p.LocalPrice, scolor);
    }

    MsgColor(" Red => 3 months life left |   Yellow => 6 months life left", "b");
    Console.WriteLine("");
}