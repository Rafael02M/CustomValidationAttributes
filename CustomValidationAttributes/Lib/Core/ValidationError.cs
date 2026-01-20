using System;

namespace CustomValidationAttributes.Lib.Core;
public sealed class ValidationError
{
    public string MemberName { get; set; }
    public string ErrorMesssage { get; set; }

    public override string ToString()
    {
        return $"> {nameof(MemberName)}: {MemberName}, {nameof(ErrorMesssage)}: {ErrorMesssage}";
    }
}