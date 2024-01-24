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
            //add while loop here so user can have access to most recent winnings and not have winnings reset to 50 
            while (replay)
            {
                //if user runs out of money to wager
                //immediately check to determine if user has enough money to wager
                if (moneyLeft < 0)
                {
                    Environment.Exit(0);
                }
                UIMethods.showMessageNoMoneyLeft();

                //user decides whether to match numbers horizontally/vertically/diagnolly
                Logic.spinningSlotMachine();

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
