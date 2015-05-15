namespace JustChess.Movements
{
    using System;

    using Board.Contracts;
    using Common;
    using Contracts;
    using Figures.Contracts;

    public class NormalKingMovement : IMovement
    {
        private const string KingInvalidMove = "{0}s can move on positions next to him!";

        public void ValidateMove(IFigure figure, IBoard board, Move move)
        {
            var rowDistance = Math.Abs(move.From.Row - move.To.Row);
            var colDistance = Math.Abs(move.From.Col - move.To.Col);
            var to = move.To;
            var figureAtPosition = board.GetFigureAtPosition(to);

            if ((rowDistance == 1 && colDistance == 0) || (rowDistance == 0 && colDistance == 1) || (rowDistance == 1 && colDistance == 1))
            {
                if (figureAtPosition == null || figureAtPosition.Color != figure.Color)
                {
                    return;
                }
            }

            throw new InvalidOperationException(KingInvalidMove);
        }
    }
}