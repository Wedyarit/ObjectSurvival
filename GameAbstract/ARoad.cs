using Config;
using Game;
using System.Collections.Generic;

namespace GameAbstract
{
    class ARoad
    {
        public List<AObstacle> Obstacles { get; protected set; }
        public Car Car { get; protected set; }
        protected ARoad(Car car)
        {
            Car = car;
            Obstacles = new List<AObstacle>();
        }

        public void AddObstacle(AObstacle obstacle) { Obstacles.Add(obstacle); }
        public void RemoveObstacle(AObstacle obstacle) { Obstacles.Remove(obstacle); }
        public void MoveCar() { Car.MovementListener(); }
        public void MoveObstacles()
        {
            for (int i = 0; i < Obstacles.Count; i++)
                if (Obstacles[i].GetCoordinates().Value >= Settings.ScreenHeight)
                {
                    Obstacles.RemoveAt(i);
                    i--;
                }
                else Obstacles[i].MoveDown();
        }

        public bool IsCollision(AObstacle obstacle)
        {
            uint oX = obstacle.GetCoordinates().Key;
            uint oY = obstacle.GetCoordinates().Value;
            uint oW = obstacle.Width - 1;
            uint oH = obstacle.Height - 1;

            uint cX = Car.GetCoordinates().Key;
            uint cY = Car.GetCoordinates().Value;
            uint cW = Car.Width - 1;
            uint cH = Car.Height - 1;

            return (oX >= cX && oX <= cX + cW && oY >= cY && oY <= cY + cH) || (cX >= oX && cX <= oX + oW && cY >= oY && cY <= oY + oH);
        }
    }
}
