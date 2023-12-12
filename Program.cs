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

            //add while loop here so user can have access to most recent winnings and not have winnings reset to 50 
            while (replay)
            {
                //if user runs out of money to wager
                //immediately check to determine if user has enough money to wager
                if (UIMethods.noMoneyLeft() == true)
                {
                    Environment.Exit(0);
                }

                //user decides whether to match numbers horizontally/vertically/diagnolly
                UIMethods.spinningSlotMachine();

                //user decides to replay the game
                if (UIMethods.playAgain() == false)
                {
                    replay = false;
                    Environment.Exit(0);
                }
            }
        }
    }
}
