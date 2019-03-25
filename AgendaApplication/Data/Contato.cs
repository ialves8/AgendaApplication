using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AgendaApplication.Data
{
    public class Contato
    {
        [Required]
        public int Id { get; set; }

        [Required(ErrorMessage = "O campo Nome Contato é obrigatório.")]
        [RegularExpression(@"^[a-zA-Z''-'\s]{1,40}$", ErrorMessage = "Números e caracteres especiais não são permitidos no nome.")]
        [StringLength(100)]
        [Display(Name = "Nome Contato")]
        public string NomeContato { get; set; }

        [Required(ErrorMessage = "O campo Contato é obrigatório. Por favor, insira um número de telefone ou e-mail válido.")]
        [Display(Name = "Contato")]
        public string DescricaoContato { get; set; }

        [Display(Name = "Tipo")]
        public int TipoContatoId { get; set; }

        [ForeignKey("TipoContatoId")]
        public virtual TipoContato TipoContato { get; set; }

        public int PessoaId { get; set; }

        [ForeignKey("PessoaId")]
        public virtual Pessoa Pessoa { get; set; }
    }
}
