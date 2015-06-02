using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TurboRango.Dominio;

namespace TurboRango.ImportadorXML
{
    class Program
    {
        static void Main(string[] args)
        {
            #region exemplos
            Restaurante restaurante = null;
            //onsole.WriteLine(restaurante.Nome ?? "Nulo!!!");
            /*

            Console.WriteLine(!string.IsNullOrEmpty(restaurante.Nome) ? "tem valor" : "não tem valor");
             * var texto = string.format
             * string.format("Eu gosto de {0}", oQueEuGosto);
             */


            #endregion

            const string nomeArquivo = "restaurantes.xml";

            var restaurantesXML = new RestaurantesXML(nomeArquivo);
            var nomes = restaurantesXML.ObterNomes();

            //var capacidadeMedia = restaurantesXML.CapacidadeMedia();
            //var capacidadeMaxima = restaurantesXML.CapacidadeMaxima();

        }
    }
}
