using FluentAssertions;

namespace VehicleIdentificationNumberLib.UnitTest
{
    public class VinTests
    {
        public class Constructor
        {
            [Test]
            public void CannotBeEmpty()
            {
                Action act = () => new Vin(string.Empty);

                act.Should().Throw<ArgumentNullException>()
                    .WithMessage("Value cannot be null. (Parameter 'value')");
            }
        }
    }
}
