namespace ProdutosAPI.Dtos
{
    public class ProdutoDTO
    {
        public int ProdutoId { get; private set; }
        public string Nome { get; set; } = string.Empty;
        public string Descricao { get; set; } = string.Empty;
        public float Preco { get; set; }
       
        public void SetNewId(int id)
        {
            ProdutoId = id;
        }
    }
}
