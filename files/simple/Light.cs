using System;

namespace Simple
{
    /// <summary>
    /// Receiver: a light with simple On/Off behavior.
    /// </summary>
    public class Light
    {
        public string Location { get; }
        public bool IsOn { get; private set; }

        public Light(string location)
        {
            Location = location;
        }

        /// <summary>Turn the light on.</summary>
        public void On()
        {
            IsOn = true;
            Console.WriteLine($"{Location} light: ON");
        }

        /// <summary>Turn the light off.</summary>
        public void Off()
        {
            IsOn = false;
            Console.WriteLine($"{Location} light: OFF");
        }
    }
}
