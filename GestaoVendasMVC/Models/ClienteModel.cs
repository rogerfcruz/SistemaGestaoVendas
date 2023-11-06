using System.ComponentModel.DataAnnotations;

namespace GestaoVendasMVC.Models
{
    public class ClienteModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "{0} obrigatório")]
        [StringLength(60, MinimumLength = 3, ErrorMessage = "{0}: o tamanho deve ser entre {2} e {1}.")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "{0} obrigatório")]
        [StringLength(11, MinimumLength = 11, ErrorMessage = "O CPF deve ser apenas números, sem caracteres e com 11 números.")]
        public string CPF { get; set; }

        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage = "{0} obrigatório")]
        [EmailAddress(ErrorMessage = "Digite um e-mail válido.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "{0} obrigatório")]
        [StringLength(12, MinimumLength = 8, ErrorMessage = "{0}: o tamanho deve ser entre {2} e {1}.")]
        public string Senha { get; set; }

        public ClienteModel()
        {
        }

        public ClienteModel(int id, string nome, string cpf, string email, string senha)
        {
            Id = id;
            Nome = nome;
            CPF = cpf;
            Email = email;
            Senha = senha;
        }
    }
}
