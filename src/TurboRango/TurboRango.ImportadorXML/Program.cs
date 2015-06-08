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
            const string nomeArquivo = "restaurantes.xml";
            var restaurantesXML = new RestaurantesXML(nomeArquivo);

            #region Exemplos

            Restaurante restaurante = new Restaurante();

            //restaurante.
            //Console.Write(restaurante.Contato.Site);
            Console.WriteLine(
                restaurante.Capacidade.HasValue ?
                    restaurante.Capacidade.Value.ToString() :
                    "oi"
                );

            restaurante.Nome = string.Empty + " ";

            Console.WriteLine(restaurante.Nome ?? "Nulo!!!");

            Console.WriteLine(!string.IsNullOrEmpty(restaurante.Nome.Trim()) ? "tem valor" : "não tem valor");

            var oQueEuGosto = "bacon";

            var texto = String.Format("Eu gosto de {0}", oQueEuGosto);
            // var texto = String.Format("Eu gosto de \{oQueEuGosto}");

            StringBuilder pedreiro = new StringBuilder();
            pedreiro.AppendFormat("Eu gosto de {0}", oQueEuGosto);
            pedreiro.Append("!!!!!!");

            object obj = "1";
            int a = Convert.ToInt32(obj);
            int convertido = 10;
            bool conseguiu = Int32.TryParse("1gdfgfd", out convertido);
            int res = 12 + a;

            Console.WriteLine(pedreiro);

            #endregion

            #region **********************EXERCÍCIOS

            var nomes = restaurantesXML.ObterNomes();
            var capacidadeMedia = restaurantesXML.CapacidadeMedia();
            var capacidadeMaxima = restaurantesXML.CapacidadeMaxima();
            var restaurantesporCategoria = restaurantesXML.AgruparPorCategoria();
            var categoriaDeRestaurantesPopulares = restaurantesXML.ApenasMaisPopulares();
            var bairrosComMenosPizzarias = restaurantesXML.BairrosComMenosPizzarias();
            var restaurantesAgrupadosPorBairroPercentual = restaurantesXML.AgrupadosPorBairroPercentual();
            var todosRestaurantes = restaurantesXML.TodosRestaurantes();



            var ordenaPorNomeAsc = restaurantesXML.OrdenarPorNomeAsc();
            var sitesDeRestaurantes = restaurantesXML.ObterSites();
            #endregion

            #region ADO.NET

            //var connString = @"Data Source=.; Initial Catalog=TurboRango_dev; UID=ARTHUR/arthur;PWD="""; //Integrated-Security:true

            //var acessoAoBanco = new CarinhaQueManinulaOBanco(connString);

            //acessoAoBanco.Inserir(new Contato { Site = "www.dogao.com", Telefone = "555555"}); 

            #endregion


            #region EXERCÍCIO 1
            var connString = @"Data Source=.\SQLEXPRESS2014;Initial Catalog=TurboRango_dev;Integrated Security=True;";
            var restaurantes = new Restaurantes(connString);


            restaurantes.Inserir(new Restaurante
            {
                Nome = "Tiririca",
                Capacidade = 50,
                Categoria = Categoria.Fastfood,
                Contato = new Contato
                {
                    Site = "http://github.com/tiririca",
                    Telefone = "5555 5555"
                },
                Localizacao = new Localizacao
                {
                    Bairro = "Vila Nova",
                    Logradouro = "ERS 239, 2755",
                    Latitude = -29.6646122,
                    Longitude = -51.1188255
                }
            });

            #endregion

            #region EXERCÍCIO 2

            foreach (Restaurante umRestaurante in restaurantesXML.TodosRestaurantes())
            {
                restaurantes.Inserir(umRestaurante);
            }

            #endregion

        }
    }
}

