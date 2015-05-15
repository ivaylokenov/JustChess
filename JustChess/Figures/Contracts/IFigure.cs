namespace JustChess.Figures.Contracts
{
    using System.Collections.Generic;

    using Common;
    using Movements.Contracts;

    public interface IFigure
    {
        ChessColor Color { get; }

        ICollection<IMovement> Move(IMovementStrategy movementStrategy);
    }
}
