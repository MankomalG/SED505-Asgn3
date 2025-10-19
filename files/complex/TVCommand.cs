using System;

namespace Complex
{
    /// <summary>
    /// Concrete command for TV ON/OFF.
    /// </summary>
    public sealed class TVCommand : ICommand
    {
        private readonly TV _tv;
        private readonly bool _turnOn;

        public TVCommand(TV tv, bool turnOn)
        {
            _tv = tv;
            _turnOn = turnOn;
        }

        public void Execute()
        {
            if (_turnOn) _tv.On();
            else _tv.Off();
        }

        public void Undo()
        {
            if (_turnOn) _tv.Off();
            else _tv.On();
        }
    }
}
