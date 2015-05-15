namespace JustChess.Common
{
    public struct Move
    {
        public Move(Position from, Position to)
            : this()
        {
            this.From = from;
            this.To = to;
        }

        public Position From { get; private set; }

        public Position To { get; private set; }
    }
}
