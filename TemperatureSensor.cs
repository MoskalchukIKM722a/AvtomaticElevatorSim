

namespace AvtomaticElevatorSim
{
    public class TemperatureSensor : Sensor
    {
        public TemperatureSensor(string name) : base(name)
        {

        }

        public override void ReadValue()
        {
            Value = new Random().NextDouble() * 80;
            Console.WriteLine($" {Name} measured temperature : {Value}.");
        }
    }
}
