namespace JustChess.Movements.Contracts
{
    using JustChess.Board.Contracts;
    using JustChess.Common;
    using JustChess.Figures.Contracts;

    public interface IMovement
    {
        void ValidateMove(IFigure figure, IBoard board, Move move);
    }
}
