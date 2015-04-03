namespace JustChess.Figures
{
    using System.Collections.Generic;

    using JustChess.Common;
    using JustChess.Figures.Contracts;
    using JustChess.Movements.Contracts;
    using JustChess.Movements;

    public class Pawn : BaseFigure, IFigure
    {
        public Pawn(ChessColor color)
            : base(color)
        {
        }

        public override ICollection<IMovement> Move(IMovementStrategy strategy)
        {
            return strategy.GetMovements(this.GetType().Name);
        }
    }
}
