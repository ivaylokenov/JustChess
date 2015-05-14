namespace JustChess.Figures.Contracts
{
    using Common;
    using Movements.Contracts;
    using System.Collections.Generic;

    public interface IFigure
    {
        ChessColor Color { get; }

        ICollection<IMovement> Move(IMovementStrategy movementStrategy);
    }
}
