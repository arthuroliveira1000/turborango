namespace TurboRango.Dominio
{
    public class Restaurante : Entidade
    {
        public string Nome { get; set; }
        public int? Capacidade { get; set; }
        public Categoria Categoria { get; set; }
        public virtual Contato Contato { get; set; }
        public virtual Localizacao Localizacao { get; set; }
    }
}
