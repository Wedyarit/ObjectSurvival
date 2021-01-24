using System;

namespace MVC
{
    internal class ViewContent
    {
        public uint X { get; set; }
        public uint Y { get; set; }
        public ConsoleColor Color { get; set; }
        public string[] Content { get; set; }

        public ViewContent(uint x, uint y, ConsoleColor color, string[] content)
        {
            X = x;
            Y = y;
            Color = color;
            Content = content;
        }
    }
}
