using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurboRango.Dominio
{
    public class Prato : Entidade
    {
        public string Nome { get; set; }
        public string DescricaoIngredientes { get; set; }
        public decimal? Preco { get; set; }
    }
}
