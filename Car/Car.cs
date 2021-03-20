using System;

namespace Car
{
    public class Car
    {
        private const double DailyLimit = 1000;

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
        public double DailyOdometer{ get; private set; }

        public double Odometer { get; private set; }

        public void Refuel(double fuelAmount)
        {
            if (fuelAmount < 0)
                throw new ArgumentOutOfRangeException(nameof(FuelAmount),"Fuel amount can not be lower than zero");

            var refueledAmount = FuelAmount + fuelAmount;
            if(refueledAmount > TankCapacity)
                throw new ArgumentOutOfRangeException(nameof(FuelAmount),"Fuel amount can not be greater than current tank capacity");

            FuelAmount = refueledAmount;
        }

        public void Drive(double distance)
        {
            var fuelNeeded = (distance / 100) * FuelUsage;
            if (fuelNeeded < FuelAmount)
            {
                FuelAmount -= fuelNeeded;
                UpdateOdometers(distance);
            }
            else
            {
                var traveledDistance = FuelAmount / FuelUsage * 100;
                UpdateOdometers(traveledDistance);
                FuelAmount = 0;
            }
        }

        public void Reset() => DailyOdometer = 0;

        private void UpdateOdometers(double distance)
        {
            UpdateDailyOdometer(distance);
            Odometer += distance;
        }

        private void UpdateDailyOdometer(double distance)
        {
            var dailyOdometerWithoutLimit = DailyOdometer + distance;
            if (dailyOdometerWithoutLimit >= DailyLimit)
            {
                Reset();
                UpdateDailyOdometer(distance - DailyLimit);
            }
            else
            {
                DailyOdometer += distance;
            }
        }
    }
}
