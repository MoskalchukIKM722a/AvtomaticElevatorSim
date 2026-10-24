

namespace AvtomaticElevatorSim
{
    public class EmergencySensor : Sensor
    {
        public EmergencySensor(string name) : base(name)
        { 

        }
        public override void ReadValue()
        {
            Value = new Random().Next(0, 2); // 0 - норма, 1 - аварія
            Console.WriteLine($"Emergency sensor '{Name}' status: {(Value == 1 ? "ALARM" : "OK")}");
        }
    }

   
}
