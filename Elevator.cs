
using AvtomaticElevatorSim.Systems;

namespace AvtomaticElevatorSim;

public class Elevator
{
    public List<Sensor> Sensors { get; set; }

    public VentilationSystem  Ventilation { get; set; }

    public MuveSystem Transport { get; set; }

    public PowerSystems Power { get; set; }
    public Elevator ( )
    {
        Sensors = new List<Sensor>();
        Ventilation = new VentilationSystem();
        Transport = new MuveSystem();
        Power = new PowerSystems();
    }

    public void Monitor()
    {
        foreach (Sensor sensor in Sensors)
        {
            sensor.ReadValue();
        }
    }




}
