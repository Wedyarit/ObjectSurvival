using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FileSystem;

namespace Game
{
    class GameStats
    {
        public uint GameSpeedDelay { get; set; }
        public double BonusDropChance { get; set; }
        public double ObstacleDropChance { get; set; }
        public uint LivesCount { get; set; }
        public GameEvent LastEvent { get; set; }
        public DateTime StartedAt { get; set; }
        public Record Record { get; set; }

        public GameStats(uint gameSpeedDelay, double bonusDropChance, double obstacleDropChance, uint livesCount)
        {
            GameSpeedDelay = gameSpeedDelay;
            BonusDropChance = bonusDropChance;
            ObstacleDropChance = obstacleDropChance;
            LivesCount = livesCount;
            LastEvent = new GameEvent("Игра началась");
            StartedAt = DateTime.Now;
            Record = new Record();
            Record.ReadRecord();
        }
    }
}
