// See https://aka.ms/new-console-template for more information
namespace TicTacToe
{
    public class Program
    {

        //2: SET THE PLAYFIELD
        //these are the default characters
        static char[,] play_field_chars =
        {
                 {'1', '2', '3' },
                 {'4', '5', '6' },
                 {'7', '8', '9' }
            };

        //8 : variable to check for draw
        static int turns = 0;

        public static void Main(String[] args)
        {


            Console.WriteLine("Tic    Tac    Toe!");



            //3: Setting up the parameters to work with
            int player = 2; //Player 1 starts
            int input = 0; //default
            bool input_correct = true;


            //4: GAMEPLAY LOGIC, AS LONG AS THE PROGRAM IS RUNNING
            //we use a do-while so that the player will always be able to do something
            do
            {
                //4.2 IMPLEMENT THE EnterXorO METHOD CREATED BELOW
                if (player == 2)
                {
                    EnterXorO(player, input);
                    player = 1;

                }
                else if (player == 1)
                {
                    EnterXorO(player, input);
                    player = 2;
                }

                //we put the method in our do-while loop and not in the open M<ain method because we don't want it to be run only once, if not, our fields will not be updated
                //if we put the play_field method at the beginning of the loop, the fields will lag by a turn, because the players are updated (EnterXorO) after the method is called
                play_field();

                #region 
                //6 : CHECK WINNING CONDITION
                char[] playerSymbols = { 'X', 'O' };


                foreach (var playersymbol in playerSymbols)
                {
                    if (((play_field_chars[0, 0] == playersymbol) && (play_field_chars[0, 1] == playersymbol) && (play_field_chars[0, 2] == playersymbol))
                        || ((play_field_chars[1, 0] == playersymbol) && (play_field_chars[1, 1] == playersymbol) && (play_field_chars[1, 2] == playersymbol))
                        || ((play_field_chars[2, 0] == playersymbol) && (play_field_chars[2, 1] == playersymbol) && (play_field_chars[2, 2] == playersymbol))
                        || ((play_field_chars[0, 0] == playersymbol) && (play_field_chars[1, 0] == playersymbol) && (play_field_chars[2, 0] == playersymbol))
                        || ((play_field_chars[0, 1] == playersymbol) && (play_field_chars[1, 1] == playersymbol) && (play_field_chars[2, 1] == playersymbol))
                        || ((play_field_chars[0, 2] == playersymbol) && (play_field_chars[1, 2] == playersymbol) && (play_field_chars[2, 2] == playersymbol))
                        || ((play_field_chars[0, 0] == playersymbol) && (play_field_chars[1, 1] == playersymbol) && (play_field_chars[2, 2] == playersymbol))
                        || ((play_field_chars[0, 2] == playersymbol) && (play_field_chars[1, 1] == playersymbol) && (play_field_chars[2, 0] == playersymbol))
                        )
                    {

                        if (playersymbol == 'X')
                        {
                            Console.WriteLine("Player 1 wins!");
                        }
                        else
                        {
                            Console.WriteLine("Player 2 wins!");
                        }

                        Console.WriteLine("Press any key to play again..");

                        // 7: RESET GAME
                        Console.ReadKey();
                        reset_game();
                        break;
                    }
                    //8.3 : when the play gets to 10, apparently, no winner
                    else if (turns == 9)
                    {
                        Console.WriteLine("\nDRAW");
                        Console.WriteLine("Press any key to play again..");
                        // 7: RESET GAME
                        Console.ReadKey();
                        reset_game();
                        break;

                    }

                }

                #endregion


                /* 
                     switch (player)
                 {
                     case 1: //Player 1's turn
                         {
                             switch (input)
                             {
                                 case 1: play_field_chars[0, 0] = 'X'; break;
                                 case 2: play_field_chars[0, 1] = 'X'; break;
                                 case 3: play_field_chars[0, 0] = 'X'; break;
                                 case 4: play_field_chars[0, 0] = 'X'; break;
                                 case 5: play_field_chars[0, 0] = 'X'; break;
                                 case 6: play_field_chars[0, 0] = 'X'; break;
                                 case 7: play_field_chars[0, 0] = 'X'; break;
                                 case 8: play_field_chars[0, 0] = 'X'; break;
                                 case 9: play_field_chars[0, 0] = 'X'; break;
                             }
                         }
                     case 2:
                         switch (input)
                         {
                             case 1: play_field_chars[0, 0] = 'O'; break;
                             case 2: play_field_chars[0, 1] = '0'; break;
                             case 3: play_field_chars[0, 0] = '0'; break;
                             case 4: play_field_chars[0, 0] = '0'; break;
                             case 5: play_field_chars[0, 0] = '0'; break;
                             case 6: play_field_chars[0, 0] = '0'; break;
                             case 7: play_field_chars[0, 0] = '0'; break;
                             case 8: play_field_chars[0, 0] = '0'; break;
                             case 9: play_field_chars[0, 0] = '0' break;
                         }
                         break;


                         break;
                     default:
                         break;
                 }
                */
                //WE CAN REPLACE THIS SWITCH STATEMENT WITH THE EnterXorO Method below;

                #region
                //5 : Tests for errors
                do
                {
                    //trying for invalid keys entered
                    Console.Write($"\nPlayer {player}, Choose A Field! ");
                    try
                    {
                        input = Convert.ToInt32(Console.ReadLine());
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("\nPlease enter a legal number!");
                    }

                    //checking for already used fields
                    if ((input == 1) && (play_field_chars[0, 0] == '1'))
                        input_correct = true;

                    else if ((input == 2) && (play_field_chars[0, 1] == '2'))
                        input_correct = true;

                    else if ((input == 3) && (play_field_chars[0, 2] == '3'))
                        input_correct = true;

                    else if ((input == 4) && (play_field_chars[1, 0] == '4'))
                        input_correct = true;

                    else if ((input == 5) && (play_field_chars[1, 1] == '5'))
                        input_correct = true;

                    else if ((input == 6) && (play_field_chars[1, 2] == '6'))
                        input_correct = true;

                    else if ((input == 7) && (play_field_chars[2, 0] == '7'))
                        input_correct = true;

                    else if ((input == 8) && (play_field_chars[2, 1] == '8'))
                        input_correct = true;

                    else if ((input == 9) && (play_field_chars[2, 2] == '9'))
                        input_correct = true;

                    else
                    {
                        Console.WriteLine("Please enter another field!");
                        input_correct = false;
                        //it makes the field false, thereby making our if statement some room to keep running
                    }


                } while (!input_correct);

                #endregion

            } while (true);
        }

