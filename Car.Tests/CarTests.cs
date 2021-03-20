using FluentAssertions;
using Xunit;

namespace Car.Tests
{
    public class CarTests
    {
        [Fact]
        public void Create_WhenValid_ShouldCreateCar()
        {
            var car = new Car(Color.Red, "Ford Mondeo", 5.0, 60, 10);
            car.Color.Should().Be(Color.Red);
            car.Name.Should().Be("Ford Mondeo");
            car.FuelUsage.Should().Be(5.0);
            car.TankCapacity.Should().Be(60);
            car.FuelAmount.Should().Be(10);
        }
    }
}
