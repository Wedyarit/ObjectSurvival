using Config;
using GameInterfaces;
using System;
using System.Collections.Generic;

namespace GameAbstract
{
    abstract class ACar : IControl
    {
        protected uint X { get; set; }
        protected uint Y { get; set; }
        public uint Width { get; protected set; }
        public uint Height { get; protected set; }

        public void MoveToTheLeft() { if (X > 1) X--; }
        public void MoveToTheRight() { if (X < Settings.ScreenWidth - 1) X++; }
        public void MovementListener()
        {
            while (Console.KeyAvailable)
            {
                ConsoleKey key = Console.ReadKey(true).Key;
                if (key == ConsoleKey.LeftArrow)
                    MoveToTheLeft();
                else if (key == ConsoleKey.RightArrow)
                    MoveToTheRight();
            }
        }
        public KeyValuePair<uint, uint> GetCoordinates() => new KeyValuePair<uint, uint>(X, Y);
    }
}
