namespace JustChess.Figures.Contracts
{
    using JustChess.Common;
    using JustChess.Movements.Contracts;
    using System.Collections.Generic;

    public interface IFigure
    {
        ChessColor Color { get; }

        ICollection<IMovement> Move(IMovementStrategy movementStrategy);
    }
}
