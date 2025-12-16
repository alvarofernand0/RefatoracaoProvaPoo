using System.Security.Cryptography.X509Certificates;
using SistemaFuncionarios.Enums;

namespace SistemaFuncionarios.Classes;
public abstract class Funcionario
{
    public string Nome { get; }
    public string Cpf { get; }
    public decimal SalarioMinimo { get; } = 1518;
    public TipoFuncionarioEnum TipoFuncionario { get; protected set; }
    public DateTime DataAdmissao { get; }
    public readonly decimal DescontoInss = 0.08m;
    public decimal PorcentagemBonus { get; protected set; }

    public Funcionario(string nome, string cpf, DateTime dataAdmissao)
    {
        while (true)
        {
            if (string.IsNullOrWhiteSpace(nome))
            {
                Console.WriteLine("Nome não pode ser vazio!");
                continue;
            }

            if(string.IsNullOrWhiteSpace(cpf) || cpf.Length != 11)
            {
                Console.WriteLine("Cpf precisa ter 11 caracteres e não pode ser um espaço vazio ou em branco");
                continue;
            }

            if(dataAdmissao > DateTime.Now)
            {
                Console.WriteLine("Data de admissão não pode ser posterior a data atual");
                continue;
            }
            Nome = nome;
            Cpf = cpf;
            DataAdmissao = dataAdmissao;
            break;
        }
    }

    public abstract decimal CalcularBonus();

    public decimal CalcularSalarioBruto()
    {
        decimal salarioBruto = SalarioMinimo + CalcularBonus();
        return salarioBruto;
    }
    public decimal CalcularSalarioLiquido()
    {
        CalcularSalarioBruto();
        decimal valorDescontoInss = CalcularSalarioBruto() * DescontoInss;
        decimal salarioLiquido = CalcularSalarioBruto() - valorDescontoInss;
        return salarioLiquido;
    }

    public override string ToString() =>
        $"Nome: {Nome} | Cargo: {TipoFuncionario} | SalarioBruto: {CalcularSalarioBruto():C} | SalarioLiquido: {CalcularSalarioLiquido():C}";
}
