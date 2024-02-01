﻿//

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
            const int RANDOM_VALUES = 2;

            //declare random value in main function instead of function
            //make it accesible to all functions
            Random rd = new Random();
            int randomValue = rd.Next(RANDOM_VALUES);

            //user's winnings, user starts at $50
            UIMethods.printWelcomeMessage();

            //give user option to replay
            bool replay = true;
            int userCredits = STARTING_BET_AMOUNT;

            //show welcome message
            UIMethods.printWelcomeMessage();


            //add while loop here so user can have access to most recent winnings and not have winnings reset to 50 
            while (replay)
            {
                //if user runs out of money to wager
                //immediately check to determine if user has enough money to wager
                if (userCredits <= 0)
                {
                    UIMethods.printMessageNoMoneyLeft();
                    break;
                }

                //fill the array with values 0 and 1
                //declare random in main to make it acccesible to every function that needs it
                Logic.fillSlotArrayValues(randomValue);

                //wager amount
                int wager = UIMethods.inputWagerAmount();
                //subtract wager from user credits
                userCredits -= wager;

                //record whether use has selected horizontal, vertical or diagonal
                char userOption = UIMethods.printMatchingOption();

                if (userOption == HORIZONTAL_OPTION)
                {
                    //update userCredits depending if user matched any horizontal lines
                    userCredits += UIMethods.inputWagerAmount() * Logic.checkHorizontalOption();
                }

                else if (userOption == VERTICAL_OPTION)
                {
                    Logic.checkVerticalOption();
                    //update userCredits depending if user matched any horizontal lines
                    userCredits += UIMethods.inputWagerAmount() * Logic.checkVerticalOption();

                }

                else if (userOption == DIAGONAL_OPTION)
                {
                    Logic.checkDiagonalOption();
                    //update userCredits depending if user matched any horizontal lines
                    userCredits += UIMethods.inputWagerAmount() * Logic.checkDiagonalOption();

                }

                //user decides to replay the game
                if (UIMethods.askUserToPlayAgain() == false)
                {
                    replay = false;
                    break;
                }
            }
        }
    }
}
