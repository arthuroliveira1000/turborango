namespace TurboRango.Dominio
{
    public class Restaurante : Entidade
    {
        public string Nome { get; set; }
        public int? Capacidade { get; set; }
        public virtual Categoria Categoria { get; set; }
        public virtual Contato Contato { get; set; }
        public Localizacao Localizacao { get; set; }
    }
}
