namespace JustChess.Movements.Strategies
{
    using JustChess.Movements.Contracts;
    using System.Collections.Generic;

    public class NormalMovementStrategy : IMovementStrategy
    {
        private IDictionary<string, IList<IMovement>> movements = new Dictionary<string, IList<IMovement>>
        {
            {"Pawn", new List<IMovement>
                {
                    new NormalPawnMovement()
                }},
            {"Bishop", new List<IMovement>
                {
                    new NormalBishopMovement()
                }},
            {"Knight", new List<IMovement>
                {
                    new NormalKnightMovement()
                }},
            {"King", new List<IMovement>
                {
                    new NormalKingMovement()
                }},
            {"Rook", new List<IMovement>
                {
                    new NormalRookMovement()
                }},

        };

        public IList<IMovement> GetMovements(string figure)
        {
            return this.movements[figure];
        }
    }
}
