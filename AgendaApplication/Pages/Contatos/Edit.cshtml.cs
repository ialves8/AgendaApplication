using System.Linq;
using System.Threading.Tasks;
using AgendaApplication.Data;
using AgendaApplication.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace AgendaApplication.Pages.Contatos
{
    public class EditModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        [TempData]
        public string Message { get; set; }

        public EditModel(ApplicationDbContext db)
        {
            _db = db;
        }

        [BindProperty]
        public ContatoViewModel ContatoViewModel { get; set; }

        public async Task<IActionResult> OnGet(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ContatoViewModel = new ContatoViewModel()
            {
                Contato = _db.Contatos.Include(m => m.TipoContato).Include(m => m.Pessoa).SingleOrDefault(m => m.Id == id),
                TipoContato = _db.TipoContatos.ToList()
            };

            if (ContatoViewModel.Contato == null)
            {
                return NotFound();
            }

            return Page();
        }

        public async Task<IActionResult> OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var ContatoFromDb = _db.Contatos.Where(m => m.Id == ContatoViewModel.Contato.Id).FirstOrDefault();

            ContatoFromDb.Pessoa = ContatoViewModel.Contato.Pessoa;
            ContatoFromDb.NomeContato = ContatoViewModel.Contato.NomeContato;
            ContatoFromDb.TipoContatoId = ContatoViewModel.Contato.TipoContatoId;
            ContatoFromDb.DescricaoContato = ContatoViewModel.Contato.DescricaoContato;

            await _db.SaveChangesAsync();

            Message = "Contato atualizado com sucesso...";

            return RedirectToPage("./Index");
        }
    }
}