namespace JustChess.Board
{
    using System;

    using JustChess.Board.Contracts;
    using JustChess.Common;
    using JustChess.Figures.Contracts;

    public class Board : IBoard
    {
        private readonly IFigure[,] board;

        public Board(
            int rows = GlobalConstants.StandardGameTotalBoardRows,
            int cols = GlobalConstants.StandardGameTotalBoardCols)
        {
            this.TotalRows = rows;
            this.TotalCols = cols;
            this.board = new IFigure[rows, cols];
        }

        public int TotalRows { get; private set; }

        public int TotalCols { get; private set; }

        public void AddFigure(IFigure figure, Position position)
        {
            ObjectValidator.CheckIfObjectIsNull(figure, GlobalErrorMessages.NullFigureErrorMessage);
            Position.CheckIfValid(position);

            int arrRow = this.GetArrayRow(position.Row);
            int arrCol = this.GetArrayCol(position.Col);
            this.board[arrRow, arrCol] = figure;
        }

        public void RemoveFigure(Position position)
        {
            Position.CheckIfValid(position);
            
            int arrRow = this.GetArrayRow(position.Row);
            int arrCol = this.GetArrayCol(position.Col);
            this.board[arrRow, arrCol] = null;
        }

        public IFigure GetFigureAtPosition(Position position)
        {
            int arrRow = this.GetArrayRow(position.Row);
            int arrCol = this.GetArrayCol(position.Col);
            return this.board[arrRow, arrCol];
        }

        public void MoveFigureAtPosition(IFigure figure, Position from, Position to)
        {
            int arrFromRow = this.GetArrayRow(from.Row);
            int arrFromCol = this.GetArrayCol(from.Col);
            this.board[arrFromRow, arrFromCol] = null;

            int arrToRow = this.GetArrayRow(to.Row);
            int arrToCol = this.GetArrayCol(to.Col);
            this.board[arrToRow, arrToCol] = figure;
        }

        private int GetArrayRow(int chessRow)
        {
            return this.TotalRows - chessRow;
        }

        private int GetArrayCol(char chessCol)
        {
            return chessCol - 'a';
        }
    }
}
