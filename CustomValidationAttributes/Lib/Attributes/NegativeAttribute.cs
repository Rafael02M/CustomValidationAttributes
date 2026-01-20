using System;

namespace CustomValidationAttributes.Lib.Attributes
{
    public class NegativeAttribute : ValidationAttribute
    {
        public NegativeAttribute(int value)
        {
            ErrorMessage = $"{value} is not negative or {value} = 0";
        }

        public override bool isValid(object value)
        {
            if (value is not int number)
            {
                return true;
            }

            return number < 0 ? true : false;
        }
    }
}
