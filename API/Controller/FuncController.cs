namespace API.Data;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;


[Route("api/[controller]")]
[ApiController]
public class FuncionarioController : ControllerBase
{
    private readonly AppDataContext _context;

    public FuncionarioController(AppDataContext context)
    {
        _context = context;
    }

    [HttpPost("cadastrar")]
    public async Task<IActionResult> CadastrarFuncionario(Funcionario funcionario)
    {
        _context.Funcionarios.Add(funcionario);
        await _context.SaveChangesAsync();
        return Ok(funcionario);
    }

    [HttpGet("listar")]
    public async Task<ActionResult<IEnumerable<Funcionario>>> ListarFuncionarios()
    {
        var funcionarios = await _context.Funcionarios.ToListAsync();
        return Ok(funcionarios);
    }
}
