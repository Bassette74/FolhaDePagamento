
namespace API;



public class CalculadoraSalario
{
    
    public decimal CalcularImpostoRenda(decimal salarioBruto)
    {
        decimal impostoDeRenda = 0; 
        return impostoDeRenda;
    }

    
    public decimal CalcularINSS(decimal salarioBruto)
    {
        
        decimal inss = 0; 
        return inss;
    }

    
    public decimal CalcularFGTS(decimal salarioBruto)
    {
        
        decimal fgts = salarioBruto * 0.08m; 
        return fgts;
    }

    
    public decimal CalcularSalarioLiquido(decimal horasTrabalhadas, decimal valorHora, int mes, int ano)
    {
        
        decimal salarioBruto = horasTrabalhadas * valorHora;
        decimal impostoRenda = CalcularImpostoRenda(salarioBruto);
        decimal inss = CalcularINSS(salarioBruto);
        decimal fgts = CalcularFGTS(salarioBruto);

        
        decimal salarioLiquido = salarioBruto - impostoRenda - inss;

        return salarioLiquido;
    }

    internal decimal CalcularSalarioLiquido(object horasTrabalhadas, object valorHora, int mes, int ano)
    {
        throw new NotImplementedException();
    }
}

