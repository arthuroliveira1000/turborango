using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurboRango.Dominio
{
    internal class Restaurante
    {
        private String nome { get; set; }
        private int capacidade { get; set; }
        private Categoria categoria { get; set; }
        private Contato contato { get; set; }
        private Localizacao localizacao { get; set; }
    }
}
