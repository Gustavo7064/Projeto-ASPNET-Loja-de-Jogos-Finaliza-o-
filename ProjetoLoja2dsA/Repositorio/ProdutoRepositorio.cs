using MySql.Data.MySqlClient;
using ProjetoLoja2dsA.Models;

namespace ProjetoLoja2dsA.Repositorio
{
    public class ProdutoRepositorio(IConfiguration configuration)
    {// Declara um campo privado somente leitura para armazenar a string de conexão com o MySQL.
        private readonly string _conexaoMySQL = configuration.GetConnectionString("ConexaoMySQL");

        //METODO CADSTRAR USUARIO

        public void AdicionarProduto(Produto produto)
        {
            using (var conexao = new MySqlConnection(_conexaoMySQL))
            {
                conexao.Open();
                var cmd = conexao.CreateCommand();
                // Cria um novo comando SQL para inserir dados na tabela 'cliente'
                cmd.CommandText = "INSERT INTO Produto (nome,descricao,preco,categoria) VALUES (@nome, @descricao, @preco,@categoria )";

                // Adiciona um parâmetro para o email, definindo seu tipo e valor
                cmd.Parameters.Add("@nome", MySqlDbType.VarChar).Value = produto.Nome;
                // Adiciona um parâmetro para o senha, definindo seu tipo e valor
                cmd.Parameters.Add("@descricao", MySqlDbType.VarChar).Value = produto.Descricao;

                cmd.Parameters.Add("@preco", MySqlDbType.Decimal).Value = produto.Preco;

                cmd.Parameters.Add("@categoria", MySqlDbType.VarChar).Value = produto.Categoria;

                // Executa o comando SQL de inserção e retorna o número de linhas afetadas
                cmd.ExecuteNonQuery();
                // Fecha explicitamente a conexão com o banco de dados 
                conexao.Close();

            }
        }

    }




}
