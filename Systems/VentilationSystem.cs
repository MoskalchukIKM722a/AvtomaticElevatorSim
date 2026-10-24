

namespace AvtomaticElevatorSim.Systems
{
    public class VentilationSystem
    {
        public bool IsOn { get; set; }

        public void TurnOn()
        {
            IsOn = true;
            Console.WriteLine("Ventilation system is turned on.");
        }

        public void TurnOff()
        {
            IsOn = false;
            Console.WriteLine("Ventilation system is turned off.");
        }
        
    }
}
