using System.ComponentModel.DataAnnotations;

namespace Atividade_LPV2.Models;

public class ClientePremiumViewModel
{
    [Display(Name = "Nome Completo")]
    [Required(ErrorMessage = "O campo {0} é obrigatório.")]
    [StringLength(100, MinimumLength = 5, ErrorMessage = "O campo {0} deve ter entre {2} e {1} caracteres.")]
    public string NomeCompleto { get; set; } = string.Empty;

    [Display(Name = "Data de Nascimento")]
    [Required(ErrorMessage = "O campo {0} é obrigatório.")]
    [DataType(DataType.Date, ErrorMessage = "O campo {0} deve conter uma data válida.")]
    public DateTime DataNascimento { get; set; }

    [Display(Name = "CPF")]
    [Required(ErrorMessage = "O campo {0} é obrigatório.")]
    [RegularExpression(@"^(\d{3}\.\d{3}\.\d{3}-\d{2}|\d{11})$", ErrorMessage = "O campo {0} deve conter um CPF válido (ex: 123.456.789-00 ou 12345678900).")]
    public string Cpf { get; set; } = string.Empty;

    [Display(Name = "Telefone Celular")]
    [Required(ErrorMessage = "O campo {0} é obrigatório.")]
    [Phone(ErrorMessage = "O campo {0} deve conter um número de telefone válido.")]
    public string TelefoneCelular { get; set; } = string.Empty;

    [Display(Name = "URL do Perfil LinkedIn")]
    [Url(ErrorMessage = "O campo {0} deve conter uma URL válida.")]
    public string? UrlPerfilLinkedIn { get; set; }

    [Display(Name = "Renda Mensal")]
    [Required(ErrorMessage = "O campo {0} é obrigatório.")]
    [Range(typeof(decimal), "3000", "1000000", ErrorMessage = "O campo {0} deve estar entre R$ {1:N2} e R$ {2:N2}.")]
    [DataType(DataType.Currency, ErrorMessage = "O campo {0} deve estar em formato de moeda.")]
    public decimal RendaMensal { get; set; }

    [Display(Name = "Número do Cartão de Crédito")]
    [Required(ErrorMessage = "O campo {0} é obrigatório.")]
    [CreditCard(ErrorMessage = "O campo {0} deve conter um número de cartão de crédito válido.")]
    public string NumeroCartaoCredito { get; set; } = string.Empty;

    [Display(Name = "Senha de Acesso")]
    [Required(ErrorMessage = "O campo {0} é obrigatório.")]
    [DataType(DataType.Password, ErrorMessage = "O campo {0} deve estar no formato de senha.")]
    [RegularExpression(
        @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^a-zA-Z\d]).{8,}$",
        ErrorMessage = "O campo {0} deve conter no mínimo 8 caracteres, uma letra maiúscula, uma letra minúscula, um número e um caractere especial.")]
    public string SenhaAcesso { get; set; } = string.Empty;

    [Display(Name = "Confirmar Senha de Acesso")]
    [Required(ErrorMessage = "O campo {0} é obrigatório.")]
    [DataType(DataType.Password, ErrorMessage = "O campo {0} deve estar no formato de senha.")]
    [Compare(nameof(SenhaAcesso), ErrorMessage = "O campo {0} deve ser idêntico à Senha de Acesso.")]
    public string ConfirmarSenhaAcesso { get; set; } = string.Empty;
}
