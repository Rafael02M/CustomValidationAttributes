using System;

namespace CustomValidationAttributes.Lib.Attributes
{
    public sealed class ContainsAttribute : ValidationAttribute
    {
        private readonly string _substring;

        public ContainsAttribute(string substring)
        {
            _substring = substring;

            ErrorMessage = $"String must contain '{_substring}'.";
        }

        public override bool isValid(object value)
        {
            if(value == null)
            {
                return true; 
            }

            if(value is not string str)
            {
                return true; 
            }

            return str.ToLower().Contains(_substring.ToLower());

        }
    }
}
