using Core.TDDMicroExercises.TirePressureMonitoringSystem;
using Moq;
using NUnit.Framework;

namespace Core.TDDMicroExercises.Test
{
    [TestFixture]
    public class AlarmTests
    {
        [Test]
        public void Check_AlarmNotTriggeredWithinThreshold_AlarmShouldNotBeOn()
        {
            // Arrange
             var mockSensor = new Mock<ISensor>();
            mockSensor.Setup(sensor => sensor.PopNextPressurePsiValue()).Returns(18);

            var alarm = new Alarm(mockSensor.Object);

            // Act
            alarm.Check();

            // Assert
            Assert.IsFalse(alarm.AlarmOn);
        }

        [Test]
        public void Check_AlarmTriggeredBelowThreshold_AlarmShouldBeOn()
        {
            // Arrange
            var mockSensor = new Mock<ISensor>();
            mockSensor.Setup(sensor => sensor.PopNextPressurePsiValue()).Returns(15);

            var alarm = new Alarm(mockSensor.Object);
            // Act
            alarm.Check();

            // Assert
            Assert.IsTrue(alarm.AlarmOn);
        }

        [Test]
        public void Check_AlarmTriggeredAboveThreshold_AlarmShouldBeOn()
        {
            // Arrange
            var mockSensor = new Mock<ISensor>();
            mockSensor.Setup(sensor => sensor.PopNextPressurePsiValue()).Returns(22);

            var alarm = new Alarm(mockSensor.Object);

            // Act
            alarm.Check();

            // Assert
            Assert.IsTrue(alarm.AlarmOn);
        }
    }
}