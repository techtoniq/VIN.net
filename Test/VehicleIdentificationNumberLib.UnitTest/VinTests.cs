using FluentAssertions;

namespace VehicleIdentificationNumberLib.UnitTest
{
    public class VinTests
    {
        public class Constructor
        {
            [Test]
            public void CannotBeNull()
            {
                Action act = () => { Vin v = new Vin(null!); };

                act.Should().Throw<ArgumentNullException>()
                    .WithMessage("Value cannot be null. (Parameter 'value')");
            }

            [Test]
            public void CannotBeEmpty()
            {
                Action act = () => { Vin v = new Vin("   "); };

                act.Should().Throw<ArgumentNullException>()
                    .WithMessage("Value cannot be null. (Parameter 'value')");
            }

            [Test]
            public void CannotBeLessThan17CharactersLong()
            {
                Action act = () => { Vin v = new Vin("1234567890123456"); };

                act.Should().Throw<ArgumentException>()
                    .WithMessage("Invalid length (must be 17 characters) (Parameter 'value')");
            }

            [Test]
            public void CannotBeMoreThan17CharactersLong()
            {
                Action act = () => { Vin v = new Vin("123456789012345678"); };

                act.Should().Throw<ArgumentException>()
                    .WithMessage("Invalid length (must be 17 characters) (Parameter 'value')");
            }

            [TestCase("1HGBH41JXMN10x106")]
            [TestCase("1HGBH41JXMN10%106")]
            public void MustBeAllUpperCaseAlphanumeric(string value)
            {
                Action act = () => { Vin v = new Vin(value); };

                act.Should().Throw<ArgumentException>()
                    .WithMessage("All characters must be upper case alphanumeric only (Parameter 'value')");
            }

            [TestCase('I')]
            [TestCase('O')]
            [TestCase('Q')]
            public void MustNotContainIllegalCharacter(Char c)
            {
                Action act = () => { Vin v = new Vin($"1HGBH41JXMN10{c}106"); };

                act.Should().Throw<ArgumentException>()
                    .WithMessage("Invalid character at position 13 (Parameter 'value')");
            }
        }

        public class ExplicitConversionOperator
        {
            [Test]
            public void HasExplicitConversionFromString()
            {
                string s = "1HGBH41JXMN109106";

                Action act = () => { Vin v = (Vin)s; };

                act.Should().NotThrow();                
            }
        }

        public class ImplicitConversionOperator
        {
            [Test]
            public void HasImplicitConversionToString()
            {
                string s = "1HGBH41JXMN109106";

                Vin v = new Vin(s);

                s.Should().Be(v);
            }
        }

        public class ToString
        {
            [Test]
            public void ToStringEqualsSourceValue()
            {
                string s = "1HGBH41JXMN109106";

                Vin v = new Vin(s);

                v.ToString().Should().Be(s);
            }
        }

        public class GetHashCode
        {
            [Test]
            public void HashCodeEqualsSourceValue()
            {
                string s = "1HGBH41JXMN109106";

                Vin v = new Vin(s);

                v.GetHashCode().Should().Be(s.GetHashCode());
            }
        }

        public class Equals
        {
            [Test]
            public void SameVinValueIsEqual()
            {
                string s = "1HGBH41JXMN109106";

                Vin first = new Vin(s);
                Vin second = new Vin(s);

                first.Should().Be(second);
            }

            [Test]
            public void DifferentVinValueIsNotEqual()
            {
                string s = "1HGBH41JXMN109106";
                string t = "1HGBH41JXMN109107";

                Vin first = new Vin(s);
                Vin second = new Vin(t);

                first.Should().NotBe(second);
            }
        }
    }
}
