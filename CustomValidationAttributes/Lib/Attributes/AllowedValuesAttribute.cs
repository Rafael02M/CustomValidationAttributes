using System;

namespace CustomValidationAttributes.Lib.Attributes
{
    public sealed class AllowedValuesAttribute : ValidationAttribute
    {
        private readonly string[] _allowedValues;

        public AllowedValuesAttribute(params string[] allowedValues)
        {
            _allowedValues = allowedValues;
            ErrorMessage = $"Allowed values are: {string.Join(", ", _allowedValues)}.";
        }

        public override bool isValid(object value)
        {

            if (value is not string str)
                return true;

            foreach (var allowed in _allowedValues)
            {
                if (str.Equals(allowed, StringComparison.OrdinalIgnoreCase))
                    return true;
            }

            return false;
        }

    }
}
