namespace slot_machine
{
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
            int userCredits = STARTING_BET_AMOUNT;

            //show welcome message
            UIMethods.PrintWelcomeMessage();

            //add while loop here so user can have access to most recent winnings and not have winnings reset to 50 
            while (replay)
            {
                //if user runs out of money to wager
                //immediately check to determine if user has enough money to wager
                if (userCredits <= 0)
                {
                    UIMethods.PrintShowMessageNoMoneyLeft();
                    break;
                }

                //wager amount
                int wager = UIMethods.InputWagerAmount(userCredits);
                //subtract wager from user credits
                userCredits -= wager;

                //record whether use has selected horizontal, vertical or diagonal
                char userOption = UIMethods.PrintMatchingOption();

                UIMethods.PrintEmptySpace();
                //fill the array with values 0 and 1
                //declare random in main to make it acccesible to every function that needs it
                Logic.FillSlotArrayValues(rd, spinningSlotMachine);

                if (userOption == HORIZONTAL_OPTION)
                {
                    int totalHorizontalLines = Logic.CheckHorizontalOption(spinningSlotMachine);
                    userCredits += (userCredits * totalHorizontalLines);
                }

                else if (userOption == VERTICAL_OPTION)
                {
                    int totalVerticalLines = Logic.CheckVerticalOption(spinningSlotMachine);
                    userCredits += (userCredits * totalVerticalLines);
                }

                else if (userOption == DIAGONAL_OPTION)
                {
                    int totalDiagonalLines = Logic.CheckDiagonalOption(spinningSlotMachine);
                    userCredits += (userCredits * totalDiagonalLines);
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
