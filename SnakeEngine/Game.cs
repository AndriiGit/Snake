namespace SnakeEngine
{
    public class Game
    {
        public PlayGround PlayGround { get; private set; }
        private Task playGroundUpdate;
        public bool IsOver { get; private set; }
        
        public Game()
        {
            PlayGround = new PlayGround(10, 10);
            PlayGround.BorderCrossed += () => { Stop(); };

            playGroundUpdate = new Task(() => {
                while (!IsOver)
                {
                    PlayGround.Update();
                    Thread.Sleep(500);
                }
            });
        }

        public void TurnSnake(MovingDirection direction)
        {
            PlayGround.TurnSnake(direction);
            if (playGroundUpdate.Status == TaskStatus.Created)
            {
                playGroundUpdate.Start();
            }
        }
        public void Stop()
        {
            IsOver = true;
            if (GameOver != null)
                GameOver();
        }

        public event Action GameOver;
    }
}
