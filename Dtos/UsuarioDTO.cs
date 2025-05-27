namespace ProdutosAPI.Dtos
{
    public class UsuarioDTO
    {
        public int UsuarioId { get; private set; }
        public string Nome { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Senha { get; set; } = string.Empty;

        public void SetNewId (int id)
        {
            UsuarioId = id;
        }
    }
}
