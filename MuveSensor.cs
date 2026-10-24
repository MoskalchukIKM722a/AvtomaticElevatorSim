using System;
using System.Collections.Generic;
using System.Text;

namespace AvtomaticElevatorSim
{
    public class MuveSensor : Sensor
    {
        public MuveSensor(string name) : base(name)
        {

        }
        public override void ReadValue()
        {
            Value = new Random().NextDouble() * 10;
            Console.WriteLine($" {Name} measured muve : {Value}.");
        }
    }
}
