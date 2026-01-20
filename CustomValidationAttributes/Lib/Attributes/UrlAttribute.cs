using System;

namespace CustomValidationAttributes.Lib.Attributes
{
    public sealed class UrlAttribute : ValidationAttribute
    {
        public UrlAttribute()
        {
            ErrorMessage = "Value must be a valid URL starting with http or https.";
        }

        public override bool isValid(object value)
        {
            if (value == null)
                return true;

            if (value is not string str)
                return true;

 
            if (string.IsNullOrWhiteSpace(str))
                return false;

            return str.StartsWith("http://", StringComparison.OrdinalIgnoreCase)
                || str.StartsWith("https://", StringComparison.OrdinalIgnoreCase);
        }
    }
}
