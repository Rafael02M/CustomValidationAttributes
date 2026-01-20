using System;

namespace CustomValidationAttributes.Lib.Attributes
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field)]
    public abstract class ValidationAttribute : Attribute
    {
        public string ErrorMessage { get; protected set; } = "Validation failed.";

        public abstract bool isValid(object value);
    }
}
