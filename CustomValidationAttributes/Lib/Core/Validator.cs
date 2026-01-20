using CustomValidationAttributes.Lib.Attributes;
using System;
using System.Reflection;

namespace CustomValidationAttributes.Lib.Core;

public sealed class Validator
{
    public ValidationResult Validate(object target)
    {
        var result = new ValidationResult();

        Type type = target.GetType();

        foreach (var member in type.GetMembers(BindingFlags.Public | BindingFlags.Instance))
        {
            if (member is not PropertyInfo && member is not FieldInfo)
            {
                continue;
            }

            var value = member switch
            {
                PropertyInfo p => p.GetValue(target),
                FieldInfo f => f.GetValue(target),
                _ => null
            };

            var attributes = member.GetCustomAttributes<ValidationAttribute>();

            foreach (ValidationAttribute attribute in attributes)
            {
                if (!attribute.isValid(value))
                {
                    var error = new ValidationError
                    {
                        MemberName = member.Name,
                        ErrorMesssage = attribute.ErrorMessage
                    };

                    result.Errors.Add(error);
                }
            }
        }

        return result;
    }
}