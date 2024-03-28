using System;

namespace ContaBancariaOO
{
    class Conta
    {
        private string _nomeTitular;
        private double _saldo;

        public int NumeroConta { get; }
        public int Quantidade { get; set; }

        public string NomeTitular
        {
            get
            {
                return _nomeTitular;
            }
            set 
            {
                _nomeTitular = value; 
            }
        }

        public double Saldo
        {
            get {
                return _saldo;
            }
            set {
                _saldo = value;
            }
        }

        private static int proximoNumeroConta = 1000;

        public Conta()
        {
            NumeroConta = proximoNumeroConta++;
            Console.WriteLine("Digite o nome do titular da conta:");
            NomeTitular = Console.ReadLine();

            Console.WriteLine("Deseja realizar um depósito inicial? (s/n):");
            string resposta = Console.ReadLine().ToLower();
            double saldoInicial = 0;

            if (resposta == "s")
            {
                Console.WriteLine("Digite o valor do depósito inicial:");
                saldoInicial = double.Parse(Console.ReadLine());
            }

            if (saldoInicial > 0)
                Saldo = saldoInicial;

            ExibirInformacoes();
            RealizarOperacao("depositar");
            RealizarOperacao("sacar");
        }

        public static Conta CriarConta()
        {
            return new Conta();
        }

        public static Conta CriarConta(string nomeTitular)
        {
            return new Conta { NomeTitular = nomeTitular };
        }

        public static Conta CriarConta(string nomeTitular, double saldoInicial)
        {
            return new Conta { NomeTitular = nomeTitular, Saldo = saldoInicial };
        }

        public void Depositar(double valor)
        {
            Saldo += valor;
            Console.WriteLine("----------------------------------------");
            Console.WriteLine($" Depositado com sucesso.\n Novo saldo: {Saldo.ToString("C")}");
            Console.WriteLine("----------------------------------------");
        }

        public bool Sacar(double valor)
        {
            Saldo -= valor;
            Console.WriteLine("----------------------------------------");
            Console.WriteLine($" Saque de {valor.ToString("C")} realizado com sucesso.\n Novo saldo: {Saldo.ToString("C")}");
            Console.WriteLine("----------------------------------------");
            return true;
        }

        public override string ToString()
        {
            return $"Conta {NumeroConta}\nTitular: {NomeTitular}\nSaldo: {Saldo.ToString("C")}";
        }

        private void ExibirInformacoes()
        {
            Console.WriteLine("----------------------------------------");
            Console.WriteLine(ToString());
            Console.WriteLine("----------------------------------------");
        }

        private void RealizarOperacao(string operacao)
        {
            Console.WriteLine($"\nDigite o valor para {operacao}:");
            double valor = double.Parse(Console.ReadLine());

            if (operacao == "sacar")
                Sacar(valor + 5.0);
            else
                Depositar(valor);
        }
    }

}