        //1 : SETTING UP OUR ENVIRONMENT;
        public static void play_field()
        {
            Console.Clear();
            Console.WriteLine("     |     |     ");
            //TODO replace numbers with variables
            Console.WriteLine("  {0}  |  {1}  |  {2}", play_field_chars[0, 0], play_field_chars[0, 1], play_field_chars[0, 2]);
            Console.WriteLine("_____|_____|_____");
            Console.WriteLine("     |     |   ");
            //TODO replace numbers with variables
            Console.WriteLine("  {0}  |  {1}  |  {2}", play_field_chars[1, 0], play_field_chars[1, 1], play_field_chars[1, 2]);
            Console.WriteLine("_____|_____|_____");
            Console.WriteLine("     |     |     ");
            //TODO replace numbers with variables
            Console.WriteLine("  {0}  |  {1}  |  {2}", play_field_chars[2, 0], play_field_chars[2, 1], play_field_chars[2, 2]);
            Console.WriteLine("     |     |     ");
            //8.1 : increment the turns variable each time we use this field
            turns++;

        }

        //7.1 : RESET GAME (METHOD)
        public static void reset_game()
        {
            char[,] play_field_chars_for_reset =
            {
               {'1', '2', '3' },
               {'4', '5', '6' },
               {'7', '8', '9' }
            };
            //setting this play_field_chars_for_reset outside this method will make the game reset only twice, since we have a foreach that runs twice(number of symbols in the loop {X,O})
            play_field_chars = play_field_chars_for_reset;
            play_field();
            //8.2 : reset the turns field after we reset the game
            turns = 0;
        }




        //4.1: METHOD TO REPLACE OUR SWITCH STATEMENT COMMENTED OUT ABOVE;
        //USED IN THE PLAYER LOGIC ABOVE TO CHANGE LETTERS AND PLAYER TURNS
        public static void EnterXorO(int player, int input)
        {
            char player_sign = ' ';

            if (player == 1)
                player_sign = 'X';
            else if (player == 2)
            {
                player_sign = 'O';
            }

            switch (input)
            {
                case 1: play_field_chars[0, 0] = player_sign; break;
                case 2: play_field_chars[0, 1] = player_sign; break;
                case 3: play_field_chars[0, 2] = player_sign; break;
                case 4: play_field_chars[1, 0] = player_sign; break;
                case 5: play_field_chars[1, 1] = player_sign; break;
                case 6: play_field_chars[1, 2] = player_sign; break;
                case 7: play_field_chars[2, 0] = player_sign; break;
                case 8: play_field_chars[2, 1] = player_sign; break;
                case 9: play_field_chars[2, 2] = player_sign; break;
            }
        }

    }
}
