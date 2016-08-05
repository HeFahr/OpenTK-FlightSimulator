using System;
using OpenTK;

namespace FlightSimulator
{
    class Program
    {
        static void Main(string[] args)
        {
            var window = new GameWindow(640, 480);
            var simulator = new FlightSimulator(window);
            window.Run();
        }
    }
}
