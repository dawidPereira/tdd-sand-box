using Xunit;

namespace Car.Tests
{
    public class CarTests
    {
        [Fact]
        public void Create_WhenValid_ShouldCreateCar()
        {
            var car = new Car(Color.Red, "Ford Mondeo", 5.0, 60, 10);
        }
    }
}
