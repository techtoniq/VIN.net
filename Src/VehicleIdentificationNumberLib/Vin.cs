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

            _value = value;
        }

        #endregion Ctor
    }
}