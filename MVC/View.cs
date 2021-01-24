using Config;
using System;
using System.Collections.Generic;
using System.Linq;
using FileSystem;
using Game;

namespace MVC
{
    class View
    {
        public List<ViewContent> ViewContents { get; set; }
        private readonly List<ViewContent> staticViewContents;

        public View()
        {
            Console.WindowHeight = (int)Settings.ScreenHeight + 2;
            Console.WindowWidth = (int)Settings.ScreenHeight + 60;

            ViewContents = new List<ViewContent>();
            staticViewContents = new List<ViewContent>();
        }

        public void UpdateView()
        {
            Console.Clear();
            ViewContents.Concat(staticViewContents).ToList().ForEach((content) => WriteContent(content));

            Console.SetCursorPosition(0, 0);
        }

        public void DesignContents()
        {
            string[] roadBorder = { "║" };

            for (uint i = 0; i <= Settings.ScreenHeight + 1; i++)
            {
                staticViewContents.Add(new ViewContent(0, i, ConsoleColor.White, roadBorder));
                staticViewContents.Add(new ViewContent(Settings.ScreenWidth + 2, i, ConsoleColor.White, roadBorder));
            }
        }

        public void LoadStats(GameStats gameStats, TimeSpan record)
        {
            string[] events = new string[5];
            events[0] = "┌──────────────────────────────┐";
            events[1] = "│     ▒ Последнее событие ▒    │";
            events[2] = $"│{$" ■ {gameStats.LastEvent.TimeSpan:ss} секунд назад",-30}│";
            events[3] = $"│{$" ■ {gameStats.LastEvent.Event}",-30}│";
            events[4] = "└──────────────────────────────┘";
            ViewContents.Add(new ViewContent(43, 2, ConsoleColor.Yellow, events));

            string[] status = new string[7];
            status[0] = "┌──────────────────────────────┐";
            status[1] = "│       ▒ Статус игры ▒        │";
            status[2] = $"│{$" ■ Жизни: {gameStats.LivesCount}",-30}│";
            status[3] = $"│{$" ■ Шанс препятствий: {Math.Round(gameStats.ObstacleDropChance, 1)}%",-30}│";
            status[4] = $"│{$" ■ Шанс бонуса: {gameStats.BonusDropChance}%",-30}│";
            status[5] = $"│{$" ■ Задержка: {gameStats.GameSpeedDelay} мс",-30}│";
            status[6] = "└──────────────────────────────┘";
            ViewContents.Add(new ViewContent(43, 7, ConsoleColor.Green, status));

            string[] stats = new string[5];
            stats[0] = "┌──────────────────────────────┐";
            stats[1] = "│        ▒ Статистика ▒        │";
            stats[2] = $"│{$" ■ Время: {(DateTime.Now - gameStats.StartedAt):hh\\:mm\\:ss}",-30}│";
            stats[3] = $"│{$" ■ Рекорд: {record:hh\\:mm\\:ss}",-30}│";
            stats[4] = "└──────────────────────────────┘";
            ViewContents.Add(new ViewContent(43, 14, ConsoleColor.Cyan, stats));
        }

        public void WriteContent(ViewContent content)
        {
            int i = 0;
            foreach (string str in content.Content)
            {
                Console.SetCursorPosition((int)content.X, (int)content.Y + i);
                Console.ForegroundColor = content.Color;
                Console.Write(str);
                i++;
            }
            Console.SetCursorPosition(0, 0);
        }

        public void WriteChar((uint, uint, ConsoleColor, char) content)
        {
            Console.SetCursorPosition((int)content.Item1, (int)content.Item2);
            Console.ForegroundColor = content.Item3;
            Console.Write(content.Item4);
            Console.SetCursorPosition(0, 0);
        }

        public void EndGame()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write(@"
   ____                         ___                 
  / ___| __ _ _ __ ___   ___   / _ \__   _____ _ __ 
 | |  _ / _` | '_ ` _ \ / _ \ | | | \ \ / / _ \ '__|
 | |_| | (_| | | | | | |  __/ | |_| |\ V /  __/ |   
  \____|\__,_|_| |_| |_|\___|  \___/  \_/ \___|_|   
            
            ");
            Console.ReadKey();
        }
    }
}
