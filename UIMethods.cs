﻿namespace slot_machine
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
        public static void PrintMatchingLines(int matchingLines)
        {
            Console.WriteLine($"You have {matchingLines} matching line(s)!");
        }

        public static void PrintTotalWinnings(int moneyWon)
        {
            Console.WriteLine($"\nYour total earnings are ${moneyWon}!\n");
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
                    //use Console.Write to ensure you print each value next to one another
                    Console.Write(slotArray[rowIndex, columnIndex] + " ");
                }
                //used to separate each row
                Console.WriteLine();
            }
        }

        //UI method to see how much user wagers
        public static int InputWagerAmount(int wagerAmount)
        {
            Console.WriteLine($"\nEnter a value from {MINIMUM_BET} to {wagerAmount} that you would like to wager!\n");
            //initialize wagerVal as an integer so it can be retained at end of method
            int wagerVal = 0;
            //ensure user enters valid wager
            bool notValidInput = true;
            while (notValidInput)
            {
                //convert string to integer value, read the wager value 
                //pass wager input statement in while loop so it is called again if invalid input
                string wager = Console.ReadLine();

                //confirm that user has entered valid integer
                //converts string of input into int wagerVal
                bool success = int.TryParse(wager, out wagerVal);

                //if user does NOT enter an integer value
                //it will recall bool statement
                if (!success)
                {
                    Console.WriteLine("\nPlease enter an integer value!\n");
                }
                //if use does enter an integer value
                else
                {
                    if (wagerVal > wagerAmount || wagerVal <= NO_WINNINGS_LEFT)
                    {
                        Console.WriteLine("\nPlease enter a positive wager value that is less than or equal your winnings!\n");
                    }
                    //if user enters valid wager value, exit out of while loop
                    else
                    {
                        notValidInput = false;
                    }
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

            //create a list of possible options
            //NOT constant since you don't assign one letter at a time to list
            List<char> LINE_MATCHING_OPTIONS = new List<char> { HORIZONTAL_OPTION, VERTICAL_OPTION, DIAGONAL_OPTION };

            //used to check if user has inputted either horizontal/vertical/diagonal
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

        //method to determine what option user has selected and return money left based off selected option
        //pass arguments for how much user can bet, amount to be wagered, selected option and spinning slot machine
        public static int AmountMoneyLeft(int moneyLeft, int wagerAmount, char selectedOption, int[,] slotMachine)
        {
            int amountLeft = moneyLeft;

            //subtract wager from user credits
            amountLeft -= wagerAmount;

            //initialize totalMatchingLines as an integer so it can be retained at end of method
            int totalMatchingLines = 0;

            if (selectedOption == HORIZONTAL_OPTION)
            {
                totalMatchingLines = Logic.CheckHorizontalOption(slotMachine);
            }

            else if (selectedOption == VERTICAL_OPTION)
            {
                totalMatchingLines = Logic.CheckVerticalOption(slotMachine);
            }

            else if (selectedOption == DIAGONAL_OPTION)
            {
                totalMatchingLines = Logic.CheckDiagonalOption(slotMachine);
            }

            //if no matching lines were found
            if (totalMatchingLines == 0)
            {
                UIMethods.PrintNoMatchingLines();
            }
            //if 1, 2 or 3 matching lines are found for horizontal/vertical/diagonal options
            else
            {
                //pass UIMethods to program or UIMethods, NOT in logic.cs
                //print number of matching lines
                UIMethods.PrintMatchingLines(totalMatchingLines);
                amountLeft += (wagerAmount * totalMatchingLines);
            }
            //print how much money user has won
            UIMethods.PrintTotalWinnings(amountLeft);

            return amountLeft;
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
