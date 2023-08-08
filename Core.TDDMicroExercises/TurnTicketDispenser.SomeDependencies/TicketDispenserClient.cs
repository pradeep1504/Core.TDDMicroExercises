using System;
namespace Core.TDDMicroExercises.TurnTicketDispenser.SomeDependencies
{
    public class TicketDispenserClient
    {
		// A class with the only goal of simulating a dependency on TicketDispenser
		// that has impact on the refactoring.

		public TicketDispenserClient()
        {
            ITurnNumberSequence _turnNumberSequence = new TurnNumberSequence();
            TicketDispenser dispenser = new TicketDispenser(_turnNumberSequence);
            TurnTicket ticket = dispenser.GetTurnTicket();
            new TicketDispenser(_turnNumberSequence).GetTurnTicket();
			new TicketDispenser(_turnNumberSequence).GetTurnTicket();
			new TicketDispenser(_turnNumberSequence).GetTurnTicket();
		}
    }
}
