
namespace W7_MiniProject
{
    internal class Utils
    {
        public static string CheckString(string s)
        {
            s = s.Trim().ToUpper();
            if (s.Length == 0)
            {
                MsgInvalidEntry();
            }
            return s;
        }


        //  Show error message 
        public static void MsgInvalidEntry()
        {
            MsgColor("Invalid Entry! Please try again: ", "r");
        }

        
        // Color text in Prompt 
        public static void MsgColor(string msg, string color)
        {
            switch (color)
            {
                case "y":
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    break;
                case "r":
                    Console.ForegroundColor = ConsoleColor.Red;
                    break;
                case "g":
                    Console.ForegroundColor = ConsoleColor.Green;
                    break;
                case "b":
                    Console.ForegroundColor = ConsoleColor.Blue;
                    break;
                case "w":
                    Console.ForegroundColor = ConsoleColor.White;
                    break;
            }
            Console.WriteLine(msg);
            Console.ResetColor();
        }

         
    }
}
