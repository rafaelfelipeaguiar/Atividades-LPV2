using System.ComponentModel.DataAnnotations;

namespace Parte_2_data_annotations.Validations;

public class Base64ValidatorAttribute : ValidationAttribute
{
    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        if (value is not string hash || string.IsNullOrWhiteSpace(hash))
            return new ValidationResult("O hash do prontuário é obrigatório.");

        try
        {
            Convert.FromBase64String(hash);
            return ValidationResult.Success;
        }
        catch (FormatException)
        {
            return new ValidationResult($"O valor '{hash}' não é uma string Base64 válida.");
        }
    }
}
