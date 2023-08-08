﻿using System;
namespace Core.TDDMicroExercises.TurnTicketDispenser.SomeDependencies
{
    public class TurnTicketAndSequenceClient
    {
		// A class with the only goal of simulating a dependencies on 
		// TurnNumberSequence and TurnTicket that have impact on the refactoring.

		public TurnTicketAndSequenceClient()
        {
            ITurnNumberSequence turnNumberSequence = new TurnNumberSequence();
            var turnTicket1 = new TurnTicket(turnNumberSequence.GetNextTurnNumber());
			var turnTicket2 = new TurnTicket(turnNumberSequence.GetNextTurnNumber());
			var turnTicket3 = new TurnTicket(turnNumberSequence.GetNextTurnNumber());
        }
    }
}
