using SistemaFuncionarios;
using SistemaFuncionarios.Classes;

FolhaPagamento folhaPagamento = new();
List<Funcionario> funcionarios = new()
{
    new Estagiario("Thales", "11111111111", new DateTime(2025, 12, 01)),
    new Desenvolvedor("Netao", "11111111111", new DateTime(2010, 10, 02)),
    new Desenvolvedor("Naldao", "11111111111", new DateTime(2025, 05, 10)),
    new Gerente("Toinhao", "11111111111", new DateTime(2023, 09, 08)),
    new Estagiario("Joao", "11111111111", new DateTime(2025, 05, 15)),
    new Desenvolvedor("Jose", "11111111111", new DateTime(2014, 03, 14)),
    new Gerente("Maria", "11111111111", new DateTime(2024, 05, 20))
};

folhaPagamento.RelatorioFolhaPagamento(funcionarios);

folhaPagamento.GerarRelatorioEstagiarios(funcionarios);
Console.ReadLine();
