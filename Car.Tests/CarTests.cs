using System;
using FluentAssertions;
using FluentAssertions.Execution;
using Xunit;

namespace Car.Tests
{
    public class CarTests
    {
        [Fact]
        public void Create_WhenValidData_ShouldCreateCar()
        {
            var sut = new Car(Color.Red, "Ford Mondeo", 5.0, 60);
            using (new AssertionScope())
            {
                sut.Color.Should().Be(Color.Red);
                sut.Name.Should().Be("Ford Mondeo");
                sut.FuelUsage.Should().Be(5.0);
                sut.TankCapacity.Should().Be(60);
            }
        }

        [Fact]
        public void Refuel_WhenNegativeAmount_ShouldThrowException()
        {
            var sut = GetDefaultCar();

            Action action = () => sut.Refuel(-10);
            action.Should().Throw<ArgumentOutOfRangeException>().WithMessage("Fuel amount can not be lower than zero (Parameter 'FuelAmount')");
        }

        [Fact]
        public void Refuel_WhenRefueledAmountIsGreaterThanCapacity_ShouldThrowException()
        {
            var sut = GetDefaultCar();

            Action action = () => sut.Refuel(70);
            action.Should().Throw<ArgumentOutOfRangeException>().WithMessage("Fuel amount can not be greater than current tank capacity (Parameter 'FuelAmount')");
        }

        [Fact]
        public void Refuel_WhenValidData_ShouldRefuelCar()
        {
            var sut = GetDefaultCar();

            sut.Refuel(30);

            sut.FuelAmount.Should().Be(30);
        }

        [Fact]
        public void Drive_WhenValid_ShouldDriveSelectedDistance()
        {
            var sut = GetDefaultCar();
            sut.Refuel(5);

            sut.Drive(50);

            using (new AssertionScope())
            {
                sut.FuelAmount.Should().Be(2.5);
                sut.DailyOdometer.Should().Be(50);
                sut.Odometer.Should().Be(50);
            }
        }

        [Fact]
        public void Drive_WhenNotEnoughFuel_ShouldStopWhenFuelRunsOut()
        {
            var sut = GetDefaultCar();
            sut.Refuel(5);

            sut.Drive(200);

            using (new AssertionScope())
            {
                sut.FuelAmount.Should().Be(0);
                sut.DailyOdometer.Should().Be(100);
                sut.Odometer.Should().Be(100);
            }
        }

        [Fact]
        public void Drive_WhenDailyOdometerExtendedLimit_ShouldResetAndUpdateWithRemainingValue()
        {
            var sut = GetDefaultCar();
            sut.Refuel(60);

            sut.Drive(1050);

            using (new AssertionScope())
            {
                sut.DailyOdometer.Should().Be(50);
                sut.Odometer.Should().Be(1050);
            }
        }

        [Fact]
        public void Reset_WhenPossible_ShouldResetDailyOdometer()
        {
            var sut = GetDefaultCar();
            sut.Refuel(40);
            sut.Drive(200);

            sut.Reset();

            sut.DailyOdometer.Should().Be(0);
        }

        private static Car GetDefaultCar() => new Car(Color.Red, "Ford Mondeo", 5.0, 60);
    }
}
