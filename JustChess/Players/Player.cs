namespace JustChess.Players
{
    using System;
    using System.Collections.Generic;

    using Common;
    using Contracts;
    using Figures.Contracts;

    public class Player : IPlayer
    {
        private readonly ICollection<IFigure> figures;

        public Player(string name, ChessColor color)
        {
            // TODO: validate name length
            this.Name = name;
            this.figures = new List<IFigure>();
            this.Color = color;
        }

        public string Name { get; private set; }

        public ChessColor Color { get; private set; }

        public void AddFigure(IFigure figure)
        {
            ObjectValidator.CheckIfObjectIsNull(figure, GlobalErrorMessages.NullFigureErrorMessage);

            // TODO: check figure and player color
            this.CheckIfFigureExists(figure);
            this.figures.Add(figure);
        }

        public void RemoveFigure(IFigure figure)
        {
            ObjectValidator.CheckIfObjectIsNull(figure, GlobalErrorMessages.NullFigureErrorMessage);

            // TODO: check figure and player color
            this.CheckIfFigureDoesNotExist(figure);
            this.figures.Remove(figure);
        }

        private void CheckIfFigureExists(IFigure figure)
        {
            if (this.figures.Contains(figure))
            {
                throw new InvalidOperationException("This player already owns this figure!");
            }
        }

        private void CheckIfFigureDoesNotExist(IFigure figure)
        {
            if (!this.figures.Contains(figure))
            {
                throw new InvalidOperationException("This player does not own this figure!");
            }
        }
    }
}
