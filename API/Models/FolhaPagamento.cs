namespace API.Models;

public class FolhaPagamento
{
    public int Id { get; set; }
    public int FuncionarioId { get; set; }
    public Funcionario Funcionario { get; set; }
    public int Mes { get; set; }
    public int Ano { get; set; }
    public decimal SalarioBruto { get; set; }
    public decimal SalarioLiquido { get; internal set; }
    public decimal HorasTrabalhadas { get; internal set; }
    public decimal ValorHora { get; internal set; }
}
