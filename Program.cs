
using AvtomaticElevatorSim;

public class Program
{
    public static void Main()
    {
        PowerSensor powerSensor = new PowerSensor("Power ");
        powerSensor.ReadValue();

        if (powerSensor.HasPower)
        {
            Console.WriteLine ("Power is on. Elevator can operate.");
            Console.WriteLine();
            RunElevator();
        }
        else
        {   
            Console.WriteLine("Power is off. Elevator cannot operate.");
        }
        Console.WriteLine();

    }

    public static void RunElevator()
    {

        EmergencySensor fireSensor = new EmergencySensor("Fire");
        EmergencySensor motorOverheatSensor = new EmergencySensor("Motor Overheat");
        EmergencySensor emergencyStopSensor = new EmergencySensor("Emergency Stop");
        TemperatureSensor outsideTemperatureSensor = new TemperatureSensor("Outside temperature");
        HumiditySensor outsideHumiditySensor = new HumiditySensor("Outside humidity ");
        TemperatureSensor innerTemperatureSensor = new TemperatureSensor("Inner temperature ");
        HumiditySensor innerHumiditySensor = new HumiditySensor("Inner humidity ");
        LevelSensor levelSensor = new LevelSensor("Silos fill level ");
        MuveSensor insideMuveSensor = new MuveSensor("Speed noriy1 ");
        MuveSensor outsideMuveSensor = new MuveSensor("Speed noriy2 ");

        Elevator elevator = new Elevator();

        elevator.Sensors.Add(outsideTemperatureSensor);
        elevator.Sensors.Add(outsideHumiditySensor);
        elevator.Sensors.Add(innerTemperatureSensor);
        elevator.Sensors.Add(innerHumiditySensor);
        elevator.Sensors.Add(levelSensor);
        elevator.Sensors.Add(insideMuveSensor);
        elevator.Sensors.Add(outsideMuveSensor);
        elevator.Sensors.Add(fireSensor);
        elevator.Sensors.Add(motorOverheatSensor);
        elevator.Sensors.Add(emergencyStopSensor);

        for (int i = 0; i < 10; i++)
        {
            Console.WriteLine($"Iteration  {i + 1}:");
            elevator.Monitor();

            if (fireSensor.Value == 1 || motorOverheatSensor.Value == 1 || emergencyStopSensor.Value == 1)
            {
                Console.WriteLine();
                Console.WriteLine("!!! EMERGENCY DETECTED !!!");
                Console.WriteLine();
            
                elevator.Transport.TurnOff();
                elevator.Ventilation.TurnOff();

                break; // зупинити роботу елеватора
            }

            if (innerTemperatureSensor.Value > 25)
            {
                elevator.Ventilation.TurnOn();
            }
            else
            {
                elevator.Ventilation.TurnOff();
            }
            Console.WriteLine();

            if (insideMuveSensor.Value > 0 || outsideMuveSensor.Value > 0)
            {
                elevator.Transport.TurnOn();
            }
            else
            {
                elevator.Transport.TurnOff();
            }
            Console.WriteLine();
        }
    }

    

    
}


