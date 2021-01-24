using Config;
using Game;
using GameAbstract;
using System;
using FileSystem;

namespace MVC
{
    class Model : ARoad
    {
        public GameStats GameStats { get; private set; }
        public bool IsGameEnabled { get; private set; }

        private static readonly Random random = new Random();

        public Model() : base(new Car(Settings.CarWidth, Settings.CarWidth))
        {
            GameStats = new GameStats(Settings.GameStartDelay, Settings.BonusDropChance, Settings.ObstacleStartDropChance, Settings.LivesCount);
            IsGameEnabled = true;
        }

        public void InitializeMotion()
        {
            if (GameStats.GameSpeedDelay > 20) GameStats.GameSpeedDelay--;
            if (GameStats.ObstacleDropChance <= 80) GameStats.ObstacleDropChance += 0.1;
            MoveObstacles();
            MoveCar();
        }

        public void ListenToBlocks()
        {
            for (int i = 0; i < Obstacles.Count; i++)
                if (IsCollision(Obstacles[i]) && Obstacles[i].GetType().Equals(typeof(Block)))
                    if (GameStats.LivesCount > 1)
                    {
                        Obstacles.Clear();
                        GameStats.LivesCount--;
                        GameStats.LastEvent = new GameEvent("-1 Life");
                    }
                    else
                    {
                        if (DateTime.Now - GameStats.StartedAt > GameStats.Record.TimeSpan)
                            GameStats.Record.SaveRecord(DateTime.Now - GameStats.StartedAt);
                        IsGameEnabled = false;
                    }
        }

        public void ListenToBonuses()
        {
            for (int i = 0; i < Obstacles.Count; i++)
                if (IsCollision(Obstacles[i]) && Obstacles[i].GetType().Equals(typeof(Bonus)))
                {
                    Obstacles.RemoveAt(i);
                    GameStats.BonusDropChance -= 1;
                    switch (random.Next(0, 4))
                    {
                        case (int)BonusModifiers.Obstacles:
                            GameStats.ObstacleDropChance -= Settings.ObstacleBonusModifier;
                            GameStats.LastEvent = new GameEvent($"-{Settings.ObstacleBonusModifier}% Obstacle chance");
                            break;

                        case (int)BonusModifiers.Delay:
                            GameStats.GameSpeedDelay += Settings.DelayBonusModifier;
                            GameStats.LastEvent = new GameEvent($"+{Settings.DelayBonusModifier} ms Delay");
                            break;

                        case (int)BonusModifiers.Live:
                            GameStats.LivesCount += Settings.LiveBonusModifier;
                            GameStats.LastEvent = new GameEvent($"+{Settings.LiveBonusModifier} Life");
                            break;

                        case (int)BonusModifiers.Bonus:
                            GameStats.BonusDropChance += Settings.BonusDropModifier;
                            GameStats.LastEvent = new GameEvent($"+{Settings.BonusDropModifier - 1}% Bonus Chance");
                            break;
                    }
                }
        }

        public void InitializeNewObstacles()
        {
            if (random.Next(0, 100) < GameStats.ObstacleDropChance)
                for (int i = 0; i < Settings.ObstaclesCount; i++)
                    if (random.Next(0, 100) < GameStats.BonusDropChance) AddObstacle(new Bonus(Settings.BonusWidth, Settings.BonusWidth));
                    else AddObstacle(new Block(Settings.BlockWidth, Settings.BlockHeight));
        }
    }
}
