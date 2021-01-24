using Config;
using GameAbstract;
using System;

namespace Game
{
    class Car : ACar
    {
        public Car(uint width, uint heigth)
        {
            X = Settings.ScreenWidth / 2;
            Y = Settings.ScreenHeight - 2;

            Width = width;
            Height = heigth;
        }
    }
}
