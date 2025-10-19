using System;

namespace Simple
{
    /// <summary>
    /// Concrete command for Light. One class handles both
    /// ON and OFF using the 'turnOn' flag.
    /// </summary>
    public sealed class LightCommand : ICommand
    {
        private readonly Light _light;   // Receiver
        private readonly bool _turnOn;   // true = On, false = Off

        public LightCommand(Light light, bool turnOn)
        {
            _light = light ?? throw new ArgumentNullException(nameof(light));
            _turnOn = turnOn;
        }

        public string Name => _turnOn
            ? $"LightOn({_light.Location})"
            : $"LightOff({_light.Location})";

        /// <summary>Run the configured action on the light.</summary>
        public void Execute()
        {
            if (_turnOn) _light.On();
            else _light.Off();
        }

        /// <summary>Reverse the action.</summary>
        public void Undo()
        {
            if (_turnOn) _light.Off();
            else _light.On();
        }
    }
}
