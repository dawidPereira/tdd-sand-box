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
            var car = new Car(Color.Red, "Ford Mondeo", 5.0, 60);
            using (new AssertionScope())
            {
                car.Color.Should().Be(Color.Red);
                car.Name.Should().Be("Ford Mondeo");
                car.FuelUsage.Should().Be(5.0);
                car.TankCapacity.Should().Be(60);
            }
        }

        [Fact]
        public void Refuel_WhenNegativeAmount_ShouldThrowException()
        {
            var car = new Car(Color.Red, "Ford Mondeo", 5.0, 60);

            Action action = () => car.Refuel(-10);
            action.Should().Throw<ArgumentOutOfRangeException>().WithMessage("Fuel amount can not be lower than zero");
        }
    }
}
