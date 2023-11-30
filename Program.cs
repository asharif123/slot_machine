//

namespace slot_machine
{
    internal class Program
    {
        static void Main()
        {
            Console.WriteLine("\nWelcome to Slot Machine!\n");
            //1 second delay
            System.Threading.Thread.Sleep(1000);

            const int ROW_COUNT = 3;
            const int COLUMN_COUNT = 3;

            //user's winnings, user starts at $50
            int winnings = 50;

            //insert values in spinning slot machine array
            //2 second delay
            Console.WriteLine("Spinning the wheel...\n");
            System.Threading.Thread.Sleep(2000);

            //array to store random digits
            //2D array that is 3 by 3
            int[,] spinningSlotMachine = new int[3, 3];
            Random rng = new Random();
            for (int i = 0; i <= ROW_COUNT - 1; i++)
            {
                for (int j = 0; j <= COLUMN_COUNT - 1; j++)
                {
                    int randomValue = rng.Next(10);
                    spinningSlotMachine[i, j] = randomValue;
                    Console.WriteLine(spinningSlotMachine[i, j]);
                }
                Console.WriteLine();
            }
            //user decides whether to match numbers horizontally/vertically/diagnolly
            Console.WriteLine("Enter 'h' to match numbers horizontally, 'v' to match vertically, 'd' to match diagonally\n");
            char userInput = Char.ToLower(Console.ReadKey().KeyChar);

            //testcase if user selects horizontal or vertical
            if (userInput == 'h' || userInput == 'v')
            {
                Console.WriteLine("\nEnter 1 to try to match 1 line or 3 to try to match 3 lines!\n");
                string val = Console.ReadLine();
                int intToVal = Convert.ToInt32(val);
            }
            //testcase if user selects diagnol
            else if (userInput == 'd')
            {
                Console.WriteLine("\nEnter 1 to try to match 1 line or 2 to try to match 2 lines!\n");
                string val = Console.ReadLine();
                int intToVal = Convert.ToInt32(val);
            }

            else
            {
                Console.WriteLine("\nPlease enter a valid input!\n");
                Main();
            }

            Console.WriteLine("\nPress y to continue playing or any key to quit!\n");
            char optionToContinue = Char.ToLower(Console.ReadKey().KeyChar);
            //if user wishes to continue, call the main function
            if (optionToContinue == 'y')
            {
                Main();
            }
            //quit the game
            return;
        }
    }
}