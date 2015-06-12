using System.ComponentModel;
namespace TurboRango.Dominio
{
    public enum Categoria //  - POCO - PLAIN OLD C OBJECT 
    {
        [Description("Comum")]
        Comum,
        [Description("Cozinha Natural")]
        CozinhaNatural,
        [Description("Cozinha Mexicana")]
        CozinhaMexicana,
        [Description("Churrascaria")]
        Churrascaria,
        [Description("Cozinha Japonesa")]
        CozinhaJaponesa,
        [Description("Pizzaria")]
        Pizzaria,
        [Description("FastFood")]
        Fastfood
    };
}

