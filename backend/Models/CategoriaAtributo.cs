public class CategoriaAtributo
{
    public int Id { get; set; }
    public string Nome { get; set; } = string.Empty;

    public int CategoriaId { get; set; }
    public Categoria? Categoria { get; set; }

}
