using SistemaFuncionarios.Enums;

namespace SistemaFuncionarios.Classes;

public class Desenvolvedor : Funcionario
{
    public Desenvolvedor(string nome, string cpf, DateTime dataAdmissao) : base(nome, cpf, dataAdmissao)
    {
        TipoFuncionario = TipoFuncionarioEnum.Desenvolvedor;
        PorcentagemBonus = 0.15m;
    }

    public override decimal CalcularBonus()
    {
        decimal calculoBonus = SalarioMinimo * PorcentagemBonus;
        return calculoBonus;
    }
}
