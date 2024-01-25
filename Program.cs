//

namespace slot_machine
{
    internal class Program
    {
        public static readonly Random rng = new Random();
        static void Main()
        {
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

                //user decides whether to match numbers horizontally/vertically/diagnolly
                Logic.fillSlotArrayValues();

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
