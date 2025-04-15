public class ProdutoAtributo
{
    public int Id { get; set; }
    public string Nome { get; set; } = string.Empty;
    public string Valor { get; set; } = string.Empty;

    public int ProdutoId { get; set; }
    public Produto? Produto { get; set; }

}
