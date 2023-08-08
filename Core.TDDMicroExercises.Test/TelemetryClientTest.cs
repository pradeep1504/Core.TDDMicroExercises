using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.TDDMicroExercises.Test
{
    using Core.TDDMicroExercises.TelemetrySystem;
    using Moq;
    using NUnit.Framework;

    [TestFixture]
    public class TelemetryClientTests
    {
        [Test]
        public void Connect_EmptyConnectionString_ThrowsArgumentNullException()
        {
            // Arrange
            var mockConnectionSimulator = new Mock<IConnectionSimulator>();
            var mockMessageSimulator = new Mock<IMessageSimulator>();

            var telemetryClient = new TelemetryClient(mockConnectionSimulator.Object, mockMessageSimulator.Object);

            // Act and Assert
            Assert.Throws<ArgumentNullException>(() => telemetryClient.Connect(null));
            Assert.Throws<ArgumentNullException>(() => telemetryClient.Connect(""));
        }

        [Test]
        public void OnlineStatus_ConnectionSimulatorReturnsTrue_ReturnsTrue()
        {
            // Arrange
            var mockConnectionSimulator = new Mock<IConnectionSimulator>();
            mockConnectionSimulator.Setup(simulator => simulator.SimulateConnection()).Returns(true);
            var mockMessageSimulator = new Mock<IMessageSimulator>();

            var telemetryClient = new TelemetryClient(mockConnectionSimulator.Object, mockMessageSimulator.Object);

            // Act
            bool onlineStatus = telemetryClient.OnlineStatus;

            // Assert
            Assert.IsTrue(onlineStatus);
        }

        [Test]
        public void Send_NullMessage_ThrowsArgumentNullException()
        {
            // Arrange
            var mockConnectionSimulator = new Mock<IConnectionSimulator>();
            var mockMessageSimulator = new Mock<IMessageSimulator>();

            var telemetryClient = new TelemetryClient(mockConnectionSimulator.Object, mockMessageSimulator.Object);

            // Act and Assert
            Assert.Throws<ArgumentNullException>(() => telemetryClient.Send(null));
        }

        [Test]
        public void Receive_DiagnosticMessageJustSent_ReturnsSimulatedDiagnosticMessage()
        {
            // Arrange
            var mockConnectionSimulator = new Mock<IConnectionSimulator>();
            var mockMessageSimulator = new Mock<IMessageSimulator>();

            var telemetryClient = new TelemetryClient(mockConnectionSimulator.Object, mockMessageSimulator.Object);
            telemetryClient.Send(TelemetryClient.DiagnosticMessage);

            // Act
            string receivedMessage = telemetryClient.Receive();

            // Assert
            Assert.AreEqual("Simulated Diagnostic Message", receivedMessage);
        }

        [Test]
        public void Receive_NormalMessage_ReturnsSimulatedMessage()
        {
            // Arrange
            var mockConnectionSimulator = new Mock<IConnectionSimulator>();
            var mockMessageSimulator = new Mock<IMessageSimulator>();
            mockMessageSimulator.Setup(simulator => simulator.SimulateMessage()).Returns("Simulated Message");

            var telemetryClient = new TelemetryClient(mockConnectionSimulator.Object, mockMessageSimulator.Object);

            // Act
            string receivedMessage = telemetryClient.Receive();

            // Assert
            Assert.AreEqual("Simulated Message", receivedMessage);
        }
    }

}
