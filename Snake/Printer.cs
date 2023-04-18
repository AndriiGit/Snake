using System.Text;
using SnakeEngine;

namespace ConsoleGame;

public class Printer : IPrinter
{
    private StringBuilder builder;
    private char topBorderSign = '_';
    private char bottomBorderSign = '_';

    public IPlayGround PlayGround { get; set; }

    public Printer()
    {
        builder = new StringBuilder();
    }
    public void Print()
    {
        Console.Clear();
        builder.Clear();

        for (int y = 0; y <= PlayGround.Height; y++)
        {
            if (y == 0)
            {
                builder.AppendLine(new string(getTopBorderLine(PlayGround.Width)));
            }
            else if (y == PlayGround.Height)
            {
                builder.AppendLine(new string(getBottomBorderLine(PlayGround.Width)));
            }
            else if (y > 0)
            {
                char[] line = new char[PlayGround.Width + 2];

                for (int x = 0; x < line.Length; x++)
                {
                    if (x == 0)
                    {
                        line[x] = '|';
                    }
                    else if (x == line.Length - 1)
                    {
                        line[x] = '|';
                    }
                    else if (x > 0)
                    {
                        if (PlayGround.Candy.X == x && PlayGround.Candy.Y == y)
                            line[x] = '@';
                        else if (PlayGround.Snake.IsSnake(x, y))
                            line[x] = '0';
                        else
                            line[x] = ' ';
                    }
                }
                builder.AppendLine(new string(line));
            }
        }

        Console.WriteLine(builder);
        Console.WriteLine($"Score: {PlayGround.Score}");
    }

    private char[] getTopBorderLine(int width)
    {
        char[] border = new char[width + 2];
        for (int i = 0; i < border.Length; i++)
        {
            border[i] = topBorderSign;
        }
        return border;
    }

    private char[] getBottomBorderLine(int width)
    {
        char[] border = new char[width + 2];
        for (int i = 0; i < border.Length; i++)
        {
            border[i] = i == 0 ? '|' : i == border.Length - 1 ? '|' : '_';
        }
        return border;
    }
}