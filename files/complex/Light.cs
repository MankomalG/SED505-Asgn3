using System;

namespace Complex
{
    /// <summary>
    /// Receiver: controls a Light.
    /// </summary>
    public class Light
    {
        public string Location { get; }
        public bool IsOn { get; private set; }

        public Light(string location)
        {
            Location = location;
        }

        public void On()
        {
            IsOn = true;
            Console.WriteLine($"{Location} light turned ON.");
        }

        public void Off()
        {
            IsOn = false;
            Console.WriteLine($"{Location} light turned OFF.");
        }
    }
}
