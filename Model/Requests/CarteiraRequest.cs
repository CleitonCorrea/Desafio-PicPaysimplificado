using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using PicPaySimplificado.Utils;

namespace PicPaySimplificado.Model.Requests
{
    public class CarteiraRequest
    {
        [Required(ErrorMessage ="O nome é obrigatório!")]
        public string NomeCompleto { get; set; }

        [Required(ErrorMessage="O CPF ou CNPJ é obrigatório.")]
        [CpfCnpjValidationAtribute(ErrorMessage = "O CPF ou CNPJ informado é inválido!")]
        public string CpfCnpj { get; set; }

        [Required(ErrorMessage = "O email é obrigatório.")]
        [EmailAddress(ErrorMessage = "O email informado é inválido!")]
        public string Email { get; set; }

        [Required(ErrorMessage = "A senha é obrigatório.")]
        [MinLength(6, ErrorMessage = "A senha deve ter no mínimo 6 caracteres.")]
        public string Senha { get; set; }

        [Required(ErrorMessage = "O tipo de usuário é obrigatório.")]
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public UserType TipoUsuario { get; set; }

        [Required(ErrorMessage = "O saldo é obrigatório.")]
        public decimal SaldoConta { get; set; } = 0;

    }
}
