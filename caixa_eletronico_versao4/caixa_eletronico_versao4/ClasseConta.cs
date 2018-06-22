using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace caixa_eletronico_versao4
{
    class ClasseConta
    {
        public string numeroConta { get; set; }
        public string agenciaConta { get; set; }
        public string titularConta { get; set; }
        public float saldo { get; set; }
        //public int[] cedulasValorIndividual = new int[] { 100, 50, 20, 10 };


        public void Sacar10proporcionalInfinitasNotas()
        {
            
            Console.WriteLine("Sacar notas (10,20,50,100) distribuidas proporcionalmente e com infinitas notas disponiveis");
            Console.Write("\nDigite o valor do saque: ");
            int solicitacaoSaque = int.Parse(Console.ReadLine());
            if ((solicitacaoSaque <= saldo) && (solicitacaoSaque > 1) && ((solicitacaoSaque % 10) == 0))
            {
                saldo -= solicitacaoSaque;
                //int[] cedulasValorIndividual = new int[] { 100, 50, 20, 10 };
                //Cedula.cedulasUsadas10= int[] { 0, 0, 0, 0 };
                Cedula.cedulasUsadas10[0] = 0;
                Cedula.cedulasUsadas10[1] = 0;
                Cedula.cedulasUsadas10[2] = 0;
                Cedula.cedulasUsadas10[3] = 0;
                do
                {
                    for (int i = 0; i < Cedula.cedulasValorIndividual10.Length; i++)
                    {
                        if (Cedula.cedulasValorIndividual10[i] <= solicitacaoSaque)
                        {
                            solicitacaoSaque = (solicitacaoSaque - Cedula.cedulasValorIndividual10[i]);
                            Cedula.cedulasUsadas10[i]++;
                        }
                    }
                } while (solicitacaoSaque > 0);
                Console.WriteLine("\nContagem de cedulas sacadas:");
                int somaNotasSaque = 0;
                for (int i = 0; i < Cedula.cedulasUsadas10.Length; i++)
                {
                    somaNotasSaque = ((Cedula.cedulasUsadas10[i] * Cedula.cedulasValorIndividual10[i]) + somaNotasSaque);
                    Console.WriteLine(string.Format("Valor da cédula: {0}, \tquantidade de cedulas: {1}", Cedula.cedulasValorIndividual10[i], Cedula.cedulasUsadas10[i]));
                }
                Console.WriteLine("Somatorio das notas: $ " + somaNotasSaque);
                //Console.WriteLine("\nPressione uma tecla para continuar");
                //Console.ReadKey();
                //Console.WriteLine("----------------------");
            }
            else
            {
                if (solicitacaoSaque > saldo)
                {
                    Console.WriteLine("\nSaldo insuficiente");
                }
                else
                {
                    Console.WriteLine("\nValor inválido");
                }
                //Console.WriteLine("\nPressione uma tecla para continuar");
                //Console.ReadKey();
                //Console.WriteLine("----------------------");
            }
        }

        public void Sacar10minimoLimiteNotas()
        {

            //int[] cedulasContagem = new int[4];
            Cedula.cedulasContagem10[0] = 0;
            Cedula.cedulasContagem10[1] = 0;
            Cedula.cedulasContagem10[2] = 0;
            Cedula.cedulasContagem10[3] = 0;
            Console.WriteLine("Sacar notas (10,20,50,100) distribuindo o minimo de cedulas e com limite de notas na maquina");
            Console.Write("\nDigite o valor do saque: ");
            int solicitacaoSaque = int.Parse(Console.ReadLine());
            bool temNotas = false;
            int TotalEmDinheiro = solicitacaoSaque;
            for (int i = 0; i < Cedula.cedulasValorIndividual10.Length; i++)
            {
                while ((Cedula.cedulasValorIndividual10[i] <= TotalEmDinheiro) && (Cedula.cedulasQtd10[i] > 0) && (Cedula.cedulasContagem10[i] < Cedula.cedulasQtd10[i]))
                {
                    TotalEmDinheiro = (TotalEmDinheiro - Cedula.cedulasValorIndividual10[i]);
                    Cedula.cedulasContagem10[i]++;
                }
            }
            if (TotalEmDinheiro == 0)
            {
                temNotas = true;
            }

            Console.WriteLine("\nContagem de cedulas:");
            TotalEmDinheiro = 0;
            for (int i = 0; i < Cedula.cedulasValorIndividual10.Length; i++)
            {
                TotalEmDinheiro = (Cedula.cedulasValorIndividual10[i] * Cedula.cedulasQtd10[i]) + TotalEmDinheiro;
                Console.WriteLine(string.Format("valor: {0}, \tquantidade em caixa: {1}, \tcontagem: {2}", Cedula.cedulasValorIndividual10[i], Cedula.cedulasQtd10[i], Cedula.cedulasContagem10[i]));
            }
            Console.WriteLine("Valor total em dinheiro no caixa eletronico: $ " + TotalEmDinheiro);

            if ((solicitacaoSaque <= saldo) && (solicitacaoSaque > 1) && ((solicitacaoSaque % 10) == 0))
            {
                if (temNotas)
                {
                    saldo -= solicitacaoSaque;

                    //int[] cedulasUsadas = new int[4];
                    Cedula.cedulasUsadas10[0] = 0;
                    Cedula.cedulasUsadas10[1] = 0;
                    Cedula.cedulasUsadas10[2] = 0;
                    Cedula.cedulasUsadas10[3] = 0;
                    for (int i = 0; i < Cedula.cedulasValorIndividual10.Length; i++)
                    {
                        while ((Cedula.cedulasValorIndividual10[i] <= solicitacaoSaque) && (Cedula.cedulasQtd10[i] > 0))
                        {
                            solicitacaoSaque = (solicitacaoSaque - Cedula.cedulasValorIndividual10[i]);
                            Cedula.cedulasUsadas10[i]++;
                            Cedula.cedulasQtd10[i]--;
                        }
                    }

                    Console.WriteLine("\nContagem de cedulas sacadas:");
                    int somaNotasSaque = 0;
                    for (int i = 0; i < Cedula.cedulasUsadas10.Length; i++)
                    {
                        somaNotasSaque = (Cedula.cedulasUsadas10[i] * Cedula.cedulasValorIndividual10[i]) + somaNotasSaque;
                        Console.WriteLine(string.Format("Valor da cédula: {0}, \tquantidade de cedulas: {1}", Cedula.cedulasValorIndividual10[i], Cedula.cedulasUsadas10[i]));
                    }
                    Console.WriteLine("Somatorio das notas sacadas: $ " + somaNotasSaque);
                    TotalEmDinheiro = 0;
                    Console.WriteLine("\nCedulas disponiveis:");
                    for (int i = 0; i < Cedula.cedulasValorIndividual10.Length; i++)
                    {
                        Console.WriteLine(string.Format("Valor da cédula: {0}, \tquantidade de cedulas: {1}", Cedula.cedulasValorIndividual10[i], Cedula.cedulasQtd10[i]));
                        TotalEmDinheiro = (Cedula.cedulasValorIndividual10[i] * Cedula.cedulasQtd10[i]) + TotalEmDinheiro;
                    }
                    Console.WriteLine("Valor total em dinheiro no caixa eletronico: $ " + TotalEmDinheiro);
                    //Console.WriteLine("\nPressione uma tecla para continuar");
                    //Console.ReadKey();
                   //Console.WriteLine("----------------------");
                }
                else
                {
                    Console.WriteLine("\nNao ha notas disponiveis. Operacao nao realizada.");
                    Console.WriteLine("\nCedulas disponiveis no caixa eletronico:");
                    TotalEmDinheiro = 0;
                    for (int i = 0; i < Cedula.cedulasValorIndividual10.Length; i++)
                    {
                        Console.WriteLine(string.Format("Valor da cédula: {0}, \tquantidade de cedulas: {1}", Cedula.cedulasValorIndividual10[i], Cedula.cedulasQtd10[i]));
                        TotalEmDinheiro = (Cedula.cedulasValorIndividual10[i] * Cedula.cedulasQtd10[i]) + TotalEmDinheiro;
                    }
                    Console.WriteLine("Valor total em dinheiro no caixa eletronico: $ " + TotalEmDinheiro);
                    //Console.WriteLine("\nPressione uma tecla para continuar");
                    //Console.ReadKey();
                }
            }
            else
            {
                if (solicitacaoSaque > saldo)
                {
                    Console.WriteLine("\nSaldo insuficiente");
                }
                else
                {
                    Console.WriteLine("\nValor inválido");
                }
                //Console.WriteLine("\nPressione uma tecla para continuar");
                //Console.ReadKey();
                //Console.WriteLine("----------------------");
            }
        }

        public void Depositar()
        {
            Console.WriteLine("Depositar");
            Console.Write("\nDigite o valor: ");
            float solicitacaoDeposito = float.Parse(Console.ReadLine());
            if (solicitacaoDeposito > 0)
            {
                saldo += solicitacaoDeposito;
                Console.WriteLine("\nOperacao realizada com sucesso!");
                //Console.WriteLine("\nPressione uma tecla para continuar");
                //Console.ReadKey();
                //Console.WriteLine("----------------------");
            }
            else
            {
                Console.WriteLine("\nValor inválido");
                //Console.WriteLine("\nPressione uma tecla para continuar");
                //Console.ReadKey();
                //Console.WriteLine("----------------------");
            }

        }

        public void Transferir()
        {
            Console.WriteLine("Transferir");
            Console.Write("\nDigite o valor da transferencia: ");
            float solicitacaoTransferencia = float.Parse(Console.ReadLine());
            Console.Write("Digite o numero da agencia: ");
            string agenciaDestino = Console.ReadLine();
            Console.Write("Digite o numero da conta: ");
            string contaDestino = Console.ReadLine();
            saldo -= solicitacaoTransferencia;
            Console.WriteLine("\nPressione uma tecla para continuar");
            Console.ReadKey();
        }

        public void Saldo()
        {
            
            Console.WriteLine("\nDados da conta");
            Console.WriteLine(string.Format("Numero da conta: \t{0}", numeroConta));
            Console.WriteLine(string.Format("Numero da agencia: \t{0}", agenciaConta));
            Console.WriteLine(string.Format("Nome do titular: \t{0}", titularConta));
            Console.WriteLine(string.Format("Saldo disponivel: \t{0}", saldo));
            //Console.WriteLine("\nPressione uma tecla para continuar");
            //Console.ReadKey();
            //Console.WriteLine("----------------------");
        }

        public ClasseConta criarConta()
        {
            ClasseConta novaConta = new ClasseConta(); 
            Console.WriteLine("\nCriar conta");
            Console.Write("Numero da conta: ");
            numeroConta = Console.ReadLine();
            Console.Write("Numero da agencia: ");
            agenciaConta = Console.ReadLine();
            Console.Write("Nome do titular da conta: ");
            titularConta = Console.ReadLine();
            Console.Write("Saldo disponivel: ");
            saldo = float.Parse(Console.ReadLine());
            return novaConta;
        }

            /*
            public void ConfigurarContas(List<contasCadastradas>)
            {
                int opcoes_caixa = 5;
                do
                {
                    Console.WriteLine("\nConfigurar Contas");
                    Console.WriteLine("\n \nEscolha uma das opções:");
                    Console.WriteLine("\t\t\t\t\t\t\t\t    Sair - 0");
                    Console.WriteLine("\n\t1 - Exibir Contas cadastras");
                    Console.WriteLine("\n\t2 - Cadastrar Conta");
                    Console.WriteLine("\n\t3 - Editar Conta");
                    Console.WriteLine("\n\t4 - Excluir Conta");
                    Console.Write("\ndigite sua opção: ");
                    opcoes_caixa = int.Parse(Console.ReadLine());
                    switch (opcoes_caixa)
                    {
                        case 0:
                            break;
                        case 1:

                            break;
                        default:
                            break;
                    }
                } while (opcoes_caixa !=0);
            
            }
            */

    }
}
