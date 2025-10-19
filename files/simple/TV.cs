using System;

namespace Simple
{
    /// <summary>
    /// Receiver: a TV with simple On/Off behavior.
    /// </summary>
    public class TV
    {
        public string Location { get; }
        public bool IsOn { get; private set; }

        public TV(string location)
        {
            Location = location;
        }

        /// <summary>Power the TV on.</summary>
        public void On()
        {
            IsOn = true;
            Console.WriteLine($"{Location} TV: ON");
        }

        /// <summary>Power the TV off.</summary>
        public void Off()
        {
            IsOn = false;
            Console.WriteLine($"{Location} TV: OFF");
        }
    }
}
