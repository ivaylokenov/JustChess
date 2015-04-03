namespace JustChess
{
    using System;

    using JustChess.Engine;
    using JustChess.Engine.Contracts;
    using JustChess.InputProviders;
    using JustChess.InputProviders.Contracts;
    using JustChess.Renderers;
    using JustChess.Renderers.Contracts;
    using JustChess.Engine.Initializations;

    public static class ChessFacade
    {
        public static void Start()
        {
            IRenderer renderer = new ConsoleRenderer();
            // renderer.RenderMainMenu();

            IInputProvider inputProvider = new ConsoleInputProvider();

            IChessEngine chessEngine = new StandardTwoPlayerEngine(renderer, inputProvider);

            IGameInitializationStrategy gameInitializationStrategy = new StandardStartGameInitializationStrategy();

            chessEngine.Initialize(gameInitializationStrategy);
            chessEngine.Start();

            Console.ReadLine();
        }
    }
}
