using System;

namespace CustomValidationAttributes.Lib.Attributes
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field)]
    public abstract class ValidationAttribute : Attribute
    {
        public string ErrorMessage { get; protected set; } = "Validation failed.";

        public virtual bool isValid(object value) => true;

        public virtual bool isValid(object value, object instance) => isValid(value);
    }
}
