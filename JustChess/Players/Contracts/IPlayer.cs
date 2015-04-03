namespace JustChess.Players.Contracts
{
    using JustChess.Common;
    using JustChess.Figures.Contracts;

    public interface IPlayer
    {
        string Name { get; }

        ChessColor Color { get; }

        void AddFigure(IFigure figure);

        void RemoveFigure(IFigure figure);
    }
}
