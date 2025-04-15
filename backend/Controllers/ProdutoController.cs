using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class ProdutoController : ControllerBase
{
    private readonly ProdutoService _produtoService;

    public ProdutoController(ProdutoService produtoService)
    {
        _produtoService = produtoService;
    }

    [HttpPost]
    [Authorize(Roles = "Administrador")]
    public async Task<IActionResult> CriarProduto([FromBody] ProdutoDTO dto)
    {
        var produto = await _produtoService.CriarProdutoAsync(dto);
        return CreatedAtAction(nameof(GetProdutos), new { id = produto.Id }, produto);
    }

    [HttpGet]
    [AllowAnonymous]
    public async Task<IActionResult> GetProdutos()
    {
        var produtos = await _produtoService.ListarProdutosAsync();
        return Ok(produtos);
    }

}
