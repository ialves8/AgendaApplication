using System.Threading.Tasks;
using AgendaApplication.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AgendaApplication.Pages.TipoContatos
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
            return Page();
        }

        [BindProperty]
        public TipoContato TipoContato { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            _db.TipoContatos.Add(TipoContato);
            await _db.SaveChangesAsync();

            Message = "Tipo de contato cadastrado com sucesso...";

            return RedirectToPage("./Index");
        }
    }
}