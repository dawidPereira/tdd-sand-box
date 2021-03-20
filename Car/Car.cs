namespace Car
{
    public class Car
    {
        public Car(Color color, string name, double fuelUsage, int tankCapacity, double fuelAmount)
        {
            Color = color;
            Name = name;
            FuelUsage = fuelUsage;
            TankCapacity = tankCapacity;
            FuelAmount = fuelAmount;
        }

        public Color Color { get; }
        public string Name { get; }
        public double FuelUsage { get; }
        public int TankCapacity { get; }
        public double FuelAmount { get; }
    }
}
