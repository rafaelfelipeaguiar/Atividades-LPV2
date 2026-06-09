using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Parte_2_data_annotations.Validations;
using System.ComponentModel.DataAnnotations;

namespace Parte_2_data_annotations.Models;

public class AdmissaoEnsaioClinicoViewModel : IValidatableObject
{
    [Required(ErrorMessage = "O código do protocolo é obrigatório.")]
    [RegularExpression(@"^BIO-\d{4}-[A-Z]{2}$", ErrorMessage = "O código do protocolo deve seguir o padrão BIO-1234-AX.")]
    [ProtocoloAtivo]
    public string CodigoProtocolo { get; set; } = string.Empty;

    [Required(ErrorMessage = "A data de consentimento é obrigatória.")]
    [DataType(DataType.DateTime)]
    public DateTime DataConsentimento { get; set; }

    [Required(ErrorMessage = "A data de início do tratamento é obrigatória.")]
    [DataType(DataType.DateTime)]
    [ComparacaoDataAttribute<AdmissaoEnsaioClinicoViewModel>("DataConsentimento", 48)]
    public DateTime DataInicioTratamento { get; set; }

    [Required(ErrorMessage = "O peso é obrigatório.")]
    [Range(0.1, 500, ErrorMessage = "O peso deve estar entre 0,1 kg e 500 kg.")]
    public decimal PesoKg { get; set; }

    [Required(ErrorMessage = "A dose do medicamento é obrigatória.")]
    [Range(0, 10000, ErrorMessage = "A dose deve ser um valor positivo.")]
    public decimal DoseMedicamentoMg { get; set; }

    [Required(ErrorMessage = "O código CID-10 é obrigatório.")]
    [Cid10Validador]
    public string CodigoCid10 { get; set; } = string.Empty;

    [Required]
    [ValidateComplexType]
    public ContatoViewModel ContatoEmergencia { get; set; } = new();

    [MarcadoresValidador]
    public List<string> MarcadoresEncontrados { get; set; } = new();

    [MustBeTrue]
    public bool AceitouTermosSigilo { get; set; }

    [Required(ErrorMessage = "O hash do prontuário é obrigatório.")]
    [Base64Validator]
    public string HashProntuario { get; set; } = string.Empty;

    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
        var resultados = new List<ValidationResult>();

        if (DataInicioTratamento <= DataConsentimento.AddHours(48))
        {
            resultados.Add(new ValidationResult(
                $"A data de início do tratamento ({DataInicioTratamento:dd/MM/yyyy HH:mm}) deve ser posterior à data de consentimento ({DataConsentimento:dd/MM/yyyy HH:mm}) em pelo menos 48 horas.",
                new[] { nameof(DataInicioTratamento) }));
        }

        if (PesoKg > 0 && DoseMedicamentoMg > PesoKg * 0.5m)
        {
            resultados.Add(new ValidationResult(
                $"A dose de {DoseMedicamentoMg}mg é excessiva para o peso de {PesoKg}kg. A dose máxima permitida é {PesoKg * 0.5m}mg.",
                new[] { nameof(DoseMedicamentoMg) }));
        }

        return resultados;
    }
}
