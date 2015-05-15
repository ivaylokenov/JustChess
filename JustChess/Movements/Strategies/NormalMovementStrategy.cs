namespace JustChess.Movements.Strategies
{
    using System.Collections.Generic;

    using Contracts;

    public class NormalMovementStrategy : IMovementStrategy
    {
        private readonly IDictionary<string, IList<IMovement>> movements = new Dictionary<string, IList<IMovement>>
        {
            { "Pawn", new List<IMovement>
                 {
                     new NormalPawnMovement()
                 } 
            },
            { "Bishop", new List<IMovement>
                 {
                     new NormalBishopMovement()
                 } 
            },
            { "Knight", new List<IMovement>
                 {
                     new NormalKnightMovement()
                 }
            },
            { "King", new List<IMovement>
                 {
                     new NormalKingMovement()
                 }
            },
            { "Rook", new List<IMovement>
                 {
                     new NormalRookMovement()
                 }
            },
            { "Queen", new List<IMovement>
                 {
                     new NormalBishopMovement(),
                     new NormalRookMovement()
                 } 
            },
        };

        public IList<IMovement> GetMovements(string figure)
        {
            return this.movements[figure];
        }
    }
}
