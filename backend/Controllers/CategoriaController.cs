using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[ApiController]
[Route("api/[controller]")]
public class CategoriaController : ControllerBase
{
    private readonly AppDbContext _context;

    public CategoriaController(AppDbContext context)
    {
        _context = context;
    }

    [HttpPost]
    [Authorize(Roles = "Administrador")]
    public async Task<IActionResult> CriarCategoria([FromBody] CategoriaDTO dto)
    {
        var categoria = new Categoria
        {
            Nome = dto.Nome,
            Atributos = dto.Atributos.Select(a => new CategoriaAtributo
            {
                Nome = a.Nome,
            }).ToList()
        };

        _context.Categorias.Add(categoria);
        await _context.SaveChangesAsync();


        var resposta = new
        {
            categoria.Id,
            categoria.Nome,
            Atributos = categoria.Atributos.Select(a => new
            {
                a.Id,
                a.Nome
            })
        };

        return Ok(resposta);
    }


    [HttpGet]
    [AllowAnonymous]
    public async Task<IActionResult> GetCategorias()
    {
        var categorias = await _context.Categorias
            .Include(c => c.Atributos)
            .ToListAsync();

        var categoriaDTOs = categorias.Select(c => new CategoriaResponseDTO
        {
            Id = c.Id,
            Nome = c.Nome,
            Atributos = c.Atributos.Select(a => new CategoriaAtributoDTO
            {
                Nome = a.Nome
            }).ToList()
        }).ToList();

        return Ok(categoriaDTOs);
    }


}
