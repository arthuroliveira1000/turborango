using System;
namespace TurboRango.Dominio
{
    public class Restaurante : Entidade
    {
        public string Nome { get; set; }
        public int? Capacidade { get; set; }
        public Categoria Categoria { get; set; }
        public Contato Contato { get; set; }
        public Localizacao Localizacao { get; set; }
        public Prato Prato { get; set; }
        public DateTime? HorarioRegistro { get; set; }
    }
}
