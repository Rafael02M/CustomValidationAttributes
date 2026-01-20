using System;
using System.Collections.Generic;
using System.Text;

namespace CustomValidationAttributes.Lib.Core;
public sealed class ValidationResult
{
    public List<ValidationError> Errors { get; } = new List<ValidationError>();
    public bool IsValid => Errors.Count == 0;
}