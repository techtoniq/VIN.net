namespace VehicleIdentificationNumberLib
{
    public class Vin
    {
        #region Private Fields

        private readonly string _value;

        #endregion Private Fields

        #region Ctor

        public Vin(string value)
        {
            if(string.IsNullOrWhiteSpace(value))
                throw new ArgumentNullException(nameof(value));

            if(value.Length != 17)
                throw new ArgumentException("Invalid length (must be 17 characters)", nameof(value));

            for(int i = 0; i < value.Length; i++)
            {
                if ((value[i] < 'A' || value[i] > 'Z') && !Char.IsDigit(value[i]))
                    throw new ArgumentException("All characters must be upper case alphanumeric only", nameof(value));

                if (value[i] == 'I' || value[i] == 'O' || value[i] == 'Q')
                    throw new ArgumentException($"Invalid character at position {i}", nameof(value));
            }

            _value = value;
        }

        #endregion Ctor

        #region Public Operators

        public static explicit operator Vin(string value)
        {
            Vin vin = new Vin(value);
            return vin;
        }

        public static implicit operator string(Vin vin)
        {
            return vin._value;
        }

        #endregion Public Operators

        #region Public Object Overrides

        public override string ToString()
        {
            return _value.ToString();
        }

        public override int GetHashCode()
        {
            return _value.GetHashCode();
        }

        public override bool Equals(object? obj)
        {
            var other = obj as Vin;

            if (other == null)
                return false;

            return _value.Equals(other._value);
        }

        #endregion Public Object Overrides
    }
}