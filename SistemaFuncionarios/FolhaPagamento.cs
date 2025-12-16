using SistemaFuncionarios.Classes;
using SistemaFuncionarios.Enums;

namespace SistemaFuncionarios;
public class FolhaPagamento
{
    public void RelatorioFolhaPagamento(List<Funcionario> funcionarios)
    {
        Console.WriteLine("----- Folha de Pagamento -------\n");
        Console.WriteLine($"Data do relatorio: {DateTime.Now}\n");
        
        var ordenarPorSalario = funcionarios.OrderByDescending(funcionario => funcionario.CalcularSalarioLiquido()).ToList();
        ordenarPorSalario.ForEach(funcionario => Console.WriteLine(funcionario.ToString()));
    }

    public void GerarRelatorioEstagiarios(List<Funcionario> funcionarios)
    {
        Console.WriteLine("\n------- Relatorio estagiarios -------\n");

        var listEstagiarios = funcionarios.OrderByDescending(estagiario => estagiario.CalcularSalarioLiquido())
        .Where(estagiario => estagiario.TipoFuncionario == TipoFuncionarioEnum.Estagiario).ToList();

        listEstagiarios.ForEach(estagiario => Console.WriteLine(estagiario.ToString()));
    }
}
