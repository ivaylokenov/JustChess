namespace JustChess.Engine.Contracts
{
    using System.Collections.Generic;
    using JustChess.Players.Contracts;
    using JustChess.Board.Contracts;

    public interface IGameInitializationStrategy
    {
        void Initialize(IList<IPlayer> players, IBoard board);
    }
}
