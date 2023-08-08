using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.TDDMicroExercises.TurnTicketDispenser;
using Moq;
using NUnit.Framework;

namespace Core.TDDMicroExercises.Test
{
    

    [TestFixture]
    public class TicketDispenserTests
    {
        [Test]
        public void GetTurnTicket_ReturnsTurnTicketWithUniqueNumber()
        {
            // Arrange
            var mockTurnNumberSequence = new Mock<ITurnNumberSequence>();
            mockTurnNumberSequence.SetupSequence(sequence => sequence.GetNextTurnNumber())
                                  .Returns(1)
                                  .Returns(2)
                                  .Returns(3);

            var dispenser = new TicketDispenser(mockTurnNumberSequence.Object);

            // Act
            TurnTicket ticket1 = dispenser.GetTurnTicket();
            TurnTicket ticket2 = dispenser.GetTurnTicket();
            TurnTicket ticket3 = dispenser.GetTurnTicket();

            // Assert
            Assert.AreEqual(1, ticket1.TurnNumber);
            Assert.AreEqual(2, ticket2.TurnNumber);
            Assert.AreEqual(3, ticket3.TurnNumber);
        }
       
        [Test]
        public void GetTurnTicket_ReturnsUniqueTicketNumbers()
        {
            // Arrange
            var mockTurnNumberSequence = new Mock<ITurnNumberSequence>();
            mockTurnNumberSequence.SetupSequence(sequence => sequence.GetNextTurnNumber())
                                  .Returns(1)
                                  .Returns(2)
                                  .Returns(3);

            var dispenser = new TicketDispenser(mockTurnNumberSequence.Object);

            // Act
            TurnTicket ticket1 = dispenser.GetTurnTicket();
            TurnTicket ticket2 = dispenser.GetTurnTicket();
            TurnTicket ticket3 = dispenser.GetTurnTicket();

            // Assert
            Assert.AreEqual(1, ticket1.TurnNumber);
            Assert.AreEqual(2, ticket2.TurnNumber);
            Assert.AreEqual(3, ticket3.TurnNumber);
        }

        [Test]
        public void GetTurnTicket_ReturnsConsecutiveTicketNumbers()
        {
            // Arrange
            var mockTurnNumberSequence = new Mock<ITurnNumberSequence>();
            mockTurnNumberSequence.SetupSequence(sequence => sequence.GetNextTurnNumber())
                                  .Returns(1)
                                  .Returns(2)
                                  .Returns(3);

            var dispenser = new TicketDispenser(mockTurnNumberSequence.Object);

            // Act
            TurnTicket ticket1 = dispenser.GetTurnTicket();
            TurnTicket ticket2 = dispenser.GetTurnTicket();
            TurnTicket ticket3 = dispenser.GetTurnTicket();

            // Assert
            Assert.AreEqual(1, ticket1.TurnNumber);
            Assert.AreEqual(2, ticket2.TurnNumber);
            Assert.AreEqual(3, ticket3.TurnNumber);
        }

        [Test]
        public void GetTurnTicket_DoesNotReturnDuplicateTicketNumbers()
        {
            // Arrange
            var mockTurnNumberSequence = new Mock<ITurnNumberSequence>();
            mockTurnNumberSequence.SetupSequence(sequence => sequence.GetNextTurnNumber())
                                  .Returns(1)
                                  .Returns(1) // Duplicate
                                  .Returns(2);

            var dispenser = new TicketDispenser(mockTurnNumberSequence.Object);

            // Act
            TurnTicket ticket1 = dispenser.GetTurnTicket();
            TurnTicket ticket2 = dispenser.GetTurnTicket();
            TurnTicket ticket3 = dispenser.GetTurnTicket();

            // Assert
            Assert.AreEqual(1, ticket1.TurnNumber);
            Assert.AreEqual(2, ticket2.TurnNumber);
            Assert.AreEqual(3, ticket3.TurnNumber);
        }
    }

}

