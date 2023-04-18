using SnakeEngine;

namespace ConsoleGame;

public class Processor
{
    private Task keyHandler;
    private Game game;
    private CancellationTokenSource cancellationTokenSource;
    private CancellationToken cancellationToken;
    private IPrinter _printer;

    public Processor(IPrinter printer)
    {
        _printer = printer;
    }

    public void Start()
    {
        StartNewGame();

        Console.WriteLine("Game Over");
        Console.WriteLine("Start new game? y/n");
        var answer  = Console.ReadLine();
        if (answer == "y")
        {
            Start();
        }
    }

    private void StartNewGame()
    {
        cancellationTokenSource = new CancellationTokenSource();
        cancellationToken = cancellationTokenSource.Token;
        keyHandler = new Task(() => UserActionHandler(), cancellationToken);

        game = new Game();
        game.GameOver += () => { cancellationTokenSource.Cancel(); };

        _printer.PlayGround = game.PlayGround;
        keyHandler.Start();

        while (!game.IsOver)
        {
            _printer.Print();
            Thread.Sleep(250);
        }
    }

    private void UserActionHandler()
    {
        ConsoleKeyInfo keyInfo;
        do
        {
            keyInfo = Console.ReadKey();

            switch (keyInfo.Key)
            {
                case ConsoleKey.UpArrow:
                    game.TurnSnake(MovingDirection.UP);
                    break;
                case ConsoleKey.DownArrow:
                    game.TurnSnake(MovingDirection.DOWN);
                    break;
                case ConsoleKey.LeftArrow:
                    game.TurnSnake(MovingDirection.LEFT);
                    break;
                case ConsoleKey.RightArrow:
                    game.TurnSnake(MovingDirection.RIGHT);
                    break;
            }
        }
        while (keyInfo.Key != ConsoleKey.Escape);
        game.Stop();
    }
}
