using SnakeEngine;

namespace Tests;

public class SegmentTests
{
    [Fact]
    public void Move()
    {
        Snake snake = new Snake(3, 3, 3);
        snake.TurnDown();
        snake.Move();

        var head = snake.Nodes.First;
        var mid = head.Next;
        var last = mid.Next;

        Assert.Equal(3, snake.Nodes.Count);

        Assert.Equal(0, head.Value.OffsetFromPreviousY);
        Assert.Equal(0, head.Value.OffsetFromPreviousX);


        Assert.Equal(-1, mid.Value.OffsetFromPreviousY);
        Assert.Equal(0, mid.Value.OffsetFromPreviousX);

        Assert.Equal(0, last.Value.OffsetFromPreviousY);
        Assert.Equal(1, last.Value.OffsetFromPreviousX);

        Assert.Equal(4, snake.HeadY);
        Assert.Equal(3, snake.HeadX);
    }

    [Fact]
    public void DoubleMove()
    {
        Snake snake = new Snake(3, 3, 3);
        snake.TurnDown();
        snake.Move();
        snake.Move();

        var head = snake.Nodes.First;
        var mid = head.Next;
        var last = mid.Next;

        Assert.Equal(3, snake.Nodes.Count);

        Assert.Equal(0, head.Value.OffsetFromPreviousY);
        Assert.Equal(0, head.Value.OffsetFromPreviousX);


        Assert.Equal(-1, mid.Value.OffsetFromPreviousY);
        Assert.Equal(0, mid.Value.OffsetFromPreviousX);

        Assert.Equal(-1, last.Value.OffsetFromPreviousY);
        Assert.Equal(0, last.Value.OffsetFromPreviousX);

        Assert.Equal(5, snake.HeadY);
        Assert.Equal(3, snake.HeadX);
    }


}