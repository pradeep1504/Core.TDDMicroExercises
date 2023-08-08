using System;

namespace Core.TDDMicroExercises.TelemetrySystem
{

    public class TelemetryClient : ITelemetryClient
    {
        public const string DiagnosticMessage = "AT#UD";
        private bool _diagnosticMessageJustSent = false;
        private readonly IConnectionSimulator _connectionSimulator;
        private readonly IMessageSimulator _messageSimulator;

        public TelemetryClient(IConnectionSimulator connectionSimulator, IMessageSimulator messageSimulator)
        {
            _connectionSimulator = connectionSimulator;
            _messageSimulator = messageSimulator;
        }

        public bool OnlineStatus => _connectionSimulator.SimulateConnection();

        public void Connect(string telemetryServerConnectionString)
        {
            if (string.IsNullOrEmpty(telemetryServerConnectionString))
            {
                throw new ArgumentNullException();
            }
        }

        public void Disconnect()
        {
            if (_connectionSimulator != null)
            {
                //_connectionSimulator= null;
            }
        }

        public void Send(string message)
        {
            if (string.IsNullOrEmpty(message))
            {
                throw new ArgumentNullException();
            }
            _diagnosticMessageJustSent = message == DiagnosticMessage;
        }

        public string Receive()
        {
            if (_diagnosticMessageJustSent)
            {
                return "Simulated Diagnostic Message"; // Simulate diagnostic response
            }
            return _messageSimulator.SimulateMessage();
        }
    }
}
