namespace API.Models;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using API;
using System.Threading.Tasks;
using API.Data;

[Route("api/[controller]")]
[ApiController]
public class FolhaPagamentoController : ControllerBase
{
    private readonly AppDataContext _context;
    private readonly CalculadoraSalario _calculadoraSalario;

    public FolhaPagamentoController(AppDataContext context)
    {
        _context = context;
        _calculadoraSalario = new CalculadoraSalario(); // Crie uma instância da CalculadoraSalario
    }

    // POST api/folha/cadastrar
    [HttpPost("cadastrar")]
    public async Task<IActionResult> CadastrarFolhaPagamento(FolhaPagamento folhaPagamento)
    {
        // Adicione a folha de pagamento ao contexto e salve no banco de dados
        _context.FolhasPagamento.Add(folhaPagamento);
        await _context.SaveChangesAsync();

        // Retorna uma resposta de sucesso com a folha de pagamento cadastrada
        return Ok(folhaPagamento);
    }

    // GET api/folha/listar
    [HttpGet("listar")]
    public async Task<ActionResult<IEnumerable<FolhaPagamento>>> ListarFolhasPagamento()
    {
        // Recupere a lista de folhas de pagamento do banco de dados
        var folhasPagamento = await _context.FolhasPagamento.ToListAsync();

        // Retorna a lista de folhas de pagamento como uma resposta
        return Ok(folhasPagamento);
    }

    // POST api/folha/calcularsalario
    [HttpPost("calcularsalario")]
    public IActionResult CalcularSalario(FolhaPagamento folhaPagamento)
    {
        // Use a CalculadoraSalario para calcular o salário líquido
        decimal salarioLiquido = _calculadoraSalario.CalcularSalarioLiquido(
            folhaPagamento.HorasTrabalhadas, 
            folhaPagamento.ValorHora, 
            folhaPagamento.Mes, 
            folhaPagamento.Ano
        );

        // Atualize o objeto de folha de pagamento com o salário líquido calculado
        folhaPagamento.SalarioLiquido = salarioLiquido;

        return Ok(folhaPagamento);
    }
}

