using System.Linq;
using System.Threading.Tasks;
using AgendaApplication.Data;
using AgendaApplication.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AgendaApplication.Pages.Contatos
{
    public class CreateModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        [TempData]
        public string Message { get; set; }

        public CreateModel(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult OnGet()
        {
            ContatoViewModel = new ContatoViewModel
            {
                Contato = new Contato(),
                TipoContato = _db.TipoContatos.ToList()
            };

            return Page();
        }

        [BindProperty]
        public ContatoViewModel ContatoViewModel { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _db.Contatos.Add(ContatoViewModel.Contato);
            await _db.SaveChangesAsync();

            Message = "Contato cadastrado com sucesso...";

            return RedirectToPage("./Index");
        }
    }
}