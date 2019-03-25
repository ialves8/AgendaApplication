using AgendaApplication.Data;
using System.Collections.Generic;

namespace AgendaApplication.ViewModel
{
    public class ContatoViewModel
    {
        public Contato Contato { get; set; }
        public IEnumerable<TipoContato> TipoContato { get; set; }
    }
}
