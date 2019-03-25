using System.Threading.Tasks;
using AgendaApplication.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace AgendaApplication.Pages.Contatos
{
    public class DeleteModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        [TempData]
        public string Message { get; set; }

        public DeleteModel(ApplicationDbContext db)
        {
            _db = db;
        }

        [BindProperty]
        public Contato Contato { get; set; }

        public async Task<IActionResult> OnGet(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Contato = await _db.Contatos.Include(m => m.TipoContato).Include(m => m.Pessoa).SingleOrDefaultAsync(m => m.Id == id);

            if (Contato == null)
            {
                return NotFound();
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Contato = await _db.Contatos.FindAsync(id);

            if (Contato != null)
            {

                _db.Contatos.Remove(Contato);
                await _db.SaveChangesAsync();

                Message = "Contato excluído com sucesso...";
            }

            return RedirectToPage("./Index");
        }
    }
}