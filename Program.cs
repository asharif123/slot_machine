//

namespace slot_machine
{
    internal class Program
    {
        static void Main()
        {
            const int ROW_COUNT = 3;
            const int COLUMN_COUNT = 3;
            const int MINIMUM_BET = 1;

            int winnings = 50;
            Console.WriteLine($"\nYou have ${winnings} that you can wager!\n");
            //user's winnings, user starts at $50

            //ask how much user wants to wager
            Console.WriteLine($"\nEnter a value from {MINIMUM_BET} to {winnings} that you would like to wager!\n");
            string wager = Console.ReadLine();
            int wagerVal = Convert.ToInt32(wager);
            if (wagerVal > winnings || wagerVal <= 0)
            {
                Console.WriteLine("\nPlease enter a positive wager value that is less than or equal your winnings!\n");
                Main();
            }

            //if user runs out of money to wager
            if (winnings <= 0)
            {
                Console.WriteLine("\nSorry, you have no more money left to bet! Exiting the game...\n");
                return;
            }

            //insert values in spinning slot machine array
            //2 second delay
            Console.WriteLine("Spinning the wheel...\n");

            //array to store random digits
            //2D array that is 3 by 3
            int[,] spinningSlotMachine = new int[3, 3];
            Random rng = new Random();
            for (int i = 0; i < ROW_COUNT; i++)
            {
                for (int j = 0; j < COLUMN_COUNT; j++)
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