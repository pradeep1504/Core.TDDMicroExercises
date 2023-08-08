namespace Core.TDDMicroExercises.TurnTicketDispenser
{
    public class TicketDispenser
    {
        private readonly ITurnNumberSequence _turnNumberSequence;

        public TicketDispenser(ITurnNumberSequence turnNumberSequence)
        {
            _turnNumberSequence = turnNumberSequence;
        }

        public TurnTicket GetTurnTicket()
        {
            int newTurnNumber = _turnNumberSequence.GetNextTurnNumber();
            return new TurnTicket(newTurnNumber);
        }
    }
}
