using Microsoft.Data.SqlClient;
using System.Collections.Generic;

namespace BibliotecaWeb
{
    public class LivroRepository
    {
        public static void CriarLivro(string connectionString, string Titulo, string Autor, int AnoPublicacao, bool Disponivel, string CaminhoImagem)
        {
            using (SqlConnection conexao = new SqlConnection(connectionString))
            {
                conexao.Open();
                string sql = "INSERT INTO Livros (Titulo, Autor, AnoPublicacao, Disponivel, CaminhoImagem) VALUES (@Titulo, @Autor, @AnoPublicacao, @Disponivel, @CaminhoImagem)";
                using (SqlCommand comando = new SqlCommand(sql, conexao))
                {
                    comando.Parameters.AddWithValue("@Titulo", Titulo);
                    comando.Parameters.AddWithValue("@Autor", Autor);
                    comando.Parameters.AddWithValue("@AnoPublicacao", AnoPublicacao);
                    comando.Parameters.AddWithValue("@Disponivel", Disponivel);
                    comando.Parameters.AddWithValue("@CaminhoImagem", CaminhoImagem);
                    comando.ExecuteNonQuery();
                }
            }
        }

        public static List<Dictionary<string, object>> ObterLivros(string connectionString)
        {
            List<Dictionary<string, object>> livros = new List<Dictionary<string, object>>();
            using (SqlConnection conexao = new SqlConnection(connectionString))
            {
                conexao.Open();
                string sql = "SELECT * FROM Livros ORDER BY Ordem";
                using (SqlCommand comando = new SqlCommand(sql, conexao))
                {
                    using (SqlDataReader leitor = comando.ExecuteReader())
                    {
                        while (leitor.Read())
                        {
                            Dictionary<string, object> livro = new Dictionary<string, object>();
                            livro["Id"] = leitor["Id"];
                            livro["Titulo"] = leitor["Titulo"];
                            livro["Autor"] = leitor["Autor"];
                            livro["AnoPublicacao"] = leitor["AnoPublicacao"];
                            livro["Disponivel"] = leitor["Disponivel"];
                            livro["CaminhoImagem"] = leitor["CaminhoImagem"];
                            livros.Add(livro);

                        }
                    }
                }
            }
            return livros;
        }

        public static Dictionary<string, object> ObterLivroPorId (string connectionString, int Id)
        {
            Dictionary<string, object> livro = null;
            using (SqlConnection conexao = new SqlConnection(connectionString))
            {
                conexao.Open();
                string sql = "SELECT * FROM Livros WHERE Id = @Id";

                using (SqlCommand comando = new SqlCommand(sql, conexao))
                {
                    comando.Parameters.AddWithValue("@Id", Id);
                    using (SqlDataReader leitor = comando.ExecuteReader())
                    {
                        if (leitor.Read())
                        {
                            livro = new Dictionary<string, object>();
                            livro["Id"] = leitor["Id"];
                            livro["Titulo"] = leitor["Titulo"];
                            livro["Autor"] = leitor["Autor"];
                            livro["AnoPublicacao"] = leitor["AnoPublicacao"];
                            livro["Disponivel"] = leitor["Disponivel"];
                            livro["CaminhoImagem"] = leitor["CaminhoImagem"];
                        }
                    }

                }
            }
            return livro;
        }

        public static void AtualizarLivro(string connectionString, string Titulo, string Autor, int AnoPublicacao, bool Disponivel, string CaminhoImagem, int Id)
        {
            using (SqlConnection conexao = new SqlConnection(connectionString))
            {
                conexao.Open();
                string sql = "UPDATE Livros SET Titulo = @Titulo, Autor = @Autor, AnoPublicacao = @AnoPublicacao, Disponivel = @Disponivel, CaminhoImagem = @CaminhoImagem WHERE Id = @Id";

                using (SqlCommand comando = new SqlCommand(sql, conexao))
                {
                    comando.Parameters.AddWithValue("@Titulo", Titulo);
                    comando.Parameters.AddWithValue("@Autor", Autor);
                    comando.Parameters.AddWithValue("@AnoPublicacao", AnoPublicacao);
                    comando.Parameters.AddWithValue("@Disponivel", Disponivel);
                    comando.Parameters.AddWithValue("@CaminhoImagem", (object)CaminhoImagem ?? DBNull.Value);
                    comando.Parameters.AddWithValue("@Id", Id);
                    comando.ExecuteNonQuery();
                }
            }
        }

        public static void ExcluirLivro(string connectionString, int Id)
        {
            using (SqlConnection conexao = new SqlConnection(connectionString))
            {
                conexao.Open();
                string sql = "DELETE FROM Livros WHERE Id = @Id";

                using (SqlCommand comando = new SqlCommand(sql, conexao))
                {
                    comando.Parameters.AddWithValue("@Id", Id);
                    comando.ExecuteNonQuery ();
                }
            }
        }

        public static void AtualizarOrdem(string connectionString, List<int> ids)
        {
            using (SqlConnection conexao = new SqlConnection(connectionString))
            {
                conexao.Open();
                for (int i = 0; i < ids.Count; i++)
                {
                    string sql = "UPDATE Livros SET Ordem = @Ordem WHERE Id = @Id";
                    using (SqlCommand comando = new SqlCommand(sql, conexao))
                    {
                        comando.Parameters.AddWithValue("@Ordem", i);
                        comando.Parameters.AddWithValue("@Id", ids[i]);
                        comando.ExecuteNonQuery();
                    }
                }
            }
        }
    }
}