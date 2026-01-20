using System;

namespace CustomValidationAttributes.Lib.Attributes
{
    public class PositiveAttribute : ValidationAttribute
    {
        public PositiveAttribute()
        {
            ErrorMessage = "Value must be positive.";
        }

        public override bool isValid(object value)
        {
            if (value == null)
            {
                return true;
            }
            if (value is not int number)
            {
                return true;
            }

            return number > 0 ? true : false;
        }
    }
}
