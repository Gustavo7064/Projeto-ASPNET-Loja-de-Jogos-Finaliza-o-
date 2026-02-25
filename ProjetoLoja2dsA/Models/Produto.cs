namespace ProjetoLoja2dsA.Models
{
    public class Produto
    {
        public int? Id { get; set; } //ACESSORES REALIZANDO O ENCAPSULAMENTO DOS DADOS
        public string? Nome { get; set; }
        public string? Descricao { get; set; }
        public decimal? Preco { get; set; }
        public string? Categoria { get; set; }
    }
}
