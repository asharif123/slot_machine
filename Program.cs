namespace slot_machine
{
    //user is greeted with a welcome message
    //user is given $50 to start with and is asked how much to wager
    //if user exceed amount to wager or puts 0, asked to reinput wager
    //user then selects whether to match values horizontally/vertically/diagonally
    //the slot machine spins generating random 0s and 1s on 2D array
    //if user gets no matches, user loses money
    //if user gets 1 matching line, user gets money back, if 2 lines user gets double, if 3 lines user get triple
    //at end of game, user is asked to play again or quit
    //if user runs out of money or selects quit, the game is over
    //if user continues, user will use updated userCredits to continue playing
    internal class Program
    {
        static void Main()
        {
            const int STARTING_BET_AMOUNT = 50;
            const int ROW_COUNT = 3;
            const int COLUMN_COUNT = 3;
            //declared outside of logic class since it's NOT constant
            //so needs to be declared in Program.cs file
            //create a 2D array to store values
            int[,] spinningSlotMachine = new int[ROW_COUNT, COLUMN_COUNT];

            //declare random value in main function instead of function
            //make it accesible to all functions
            Random rd = new Random();

            //give user option to replay
            bool replay = true;

            //initial amount user starts with
            int userCredits = STARTING_BET_AMOUNT;

            //show welcome message
            UIMethods.PrintWelcomeMessage();

            //add while loop here so user can have access to most recent winnings and not have winnings reset to 50 
            while (replay)
            {
                //wager amount
                int wager = UIMethods.InputWagerAmount(userCredits);

                //record whether use has selected horizontal, vertical or diagonal
                char userOption = UIMethods.InputMatchingOption();
                UIMethods.PrintEmptySpace();
                UIMethods.PrintEmptySpace();

                //fill the array with values 0 and 1
                //declare random in main to make it acccesible to every function that needs it
                //pass results of spinningSlotMachine to horizontal/vertical/diagonal options
                //pass it once slot machine has been filled!
                int[,] spinningSlotMachineResults = Logic.FillSlotArrayValues(rd, spinningSlotMachine);
                UIMethods.PrintSlotArray(spinningSlotMachineResults);
                UIMethods.PrintEmptySpace();

                //method that calculates user credits based off either horizontal/vertical/diagonal options
                //takes arguments for amount of money user has left, slot machine, what user has wagered and selected option
                userCredits = UIMethods.AmountMoneyLeft(userCredits, wager, userOption, spinningSlotMachine);

                //if user runs out of money to wager
                //immediately check to determine if user has enough money to wager
                if (userCredits <= 0)
                {
                    UIMethods.PrintShowMessageNoMoneyLeft();
                    break;
                }

                //user decides to replay the game or exit the program
                if (UIMethods.AskUserToPlayAgain() == false)
                {
                    replay = false;
                }
            }
        }
    }
}
