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
            const int STARTING_BET_AMOUNT = 50;
            const int NO_WINNINGS_LEFT = 0;
            const int NO_MATCHING_LINES = 0;
            const int MATCH_SINGLE_HORIZONTAL_LINE = 1;
            const int MATCH_THREE_HORIZONTAL_LINES = 3;
            const int MATCH_TWO_ADJACENT_VALUES = 2;
            const int MATCH_SINGLE_VERTICAL_LINE = 1;
            const int MATCH_THREE_VERTICAL_LINES = 3;
            const int MATCH_SINGLE_DIAGONAL_LINE = 2;
            const char HORIZONTAL_OPTION = 'h';
            const char VERTICAL_OPTION = 'v';
            const char DIAGONAL_OPTION = 'd';
            const char CONTINUE_PLAYING = 'y';

            Console.WriteLine($"\nYou have ${STARTING_BET_AMOUNT} that you can wager!\n");
            //user's winnings, user starts at $50
            int winnings = STARTING_BET_AMOUNT;

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
                    int randomValue = rng.Next(1);
                    //assign each value to each index in row,column
                    spinningSlotMachine[rowIndex, columnIndex] = randomValue;
                    Console.WriteLine(spinningSlotMachine[rowIndex, columnIndex]);
                }
                Console.WriteLine();
            }

            //horizontal scenarios
            if (userInput == HORIZONTAL_OPTION)
            {
                //keep track of number of correct row matches
                int matchingRows = 0;
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
                    //if we have 2 matching values adjacent to one another in each row, increment matchingRows
                    if (correctMatches == MATCH_TWO_ADJACENT_VALUES)
                    {
                        matchingRows += 1;
                    }
                    //reset correctMatches to iterate next row of values
                    correctMatches = NO_MATCHING_LINES;
                }

                //testcase if we have one matching horizontal line
                if (matchingRows == MATCH_SINGLE_HORIZONTAL_LINE)
                {
                    Console.WriteLine("\nYou have a matching horizontal line!\n");
                    winnings += wagerVal * MATCH_SINGLE_HORIZONTAL_LINE;
                }
                //testcase if we have three matching horizontal lines
                else if (matchingRows == MATCH_THREE_HORIZONTAL_LINES)
                {
                    Console.WriteLine("\nYou have triple horizontal lines!\n");
                    winnings += wagerVal * (MATCH_THREE_HORIZONTAL_LINES / MATCH_SINGLE_HORIZONTAL_LINE);
                }
                //if no matching lines
                else
                {
                    Console.WriteLine("\nYou have no matching horizontal lines!\n");
                }
                Console.WriteLine($"Your total winnings are ${winnings}!\n");
            }

            //vertical scenarios
            //vertical option and single line input
            if (userInput == VERTICAL_OPTION)
            {
                //keep track of number of correct column matches
                int matchingColumns = 0;
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

                    //if we have two matching adjacent values in each column, increment column matches by 1
                    if (correctMatches == MATCH_TWO_ADJACENT_VALUES)
                    {
                        matchingColumns += 1;
                    }
                    //reset correct matches to iterate next column
                    correctMatches = 0;
                }

                //testcase if we have one matching vertical line
                if (matchingColumns == MATCH_SINGLE_VERTICAL_LINE)
                {
                    Console.WriteLine("\nYou have a matching vertical line!\n");
                    winnings += wagerVal * MATCH_SINGLE_VERTICAL_LINE;
                }
                //testcase if we have three matching vertical lines
                else if (matchingColumns == MATCH_THREE_VERTICAL_LINES)
                {
                    Console.WriteLine("\nYou have triple vertical lines!\n");
                    winnings += wagerVal * (MATCH_THREE_VERTICAL_LINES / MATCH_SINGLE_VERTICAL_LINE);
                }
                //if no matching lines
                else
                {
                    Console.WriteLine("\nYou have no matching vertical lines!\n");
                }
                Console.WriteLine($"Your total winnings are ${winnings}!\n");
            }

            //diagonal scenarios
            //diagonal selection and single input
            if (userInput == DIAGONAL_OPTION)
            {
                int correctMatches = 0;
                for (int rowIndex = 0; rowIndex < ROW_COUNT - 1; rowIndex++)
                {
                    if (spinningSlotMachine[rowIndex, rowIndex] == spinningSlotMachine[rowIndex + 1, rowIndex + 1])
                    {
                        correctMatches += 1;
                    }
                }
                if (correctMatches >= MATCH_SINGLE_DIAGONAL_LINE)
                {
                    Console.WriteLine("\nYou have a matching diagonal line!\n");
                    winnings += wagerVal;
                }
                else
                {
                    Console.WriteLine("\nYou don't have a matching diagonal line!\n");
                }
                Console.WriteLine($"Your total winnings are {winnings}.\n");
            }

            Console.WriteLine($"\nPress {CONTINUE_PLAYING} to continue playing or any key to quit!\n");
            char optionToContinue = Char.ToLower(Console.ReadKey().KeyChar);
        }
    }
}