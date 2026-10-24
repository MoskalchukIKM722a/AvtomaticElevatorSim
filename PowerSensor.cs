

namespace AvtomaticElevatorSim
{
    public class PowerSensor : Sensor
    {

        public bool HasPower { get; protected set; }

        public PowerSensor(string name) : base(name)
        {

        }
        public override void ReadValue()
        {
            HasPower = new Random().Next(0, 2) == 1;
            //Value = new Random().NextDouble() * 1;
            Console.WriteLine($"Power Sensor '{Name}' reads: {(HasPower ? "ON" : "OFF")}");
        }
    }
}
