using SistemaBancario.Enums;

namespace SistemaBancario.Classes;
public class TransacaoBancaria
{
    public decimal Valor { get; }
    public DateTime DataTransacao { get; }
    public TipoOperacaoEnum TipoOperacao { get;}
    public bool Sucesso { get; }

    public TransacaoBancaria(decimal valor, TipoOperacaoEnum tipoOperacao, bool sucesso)
    {
        Valor = valor;
        DataTransacao = DateTime.Now;
        TipoOperacao = tipoOperacao;
        Sucesso = sucesso;
    }

    public override string ToString() =>
        $"Valor: {Valor:C} | DataTransacao: {DataTransacao} | TipoOperacao: {TipoOperacao} | Status: {(Sucesso ? "Operacao bem Sucedida" : "Operacao Falhou")}";
}
