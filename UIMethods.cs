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

        public static readonly Random rng = new Random();

        //UI method that displays amount of money user starts off with
        public static void printWelcomeMessage()
        {
            Console.WriteLine($"\nYou have ${STARTING_BET_AMOUNT} that you can wager!\n");
            Console.WriteLine("\nSpinning the wheel...\n");
        }

        //UI method showing message to display if user has money left!
        public static void showMessageNoMoneyLeft()
        {
            Console.WriteLine("\nSorry, you have no money left!");
        }

        public static void emptySpace()
        {
            Console.WriteLine();
        }
        public static void printNoMatchingLines(int matchingLines)
        {
            Console.WriteLine($"You have no {matchingLines} lines!");
        }
        public static void printMatchingRowLines(int matchingLines)
        {
            Console.WriteLine($"You have {matchingLines} horizontal lines!");
        }
        public static void printMatchingColumnLines(int matchingLines)
        {
            Console.WriteLine($"You have {matchingLines} vertical lines!");
        }
        public static void printMatchingDiagonalLines(int matchingLines)
        {
            Console.WriteLine($"You have {matchingLines} diagonal lines!");
        }

        //output the slot machine having filled values
        //separate it from logic method that is filling values
        public static void OutputSlotArray(int[,] slotArray)
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
        public static int wagerAmount()
        {
            Console.WriteLine($"\nEnter a value from {MINIMUM_BET} to {STARTING_BET_AMOUNT} that you would like to wager!\n");
            //convert string to integer value
            string wager = Console.ReadLine();
            int wagerVal = Convert.ToInt32(wager);
            bool notValidInput = true;

            //ensure user enters valid wager
            while (notValidInput)
            {
                if (wagerVal > STARTING_BET_AMOUNT || wagerVal <= NO_WINNINGS_LEFT)
                {
                    Console.WriteLine("\nPlease enter a positive wager value that is less than or equal your winnings!\n");
                    //ask user again for wager amount        
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
        public static char matchingOption()
        {
            Console.WriteLine($"\nEnter {HORIZONTAL_OPTION} to match numbers horizontally, {VERTICAL_OPTION} to match vertically, {DIAGONAL_OPTION} to match diagonally\n");
            char userInput = Char.ToLower(Console.ReadKey().KeyChar);
            //make userInput accessible
            return userInput;
        }

        //give user the option to replay the game or quit
        public static bool playAgain()
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
