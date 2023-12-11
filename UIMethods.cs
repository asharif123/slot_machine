using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace slot_machine
{
    public static class UIMethods
    {
        const int STARTING_BET_AMOUNT = 50;
        const int NO_WINNINGS_LEFT = 0;
        public static void welcomeMessage()
        {
            Console.WriteLine($"\nYou have ${STARTING_BET_AMOUNT} that you can wager!\n");
        }

        public static void noMoneyLeft()
        {
            Console.WriteLine("\nSorry, you have no more money left to bet! Exiting the game...\n");
            return;
        }


    }
}
