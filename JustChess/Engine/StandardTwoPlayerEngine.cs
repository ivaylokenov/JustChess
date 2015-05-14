namespace JustChess.Engine
{
    using System.Collections.Generic;
    using System.Linq;

    using JustChess.Board;
    using JustChess.Engine.Contracts;
    using JustChess.Players.Contracts;
    using JustChess.Renderers.Contracts;
    using JustChess.InputProviders.Contracts;
    using JustChess.Common;
    using JustChess.Board.Contracts;
    using JustChess.Players;
    using System;
    using JustChess.Figures.Contracts;
    using JustChess.Movements.Contracts;
    using JustChess.Movements.Strategies;

    public class StandardTwoPlayerEngine : IChessEngine
    {
        private IList<IPlayer> players;
        private readonly IRenderer renderer;
        private readonly IInputProvider input;
        private readonly IBoard board;
        private readonly IMovementStrategy movementStrategy;

        private int currentPlayerIndex;

        public StandardTwoPlayerEngine(IRenderer renderer, IInputProvider inputProvider)
        {
            this.renderer = renderer;
            this.input = inputProvider;
            this.movementStrategy = new NormalMovementStrategy();
            this.board = new Board();
        }

        public void Initialize(IGameInitializationStrategy gameInitializationStrategy)
        {
            // TODO: remove using JustChess.Players and use the input for players
            // TODO: BUG: if players are changed - board is reversed
            this.players = new List<IPlayer> 
            {
                new Player("Gosho", ChessColor.Black),
                new Player("Pesho", ChessColor.White)
            }; // this.input.GetPlayers(GlobalConstants.StandardGameNumberOfPlayers);

            this.SetFirstPlayerIndex();
            gameInitializationStrategy.Initialize(this.players, this.board);
            this.renderer.RenderBoard(board);
        }

        public void Start()
        {
            while(true)
            {
                try
                {
                    var player = this.GetNextPlayer();
                    var move = this.input.GetNextPlayerMove(player);
                    var from = move.From;
                    var to = move.To;
                    var figure = this.board.GetFigureAtPosition(from);
                    this.CheckIfPlayerOwnsFigure(player, figure, from);
                    this.CheckIfToPositionIsEmpty(figure, to);

                    var availableMovements = figure.Move(this.movementStrategy);
                    this.ValidateMovements(figure, availableMovements, move);

                    board.MoveFigureAtPosition(figure, from, to);
                    this.renderer.RenderBoard(board);

                    // TODO: On every move check if we are in check
                    // TODO: Check pawn on last row
                    // TODO: If not castle - move figure (check castle - check if castle is valid, check pawn for An-pasan)
                    // TODO: Check check
                    // TODO: If in check - check checkmate
                    // TODO: If not in check - check draw
                    // TODO: Continue
                }
                catch (Exception ex)
                {
                    this.currentPlayerIndex--;
                    this.renderer.PrintErrorMessage(ex.Message);
                }
            }
        }

        private void ValidateMovements(IFigure figure, IEnumerable<IMovement> availableMovements, Move move)
        {
            var validMoveFound = false;
            var foundException = new Exception();
            foreach (var movement in availableMovements)
            {
                try
                {
                    movement.ValidateMove(figure, board, move);
                    validMoveFound = true;
                    break;
                }
                catch (Exception ex)
                {
                    foundException = ex;
                }
            }

            if (!validMoveFound)
            {
                throw foundException;
            }
        }

        public void WinningConditions()
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<IPlayer> Players
        {
            get
            {
                return new List<IPlayer>(this.players);
            }
        }

        private void SetFirstPlayerIndex()
        {
            for (int i = 0; i < this.players.Count; i++)
            {
                if (this.players[i].Color == ChessColor.White)
                {
                    this.currentPlayerIndex = i - 1;
                    return;
                }
            }
        }

        private IPlayer GetNextPlayer()
        {
            this.currentPlayerIndex++;
            if (this.currentPlayerIndex >= this.players.Count)
            {
                this.currentPlayerIndex = 0;
            }

            return this.players[this.currentPlayerIndex];
        }

        private void CheckIfPlayerOwnsFigure(IPlayer player, IFigure figure, Position from)
        {
            if (figure == null)
            {
                throw new InvalidOperationException(string.Format("Position {0}{1} is empty!", from.Col, from.Row));
            }

            if (figure.Color != player.Color)
            {
                throw new InvalidOperationException(string.Format("Figure at {0}{1} is not yours!", from.Col, from.Row));
            }
        }

        private void CheckIfToPositionIsEmpty(IFigure figure, Position to)
        {
            var figureAtPosition = this.board.GetFigureAtPosition(to);
            if (figureAtPosition != null && figureAtPosition.Color == figure.Color)
            {
                throw new InvalidOperationException(string.Format("You already have a figure at {0}{1}!", to.Col, to.Row));
            }
        }
    }
}
