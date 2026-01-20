using System;

namespace CustomValidationAttributes.Lib.Attributes
{
    public class AllowedEnumAttribute : ValidationAttribute
    {
        private readonly Type _enumType;

        public AllowedEnumAttribute(Type enumType)
        {
            _enumType = enumType;
            ErrorMessage = $"Enum does not match.";
        }

        public override bool isValid(object value)
        {
            if (value == null) return true;
            if (!_enumType.IsEnum) return false;

            if (value.GetType() == _enumType)
                return Enum.IsDefined(_enumType, value);

            if (value is string str)
                return Enum.TryParse(_enumType, str, ignoreCase: true, out _);

            return false;
        }

    }
}
