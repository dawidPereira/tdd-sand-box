using System;

namespace Car
{
    public class Car
    {
        public Car(Color color, string name, double fuelUsage, int tankCapacity)
        {
            Color = color;
            Name = name;
            FuelUsage = fuelUsage;
            TankCapacity = tankCapacity;
        }

        public Color Color { get; }
        public string Name { get; }
        public double FuelUsage { get; }
        public int TankCapacity { get; }
        public double FuelAmount { get; private set; }

        public void Refuel(double fuelAmount)
        {
            if (fuelAmount < 0)
                throw new ArgumentOutOfRangeException(nameof(FuelAmount),"Fuel amount can not be lower than zero");

            var refueledAmount = FuelAmount + fuelAmount;
            if(refueledAmount > TankCapacity)
                throw new ArgumentOutOfRangeException(nameof(FuelAmount),"Fuel amount can not be greater than current tank capacity");
        }

        public void Drive(double distance)
        {

        }
    }
}
