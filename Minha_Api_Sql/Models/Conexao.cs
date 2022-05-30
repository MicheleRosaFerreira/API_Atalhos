

using ApiAtalho.Interface;
using System.Data.SqlClient;

namespace ApiAtalho.Models
{
    public class Conexao : IDisposable, IClienteService
    {
        private string _stringconexao = @"Data Source=(LocalDB)\MSSQLLocalDB;Initial Catalog=FAZER_LOGIN;Integrated Security=True";
        private SqlConnection? _conexao
        {
            get
            {
                try
                {
                    var conexao = new SqlConnection(_stringconexao);
                    if (conexao.State == System.Data.ConnectionState.Closed)
                    {
                        conexao.Open();
                    }
                    return conexao;
                }
                catch
                {
                    return null;
                }
            }

        }
        public void Dispose()
        {
            if (_conexao?.State == System.Data.ConnectionState.Open)
            {
                _conexao.Dispose();
            }
        }
           bool IClienteService.Cadastrar(ClienteModels cliente)
        {
            try
            {
                string stringSql = "INSERT INTO ApiAtalho (Nome, _Url , Email , Senha) " +
                    "VALUES (@Nome, @_Url, @Email,@Senha)";
                SqlCommand sqlCommand = new SqlCommand(stringSql);

                sqlCommand.Parameters.AddWithValue("@Nome", cliente.Nome);
                sqlCommand.Parameters.AddWithValue("@_Url", cliente.Url);
                sqlCommand.Parameters.AddWithValue("@Email", cliente.Email);
                sqlCommand.Parameters.AddWithValue("@Senha", cliente.Senha);

                sqlCommand.Connection = _conexao;
                if (sqlCommand.ExecuteNonQuery() > 0)
                {
                    return true;
                }
                return false;
            }
            catch
            {
                return false;
            }
            finally
            {
                _conexao?.Dispose();

            }
        }


        public List<ClienteModels>? BuscarTodos()
        {
            try
            {
                string stringSql = "SELECT * FROM ApiAtalho;";

                SqlCommand sqlCommand = new SqlCommand(stringSql);

                sqlCommand.Connection = _conexao;
                SqlDataReader reader = sqlCommand.ExecuteReader();

                if (reader.HasRows == false)
                    return null;
                else
                {
                    var lista = new List<ClienteModels>();
                    while (reader.Read())
                    {
                        ClienteModels clienteModel = new ClienteModels()
                        {
                            Nome= reader["Nome"].ToString(),
                            Url = reader["_Url"].ToString(),
                            Email = reader["Email"].ToString(),
                            Senha= reader["Senha"].ToString()
                        };

                        lista.Add(clienteModel);
                    }
                    return lista;
                }
            }
            catch
            {
                return null;
            }
            finally
            {
                _conexao?.Dispose();
            }
        }

        public bool Deletar(int Id)
        {

            try
            {
                string stringSql = "DELETE FROM ApiAtalho WHERE Id=@Id ";
                SqlCommand sqlCommand = new SqlCommand(stringSql);

                sqlCommand.Parameters.AddWithValue("@id", Id);

                sqlCommand.Connection = _conexao;

                if (sqlCommand.ExecuteNonQuery() > 0)
                {
                    return true;

                }
                return false;
            }


            catch
            {
                return false;
            }

            finally
            {
                _conexao?.Dispose();
            }
        } 
    }
    }






