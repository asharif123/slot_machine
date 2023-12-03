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
            const int STARTING_BANK_AMOUNT = 50;

            Console.WriteLine($"\nYou have ${STARTING_BANK_AMOUNT} that you can wager!\n");
            //user's winnings, user starts at $50
            int winnings = STARTING_BANK_AMOUNT;

            //ask how much user wants to wager
            Console.WriteLine($"\nEnter a value from {MINIMUM_BET} to {winnings} that you would like to wager!\n");
            string wager = Console.ReadLine();
            int wagerVal = Convert.ToInt32(wager);
            bool notValidInput = true;

            //ensure user enters valid wager
            while (notValidInput)
            {
                if (wagerVal > winnings || wagerVal <= 0)
                {
                    Console.WriteLine("\nPlease enter a positive wager value that is less than or equal your winnings!\n");
                    wager = Console.ReadLine();
                    wagerVal = Convert.ToInt32(wager);
                }
                notValidInput = false;
            }

            //how much money user loses based off wager amount
            winnings -= wagerVal;
            //if user runs out of money to wager
            if (winnings <= 0)
            {
                Console.WriteLine("\nSorry, you have no more money left to bet! Exiting the game...\n");
                return;
            }

            //user decides whether to match numbers horizontally/vertically/diagnolly
            Console.WriteLine("Enter 'h' to match numbers horizontally, 'v' to match vertically, 'd' to match diagonally\n");
            char userInput = Char.ToLower(Console.ReadKey().KeyChar);

            //if user selects either horizontal or vertical, user can match either 1 or 3 lines
            if (userInput == 'h' || userInput == 'v') {
                Console.WriteLine("\nEnter 1 to try to match 1 line or 3 to try to match 3 lines!\n");
            }

            //if diagnol, ask user to match either 1 or 2 lines
            else if (userInput == 'd')
            {
                Console.WriteLine("\nEnter 1 to try to match 1 line or 2 to try to match 2 lines!\n");
            }

            string val = Console.ReadLine();
            int intToVal = Convert.ToInt32(val);

            //insert values in spinning slot machine array
            Console.WriteLine("\nSpinning the wheel...\n");

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

            //horizontal scenarios
            //if any single horizontal row matches
            if (userInput == 'h' && intToVal == 1)
            {
                if ((spinningSlotMachine[0,0] == spinningSlotMachine[0,1]) && (spinningSlotMachine[0,1] == spinningSlotMachine[0,2]) ||
                    (spinningSlotMachine[1,0] == spinningSlotMachine[1,1]) && (spinningSlotMachine[1,1] == spinningSlotMachine[1,2]) ||
                    (spinningSlotMachine[2,0] == spinningSlotMachine[2,1]) && (spinningSlotMachine[2,1] == spinningSlotMachine[2,2]))
                {
                    Console.WriteLine("You matched a single horizontal line!\n");
                    winnings += wagerVal;
                    Console.WriteLine($"Your total winnings are {winnings}\n");
                }                
                else
                {
                    Console.WriteLine("You did not match a single horizontal line!\n");
                    winnings -= wagerVal;
                    Console.WriteLine($"Your total winnings are {winnings}\n");
                }
            }

            //if all 3 horizontal lines match
            if (userInput == 'h' && intToVal == 3)
            {
                if ((spinningSlotMachine[0, 0] == spinningSlotMachine[0, 1]) && (spinningSlotMachine[0, 1] == spinningSlotMachine[0, 2]) &&
                    (spinningSlotMachine[1, 0] == spinningSlotMachine[1, 1]) && (spinningSlotMachine[1, 1] == spinningSlotMachine[1, 2]) &&
                    (spinningSlotMachine[2, 0] == spinningSlotMachine[2, 1]) && (spinningSlotMachine[2, 1] == spinningSlotMachine[2, 2]))
                {
                    Console.WriteLine("You matched all three horizontal line!\n");
                    winnings += (ROW_COUNT)*wagerVal;
                    Console.WriteLine($"Your total winnings are {winnings}\n");
                }
                else
                {
                    Console.WriteLine("You did not match all three horizontal lines!\n");
                    winnings -= (ROW_COUNT)*wagerVal;
                    Console.WriteLine($"Your total winnings are {winnings}\n");
                }
            }

            //vertical scenarios
            //if any single vertical row matches
            if (userInput == 'v' && intToVal == 1)
            {
                if ((spinningSlotMachine[0, 0] == spinningSlotMachine[1, 0]) && (spinningSlotMachine[1, 0] == spinningSlotMachine[2, 0]) ||
                    (spinningSlotMachine[0, 1] == spinningSlotMachine[1, 1]) && (spinningSlotMachine[1, 1] == spinningSlotMachine[2, 1]) ||
                    (spinningSlotMachine[0, 2] == spinningSlotMachine[1, 2]) && (spinningSlotMachine[2, 1] == spinningSlotMachine[2, 2]))
                {
                    Console.WriteLine("You matched a single vertical line!\n");
                    winnings += wagerVal;
                    Console.WriteLine($"Your total winnings are {winnings}\n");
                }
                else
                {
                    Console.WriteLine("You did not match a single horizontal line!\n");
                    winnings -= wagerVal;
                    Console.WriteLine($"Your total winnings are {winnings}\n");
                }
            }

            //if all 3 vertical lines match
            if (userInput == 'v' && intToVal == 3)
            {
                if ((spinningSlotMachine[0, 0] == spinningSlotMachine[1, 0]) && (spinningSlotMachine[1, 0] == spinningSlotMachine[2, 0]) &&
                    (spinningSlotMachine[0, 1] == spinningSlotMachine[1, 1]) && (spinningSlotMachine[1, 1] == spinningSlotMachine[2, 1]) &&
                    (spinningSlotMachine[0, 2] == spinningSlotMachine[1, 2]) && (spinningSlotMachine[2, 1] == spinningSlotMachine[2, 2]))
                {
                    Console.WriteLine("You matched all three vertical lines!\n");
                    winnings += (ROW_COUNT) * wagerVal;
                    Console.WriteLine($"Your total winnings are {winnings}\n");
                }
                else
                {
                    Console.WriteLine("You did not match all three vertical lines!\n");
                    winnings -= (COLUMN_COUNT)*wagerVal;
                    Console.WriteLine($"Your total winnings are {winnings}\n");
                }
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