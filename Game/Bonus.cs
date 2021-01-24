using GameAbstract;
using System;

namespace Game
{
    class Bonus : AObstacle
    {
        private readonly Random random = new Random();

        public Bonus(uint width, uint heigth)
        {
            X = (uint)random.Next(1, (int)Config.Settings.ScreenWidth - 1);
            Y = 0;

            Width = width;
            Height = heigth;
        }
    }
}
