namespace Core.TDDMicroExercises.TurnTicketDispenser
{
    public interface ITurnNumberSequence
    {
        int GetNextTurnNumber();
    }

    public class TurnNumberSequence : ITurnNumberSequence
    {
        private int _turnNumber = 0;

        public int GetNextTurnNumber()
        {
            return _turnNumber++;
        }
    }
}
