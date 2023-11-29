/*Design a game where the user can play a make believe slot machine. 
 * The user will be asked to make a wager to play various lines in a 3 x 3 grid. 
 * They can play center line, all three horizontal lines, all vertical lines and diagonals.
For instance the user can enter $3 dollars and play all three horizontal lines. 
If the top line hits a winning combination, they earn $1 dollar for that line.

rocket Tips: The mention of a grid here should be a dead giveaway that you need a 2D array.

You will also need functionality that can check a horizontal line, a vertical line and a diagonal.

Depending on the number of lines they play, you may need to execute all three of these statements one or multiple times to 
look for winning lines. If they are playing three lines, you would call your horizontal line check function three times... 
one for the top row, one for the center row and one for the bottom row. Each of these row checking algorithms will 
then need to look for winning combinations. The result is then dumped into the player’s money total. 
As for the mechanism to determine what the wheels produce per spin, use a random number generating function.
*/

/*
 STEPS:
- create welcome message to the user
- create a function for this
- create random number from 0 to 9 and insert in 2D grid
- insert random numbers in slot machine
- create variable to store user's money
- 
 */
namespace slot_machine
{
    internal class Program
    {
        //function for slot machine
        static void SlotMachine()
        {
            Console.WriteLine("\nWelcome to Slot Machine!\n");
            //1 second delay
            System.Threading.Thread.Sleep(1000);

            const int STARTING_ROW = 0;
            const int STARTING_COLUMN = 0;
            const int ENDING_ROW = 2;
            const int ENDING_COLUMN = 2;

            //user's winnings, user starts at $10
            int winnings = 10;

            //array to store random digits
            //2D array that is 3 by 3
            int[,] spinningSlotMachine = new int[3, 3];

            //insert values in spinning slot machine array
            //2 second delay
            Console.WriteLine("Spinning the wheel...\n");
            System.Threading.Thread.Sleep(2000);
            Random rng = new Random();
            for (int i = STARTING_ROW; i <= ENDING_ROW; i++)
            {
                for (int j = STARTING_COLUMN; j <= ENDING_COLUMN; j++)
                {
                    int randomValue = rng.Next(10);
                    spinningSlotMachine[i, j] = randomValue;
                    Console.WriteLine(spinningSlotMachine[i, j]);
                }
                Console.WriteLine();
            }

            Console.WriteLine("\nPress y to continue playing or any key to quit!\n");
            char userInput = Char.ToLower(Console.ReadKey().KeyChar);
            //if user wishes to continue, call the slotmachine function
            if (userInput == 'y')
            {
                SlotMachine();
            }
            //quit the game
            return;
        }
        static void Main(string[] args)
        {
            //call the function
            SlotMachine();
        }
    }
}