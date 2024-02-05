namespace slot_machine
{
    //user is greeted with a welcome message
    //user is given $50 to start with and is asked how much to wager
    //if user exceed amount to wager or puts 0, asked to reinput wager
    //user then selects whether to match values horizontall/vertically/diagonally
    //the slot machine spins generating random 0s and 1s on 2D array
    //if user gets no matches, user loses money
    //if user gets 1 matching line, user gets money back, if 2 lines user gets double, if 3 lines user get triple
    //at end of game, user is asked to play again or quit
    //if user runs out of money, the game is over
    internal class Program
    {
        static void Main()
        {
            const char HORIZONTAL_OPTION = 'h';
            const char VERTICAL_OPTION = 'v';
            const char DIAGONAL_OPTION = 'd';
            const int STARTING_BET_AMOUNT = 50;
            const int ROW_COUNT = 3;
            const int COLUMN_COUNT = 3;
            //declared outside of logic class since it's NOT constant
            //so needs to be declared in Program.cs file
            int[,] spinningSlotMachine = new int[ROW_COUNT, COLUMN_COUNT];

            //declare random value in main function instead of function
            //make it accesible to all functions
            Random rd = new Random();

            //give user option to replay
            bool replay = true;

            //amount of money user starts off with
            int userCredits = STARTING_BET_AMOUNT;

            //show welcome message
            UIMethods.PrintWelcomeMessage();

            //add while loop here so user can have access to most recent winnings and not have winnings reset to 50 
            while (replay)
            {
                //wager amount
                int wager = UIMethods.InputWagerAmount(userCredits);
                //subtract wager from user credits
                userCredits -= wager;

                //record whether use has selected horizontal, vertical or diagonal
                char userOption = UIMethods.PrintMatchingOption();
                UIMethods.PrintEmptySpace();
                //fill the array with values 0 and 1
                //declare random in main to make it acccesible to every function that needs it
                //pass results of spinningSlotMachine to horizontal/vertical/diagonal options
                int[,] spinningSlotMachineResults = Logic.FillSlotArrayValues(rd, spinningSlotMachine);
                UIMethods.PrintSlotArray(spinningSlotMachineResults);
                UIMethods.PrintEmptySpace();

                if (userOption == HORIZONTAL_OPTION)
                {
                    int totalHorizontalLines = Logic.CheckHorizontalOption(spinningSlotMachineResults);
                    //if no matching columns were found
                    if (totalHorizontalLines == 0)
                    {
                        UIMethods.PrintNoMatchingLines();
                    }
                    //if 1, 2 or 3 matching columns are found
                    else
                    {
                        //pass UIMethods to program or UIMethods, NOT in logic.cs
                        UIMethods.PrintMatchingRowLines(totalHorizontalLines);
                        userCredits += (wager * totalHorizontalLines);
                    }
                }

                else if (userOption == VERTICAL_OPTION)
                {
                    int totalVerticalLines = Logic.CheckVerticalOption(spinningSlotMachineResults);
                    if (totalVerticalLines == 0)
                    {
                        UIMethods.PrintNoMatchingLines();
                    }
                    else
                    {
                        //pass UIMethods to program or UIMethods, NOT in logic.cs
                        UIMethods.PrintMatchingColumnLines(totalVerticalLines);
                        userCredits += (wager * totalVerticalLines);
                    }
                }

                else if (userOption == DIAGONAL_OPTION)
                {
                    int totalDiagonalLines = Logic.CheckDiagonalOption(spinningSlotMachineResults);
                    if (totalDiagonalLines == 0)
                    {
                        UIMethods.PrintNoMatchingLines();
                    }
                    else
                    {
                        //pass UIMethods to program or UIMethods, NOT in logic.cs
                        UIMethods.PrintMatchingDiagonalLines(totalDiagonalLines);
                        userCredits += (wager * totalDiagonalLines);
                    }
                    userCredits += (wager * totalDiagonalLines);
                }

                //if user runs out of money to wager
                //immediately check to determine if user has enough money to wager
                if (userCredits <= 0)
                {
                    UIMethods.PrintShowMessageNoMoneyLeft();
                    break;
                }

                //user decides to replay the game
                if (UIMethods.AskUserToPlayAgain() == false)
                {
                    replay = false;
                    return;
                }
            }
        }
    }
}
