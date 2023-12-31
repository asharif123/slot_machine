﻿namespace slot_machine
{
    //contains methods for spinning slot machine, check if user has won horizontally/vertically/diagonally
    public static class Logic
    {
        const int ROW_COUNT = 3;
        const int COLUMN_COUNT = 3;
        const int RANDOM_VALUES = 2;
        const int MATCH_TWO_ADJACENT_VALUES = 2;
        const int NO_MATCHING_LINES = 0;
        const char HORIZONTAL_OPTION = 'h';
        const char VERTICAL_OPTION = 'v';
        const char DIAGONAL_OPTION = 'd';
        public static bool spinningSlotMachine()
        {
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
            return true;
        }

        //check how much user has won or lost based off horizontal/vertical/diagonal options

        public static void checkHorizontalOption()
        {
            if (UIMethods.matchingOption() == HORIZONTAL_OPTION)
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

                //if no matching columns were found
                if (matchingRows == NO_MATCHING_LINES)
                {
                    Console.WriteLine($"\nYou have {NO_MATCHING_LINES} matching columns!\n");
                }
                //if 1, 2 or 3 matching columns are found
                else
                {
                    Console.WriteLine($"\nYou have {matchingRows} matching columns!\n");
                    winnings += wagerVal * matchingRows;
                }
                Console.WriteLine($"Your total winnings are ${winnings}!\n");
            }
        }
        public static void checkVerticalOption()
        {
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
        }

        public static void checkDiagonalOption()
        {
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
                int colIndex = spinningSlotMachine.GetLength(0) - 1;

                for (int rowIndex = 0; rowIndex < ROW_COUNT - 1; rowIndex++)
                {
                    if (spinningSlotMachine[rowIndex, colIndex] == spinningSlotMachine[rowIndex + 1, colIndex - 1])
                    {
                        correctMatches += 1;
                        //decrement colIndex by 1 once match is found
                        colIndex -= 1;
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
                Console.WriteLine($"Your total winnings are ${winnings}.\n");
                return;
            }
        }

    }
}
