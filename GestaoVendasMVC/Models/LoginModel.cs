using System.ComponentModel.DataAnnotations;

namespace GestaoVendasMVC.Models
{
    public class LoginModel
    {
        public int Id { get; set; }

        public string Nome { get; set; }

        [Required(ErrorMessage = "Informe o e-mail do usuário!")]
        [DataType(DataType.EmailAddress)]
        [EmailAddress(ErrorMessage = "O e-mail informado é inválido!")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Informe a senha do usuário!")]
        [DataType(DataType.Password)]
        public string Senha { get; set; }

        public LoginModel()
        {
        }

        public LoginModel(int id, string email, string senha)
        {
            Id = id;
            Email = email;
            Senha = senha;
        }
    }
}
