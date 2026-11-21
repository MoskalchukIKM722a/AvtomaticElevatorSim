using AvtomaticElevatorSim.Mqtt;
using Models;
using MQTTnet;
using System.Text.Json;

public class Program
{
    public static async Task Main()
    {
        SensorConfiguration[] sensors = CreateSensors();
        var factory = new MqttClientFactory();
        using var mqttClient = factory.CreateMqttClient();
        var options = new MqttClientOptionsBuilder()
            .WithTcpServer("127.0.0.1", 1883)
            .Build();


        await mqttClient.ConnectAsync(options);
        Console.WriteLine("Connected to MQTT broker.");


        await RunSimulationAsync(mqttClient, sensors);

        await mqttClient.DisconnectAsync();
    }      

    private static SensorConfiguration[] CreateSensors()
    {
        return
            [
                new (
                    new EmergencySensor("Fire"),
                    "elevator/1/sensors/emergency/fire",
                    " "),
                new (
                    new EmergencySensor("Motor Overheat"),
                    "elevator/1/sensors/emergency/motor_overheat",
                    " "),
                new (
                    new EmergencySensor("Emergency Stop"),
                    "elevator/1/sensors/emergency/stop",
                    " "),
                new (
                    new TemperatureSensor("Outside temperature"),
                    "elevator/1/sensors/outside/temperature",
                    "C"),
                new (
                    new HumiditySensor("Outside humidity"),
                    "elevator/1/sensors/outside/humidity",
                    "%"),
                new (
                    new TemperatureSensor("Inner temperature"),
                    "elevator/1/sensors/inside/temperature",
                    "C"),
                new (
                    new HumiditySensor("Inner humidity"),
                    "elevator/1/sensors/inside/humidity",
                    "%"),
                new (
                    new LevelSensor("Silos fill level"),
                    "elevator/1/sensors/silos/level",
                    "%"),
                new (
                    new MuveSensor("Speed noriy1"),
                    "elevator/1/sensors/noriy1/speed",
                    "m/s"),
                new (
                    new MuveSensor("Speed noriy2"),
                    "elevator/1/sensors/noriy2/speed",
                    "m/s"),
            ];
    }

    private static async Task RunSimulationAsync(
        IMqttClient mqttClient,
        SensorConfiguration[] sensors)
    {
        for (int iteration = 1; iteration <= 10; iteration++)
        {
            Console.WriteLine($"Iteration {iteration}.");


            foreach (var sensor in sensors)
            {
                await PublichSensorReadingAsync(mqttClient, sensor);
            }

            Console.WriteLine();
            await Task.Delay(TimeSpan.FromSeconds(2));
        }
    }

    private static async Task PublichSensorReadingAsync(
        IMqttClient mqttClient,
        SensorConfiguration configuration)
    {
        configuration.Sensor.ReadValue();

        string payload = JsonSerializer.Serialize(new
        {
            value = Math.Round(configuration.Sensor.Value, 2),
            unit = configuration.Unit,
            measuredAtUtc = DateTimeOffset.UtcNow
        });

        var message = new MqttApplicationMessageBuilder()
            .WithTopic(configuration.Topic)
            .WithPayload(payload)
            .Build();

        await mqttClient.PublishAsync(message);

        Console.WriteLine($"Published {configuration.Topic} -> {payload} ");
    }
}