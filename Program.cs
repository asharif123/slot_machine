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
            const int NO_WINNINGS_LEFT = 0;
            const int MATCH_SINGLE_LINE = 1;
            const int MATCH_TWO_LINES = 2;
            const int MATCH_THREE_LINES = 3;
            const char HORIZONTAL_OPTION = 'h';
            const char VERTICAL_OPTION = 'v';
            const char DIAGONAL_OPTION = 'd';
            const char CONTINUE_PLAYING = 'y';

            Console.WriteLine($"\nYou have ${STARTING_BANK_AMOUNT} that you can wager!\n");
            //user's winnings, user starts at $50
            int winnings = STARTING_BANK_AMOUNT;

            //ask how much user wants to wager
            Console.WriteLine($"\nEnter a value from {MINIMUM_BET} to {winnings} that you would like to wager!\n");
            //convert string to integer value
            string wager = Console.ReadLine();
            int wagerVal = Convert.ToInt32(wager);
            bool notValidInput = true;

            //ensure user enters valid wager
            while (notValidInput)
            {
                if (wagerVal > winnings || wagerVal <= NO_WINNINGS_LEFT)
                {
                    Console.WriteLine("\nPlease enter a positive wager value that is less than or equal your winnings!\n");
                    wager = Console.ReadLine();
                    wagerVal = Convert.ToInt32(wager);
                }
                //if user enters valid wager value, exit out of while loop
                else
                {
                    notValidInput = false;
                }
            }

            //how much money user loses based off wager amount
            winnings -= wagerVal;
            //if user runs out of money to wager
            if (winnings <= NO_WINNINGS_LEFT)
            {
                Console.WriteLine("\nSorry, you have no more money left to bet! Exiting the game...\n");
                return;
            }

            //user decides whether to match numbers horizontally/vertically/diagnolly
            Console.WriteLine($"\nEnter {HORIZONTAL_OPTION} to match numbers horizontally, {VERTICAL_OPTION} to match vertically, {DIAGONAL_OPTION} to match diagonally\n");
            char userInput = Char.ToLower(Console.ReadKey().KeyChar);

            //if user selects either horizontal or vertical, user can match either 1 or 3 lines
            if (userInput == HORIZONTAL_OPTION || userInput == VERTICAL_OPTION)
            {
                Console.WriteLine($"\nEnter {MATCH_SINGLE_LINE} to try to match {MATCH_SINGLE_LINE} line or {MATCH_THREE_LINES} to try to match {MATCH_THREE_LINES} lines!\n");
            }

            //if diagnol, ask user to match either 1 or 2 lines
            else if (userInput == DIAGONAL_OPTION)
            {
                Console.WriteLine($"\nEnter {MATCH_SINGLE_LINE} to try to match {MATCH_SINGLE_LINE} line or {MATCH_TWO_LINES} to try to match {MATCH_TWO_LINES} lines!\n");
            }

            string lineOption = Console.ReadLine();
            int intToLineOption = Convert.ToInt32(lineOption);

            //insert values in spinning slot machine array
            Console.WriteLine("\nSpinning the wheel...\n");

            //array to store random digits
            //2D array that is 3 by 3
            int[,] spinningSlotMachine = new int[ROW_COUNT, COLUMN_COUNT];
            Random rng = new Random();
            for (int rowIndex = 0; rowIndex < ROW_COUNT; rowIndex++)
            {
                for (int columnIndex = 0; columnIndex < COLUMN_COUNT; columnIndex++)
                {
                    int randomValue = rng.Next(10);
                    spinningSlotMachine[rowIndex, columnIndex] = randomValue;
                    Console.WriteLine(spinningSlotMachine[rowIndex, columnIndex]);
                }
                Console.WriteLine();
            }

            //horizontal scenarios
            //if any single horizontal row matches
            if (userInput == HORIZONTAL_OPTION && intToLineOption == MATCH_SINGLE_LINE)
            {
                //keep track of number of correct row matches
                int correctMatches = 0;
                for (int rowIndex = 0; rowIndex < ROW_COUNT; rowIndex++)
                {
                    for (int columnIndex = 0; columnIndex < COLUMN_COUNT - 1; columnIndex++)
                    {
                        if (spinningSlotMachine[rowIndex, columnIndex] == spinningSlotMachine[rowIndex, columnIndex + 1])
                        {
                            correctMatches += 1;
                        }
                    }
                }
                //after iterating through each line, determine if we see at least 2 correct matches
                if (correctMatches == 2)
                {
                    Console.WriteLine("You have a matching horizontal line!\n");
                    winnings += wagerVal;
                    Console.WriteLine($"Your total winnings are ${winnings}\n!");
                }
                else
                {
                    Console.WriteLine("You don't have a matching horizontal line!\n");
                    Console.WriteLine($"Your total winnings are ${winnings}!\n");
                }
            }

            //vertical scenarios
            //vertical option and single line input
            if (userInput == VERTICAL_OPTION && intToLineOption == MATCH_SINGLE_LINE)
            {
                int correctMatches = 0;
                for (int columnIndex = 0; columnIndex < COLUMN_COUNT; columnIndex++)
                {
                    for (int rowIndex = 0; rowIndex < ROW_COUNT - 1; rowIndex++)
                    {
                        if (spinningSlotMachine[rowIndex, columnIndex] == spinningSlotMachine[rowIndex + 1, columnIndex])
                        {
                            correctMatches += 1;
                        }
                    }
                }
                //after iterating through each line, determine if we see at least 2 correct matches
                if (correctMatches == 2)
                {
                    Console.WriteLine("You have a matching vertical line!\n");
                    winnings += wagerVal;
                    Console.WriteLine($"Your total winnings are ${winnings}\n!");
                }
                else
                {
                    Console.WriteLine("You don't have a matching vertical line!\n");
                    Console.WriteLine($"Your total winnings are ${winnings}!\n");
                }
            }

            Console.WriteLine($"\nPress {CONTINUE_PLAYING} to continue playing or any key to quit!\n");
            char optionToContinue = Char.ToLower(Console.ReadKey().KeyChar);
            //if user wishes to continue, call the main function
            if (optionToContinue == CONTINUE_PLAYING)
            {
                Main();
            }
            //quit the game
            return;
        }
    }
}