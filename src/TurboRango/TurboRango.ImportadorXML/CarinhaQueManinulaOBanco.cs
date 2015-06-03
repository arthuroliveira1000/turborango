using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TurboRango.Dominio;

namespace TurboRango.ImportadorXML
{
    class CarinhaQueManinulaOBanco
    {
        private string connectionString; //ADO.NET  - FRAMEWORK DE ACESSO A DADOS 
                                         //EQUIVALENTE AO JDBC DO JAVA

        public CarinhaQueManinulaOBanco(string connectionString)
        {
            this.connectionString = connectionString;
        }

        internal void Inserir(Contato contato)
        {
            using (var connection = new SqlConnection(this.connectionString))
            {
                string comandoSQL = "INSERT INTO [dbo].[Contato] ([Site], [Telefone]) VALUES (@Site, @Telefone)";
                using (var inserirContato = new SqlCommand(comandoSQL, connection))
                {
                    inserirContato.Parameters.Add("@Site", SqlDbType.NVarChar).Value = contato.Site;
                    inserirContato.Parameters.Add("@Telefone", SqlDbType.NVarChar).Value = contato.Telefone;

                    connection.Open();
                    int resultado = inserirContato.ExecuteNonQuery();
                }
            }
        }

        internal IEnumerable<Contato> GetContatos()
        {
            using (var connection = new SqlConnection(this.connectionString))
            {
                string comandoSQL = "SELECT [Site], [Telefone] FROM [dbo].[Contato] (nolock)";
                using (var selecionarContatos = new SqlCommand(comandoSQL, connection))
                {
                    connection.Open();
                    var reader = selecionarContatos.ExecuteReader();

                    while(reader.Read()) {
                        string site = reader.GetString(0);
                        string telefone = reader.GetString(1);
                    }
                }
            }
        }
    }
}
