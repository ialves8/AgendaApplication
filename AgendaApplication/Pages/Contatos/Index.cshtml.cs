using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AgendaApplication.Data;
using AgendaApplication.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace AgendaApplication.Pages.Contatos
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

        public IList<Contato> Contato { get; set; }

        public async Task OnGet(string option = null, string search = null)
        {
            if (option == "nome" && search != null)
            {
                Contato = await _db.Contatos.Include(m => m.Pessoa).Include(m => m.TipoContato).Where(u => u.NomeContato.ToLower().Contains(search.ToLower())).ToListAsync();
            }
            else
            {
                if (option == "contato" && search != null)
                {
                    Contato = await _db.Contatos.Include(m => m.Pessoa).Include(m => m.TipoContato).Where(n => n.DescricaoContato.ToLower().Contains(search.ToLower())).ToListAsync();
                }
                else
                {
                    Contato = await _db.Contatos
                        .Include(m => m.Pessoa)
                        .Include(m => m.TipoContato)
                        .ToListAsync();
                }
            }
        }
    }
}