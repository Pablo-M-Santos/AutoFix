public class ProdutoDTO
{
    public string Nome { get; set; } = string.Empty;
    public decimal Preco { get; set; }
    public int CategoriaId { get; set; }

    public List<ProdutoAtributoDTO> Atributos { get; set; } = new();
}

public class ProdutoAtributoDTO
{
    public string Nome { get; set; } = string.Empty;
    public string Valor { get; set; } = string.Empty;
}

public class ProdutoRespostaDTO
{
    public int Id { get; set; }
    public string Nome { get; set; } = string.Empty;
    public decimal Preco { get; set; }
    public int CategoriaId { get; set; }
    public string CategoriaNome { get; set; } = string.Empty;

    public List<ProdutoAtributoDTO> Atributos { get; set; } = new();
}