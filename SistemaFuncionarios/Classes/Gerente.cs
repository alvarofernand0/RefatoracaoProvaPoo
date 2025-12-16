using SistemaFuncionarios.Enums;

namespace SistemaFuncionarios.Classes;

public class Gerente : Funcionario
{
    public Gerente(string nome, string cpf, DateTime dataAdmissao) : base(nome, cpf, dataAdmissao)
    {
        TipoFuncionario = TipoFuncionarioEnum.Gerente;
        PorcentagemBonus = 0.20m;
    }

    public override decimal CalcularBonus() // 0.20m
    {
        decimal calculoBonus = SalarioMinimo * PorcentagemBonus;
        return calculoBonus;
    }
}
