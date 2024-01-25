//

namespace slot_machine
{
    internal class Program
    {
        static void Main()
        {
            const char HORIZONTAL_OPTION = 'h';
            const char VERTICAL_OPTION = 'v';
            const char DIAGONAL_OPTION = 'd';

            //user's winnings, user starts at $50
            UIMethods.welcomeMessage();

            //give user option to replay
            bool replay = true;
            int moneyLeft = 0;

            //show welcome message
            UIMethods.welcomeMessage();

            //add while loop here so user can have access to most recent winnings and not have winnings reset to 50 
            while (replay)
            {
                //if user runs out of money to wager
                //immediately check to determine if user has enough money to wager
                if (moneyLeft < 0)
                {
                    UIMethods.showMessageNoMoneyLeft();
                    Environment.Exit(0);
                }

                //get bet from user


                //fill the array with values 0 and 1
                Logic.fillSlotArrayValues();

                //wager amount
                UIMethods.wagerAmount();

                //record whether use has selected horizontal, vertical or diagonal
                char userOption = UIMethods.matchingOption();

                if (userOption == HORIZONTAL_OPTION)
                {
                    Logic.checkHorizontalOption();
                }


                else if (userOption == VERTICAL_OPTION)
                {
                    Logic.checkVerticalOption();
                }


                else if (userOption == DIAGONAL_OPTION)
                {
                    Logic.checkDiagonalOption();
                }

                //user decides to replay the game
                if (UIMethods.playAgain() == false)
                {
                    replay = false;
                    return;
                }
            }
        }
    }
}
