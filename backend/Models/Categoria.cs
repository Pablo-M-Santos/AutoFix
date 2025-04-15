public class Categoria
{
    public int Id { get; set; }
    public string Nome { get; set; } = string.Empty;

    public ICollection<CategoriaAtributo> Atributos { get; set; } = new List<CategoriaAtributo>();
}
