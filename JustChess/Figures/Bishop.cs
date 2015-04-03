namespace JustChess.Figures
{
    using System.Collections.Generic;

    using JustChess.Common;
    using JustChess.Figures.Contracts;
    using JustChess.Movements.Contracts;

    public class Bishop : BaseFigure, IFigure
    {
        public Bishop(ChessColor color)
            : base(color)
        {
        }

        public override ICollection<IMovement> Move(IMovementStrategy strategy)
        {
            return strategy.GetMovements(this.GetType().Name);
        }
    }
}
