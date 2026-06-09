using System.ComponentModel.DataAnnotations;

namespace Parte_2_data_annotations.Validations;

public class MustBeTrueAttribute : ValidationAttribute
{
    public MustBeTrueAttribute() : base("Você deve aceitar os termos de sigilo para prosseguir.") { }

    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        if (value is not bool boolValue || !boolValue)
            return new ValidationResult(ErrorMessageString);

        return ValidationResult.Success;
    }
}
