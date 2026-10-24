

namespace AvtomaticElevatorSim.Systems
{
    public class PowerSystems
    {
        public bool IsOn { get; set; }

        public void TurnOn()
        {
            IsOn = true;
            Console.WriteLine("Power is turned on.");
        }

        public void TurnOff()
        {
            IsOn = false;
            Console.WriteLine("Power is turned off.");
        }

    }
}
