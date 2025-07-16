using System.ComponentModel.DataAnnotations;

namespace PicPaySimplificado.Utils
{
    public class CpfCnpjValidationAtribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value == null || string.IsNullOrWhiteSpace(value.ToString()))
            {
                return new ValidationResult(ErrorMessage ?? "O CPF ou CNPJ é obrigatório.");
            }
            var cpfCnpj = value.ToString().Trim();
            if (cpfCnpj.Length == 11 && !CpfCnpjValidator.IsValidCpf(cpfCnpj))
            {
                return new ValidationResult(ErrorMessage ?? "O CPF informado é inválido!");
            }
            else if (cpfCnpj.Length == 14 && !CpfCnpjValidator.IsValidCpf(cpfCnpj))
            {
                return new ValidationResult(ErrorMessage ?? "O CNPJ informado é inválido!");
            }
            else if (cpfCnpj.Length != 11 && cpfCnpj.Length != 14)
            {
                return new ValidationResult(ErrorMessage ?? "O CPF ou CNPJ deve ter 11 ou 14 dígitos.");
            }
            return ValidationResult.Success;
        }
    }
}
