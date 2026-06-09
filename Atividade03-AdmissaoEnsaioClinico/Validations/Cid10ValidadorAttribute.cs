using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace Parte_2_data_annotations.Validations;

public partial class Cid10ValidadorAttribute : ValidationAttribute
{
    [GeneratedRegex(@"^[A-Z]\d{2}\.\d$")]
    private static partial Regex Cid10Regex();

    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        if (value is not string codigo || string.IsNullOrWhiteSpace(codigo))
            return new ValidationResult("O código CID-10 é obrigatório.");

        if (!Cid10Regex().IsMatch(codigo))
            return new ValidationResult($"O código CID-10 '{codigo}' é inválido. O formato correto é uma letra maiúscula seguida de dois números, um ponto e mais um número (ex: E11.9).");

        return ValidationResult.Success;
    }
}
