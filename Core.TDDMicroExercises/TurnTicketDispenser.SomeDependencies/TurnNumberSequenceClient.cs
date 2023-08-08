using System;
namespace Core.TDDMicroExercises.TurnTicketDispenser.SomeDependencies
{
    public class TurnNumberSequenceClient
    {
		// A class with the only goal of simulating a dependency on TurnNumberSequence
		// that has impact on the refactoring.

		public TurnNumberSequenceClient()
        {
            ITurnNumberSequence turnNumberSequence = new TurnNumberSequence();
            int nextUniqueTicketNumber;
            nextUniqueTicketNumber = turnNumberSequence.GetNextTurnNumber();
			nextUniqueTicketNumber = turnNumberSequence.GetNextTurnNumber();
			nextUniqueTicketNumber = turnNumberSequence.GetNextTurnNumber();
		}
    }
}
