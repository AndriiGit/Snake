using SnakeEngine;

namespace ConsoleGame;

public class PrinterCollored : IPrinter
{
    public IPlayGround PlayGround { get; set; }

    public void Print()
    {
        Console.Clear();

        for (int y = 0; y <= PlayGround.Height; y++)
        {
            if (y == 0)
            {
                Console.BackgroundColor = ConsoleColor.Green;
                for (int x = 0; x < PlayGround.Width + 2; x++)
                {
                    Console.Write(' ');
                }
                Console.BackgroundColor = ConsoleColor.Black;
                Console.WriteLine();
            }
            else if (y == PlayGround.Height)
            {
                Console.BackgroundColor = ConsoleColor.Green;
                for (int x = 0; x < PlayGround.Width + 2; x++)
                {
                    Console.Write(' ');
                }
                Console.BackgroundColor = ConsoleColor.Black;
                Console.WriteLine();
            }
            else if (y > 0)
            {
                for (int x = 0; x < PlayGround.Width + 2; x++)
                {
                    if (x == 0)
                    {
                        Console.BackgroundColor = ConsoleColor.Green;
                        Console.Write(' ');
                    }
                    else if (x == PlayGround.Width + 1)
                    {
                        Console.BackgroundColor = ConsoleColor.Green;
                        Console.Write(' ');
                    }
                    else if (x > 0)
                    {
                        if (PlayGround.Candy.X == x && PlayGround.Candy.Y == y)
                        {
                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                            Console.BackgroundColor = ConsoleColor.Black;
                            Console.Write('@');
                        }
                        else if (PlayGround.Snake.IsSnake(x, y))
                        {
                            if(PlayGround.Snake.HeadX == x && PlayGround.Snake.HeadY == y)
                            {
                                Console.BackgroundColor = ConsoleColor.Black;
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.Write('8');
                            }
                            else{
                                Console.BackgroundColor = ConsoleColor.Black;
                                Console.ForegroundColor = ConsoleColor.Yellow;
                                Console.Write('0');
                            }
                        }
                        else
                        {
                            Console.BackgroundColor = ConsoleColor.Black;
                            Console.Write(' ');
                        }
                    }
                }
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.WriteLine();
            }
        }
        Console.WriteLine($"Score: {PlayGround.Score}");
    }
}
