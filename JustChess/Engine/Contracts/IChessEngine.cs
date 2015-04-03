namespace JustChess.Engine.Contracts
{
    using System.Collections.Generic;
    using JustChess.Players.Contracts;

    public interface IChessEngine
    {
        IEnumerable<IPlayer> Players { get; }

        void Initialize(IGameInitializationStrategy gameInitializationStrategy);

        void Start();

        void WinningConditions();
    }
}
