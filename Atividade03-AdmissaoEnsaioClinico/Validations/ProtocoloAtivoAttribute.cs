using System.ComponentModel.DataAnnotations;

namespace Parte_2_data_annotations.Validations;

public class ProtocoloAtivoAttribute : ValidationAttribute
{
    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        if (value is not string codigo || string.IsNullOrWhiteSpace(codigo))
            return new ValidationResult("O código do protocolo é obrigatório.");

        if (!codigo.StartsWith("BIO", StringComparison.OrdinalIgnoreCase))
            return new ValidationResult("O protocolo deve estar ativo e iniciar com o prefixo 'BIO'.");

        return ValidationResult.Success;
    }
}
