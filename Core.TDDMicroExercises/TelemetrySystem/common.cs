using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.TDDMicroExercises.TelemetrySystem
{
    public interface IConnectionSimulator
    {
        bool SimulateConnection();
    }

    public interface IMessageSimulator
    {
        string SimulateMessage();
    }
    public class ConnectionSimulator : IConnectionSimulator
    {
        private readonly Random _connectionEventsSimulator = new Random();

        public bool SimulateConnection()
        {
            // Fake the connection with 20% chances of success
            return _connectionEventsSimulator.Next(1, 10) <= 2;
        }
    }
    public class MessageSimulator : IMessageSimulator
    {
        private readonly Random _randomMessageSimulator = new Random();

        public string SimulateMessage()
        {
            string message = string.Empty;
            int messageLength = _randomMessageSimulator.Next(50, 110);
            for (int i = messageLength; i > 0; --i)
            {
                message += (char)_randomMessageSimulator.Next(40, 126);
            }
            return message;
        }
    }


}
