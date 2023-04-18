namespace SnakeEngine
{
    public class PlayGround: IPlayGround
    {
        private CandyGenerator candyGenerator;
        public int Width { get; private set; }
        public int Height { get; private set; }
        public Snake Snake { get; private set; }
        public Candy Candy { get; private set; }
        public int Score { get; private set; }

        public event Action BorderCrossed;
        
        public PlayGround(int width, int height)
        {
            Width = width;
            Height = height;
            Snake = new Snake(3, width/2, height/2);
            Snake.CandyCaptured += () => { Score++; };
            candyGenerator = new CandyGenerator(width, height);
            CreateNewCandy();
        }

        private void CreateNewCandy()
        {
            do
            {
                Candy = candyGenerator.Generate();
            } while (Snake.IsSnake(Candy.X, Candy.Y));
        }

        public void Update()
        {
            Snake.Move();
            if(Snake.IsSnake(Candy.X, Candy.Y))
            {
                Snake.AddNode();
                CreateNewCandy();
            }
            if(Snake.HeadX > Width || Snake.HeadX < 1 ||
                Snake.HeadY > Height-1 || Snake.HeadY < 1)
            {
                if (BorderCrossed != null)
                    BorderCrossed();
            }
        }

        public void TurnSnake(MovingDirection direction)
        {
            switch(direction)
            {
                case MovingDirection.UP:
                    Snake.TurnUp();
                    break;
                case MovingDirection.DOWN:
                    Snake.TurnDown();
                    break;
                case MovingDirection.LEFT:
                    Snake.TurnLeft();
                    break;
                case MovingDirection.RIGHT:
                    Snake.TunrnRight();
                    break;
            }
        }
    }
}
