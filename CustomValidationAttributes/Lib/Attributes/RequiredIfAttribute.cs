using System;
using System.Reflection;

namespace CustomValidationAttributes.Lib.Attributes
{
    public sealed class RequiredIfAttribute : ValidationAttribute
    {
        private readonly string _dependentPropertyName;
        private readonly object _expectedValue;

        public RequiredIfAttribute(string dependentPropertyName, object expectedValue)
        {
            _dependentPropertyName = dependentPropertyName;
            _expectedValue = expectedValue;
            ErrorMessage = "Field is required due to condition.";
        }

        public override bool isValid(object value)
        {
            return true;
        }

        public bool isValid(object value, object instance)
        {
            if (instance == null)
                return true;

            PropertyInfo property =
                instance.GetType().GetProperty(_dependentPropertyName);

            if (property == null)
                return true;

            object dependentValue = property.GetValue(instance);

            if (!Equals(dependentValue, _expectedValue))
                return true;

            if (value == null)
                return false;

            if (value is string str)
                return !string.IsNullOrWhiteSpace(str);

            return true;
        }
    }
}
