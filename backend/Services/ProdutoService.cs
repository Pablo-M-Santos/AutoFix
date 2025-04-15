using Microsoft.EntityFrameworkCore;

public class ProdutoService
{
    private readonly AppDbContext _context;

    public ProdutoService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<ProdutoRespostaDTO> CriarProdutoAsync(ProdutoDTO dto)
    {
        var categoria = await _context.Categorias.FindAsync(dto.CategoriaId);
        if (categoria == null)
            throw new Exception("Categoria não encontrada");

        var produto = new Produto
        {
            Nome = dto.Nome,
            Preco = dto.Preco,
            CategoriaId = dto.CategoriaId,
            Atributos = dto.Atributos.Select(a => new ProdutoAtributo
            {
                Nome = a.Nome,
                Valor = a.Valor
            }).ToList()
        };

        _context.Produtos.Add(produto);
        await _context.SaveChangesAsync();

        return new ProdutoRespostaDTO
        {
            Id = produto.Id,
            Nome = produto.Nome,
            Preco = produto.Preco,
            CategoriaId = produto.CategoriaId,
            CategoriaNome = categoria.Nome,
            Atributos = produto.Atributos.Select(a => new ProdutoAtributoDTO
            {
                Nome = a.Nome,
                Valor = a.Valor
            }).ToList()
        };
    }


    public async Task<List<ProdutoRespostaDTO>> ListarProdutosAsync()
    {
        var produtos = await _context.Produtos
            .Include(p => p.Categoria)
            .Include(p => p.Atributos)
            .ToListAsync();

        return produtos.Select(p => new ProdutoRespostaDTO
        {
            Id = p.Id,
            Nome = p.Nome,
            Preco = p.Preco,
            CategoriaId = p.CategoriaId,
            CategoriaNome = p.Categoria?.Nome ?? string.Empty,
            Atributos = p.Atributos.Select(a => new ProdutoAtributoDTO
            {
                Nome = a.Nome,
                Valor = a.Valor
            }).ToList()
        }).ToList();
    }

}
