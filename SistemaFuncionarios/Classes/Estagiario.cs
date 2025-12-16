using SistemaFuncionarios.Enums;

namespace SistemaFuncionarios.Classes;

public class Estagiario : Funcionario
{
    public Estagiario(string nome, string cpf, DateTime dataAdmissao) : base(nome, cpf, dataAdmissao)
    {
        TipoFuncionario = TipoFuncionarioEnum.Estagiario;
        PorcentagemBonus = 0.05m;
    }

    public bool CumpriuPeriodoProbatorio()
    {
        int duracaoMeses = 3;

        DateTime dataFimPeriodo = DataAdmissao.AddMonths(duracaoMeses);
        if(DateTime.Today >= dataFimPeriodo)
            return true;
        return false;
    }
    public override decimal CalcularBonus()
    {
        if (CumpriuPeriodoProbatorio())
        {
            decimal calculoBonus = SalarioMinimo * PorcentagemBonus;
            return calculoBonus;
        }
        return 0;
    }
}
