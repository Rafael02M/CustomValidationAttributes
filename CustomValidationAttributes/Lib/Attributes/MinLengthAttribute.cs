using System;

namespace CustomValidationAttributes.Lib.Attributes
{
    public class MinLengthAttribute : ValidationAttribute
    {
        private readonly int _length;

        public MinLengthAttribute(int length)
        {
            _length = length;
            ErrorMessage = $"Minimum length is {_length}.";
        }

        public override bool isValid(object value)
        {
            if(value == null) 
                return true;

            if(value is not string str)
            {
                return true; 
            }

            return str.Length >= _length;
        }
    }
}
