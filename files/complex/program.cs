using System;

namespace Complex
{
    /// <summary>
    /// Client: 4-button console. Each button toggles its target:
    /// TV, Light, Movie Night scene, and a NoCommand placeholder.
    /// </summary>
    public static class Program
    {
        public static void Main()
        {
            var light  = new Light("Living Room");
            var tv     = new TV("Living Room");
            var remote = new RemoteControl();

            // Pre-build the scene (TV ON, Lights OFF)
            var movieNight = new MacroCommand(new ICommand[]
            {
                new LightCommand(light, false), // Off
                new TVCommand(tv, true)         // On
            });

            // Track scene state so the "Movie Night" button toggles scene on/off
            bool movieNightActive = false;

            bool running = true;
            while (running)
            {
                Console.WriteLine("\n=== Remote Control — 4 Buttons ===");
                Console.WriteLine("1) TV (toggle)");
                Console.WriteLine("2) Light (toggle)");
                Console.WriteLine("3) Movie Night (toggle scene)");
                Console.WriteLine("4) NoCommand");
                Console.WriteLine("5) Exit");
                Console.Write("Choose (1-5): ");

                var input = Console.ReadLine();

                switch (input)
                {
                    // TV toggle
                    case "1":
                    {
                        // If TV is ON, build an OFF command; else build an ON command
                        var cmd = tv.IsOn
                            ? new TVCommand(tv, turnOn: false)
                            : new TVCommand(tv, turnOn: true);

                        // Use a slot to execute (slot 0 reserved for TV toggle)
                        remote.SetCommand(0, cmd);
                        remote.PressButton(0);
                        break;
                    }

                    // Light toggle
                    case "2":
                    {
                        var cmd = light.IsOn
                            ? new LightCommand(light, turnOn: false)
                            : new LightCommand(light, turnOn: true);

                        // Use a slot to execute (slot 1 reserved for Light toggle)
                        remote.SetCommand(1, cmd);
                        remote.PressButton(1);
                        break;
                    }

                    // Movie Night toggle (apply scene / undo scene)
                    case "3":
                    {
                        if (!movieNightActive)
                        {
                            // Apply the scene via a slot (slot 2 for scene)
                            remote.SetCommand(2, movieNight);
                            remote.PressButton(2);
                            movieNightActive = true;
                        }
                        else
                        {
                            // Toggle off the scene by undoing the macro directly
                            // (Independent of whatever other commands ran)
                            movieNight.Undo();
                            movieNightActive = false;
                        }
                        break;
                    }

                    // NoCommand (safe placeholder)
                    case "4":
                    {
                        remote.SetCommand(3, new NoOpCommand());
                        remote.PressButton(3);
                        break;
                    }

                    case "5":
                        running = false;
                        break;

                    default:
                        Console.WriteLine("Invalid choice.");
                        break;
                }
            }

            Console.WriteLine("\nExiting program...");
            
        }
    }
}
