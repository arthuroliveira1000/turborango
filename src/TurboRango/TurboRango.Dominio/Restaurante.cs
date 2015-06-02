using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurboRango.Dominio
{
    class Restaurante
    {
        String nome { get; set; }
        int capacidade { get; set; }
        Categoria categoria { get; set; }
        Contato contato { get; set; }
        Localizacao localizacao { get; set; }
    }
}
