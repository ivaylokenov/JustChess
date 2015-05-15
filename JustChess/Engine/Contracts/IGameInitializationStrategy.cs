namespace JustChess.Engine.Contracts
{
    using System.Collections.Generic;

    using Board.Contracts;
    using Players.Contracts;

    public interface IGameInitializationStrategy
    {
        void Initialize(IList<IPlayer> players, IBoard board);
    }
}
