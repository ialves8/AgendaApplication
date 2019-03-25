using System.Threading.Tasks;
using AgendaApplication.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace AgendaApplication.Pages.TipoContatos
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


        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            TipoContato = await _db.TipoContatos.FindAsync(id);

            if (TipoContato != null)
            {
                _db.TipoContatos.Remove(TipoContato);
                await _db.SaveChangesAsync();

                Message = "Tipo de contato exclído com sucesso...";
            }
            return RedirectToPage("./Index");
        }
    }
}