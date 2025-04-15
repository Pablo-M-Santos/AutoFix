public class CategoriaDTO
{
    public string Nome { get; set; } = string.Empty;

    public List<CategoriaAtributoDTO> Atributos { get; set; } = new();
}

public class CategoriaAtributoDTO
{
    public string Nome { get; set; } = string.Empty;

}

public class CategoriaResponseDTO
{
    public int Id { get; set; }
    public string Nome { get; set; } = string.Empty;
    public List<CategoriaAtributoDTO> Atributos { get; set; } = new();
}
