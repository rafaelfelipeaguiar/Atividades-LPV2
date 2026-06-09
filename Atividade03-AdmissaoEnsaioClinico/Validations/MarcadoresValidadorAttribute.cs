using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace Parte_2_data_annotations.Validations;

public partial class MarcadoresValidadorAttribute : ValidationAttribute
{
    [GeneratedRegex(@"^[a-zA-Z0-9]{4}$")]
    private static partial Regex MarcadorRegex();

    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        if (value is not List<string> marcadores || marcadores.Count == 0)
            return new ValidationResult("A lista de marcadores genéticos não pode estar vazia.");

        if (marcadores.Count > 5)
            return new ValidationResult($"A lista de marcadores genéticos não pode conter mais de 5 itens. Foram encontrados {marcadores.Count}.");

        for (int i = 0; i < marcadores.Count; i++)
        {
            var marcador = marcadores[i];
            if (string.IsNullOrWhiteSpace(marcador) || !MarcadorRegex().IsMatch(marcador))
                return new ValidationResult($"O marcador na posição {i + 1} ('{marcador}') é inválido. Deve conter exatamente 4 caracteres alfanuméricos.");
        }

        return ValidationResult.Success;
    }
}
