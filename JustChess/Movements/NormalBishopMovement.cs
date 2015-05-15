namespace JustChess.Movements
{
    using System;

    using Board.Contracts;
    using Common;
    using Contracts;
    using Figures.Contracts;

    public class NormalBishopMovement : IMovement
    {
        private const string BishopInvalidMove = "{0}s can move diagonally!";

        public void ValidateMove(IFigure figure, IBoard board, Move move)
        {
            var rowDistance = Math.Abs(move.From.Row - move.To.Row);
            var colDistance = Math.Abs(move.From.Col - move.To.Col);

            // TODO: extract to method
            var other = figure.Color == ChessColor.White ? ChessColor.Black : ChessColor.White;

            if (rowDistance != colDistance)
            {
                throw new InvalidOperationException(BishopInvalidMove);
            }

            var from = move.From;
            var to = move.To;

            int rowIndex = from.Row;
            char colIndex = from.Col;

            int rowDirection = from.Row < to.Row ? 1 : -1;
            char colDirection = (char)(from.Col < to.Col ? 1 : -1);

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
