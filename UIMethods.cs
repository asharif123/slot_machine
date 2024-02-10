namespace slot_machine
{
    //Methods to define user interaction (user input/output)
    //used to verify user input or output message
    //ask user to bet money, replay game or quit, input valid wager amount, user has enough money to bet
    public static class UIMethods
    {
        const int ROW_COUNT = 3;
        const int COLUMN_COUNT = 3;
        const int STARTING_BET_AMOUNT = 50;
        const int MINIMUM_BET = 1;
        const int NO_WINNINGS_LEFT = 0;
        const char HORIZONTAL_OPTION = 'h';
        const char VERTICAL_OPTION = 'v';
        const char DIAGONAL_OPTION = 'd';
        const char CONTINUE_PLAYING = 'y';
        //used to check if user has inputted either horizontal/vertical/diagonal
        const string LINE_MATCHING_OPTIONS = "hvd";

        public static readonly Random rng = new Random();

        //UI method that displays amount of money user starts off with
        public static void PrintWelcomeMessage()
        {
            Console.WriteLine($"\nYou have ${STARTING_BET_AMOUNT} that you can wager!\n");
            Console.WriteLine("\nSpinning the wheel...\n");
        }

        //UI method showing message to display if user has money left!
        public static void PrintShowMessageNoMoneyLeft()
        {
            Console.WriteLine("\nSorry, you have no money left! Exiting the game!");
        }
        public static void PrintEmptySpace()
        {
            Console.WriteLine();
        }
        public static void PrintNoMatchingLines()
        {
            Console.WriteLine($"You have no matching lines!");
        }
        public static void PrintMatchingRowLines(int matchingLines)
        {
            Console.WriteLine($"You have {matchingLines} horizontal lines!");
        }
        public static void PrintMatchingColumnLines(int matchingLines)
        {
            Console.WriteLine($"You have {matchingLines} vertical lines!");
        }
        public static void PrintMatchingDiagonalLines(int matchingLines)
        {
            Console.WriteLine($"You have {matchingLines} diagonal lines!");
        }

        //output the slot machine having filled values
        //separate it from logic method that is filling values
        //declare as int so can return each integer in 2D slot array and display to user what was spun
        //use nested for loops to print slot machine line by line
        public static void PrintSlotArray(int[,] slotArray)
        {
            for (int rowIndex = 0; rowIndex < ROW_COUNT; rowIndex++)
            {
                for (int columnIndex = 0; columnIndex < COLUMN_COUNT; columnIndex++)
                {
                    Console.WriteLine(slotArray[rowIndex, columnIndex]);
                }
            }
        }

        //UI method to see how much user wagers
        public static int InputWagerAmount(int wagerAmount)
        {
            Console.WriteLine($"\nEnter a value from {MINIMUM_BET} to {wagerAmount} that you would like to wager!\n");
            //convert string to integer value, read the wager value 
            string wager = Console.ReadLine();
            int wagerVal = Convert.ToInt32(wager);
            bool notValidInput = true;

            //ensure user enters valid wager
            while (notValidInput)
            {
                if (wagerVal > wagerAmount || wagerVal <= NO_WINNINGS_LEFT)
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
            //immediately return what user has wagered
            return wagerVal;
        }

        //UIMethod containing options to match horizontally, vertically, or diagonally
        //check if user selected horizontal, vertical or diagonal
        public static char InputMatchingOption()
        {
            bool notValidInput = true;
            Console.WriteLine($"\nEnter {HORIZONTAL_OPTION} to match numbers horizontally, {VERTICAL_OPTION} to match vertically, {DIAGONAL_OPTION} to match diagonally\n");
            char userInput = Char.ToLower(Console.ReadKey().KeyChar);

            while (notValidInput)
            {
                //ask user to input correct option if user does not select horizontal/vertical/diagonal
                if (!LINE_MATCHING_OPTIONS.Contains(userInput))
                {
                    Console.WriteLine("\nPlease enter a valid option!\n");
                    userInput = Char.ToLower(Console.ReadKey().KeyChar);
                }
                else
                {
                    notValidInput = false;
                }
            }
            return userInput;
        }

        //give user the option to replay the game or quit
        public static bool AskUserToPlayAgain()
        {
            Console.WriteLine($"\nPress {CONTINUE_PLAYING} to continue playing or any key to quit!\n");
            char optionToContinue = Char.ToLower(Console.ReadKey().KeyChar);
            //exit the game if user enters any key besides 'y'
            if (optionToContinue != CONTINUE_PLAYING)
            {
                Console.WriteLine("\nExiting the game!\n");
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
