using System;

namespace Complex
{
    /// <summary>
    /// Receiver: controls a TV device.
    /// </summary>
    public class TV
    {
        public string Location { get; }
        public bool IsOn { get; private set; }

        public TV(string location)
        {
            Location = location;
        }

        public void On()
        {
            IsOn = true;
            Console.WriteLine($"{Location} TV turned ON.");
        }

        public void Off()
        {
            IsOn = false;
            Console.WriteLine($"{Location} TV turned OFF.");
        }
    }
}
