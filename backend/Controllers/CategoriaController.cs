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


    [HttpPut("{id}")]
    [Authorize(Roles = "Administrador")]
    public async Task<IActionResult> AtualizarCategoria(int id, [FromBody] CategoriaDTO dto)
    {
        var categoria = await _context.Categorias
            .Include(c => c.Atributos)
            .FirstOrDefaultAsync(c => c.Id == id);

        if (categoria == null)
            return NotFound("Categoria não encontrada");

        categoria.Nome = dto.Nome;

        // Remove os atributos antigos
        _context.RemoveRange(categoria.Atributos);

        // Adiciona os novos
        categoria.Atributos = dto.Atributos.Select(a => new CategoriaAtributo
        {
            Nome = a.Nome
        }).ToList();

        await _context.SaveChangesAsync();

        return NoContent();
    }

    [HttpDelete("{id}")]
    [Authorize(Roles = "Administrador")]
    public async Task<IActionResult> DeletarCategoria(int id)
    {
        var categoria = await _context.Categorias
            .Include(c => c.Atributos)
            .FirstOrDefaultAsync(c => c.Id == id);

        if (categoria == null)
            return NotFound("Categoria não encontrada");

        _context.RemoveRange(categoria.Atributos); // Remove os atributos
        _context.Categorias.Remove(categoria);     // Remove a categoria

        await _context.SaveChangesAsync();

        return NoContent();
    }




}
