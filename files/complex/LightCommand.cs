using System;

namespace Complex
{
    /// <summary>
    /// Concrete command for Light ON/OFF.
    /// </summary>
    public sealed class LightCommand : ICommand
    {
        private readonly Light _light;
        private readonly bool _turnOn;

        public LightCommand(Light light, bool turnOn)
        {
            _light = light;
            _turnOn = turnOn;
        }

        public void Execute()
        {
            if (_turnOn) _light.On();
            else _light.Off();
        }

        public void Undo()
        {
            if (_turnOn) _light.Off();
            else _light.On();
        }
    }
}
