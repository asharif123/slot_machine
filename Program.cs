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
            const int RANDOM_VALUES = 2;
            const int MATCH_TWO_ADJACENT_VALUES = 2; ;
            const char HORIZONTAL_OPTION = 'h';
            const char VERTICAL_OPTION = 'v';
            const char DIAGONAL_OPTION = 'd';
            const char CONTINUE_PLAYING = 'y';

            Console.WriteLine($"\nYou have ${STARTING_BET_AMOUNT} that you can wager!\n");
            //user's winnings, user starts at $50
            int winnings = STARTING_BET_AMOUNT;

            //give user option to replay
            bool replay = true;
            //add while loop here so user can have access to most recent winnings and not have winnings reset to 50 
            while (replay)
            {
                //if user runs out of money to wager
                //immediately check to determine if user has enough money to wager
                if (winnings <= NO_WINNINGS_LEFT)
                {
                    Console.WriteLine("\nSorry, you have no more money left to bet! Exiting the game...\n");
                    return;
                }
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
                        //generate random value from 0 to 1, where RANDOM_VALUES = 2 to generate either 0 or 1
                        int randomValue = rng.Next(RANDOM_VALUES);
                        //assign each value to each index in row,column
                        spinningSlotMachine[rowIndex, columnIndex] = randomValue;
                        //print out the slot machine
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

                        //reset correctMatches to iterate next row
                        correctMatches = 0;
                    }

                    //if no matches exist
                    if (matchingRows == NO_MATCHING_LINES)
                    {
                        Console.WriteLine($"\nYou have {NO_MATCHING_LINES} matching horizontal lines!");
                    }
                    //if we have either 1, 2 or 3 matching lines
                    else
                    {
                        Console.WriteLine($"\nYou have {matchingRows} matching horizontal lines!\n");
                        winnings += wagerVal * matchingRows;
                    }
                    Console.WriteLine($"You total winnings are ${winnings}\n");
                }

                //vertical scenarios
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

                    //if no matching columns were found
                    if (matchingColumns == NO_MATCHING_LINES)
                    {
                        Console.WriteLine($"\nYou have {NO_MATCHING_LINES} matching columns!\n");
                    }
                    //if 1, 2 or 3 matching columns are found
                    else
                    {
                        Console.WriteLine($"\nYou have {matchingColumns} matching columns!\n");
                        winnings += wagerVal * matchingColumns;
                    }
                    Console.WriteLine($"Your total winnings are ${winnings}!\n");
                }

                //diagonal scenarios
                if (userInput == DIAGONAL_OPTION)
                {
                    int correctMatches = 0;
                    int matchingDiagonals = 0;

                    //verify that three numbers from top left to bottom right diagonal match
                    for (int rowIndex = 0; rowIndex < ROW_COUNT - 1; rowIndex++)
                    {
                        if (spinningSlotMachine[rowIndex, rowIndex] == spinningSlotMachine[rowIndex + 1, rowIndex + 1])
                        {
                            correctMatches += 1;
                        }
                    }

                    //if we have matching diagonals from top left to bottom right
                    if (correctMatches == MATCH_TWO_ADJACENT_VALUES)
                    {
                        matchingDiagonals += 1;
                    }
                    //reset correctMatches to iterate next diagonal
                    correctMatches = 0;

                    //row starts at 0 and column starts at 2, decrease by 1 each time until column is 2 and row is 0
                    //start at rowIndex = 0 and columnIndex = 2
                    //length of 2D array is 3
                    int lengthOfArray = spinningSlotMachine.GetLength(0);

                    for (int rowIndex = 0; rowIndex < ROW_COUNT - 1; rowIndex++)
                    {
                        if (spinningSlotMachine[rowIndex, lengthOfArray - 1] == spinningSlotMachine[rowIndex + 1, lengthOfArray - 2])
                        {
                            correctMatches += 1;
                            //decrement lengthOfArray by 1 once match is found
                            lengthOfArray -= 1;
                        }
                    }

                    //if we have matching diagonals from top right to bottom left
                    if (correctMatches == MATCH_TWO_ADJACENT_VALUES)
                    {
                        matchingDiagonals += 1;
                    }

                    if (matchingDiagonals == NO_MATCHING_LINES)
                    {
                        Console.WriteLine($"\nYou have {NO_MATCHING_LINES} matching diagonal lines!\n");
                    }
                    else
                    {
                        Console.WriteLine($"\nYou have {matchingDiagonals} matching diagonal lines!\n");
                        winnings += wagerVal * matchingDiagonals;
                    }
                    Console.WriteLine($"Your total winnings are {winnings}.\n");
                }

                Console.WriteLine($"\nPress {CONTINUE_PLAYING} to continue playing or any key to quit!\n");
                char optionToContinue = Char.ToLower(Console.ReadKey().KeyChar);
                //exit the game if user enters any key besides 'y'
                if (optionToContinue != 'y')
                {
                    Console.WriteLine("\nExiting the game!\n");
                    replay = false;
                }
            }

        }
    }
}