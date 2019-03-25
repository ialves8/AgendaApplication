using System.Collections.Generic;
using System.Threading.Tasks;
using AgendaApplication.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace AgendaApplication.Pages.TipoContatos
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        [TempData]
        public string Message { get; set; }

        public IndexModel(ApplicationDbContext db)
        {
            _db = db;
        }

        public IList<TipoContato> TipoContato { get; set; }

        public async Task OnGetAsync()
        {
            TipoContato = await _db.TipoContatos.ToListAsync();
        }
    }
}