namespace JustChess.Movements
{
    using System;

    using Board.Contracts;
    using Common;
    using Contracts;
    using Figures.Contracts;

    public class NormalRookMovement : IMovement
    {
        private const string RookInvalidMove = "{0}s can move horizontally or vertically!";

        public void ValidateMove(IFigure figure, IBoard board, Move move)
        {
            var rowDistance = Math.Abs(move.From.Row - move.To.Row);
            var colDistance = Math.Abs(move.From.Col - move.To.Col);
            var from = move.From;
            var to = move.To;

            if (rowDistance > 0 && colDistance > 0)
            {
                throw new InvalidOperationException(RookInvalidMove);
            }

            int rowIndex = from.Row;
            char colIndex = from.Col;
            int rowDirection = from.Row < to.Row ? 1 : -1;
            char colDirection = (char)(from.Col < to.Col ? 1 : -1);

            rowDirection = rowDistance > 0 ? rowDirection : 0;
            colDirection = (char)(colDistance > 0 ? colDirection : 0);

            while (true)
            {
                rowIndex += rowDirection;
                colIndex += colDirection;

                if (to.Row == rowIndex && to.Col == colIndex)
                {
                    var figureAtPositon = board.GetFigureAtPosition(to);

                    if (figureAtPositon != null && figureAtPositon.Color == figure.Color)
                    {
                        throw new InvalidOperationException(GlobalErrorMessages.FigureOnTheWayErrorMessage);
                    }
                    else
                    {
                        return;
                    }
                }

                var position = Position.FromChessCoordinates(rowIndex, colIndex);
                var figureAtPosition = board.GetFigureAtPosition(position);

                if (figureAtPosition != null)
                {
                    throw new InvalidOperationException(GlobalErrorMessages.FigureOnTheWayErrorMessage);
                }
            }
        }
    }
}