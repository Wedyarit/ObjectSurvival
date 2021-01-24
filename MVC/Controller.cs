using Config;
using Game;
using GameAbstract;
using GameInterfaces;
using System.Collections.Generic;
using System.Threading;
using System;
using FileSystem;

namespace MVC
{
    class Controller : IDataToView
    {
        readonly Model model;
        readonly View view;

        public Controller()
        {
            model = new Model();
            view = new View();
            view.DesignContents();

            while (model.IsGameEnabled)
            {
                model.InitializeNewObstacles();
                model.InitializeMotion();
                view.ViewContents = DataToView();
                view.LoadStats(model.GameStats, Record.Max(model.GameStats.Record.TimeSpan, DateTime.Now - model.GameStats.StartedAt));
                view.UpdateView();
                model.ListenToBlocks();
                model.ListenToBonuses();

                Thread.Sleep((int)model.GameStats.GameSpeedDelay);
            }

            view.EndGame();
        }

        public void AddObstacleToView(AObstacle obstacle, List<ViewContent> list)
        {
            for (uint i = 0; i < obstacle.Width; i++)
                for (uint j = 0; j < obstacle.Height; j++)
                    if (obstacle.GetType().Equals(typeof(Bonus)))
                        list.Add(new ViewContent(obstacle.GetCoordinates().Key, obstacle.GetCoordinates().Value, Settings.BonusColor, Settings.BonusView));
                    else if (obstacle.GetType().Equals(typeof(Block)))
                        list.Add(new ViewContent(obstacle.GetCoordinates().Key, obstacle.GetCoordinates().Value, Settings.BlockColor, Settings.BlockView));
        }

        public List<ViewContent> DataToView()
        {
            List<ViewContent> viewContents = new List<ViewContent>();

            foreach (AObstacle obstacle in model.Obstacles)
                AddObstacleToView(obstacle, viewContents);

            viewContents.Add(new ViewContent(model.Car.GetCoordinates().Key, model.Car.GetCoordinates().Value, Settings.CarColor, Settings.CarView));

            return viewContents;
        }
    }
}
