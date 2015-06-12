namespace TurboRango.Web.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using TurboRango.Dominio;

    internal sealed class Configuration : DbMigrationsConfiguration<TurboRango.Web.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            
            ContextKey = "TurboRango.Web.Models.ApplicationDbContext";
        }

        protected override void Seed(TurboRango.Web.Models.ApplicationDbContext context)
        {
            context.Restaurantes.AddOrUpdate(
                n => n.Nome,
                new Restaurante
                {
                    Nome = "GARFÃO RESTAURANTE E PIZZARIA",
                    Capacidade = 100,
                    Categoria = Categoria.Comum,
                    Contato = new Contato
                    {
                        Site = "www.garfao.com",
                        Telefone = "(51) 3587-7700"
                    },
                    Localizacao = new Localizacao
                    {
                        Bairro = "Liberdade",
                        Logradouro = "Rua Sete de Setembro, 1045 - Liberdade",
                        Latitude = -29.712571,
                        Longitude = -51.13636
                    },
                    Prato = new Prato
                    {
                        Nome = "Alaminuta",
                        DescricaoIngredientes = "Arroz, feijão, alface, bife de carne ou frango, Batata Frita",
                        Preco = 5.0m
                    }
                });

            context.Restaurantes.AddOrUpdate(
                n => n.Nome,
                new Restaurante
                {
                    Nome = "SEMENTE",
                    Capacidade = 40,
                    Categoria = Categoria.CozinhaNatural,
                    Contato = new Contato
                    {
                        Telefone = "3595-5258"
                    },
                    Localizacao = new Localizacao
                    {
                        Bairro = "Centro",
                        Logradouro = "Rua: Joaquim Pedro Soares, 633",
                        Latitude = -29.6812707,                  
                        Longitude = -51.1272292
                    },
                   Prato = new Prato
                   {
                       Nome = "Ensopado de Vagem",
                       DescricaoIngredientes = "Vagem, batata, cenoura e molho",
                       Preco = 8.5m
                   }
                });

            context.Restaurantes.AddOrUpdate(
               n => n.Nome,
               new Restaurante
               {
                   Nome = "OLÉ ARMAZÉM MEXICANO",
                   Capacidade = 30,
                   Categoria = Categoria.CozinhaMexicana,
                   Contato = new Contato
                   {
                       Telefone = "3279-8828"
                   },
                   Localizacao = new Localizacao
                   {
                       Bairro = "Centro",
                       Logradouro = "Rua Gomes Portinho, 448",
                       Latitude = -29.682078,
                       Longitude = -51.125199
                   },
                   Prato = new Prato
                   {
                       Nome = "Paleta",
                       DescricaoIngredientes = "Morango e Leite Condensado",
                       Preco = 5.0m
                   },
                   HorarioRegistro = DateTime.Now
               });

            context.Restaurantes.AddOrUpdate(
              n => n.Nome,
              new Restaurante
              {
                  Nome = "CHURRASCARIA PRIMAVERA",
                  Capacidade = 110,
                  Categoria = Categoria.Churrascaria,
                  Contato = new Contato
                  {
                      Site = "www.grupoprimaveranh.com.br",
                      Telefone = "3595-8081"
                  },
                  Localizacao = new Localizacao
                  {
                      Bairro = "Primavera",
                      Logradouro = "BR 116, 2554, Km 31",
                      Latitude = -29.693741,
                      Longitude = -51.144554
                  },
                  HorarioRegistro = DateTime.Now
              });

            context.Restaurantes.AddOrUpdate(
             n => n.Nome,
             new Restaurante
             {
                 Nome = "SUSHI DAI",
                 Capacidade = 110,
                 Categoria = Categoria.Churrascaria,
                 Localizacao = new Localizacao
                 {
                     Bairro = "Boa Vista",
                     Logradouro = "Bagé, 149",
                     Latitude = -29.68942,
                     Longitude = -51.125224
                 },
                 HorarioRegistro = DateTime.Now
             });


            context.Restaurantes.AddOrUpdate(
             n => n.Nome,
             new Restaurante
             {
                 Nome = "TAKESHI",
                 Capacidade = 35,
                 Categoria = Categoria.CozinhaJaponesa,
                 Contato = new Contato
                 {
                     Telefone = "3066-6660"
                 },
                 Localizacao = new Localizacao
                 {
                     Bairro = "Pátria Nova",
                     Logradouro = "Rua Confraternização, 792",
                     Latitude = -29.698669,
                     Longitude = -51.130195
                 },
                 HorarioRegistro = DateTime.Now
             });

            context.Restaurantes.AddOrUpdate(
           n => n.Nome,
           new Restaurante
           {
               Nome = "HAI SAIKÔ",
               Capacidade = 35,
               Categoria = Categoria.CozinhaJaponesa,
               Contato = new Contato
               {
                   Site = "www.haisaiko.com.br",
                   Telefone = "3593-5757"
               },
               Localizacao = new Localizacao
               {
                   Bairro = "Mauá",
                   Logradouro = "Rua Gomes Portinho, 730",
                   Latitude = -29.684873,
                   Longitude = -51.122252
               },
               HorarioRegistro = DateTime.Now
           });
        }
    }
}
