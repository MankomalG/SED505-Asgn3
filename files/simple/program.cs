using System;

namespace Simple
{
    /// <summary>
    /// Client: wires everything together and simulates button presses.
    /// </summary>
    public static class Program
    {
        public static void Main()
        {
            // Receivers
            var light = new Light("Living Room");
            var tv    = new TV("Living Room");

            // Invoker
            var remote = new RemoteControl();

            // Build commands (simple four-command behavior via two classes)
            var lightOn  = new LightCommand(light, turnOn: true);
            var lightOff = new LightCommand(light, turnOn: false);
            var tvOn     = new TVCommand(tv, turnOn: true);
            var tvOff    = new TVCommand(tv, turnOn: false);

            // Simulate button presses
            remote.Press(lightOn);   // Light ON
            remote.Press(tvOn);      // TV ON
            remote.Press(lightOff);  // Light OFF

            remote.Undo();           // Undo Light OFF -> Light ON
            remote.Redo();           // Redo Light OFF

            remote.Press(tvOff);     // TV OFF

            Console.WriteLine("Done.");
        }
    }
}
