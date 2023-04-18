using SnakeEngine;

namespace ConsoleGame;

public interface IPrinter
{
    IPlayGround PlayGround { get; set; }
    void Print();
    
}
