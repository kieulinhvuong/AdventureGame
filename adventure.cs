using System;
using System.Text;
using System.Linq;
using System.Collections.Generic;

/*
 Cool ass stuff people could implement:
 > jumping
 > attacking
 > randomly moving monsters
 > smarter moving monsters
*/
namespace asciiadventure
{
    public class Game
    {
        private Random random = new Random();
        private static Boolean Eq(char c1, char c2)
        {
            return c1.ToString().Equals(c2.ToString(), StringComparison.OrdinalIgnoreCase);
        }

        private static string Menu()
        {
            return "TFGH to jump 3 steps\nWASD to move\nIJKL to move the moving treasure (Treasure1)\nC to change color\nE to start over\nEnter command: ";
        }

        private static void PrintScreen(Screen screen, string message, string menu)
        {
            Console.Clear();
            Console.WriteLine(screen);
            Console.WriteLine($"\n{message}");
            Console.WriteLine($"\n{menu}");
        }

        //add a new variable to store random color 
        Random r = new Random();

        public void Run()
        {
            Console.ForegroundColor = ConsoleColor.Green;

            Screen screen = new Screen(10, 10);
            // add a couple of walls
            for (int i = 0; i < 3; i++)
            {
                new Wall(1, 2 + i, screen);
            }
            for (int i = 0; i < 4; i++)
            {
                new Wall(3 + i, 4, screen);
            }

            // add a player
            Player player = new Player(0, 0, screen, "Zelda");

            // add a treasure
            Treasure treasure = new Treasure(6, 2, screen);

            //add another treasure called treasure1
            Treasure1 treasure1 = new Treasure1(2, 2, screen);

            //add a heart (extra live for player)
            Heart heart = new Heart(8, 6, screen);

            // add some mobs
            List<Mob> mobs = new List<Mob>();
            mobs.Add(new Mob(9, 9, screen));

            // initially print the game board
            PrintScreen(screen, "Welcome!", Menu());

            Boolean gameOver = false;

            while (!gameOver)
            {
                char input = Console.ReadKey(true).KeyChar;

                String message = "";

                if (Eq(input, 'q'))
                {
                    break;
                }
                else if (Eq(input, 'w'))
                {
                    if (screen[player.Row - 1, player.Col] is Treasure1)
                    {
                        message += "YOU GOT THE TREASURE!\n";
                        gameOver = true;
                    }
                    else if (screen[player.Row - 1, player.Col] is Heart)
                    {
                        message += "YOU WIN!\n";
                        gameOver = true;
                    }
                    player.Move(-1, 0);
                }
                else if (Eq(input, 's'))
                {
                    if (screen[player.Row + 1, player.Col] is Treasure1)
                    {
                        message += "YOU GOT THE TREASURE!\n";
                        gameOver = true;
                    }
                    else if (screen[player.Row + 1, player.Col] is Heart)
                    {
                        message += "YOU WIN!\n";
                        gameOver = true;
                    }
                    player.Move(1, 0);
                }
                else if (Eq(input, 'a'))
                {
                    if (screen[player.Row, player.Col - 1] is Treasure1)
                    {
                        message += "YOU GOT THE TREASURE!\n";
                        gameOver = true;
                    }
                    else if (screen[player.Row, player.Col - 1] is Heart)
                    {
                        message += "YOU WIN!\n";
                        gameOver = true;
                    }
                    player.Move(0, -1);
                }
                else if (Eq(input, 'd'))
                {
                    if (screen[player.Row, player.Col + 1] is Treasure1)
                    {
                        message += "YOU GOT THE TREASURE!\n";
                        gameOver = true;
                    }
                    else if (screen[player.Row, player.Col + 1] is Heart)
                    {
                        message += "YOU WIN!\n";
                        gameOver = true;
                    }
                    player.Move(0, 1);
                }
                else if (Eq(input, 't'))
                {
                    player.Move(-3, 0);
                }
                else if (Eq(input, 'f'))
                {
                    player.Move(0, -3);
                }
                else if (Eq(input, 'g'))
                {
                    player.Move(3, 0);
                }
                else if (Eq(input, 'h'))
                {
                    player.Move(0, 3);
                }
                else if (Eq(input, 'i'))
                {
                    message += treasure1.Move(-1, 0) + "\n";
                }
                else if (Eq(input, 'k'))
                {
                    message += treasure1.Move(1, 0) + "\n";
                }
                else if (Eq(input, 'j'))
                {
                    message += treasure1.Move(0, -1) + "\n";
                }
                else if (Eq(input, 'l'))
                {
                    message += treasure1.Move(0, 1) + "\n";
                } //when press key 'c', the screen changes color randomly 
                else if (Eq(input, 'c'))
                {
                    Console.ForegroundColor = (ConsoleColor)r.Next(0, 16);
                } //press key 'e' to clear the screen and start over
                else if (Eq(input, 'e'))
                {
                    Console.Clear();
                    Console.WriteLine(screen1);
                    Screen screen1 = new Screen(20, 20);
                    Game game1 = new Game();
                    game1.Run();
                }
                else if (Eq(input, 'v'))
                {
                    // TODO: handle inventory
                    message = "You have nothing\n";
                }
                else
                {
                    message = $"Unknown command: {input}";
                }

                // OK, now move the mobs
                foreach (Mob mob in mobs)
                {
                    // TODO: Make mobs smarter, so they jump on the player, if it's possible to do so
                    List<Tuple<int, int>> moves = screen.GetLegalMoves(mob.Row, mob.Col);
                    if (moves.Count == 0)
                    {
                        continue;
                    }
                    // mobs move randomly
                    var (deltaRow, deltaCol) = moves[random.Next(moves.Count)];

                    if (screen[mob.Row + deltaRow, mob.Col + deltaCol] is Player)
                    {
                        // the mob got the player!
                        mob.Token = "*";
                        message += "A MOB GOT YOU! GAME OVER\n";
                        gameOver = true;
                    }
                    mob.Move(deltaRow, deltaCol);
                }

                PrintScreen(screen, message, Menu());
            }
        }

        public static void Main(string[] args)
        {
            Game game = new Game();
            game.Run();
        }
    }
}