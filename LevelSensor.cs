using System;
using System.Collections.Generic;
using System.Text;

namespace AvtomaticElevatorSim
{
    public class LevelSensor : Sensor
    {
        public LevelSensor(string name) : base(name)
        {

        }
        public override void ReadValue()
        {
            Value = new Random().NextDouble() * 100;
            Console.WriteLine($" {Name} measured level : {Value}.");
        }
    }
    
}
