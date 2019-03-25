using System.ComponentModel.DataAnnotations;

namespace AgendaApplication.Data
{
    public class TipoContato
    {
        [Required]
        public int Id { get; set; }

        [Required(ErrorMessage = "O campo Tipo é obrigatório.")]
        [StringLength(100)]
        public string Tipo { get; set; }
    }
}
