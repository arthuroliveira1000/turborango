using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using TurboRango.Dominio;

namespace TurboRango.ImportadorXML
{
    public class RestaurantesXML
    {
        public string NomeArquivo { get; private set; }
        IEnumerable<XElement> restaurantes;

        /// <summary>
        /// Constrói RestaurantesXML a partir de um nome de arquivo.
        /// </summary>
        /// <param name="nomeArquivo">Nome do arquivo XML a ser manipulado</param>
        public RestaurantesXML(string nomeArquivo)
        {
            NomeArquivo = nomeArquivo;
            restaurantes = XDocument.Load(NomeArquivo).Descendants("restaurante");
        }

        public IList<string> ObterNomes()
        {
            #region outrasFormasDeObterONome
            //var resultado = new List<string>();

            //var nodos = restaurantes;

            //foreach (var item in nodos)
            //{
            //    resultado.Add(item.Attribute("nome").Value);
            //}

            //return resultado;

            /*var res = restaurantes
                .Select(n => new Restaurante
                {
                    Nome = n.Attribute("nome").Value,
                    Capacidade = Convert.ToInt32(n.Attribute("capacidade").Value)
                });

            return res.Where(x => x.Capacidade < 100).Select(x => x.Nome).OrderBy(x => x).ToList();
            */

            #endregion
            return (
                from n in restaurantes
                orderby n.Attribute("nome").Value descending
                where Convert.ToInt32(n.Attribute("capacidade").Value) < 100
                select n.Attribute("nome").Value
            ).ToList();
        }

        public double CapacidadeMaxima()
        {
            var mad = (
                from n in restaurantes
                select Convert.ToInt32(n.Attribute("capacidade").Value)
            );

            return mad.Max();
        }

        #region **************************************EXERCÍCIOS-LINQ-LANGUAGE INTEGRATED QUERY
        
        //1A
        
        public IList<string> OrdenarPorNomeAsc()
        {
            return (from restaurante in restaurantes
                    orderby restaurante.Attribute("nome").Value
                    select restaurante.Attribute("nome").Value
            ).ToList();
        }

        //1B
        public IList<string> ObterSites()
        {
            return (
              from restaurante in restaurantes
              let contato = restaurante.Element("contato")
              let site = contato != null ? contato.Element("site") : null
              where site != null && !String.IsNullOrEmpty(site.Value)
              select contato.Element("site").Value
            ).ToList();
        }

        // 1C 
        public double CapacidadeMedia()
        {
            return (
                from restaurante in restaurantes
                select Convert.ToInt32(restaurante.Attribute("capacidade").Value)
            ).Average();
        }

        //1D
        public object AgruparPorCategoria()
        {
            return (from restaurante in restaurantes
                    group restaurante by restaurante.Attribute("categoria").Value into g
                    select new
                    {
                        Categoria = g.Key,
                        Restaurantes = g.ToList()
                    }).ToList();
        }

        //1E
        public IList<Categoria> ApenasComUmRestaurante()
        {
            return (from restaurante in restaurantes
                    group restaurante by restaurante.Attribute("categoria").Value into g
                    where g.Count() == 1
                    select
                    (Categoria)Enum.Parse(typeof(Categoria), g.Key, ignoreCase: true)
                    ).ToList();
        }
        //1F
        public IList<Categoria> ApenasMaisPopulares()
        {
            return (from restaurante in restaurantes
                    group restaurante by restaurante.Attribute("categoria").Value into g
                    let contRestaurantePorCategoria = g.Count()
                    orderby contRestaurantePorCategoria descending
                    where contRestaurantePorCategoria > 2
                    select
                    (Categoria)Enum.Parse(typeof(Categoria), g.Key, ignoreCase: true)
                    ).Take(2).ToList();
        }

        //1G
        public IList<string> BairrosComMenosPizzarias()
        {
            return (
                 from n in restaurantes
                 let cat = (Categoria)Enum.Parse(typeof(Categoria), n.Attribute("categoria").Value, ignoreCase: true)
                 where cat == Categoria.Pizzaria
                 group n by n.Element("localizacao").Element("bairro").Value into g
                 orderby g.Count()
                 select g.Key
                 ).Take(8).ToList();		                 
        }

        //1H
        public object AgrupadosPorBairroPercentual()
        {
            return (
                 from n in restaurantes
                 group n by n.Element("localizacao").Element("bairro").Value into g
                 let totalRestaurantes = restaurantes.Count()
                 select new { Bairro = g.Key, Percentual = Math.Round(Convert.ToDouble(g.Count() * 100) / totalRestaurantes, 2) }
             ).OrderByDescending(g => g.Percentual);
        }
        
        #endregion

        #region ****************EXERCÍCIO - TODOS OS RESTAURANTES

        public IEnumerable<Restaurante> TodosRestaurantes()
        {
            return (
                from n in restaurantes
                let contato = n.Element("contato")
                let site = contato != null && contato.Element("site") != null ? contato.Element("site").Value : null
                let telefone = contato != null && contato.Element("telefone") != null ? contato.Element("telefone").Value : null
                let localizacao = n.Element("localizacao")
                select new Restaurante
                {
                    Nome = n.Attribute("nome").Value,
                    Capacidade = Convert.ToInt32(n.Attribute("capacidade").Value),
                    Categoria = (Categoria)Enum.Parse(typeof(Categoria), n.Attribute("categoria").Value, ignoreCase: true),
                    Contato = new Contato
                    {
                        Site = site,
                        Telefone = telefone
                    },
                    Localizacao = new Localizacao
                    {
                        Bairro = localizacao.Element("bairro").Value,
                        Logradouro = localizacao.Element("logradouro").Value,
                        Latitude = Convert.ToDouble(localizacao.Element("latitude").Value),
                        Longitude = Convert.ToDouble(localizacao.Element("longitude").Value)
                    }
                }
            );
        }
        
        #endregion


       
    }
}

