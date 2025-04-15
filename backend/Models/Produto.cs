public class Produto
{
    public int Id { get; set; }
    public string Nome { get; set; } = string.Empty;
    public decimal Preco { get; set; }

    public int CategoriaId { get; set; }
    public Categoria? Categoria { get; set; }


    public ICollection<ProdutoAtributo> Atributos { get; set; } = new List<ProdutoAtributo>();
}
