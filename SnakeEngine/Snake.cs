namespace SnakeEngine;

public enum MovingDirection
{
    UP,
    DOWN,
    LEFT,
    RIGHT,
}


public class Snake
{
    private MovingDirection _direction;
    private bool needToAddNode;
    public LinkedList<SnakeNode> Nodes;

    public int HeadX { get; set; }
    public int HeadY { get; set; }


    public Snake(int length, int headX, int headY)
    {
        HeadX = headX;
        HeadY = headY;

        Nodes = new LinkedList<SnakeNode>();
        BuildSnake(length);
    }

    private void BuildSnake(int length, int x = 0, int y = 0)
    {
        
        for (int i = 0; i < length; i++)
        {
            SnakeNode node = new SnakeNode(i==0?0:1,0);
            Nodes.AddLast(node);
        }
    }
    
    public bool IsSnake(int x, int y)
    {
        lock (this)
        {
            foreach (SnakeNode node in Nodes)
            {
                if (x == HeadX + GetFullOffsetX(Nodes.Find(node)) && y == HeadY + GetFullOffsetY(Nodes.Find(node)))
                    return true;
            }
        }
        return false;
    }

    private int GetFullOffsetY(LinkedListNode<SnakeNode> snakeNode)
    {
        return snakeNode.Value.OffsetFromPreviousY + (snakeNode.Previous != null ? GetFullOffsetY(snakeNode.Previous) : 0);
    }

    private int GetFullOffsetX(LinkedListNode<SnakeNode> snakeNode)
    {
        return snakeNode.Value.OffsetFromPreviousX + (snakeNode.Previous != null ? GetFullOffsetX(snakeNode.Previous) : 0);
    }

    public void AddNode()
    {
        needToAddNode = true;
    }

    public void Move()
    {
        lock (this)
        {
            HeadX += _direction == MovingDirection.LEFT ? -1 : (_direction == MovingDirection.RIGHT ? 1 : 0);
            HeadY += _direction == MovingDirection.UP ? -1 : (_direction == MovingDirection.DOWN ? 1 : 0);
            MoveTailToHead();
        }
    }

    private void MoveTailToHead()
    {
        if(needToAddNode)
        {
            var newNode = new SnakeNode(0, 0);
            Nodes.AddFirst(newNode);
            needToAddNode = false;
            if (CandyCaptured != null)
                CandyCaptured();
        }
        else
        {
            var lastNode = Nodes.Last;
            Nodes.RemoveLast();
            Nodes.AddFirst(lastNode);
            lastNode.Value.OffsetFromPreviousX = 0;
            lastNode.Value.OffsetFromPreviousY = 0;
        }

        var first = Nodes.First;
        first.Next.Value.OffsetFromPreviousX = _direction == MovingDirection.LEFT ? 1 : (_direction == MovingDirection.RIGHT ? -1 : 0);
        first.Next.Value.OffsetFromPreviousY = _direction == MovingDirection.UP ? 1 : (_direction == MovingDirection.DOWN ? -1 : 0);
    }
    public void TurnLeft()
    {
        _direction = MovingDirection.LEFT;
    }
    public void TunrnRight()
    {
        _direction=MovingDirection.RIGHT;
    }
    public void TurnUp()
    {
        _direction = MovingDirection.UP;
    }
    public void TurnDown()
    {
        _direction = MovingDirection.DOWN;
    }

    public event Action CandyCaptured;
}
