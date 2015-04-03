namespace JustChess.Board.Contracts
{
    using JustChess.Common;
    using JustChess.Figures.Contracts;

    public interface IBoard
    {
        int TotalRows { get; }

        int TotalCols { get; }

        void AddFigure(IFigure figure, Position position);

        void RemoveFigure(Position position);

        IFigure GetFigureAtPosition(Position position);

        void MoveFigureAtPosition(IFigure figure, Position from, Position to);
    }
}
