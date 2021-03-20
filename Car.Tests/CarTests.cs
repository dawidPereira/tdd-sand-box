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
        public void Drive_WhenValid_ShouldNotThrowException()
        {
            var sut = GetDefaultCar();
            sut.Drive(40);
        }

        private static Car GetDefaultCar() => new Car(Color.Red, "Ford Mondeo", 5.0, 60);
    }
}
