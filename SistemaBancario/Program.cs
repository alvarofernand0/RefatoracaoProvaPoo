using SistemaBancario.Classes;
using SistemaBancario.Enums;

ContaBancaria contaBancaria = new ContaBancaria("Jusé", "70859746477");
contaBancaria.FazerDeposito(200);
contaBancaria.FazerSaque(201);
contaBancaria.FazerDeposito(2000);
contaBancaria.GerarExtrato();
contaBancaria.GerarExtratoConsolidado(TipoOperacaoEnum.Saque);
contaBancaria.GerarExtratoConsolidado(TipoOperacaoEnum.Deposito);
Console.ReadKey();
