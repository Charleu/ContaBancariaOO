using System;

namespace ContaBancariaOO
{
    class Program
    {
        static int numeroConta = 1000;

        static void Main(string[] args)
        {
            string nomeTitular;
            double saldo = 0.0;
            Console.WriteLine("Digite o nome do titular da conta:");
            nomeTitular = Console.ReadLine();
            Console.WriteLine("Deseja realizar um depósito inicial? (s/n):");
            if (Console.ReadLine().ToLower() == "s")
            {
                Console.WriteLine("Digite o valor do depósito inicial:");
                saldo += double.Parse(Console.ReadLine());
            }

            ExibirInformacoesConta(numeroConta, nomeTitular, saldo);
            saldo = RealizarOperacao("depositar", saldo);
            saldo = RealizarOperacao("sacar", saldo);

            numeroConta++;
        }

        public static double RealizarOperacao(string operacao, double saldo)
        {
            Console.WriteLine($"\nDigite o valor para {operacao}:");
            double valor = double.Parse(Console.ReadLine());

            if (operacao == "sacar")
                saldo -= valor + 5.0;
            else
                saldo += valor;
            Console.WriteLine("----------------------------------------");
            Console.WriteLine($"Novo saldo após {operacao}: {saldo.ToString("C")}");
            Console.WriteLine("----------------------------------------");

            return saldo;
        }

        public static void ExibirInformacoesConta(int numeroConta, string nomeTitular, double saldo)
        {
            Console.WriteLine("----------------------------------------"); 
            Console.WriteLine($" Conta {numeroConta}\n Titular: {nomeTitular}\n Saldo: {saldo.ToString("C")}");
            Console.WriteLine("----------------------------------------");
        }
    }
}
