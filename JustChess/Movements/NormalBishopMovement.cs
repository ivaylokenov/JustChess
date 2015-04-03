namespace JustChess.Movements
{
    using System;

    using JustChess.Board.Contracts;
    using JustChess.Common;
    using JustChess.Figures.Contracts;
    using JustChess.Movements.Contracts;

    public class NormalBishopMovement : IMovement
    {
        private const string BishopInvalidMove = "Bishops cannot move this way!";

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
            // top-right
            while(true)
            {
                rowIndex++;
                colIndex++;
                if (to.Row == rowIndex && to.Col == colIndex)
                {
                    var figureAtPositon = board.GetFigureAtPosition(to);
                    if (figureAtPositon != null && figureAtPositon.Color == figure.Color)
                    {
                        throw new NotImplementedException("There is a figure on your way!");
                    }
                    else
                    {
                        return;
                    }
                }

                var position = Position.FromChessCoordinates(rowIndex, colIndex);
                var figureAtPosition = board.GetFigureAtPosition(position);
                if (figure != null)
                {
                    throw new NotImplementedException("There is a figure on your way!");
                }
            }
        }
    }
}
