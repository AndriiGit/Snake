namespace SnakeEngine;

public interface IPlayGround
{
    int Width { get; }
    int Height { get; }
    int Score { get; }
    Snake Snake { get; }
    Candy Candy { get; }
}
