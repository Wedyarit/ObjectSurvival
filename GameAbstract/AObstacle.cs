using System.Collections.Generic;

namespace GameAbstract
{
    abstract class AObstacle
    {
        protected uint X { get; set; }
        protected uint Y { get; set; }
        public uint Width { get; protected set; }
        public uint Height { get; protected set; }

        public void MoveDown() { Y++; }
        public KeyValuePair<uint, uint> GetCoordinates() { return new KeyValuePair<uint, uint>(X, Y); }
    }
}
