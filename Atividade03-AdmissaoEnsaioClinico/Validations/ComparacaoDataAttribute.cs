using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace Parte_2_data_annotations.Validations;

[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = false)]
public class ComparacaoDataAttribute<TModel> : ValidationAttribute where TModel : class
{
    public string PropriedadeReferencia { get; }
    public int HorasMinimas { get; }

    public ComparacaoDataAttribute(string propriedadeReferencia, int horasMinimas)
    {
        PropriedadeReferencia = propriedadeReferencia;
        HorasMinimas = horasMinimas;
    }

    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        if (value is not DateTime dataAtual)
            return new ValidationResult("Data inválida.");

        var propriedade = validationContext.ObjectType.GetProperty(PropriedadeReferencia);
        if (propriedade == null)
            return new ValidationResult($"Propriedade de referência '{PropriedadeReferencia}' não encontrada.");

        var valorReferencia = propriedade.GetValue(validationContext.ObjectInstance);
        if (valorReferencia is not DateTime dataReferencia)
            return new ValidationResult($"A propriedade '{PropriedadeReferencia}' deve ser uma data válida.");

        if ((dataAtual - dataReferencia).TotalHours < HorasMinimas)
            return new ValidationResult($"A data deve ser posterior à '{PropriedadeReferencia}' em pelo menos {HorasMinimas} horas.");

        return ValidationResult.Success;
    }
}
