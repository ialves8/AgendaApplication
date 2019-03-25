using System.ComponentModel.DataAnnotations;

namespace AgendaApplication.Data
{
    public class Pessoa
    {
        [Required]
        public int Id { get; set; }

        [Required(ErrorMessage = "O campo Nome Pessoa é obrigatório.")]
        [RegularExpression(@"^[a-zA-Z''-'\s]{1,40}$", ErrorMessage = "Números e caracteres especiais não são permitidos no nome.")]
        [StringLength(100)]
        [Display(Name = "Nome Pessoa")]
        public string NomePessoa { get; set; }
    }
}
