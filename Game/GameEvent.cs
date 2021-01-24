using System;

namespace Game
{
    class GameEvent
    {
        private DateTime DateTime { get; set; }
        public TimeSpan TimeSpan { get => DateTime.Now - DateTime; }
        public string Event { get; }

        public GameEvent(string eventName)
        {
            DateTime = DateTime.Now;
            Event = eventName;
        }
    }
}
