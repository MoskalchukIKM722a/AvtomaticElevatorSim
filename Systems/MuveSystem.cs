

namespace AvtomaticElevatorSim.Systems
{
    public class MuveSystem
    {
        public bool IsOn { get; set; }

        public void TurnOn()
        {
            IsOn = true;
            Console.WriteLine("Transport system is turned on.");
        }

        public void TurnOff()
        {
            IsOn = false;
            Console.WriteLine("Transport system is turned off.");
        }


    }
}
