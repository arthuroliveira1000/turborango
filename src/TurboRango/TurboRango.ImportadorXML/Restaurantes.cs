using System;
using System.Data;
using System.Data.SqlClient;
using TurboRango.Dominio;
namespace TurboRango.ImportadorXML
{
    class Restaurantes
    {
        private string connectionString { get; set; }

        public Restaurantes(string connectionString)
        {
            this.connectionString = connectionString;
        }

        internal void Inserir(Restaurante restaurante)
        {
            using (var connection = new SqlConnection(this.connectionString))
            {
                string comandoSQL = "INSERT INTO [dbo].[Restaurante] ([Nome], [Capacidade], [Categoria], [ID_Contato], [ID_Localizacao]) VALUES (@Nome, @Capacidade, @Categoria, @ContatoId, @LocalizacaoId)";
                using (var inserirRestaurante = new SqlCommand(comandoSQL, connection))
                {
                    inserirRestaurante.Parameters.Add("@Nome", SqlDbType.NVarChar).Value = restaurante.Nome;
                    inserirRestaurante.Parameters.Add("@Capacidade", SqlDbType.NVarChar).Value = restaurante.Capacidade;
                    inserirRestaurante.Parameters.Add("@Categoria", SqlDbType.NVarChar).Value = restaurante.Categoria;
                    inserirRestaurante.Parameters.Add("@ContatoId", SqlDbType.Int).Value = InserirContato(restaurante.Contato);
                    inserirRestaurante.Parameters.Add("@LocalizacaoId", SqlDbType.Int).Value = InserirLocalizacao(restaurante.Localizacao);

                    connection.Open();
                }
            }
        }

        private object InserirLocalizacao(Localizacao localizacao)
        {
            using (var connection = new SqlConnection(this.connectionString))
            {
                string comandoSQL = "INSERT INTO [dbo].[Localizacao] ([Bairro], [Logradouro], [Latitude], [Longitude]) VALUES (@Bairro, @Logradouro, @Latitude, @Longitude)";
                using (var inseriLocalizacao = new SqlCommand(comandoSQL, connection))
                {
                    inseriLocalizacao.Parameters.Add("@Bairro", SqlDbType.NVarChar).Value = localizacao.Bairro;
                    inseriLocalizacao.Parameters.Add("@Logradouro", SqlDbType.NVarChar).Value = localizacao.Logradouro;
                    inseriLocalizacao.Parameters.Add("@Latitude", SqlDbType.Float).Value = localizacao.Latitude;
                    inseriLocalizacao.Parameters.Add("@Longitude", SqlDbType.Float).Value = localizacao.Longitude;

                    connection.Open();
                    int idCriado = Convert.ToInt32(inseriLocalizacao.ExecuteScalar());
                    return idCriado;
                }
            }
        }

        private int InserirContato(Contato contato)
        {
            using (var connection = new SqlConnection(this.connectionString))
            {
                string comandoSQL = "INSERT INTO [dbo].[Contato] ([Site], [Telefone]) VALUES (@Site, @Telefone)";
                using (var inseriContato = new SqlCommand(comandoSQL, connection))
                {
                    inseriContato.Parameters.Add("@Site", SqlDbType.NVarChar).Value = contato.Site;
                    inseriContato.Parameters.Add("@Telefone", SqlDbType.NVarChar).Value = contato.Telefone;

                    connection.Open();
                    int idCriado = Convert.ToInt32(inseriContato.ExecuteScalar());
                    return idCriado;
                }
            }
        }
    }
}
