using System.Threading.Tasks;
using AgendaApplication.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace AgendaApplication.Pages.TipoContatos
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
        public TipoContato TipoContato { get; set; }

        public async Task<IActionResult> OnGet(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            TipoContato = await _db.TipoContatos.SingleOrDefaultAsync(c => c.Id == id);

            if (TipoContato == null)
            {
                return NotFound();
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _db.Attach(TipoContato).State = EntityState.Modified;

            await _db.SaveChangesAsync();

            Message = "Tipo de contato atualizado com sucesso...";

            return RedirectToPage("./Index");
        }
    }
}