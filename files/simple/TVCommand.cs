using System;

namespace Simple
{
    /// <summary>
    /// Concrete command for TV. One class handles both
    /// ON and OFF using the 'turnOn' flag.
    /// </summary>
    public sealed class TVCommand : ICommand
    {
        private readonly TV _tv;       // Receiver
        private readonly bool _turnOn; // true = On, false = Off

        public TVCommand(TV tv, bool turnOn)
        {
            _tv = tv ?? throw new ArgumentNullException(nameof(tv));
            _turnOn = turnOn;
        }

        public string Name => _turnOn
            ? $"TVOn({_tv.Location})"
            : $"TVOff({_tv.Location})";

        /// <summary>Run the configured action on the TV.</summary>
        public void Execute()
        {
            if (_turnOn) _tv.On();
            else _tv.Off();
        }

        /// <summary>Reverse the action.</summary>
        public void Undo()
        {
            if (_turnOn) _tv.Off();
            else _tv.On();
        }
    }
}
