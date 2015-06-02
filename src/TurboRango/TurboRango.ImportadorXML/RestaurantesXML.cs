using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace TurboRango.ImportadorXML
{
    public class RestaurantesXML
    {
        public string NomeArquivo { get; private set; }
        IEnumerable<XElement> restaurantes;
        /// <summary>
        /// Constrói RestauranteXML a partir de um nome de arquivo.
        /// </summary>
        /// <param name="nomeArquivo">Nome do arquivo a ser manipulado</param>

        public RestaurantesXML(String nomeArquivo) //ATALHO -- CTOR + TAB + TAB -> CRIA CONSTRUTOR
        {
            this.NomeArquivo = NomeArquivo;
            restaurantes = XDocument.Load(NomeArquivo).Descendants("restaurante");
        }

        public IList<string> ObterNomes()
        {
            #region outrasManeirasDeObterNomes
            //var resultado = new List<string>();
            //var nodos = XDocument.Load(NomeArquivo).Descendants("restaurante");

            //foreach (var item in nodos)
            //{
            //    resultado.Add(item.Attribute("nome").Value);
            //}

            //return resultado;

            //return (from n in XDocument.Load(NomeArquivo).Descendants("restaurante")
            //         orderby n.Attribute("nome").Value
            //        select n.Attribute("nome").Value).ToList();
            #endregion

            return (from n in XDocument.Load(NomeArquivo).Descendants("restaurante") orderby n.Attribute("nome").Value where Convert.ToInt32(n.Attribute("capacidade").Value) < 100 );
            return XDocument.Load(NomeArquivo).Descendants("restaurante").Select(_ => _.Attribute("nome").Value).ToList();
        }

        public double CapacidadeMedia()
        {
            return (from n in restaurantes select Convert.ToInt32(n.Attribute("capacidade").Value)).Average();
        }

        public double CapacidadeMaxima()
        {
            var consulta = (from n in restaurantes select Convert.ToInt32(n.Attribute("capacidade").Value));
            return consulta.Max();
        }


    }
}
