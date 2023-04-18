namespace SnakeEngine;

public class SnakeNode
{
    public int OffsetFromPreviousX { get; set; }
    public int OffsetFromPreviousY { get; set; }

    public SnakeNode(int offsetX, int offsetY)
    {
        OffsetFromPreviousX = offsetX;
        OffsetFromPreviousY = offsetY;
    }
}
