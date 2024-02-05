
namespace slot_machine
{
    //contains methods for spinning slot machine, check if user has won horizontally/vertically/diagonally

    public static class Logic
    {

        const int ROW_COUNT = 3;
        const int COLUMN_COUNT = 3;
        const int MATCH_TWO_ADJACENT_VALUES = 2;
        const int MIN_VALUE = 0;
        const int MAX_VALUE = 2;

        //function should return int array containing random value
        //only fills array with values without any output
        //return 2D array
        //use int[,] to ensure we return 2d array with int values
        public static int[,] FillSlotArrayValues(Random randomValue, int[,] slotMachine)
        {
            //insert values in spinning slot machine array
            //array to store random digits
            //2D array that is 3 by 3
            for (int rowIndex = 0; rowIndex < ROW_COUNT; rowIndex++)
            {
                for (int columnIndex = 0; columnIndex < COLUMN_COUNT; columnIndex++)
                {
                    //assign each value to each index in row,column
                    slotMachine[rowIndex, columnIndex] = randomValue.Next(MIN_VALUE, MAX_VALUE);
/*                    UIMethods.PrintSlotArray(slotMachine[rowIndex, columnIndex]);
*/                }
/*                UIMethods.PrintEmptySpace();
*/            }
            return slotMachine;
        }

        //check how much user has won or lost based off horizontal/vertical/diagonal option
        public static int CheckHorizontalOption(int[,] slotMachine)
        {
            //keep track of number of correct row matches
            int matchingRows = 0;
            int correctMatches = 0;
            for (int rowIndex = 0; rowIndex < ROW_COUNT; rowIndex++)
            {
                for (int columnIndex = 0; columnIndex < COLUMN_COUNT - 1; columnIndex++)
                {
                    if (slotMachine[rowIndex, columnIndex] == slotMachine[rowIndex, columnIndex + 1])
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
            return matchingRows;
        }

        public static int CheckVerticalOption(int[,] slotMachine)
        {
            //vertical scenarios
            //keep track of number of correct column matches
            int matchingColumns = 0;
            int correctMatches = 0;

            for (int columnIndex = 0; columnIndex < COLUMN_COUNT; columnIndex++)
            {
                for (int rowIndex = 0; rowIndex < ROW_COUNT - 1; rowIndex++)
                {
                    if (slotMachine[rowIndex, columnIndex] == slotMachine[rowIndex + 1, columnIndex])
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
            return matchingColumns;
        }

        public static int CheckDiagonalOption(int[,] slotMachine)
        {
            //diagonal scenarios
            int correctMatches = 0;
            int matchingDiagonals = 0;

            //verify that three numbers from top left to bottom right diagonal match
            for (int rowIndex = 0; rowIndex < ROW_COUNT - 1; rowIndex++)
            {
                if (slotMachine[rowIndex, rowIndex] == slotMachine[rowIndex + 1, rowIndex + 1])
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
            //length of 2D array is 3, get length of first row having 3 values
            int colIndex = slotMachine.GetLength(0) - 1;

            for (int rowIndex = 0; rowIndex < ROW_COUNT - 1; rowIndex++)
            {
                if (slotMachine[rowIndex, colIndex] == slotMachine[rowIndex + 1, colIndex - 1])
                {
                    correctMatches += 1;
                    //decrement colIndex by 1 once match is found
                    colIndex -= 1;
                }
            }

            //if we have matching diagonals from top left to bottom right
            if (correctMatches == MATCH_TWO_ADJACENT_VALUES)
            {
                matchingDiagonals += 1;
            }
            return matchingDiagonals;
        }

    }
}
