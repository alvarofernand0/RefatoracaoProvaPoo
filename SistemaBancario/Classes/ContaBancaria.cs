using SistemaBancario.Enums;

namespace SistemaBancario.Classes;

public class ContaBancaria
{
    public readonly List<TransacaoBancaria> Transacoes = new List<TransacaoBancaria>();
    public string Titular { get; }
    public string Cpf { get; }
    public decimal Saldo { get; private set; }
    public TipoOperacaoEnum TipoOperacao { get; private set; }

    public ContaBancaria(string titular, string cpf)
    {
        if (string.IsNullOrWhiteSpace(titular))
        {
            Console.WriteLine("Nome do titular não pode ser vazio ou espaço em branco");
            return;
        }
        Titular = titular;

        if (string.IsNullOrWhiteSpace(cpf) || cpf.Length != 11)
        {
            Console.WriteLine($"Cpf não pode ser vazio e deve ter 11 caracteres!, O atual tem {cpf.Length}");
            return;
        }
        Cpf = cpf;
    }

    public void FazerDeposito(decimal valorDeposito)
    {
        bool status;
        if(valorDeposito <= 0)
        {
            Console.WriteLine($"Valor {valorDeposito:C} deve ser maior que zero!");
            status = false;
            Transacoes.Add(new TransacaoBancaria(valorDeposito, TipoOperacaoEnum.Deposito, status));
        }
        Saldo += valorDeposito;
        status = true;
        Transacoes.Add(new TransacaoBancaria(valorDeposito, TipoOperacaoEnum.Deposito, status));
    }

    public void FazerSaque(decimal valorSaque)
    {
        bool status;
        if(valorSaque <= 0 || valorSaque > Saldo)
        {
            Console.WriteLine($"O valor de saque {valorSaque:C} DEVE ser maior que zero e NÃO pode ser maior que o Saldo {Saldo:C}");
            status = false;
            Transacoes.Add(new TransacaoBancaria(valorSaque, TipoOperacaoEnum.Saque, status));
        }
        Saldo -= valorSaque;
        status = true;
        Transacoes.Add(new TransacaoBancaria(valorSaque, TipoOperacaoEnum.Saque, status));
    }

    public void GerarExtrato()
    {
        var listaOrdenada = Transacoes.OrderByDescending(transacao => transacao.Valor).ToList();
        Console.WriteLine("------ Extrato Cliente ------\n");
        foreach(TransacaoBancaria transacao in listaOrdenada)
            Console.WriteLine(transacao.ToString());
    }

    public void GerarExtratoConsolidado(TipoOperacaoEnum tipoOperacao)
    {
        Console.WriteLine("------ Extrato Consolidado ------\n");
        Transacoes
        .Where(tipoTransacao => tipoTransacao.TipoOperacao == tipoOperacao)
        .ToList().ForEach(transacao => Console.WriteLine(transacao.ToString()));
        Console.WriteLine("\n-----------------------------\n");
    }
}
