using System.ComponentModel.DataAnnotations;

namespace Parte_2_data_annotations.Models;

public class ContatoViewModel
{
    [Required(ErrorMessage = "O nome do contato de emergência é obrigatório.")]
    [StringLength(100, MinimumLength = 3, ErrorMessage = "O nome deve ter entre 3 e 100 caracteres.")]
    public string Nome { get; set; } = string.Empty;

    [Required(ErrorMessage = "O telefone de emergência é obrigatório.")]
    [RegularExpression(@"^\+\d{10,15}$", ErrorMessage = "O telefone deve seguir o padrão internacional E.164 (ex: +5569999999999).")]
    public string Telefone { get; set; } = string.Empty;

    [Required(ErrorMessage = "O grau de parentesco é obrigatório.")]
    [StringLength(50, ErrorMessage = "O grau de parentesco deve ter no máximo 50 caracteres.")]
    public string GrauParentesco { get; set; } = string.Empty;
}
