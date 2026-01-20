using System;

namespace CustomValidationAttributes.Lib.Attributes
{
    public sealed class FutureDateAttribute : ValidationAttribute
    {
        public FutureDateAttribute()
        {
            ErrorMessage = "Date must be in the future.";
        }

        public override bool isValid(object value)
        {
            if (value == null)
                return true;

            if (value is not DateTime date)
                return true;

            return date > DateTime.UtcNow;
        }
    }
}
