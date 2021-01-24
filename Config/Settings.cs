using System;

namespace Config
{
    struct Settings
    {
        #region  // ----------- ПОСТОЯННЫЕ НАСТРОЙКИ ----------- \\
        // Ширина экрана. По умолчанию: 35
        public const uint ScreenWidth = 35;

        // Высота экрана. По умолчанию: 20
        public const uint ScreenHeight = 20;
        #endregion

        #region // ----------- ГЛАВНЫЕ НАСТРОЙКИ ----------- \\
        // Начальная игровая задержка (в миллисекундах). По умолчанию: 150
        public const uint GameStartDelay = 150;

        // Первоначальное количество жизней. По умолчанию: 3
        public const uint LivesCount = 3;
        #endregion

        #region // ----------- НАСТРОЙКИ ПРЕПЯТСТВИЙ ----------- \\
        // Количество препятствий, генерирующихся за раз. По умолчанию: 1
        public const uint ObstaclesCount = 1;

        // Первоначальный шанс генерации препятствия (в процентах). По умолчанию: 20
        public const double ObstacleStartDropChance = 20;

        #region Настройки бонусов
        // Шанс генерации бонуса (в процентах). По умолчанию: 30
        public const double BonusDropChance = 30;

        // Количество жизней, прибавляемое к текущим жизням бонусом "Новая жизнь". По умолчанию: 1
        public const uint LiveBonusModifier = 1;

        // Количество миллисекунд, прибавляемое к текущей задержке бонусом "Задержка". По умолчанию: 30
        public const uint DelayBonusModifier = 30;

        // Отнимаемый от текущего шанс генерации препятствия (в процентах). По умолчанию: 10
        public const uint ObstacleBonusModifier = 10;

        // Прибавляемый к текущему шанс генерации бонуса (в процентах). По умолчанию: 2
        public const uint BonusDropModifier = 2;

        // Ширина бонуса. По умолчанию: 2
        public const uint BonusWidth = 2;

        // Высота бонуса. По умолчанию: 3
        public const uint BonusHeight = 2;

        // Визуализация бонуса. По умолчанию: "╔╗", "╚╝" 
        public static string[] BonusView = new string[] { "╔╗", "╚╝" };

        // Цвет бонуса. По умолчанию: ConsoleColor.Green
        public const ConsoleColor BonusColor = ConsoleColor.Green;

        #endregion

        #region Настройки блоков
        // Ширина блока. По умолчанию: 3
        public const uint BlockWidth = 2;

        // Высота блока. По умолчанию: 3
        public const uint BlockHeight = 2;

        // Визуализация блока. По умолчанию: "╔╗", "╚╝" 
        public static string[] BlockView = new string[] { "╔╗", "╚╝" };

        // Цвет блока. По умолчанию: ConsoleColor.Red
        public const ConsoleColor BlockColor = ConsoleColor.Red;
        #endregion

        #endregion

        #region // ----------- НАСТРОЙКИ МАШИНЫ ----------- \\
        // Визуализация машины. Default: "┌─┐", "├─┤", "└─┘"
        public static string[] CarView = new string[] { "┌─┐", "├─┤", "└─┘" };

        // Ширина машины. По умолчанию: 3
        public const uint CarWidth = 3;

        // Высота машины. По умолчанию: 3
        public const uint CarHeight = 3;

        // Цвет машины. По умолчанию: ConsoleColor.Yellow
        public const ConsoleColor CarColor = ConsoleColor.Yellow;

        #endregion
    }
}
