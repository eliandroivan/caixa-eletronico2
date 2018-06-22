using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace caixa_eletronico_versao4
{
    class Program
    {
        static void Main(string[] args)
        {
            List<ClasseConta> contasCadastradas = new List<ClasseConta>(); //cria a lista de contas cadastradas
            ClasseConta ContaEmUso = new ClasseConta(); //instancia a classe Conta

            ContaEmUso = new ClasseConta();
            ContaEmUso.agenciaConta = "022";
            ContaEmUso.numeroConta = "14014";
            ContaEmUso.titularConta = "jose";
            ContaEmUso.saldo = 100004;
            contasCadastradas.Add(ContaEmUso);

            ContaEmUso = new ClasseConta();
            ContaEmUso.agenciaConta = "022";
            ContaEmUso.numeroConta = "20020";
            ContaEmUso.titularConta = "maria";
            ContaEmUso.saldo = 100005;
            contasCadastradas.Add(ContaEmUso);

            Cedula.cedulasValorIndividual10 = new int[] { 100, 50, 20, 10 };
            Cedula.cedulasQtd10 = new int[] { 2000, 200, 2000, 2000 };
            Cedula.cedulasUsadas10 = new int[4];
            Cedula.cedulasContagem10 = new int[4];

            /*
            Conta contaCorrente = new Conta(); //instanciar o objeto
            contaCorrente.agenciaConta = "0333";
            contaCorrente.numeroConta = "65333";
            contaCorrente.titularConta = "joao";
            contaCorrente.saldo = 100003;
            //Cedula.cedulasValorIndividual = { 100,50,20,10};
           

            Cedula cedulasCAIXA = new Cedula();
            cedulasCAIXA.cedulasValorIndividual10 = new int[4];
            cedulasCAIXA.cedulasValorIndividual10[0] = 100;
            cedulasCAIXA.cedulasValorIndividual10[1] = 50;
            cedulasCAIXA.cedulasValorIndividual10[2] = 20;
            cedulasCAIXA.cedulasValorIndividual10[3] = 10;
            Cedula.cedulasValorIndividual = new int[] { 100, 50, 20, 10 };
            Cedula.cedulasValorIndividual[0] = 108;
            //            { 100,50,20,10} ;


            //cedulasCAIXA[0] = 100;            ,50,20,10 };
            cedulasCAIXA.SomarCedulasNovo();
            */





            int opcoes_caixa;
            do
            {
                for (int i = 0; i < contasCadastradas.Count; i++)
                {
                    if ((contasCadastradas[i].numeroConta==ContaEmUso.numeroConta) && (contasCadastradas[i].titularConta==ContaEmUso.titularConta))
                    {
                        contasCadastradas[i].saldo = ContaEmUso.saldo;
                    }
                }
                Console.Clear();
                Console.WriteLine("Caixa eletronico");
                Console.WriteLine("--------------------------------------------------------------------------------");
                Console.WriteLine("\n \nEscolha uma das opções:");
                Console.WriteLine("\t\t\t\t\t\t\t\t    Sair - 0");
                Console.WriteLine("\n\t1 - Saldo");
                Console.WriteLine("\n\t2 - Sacar notas (10,20,50,100) distribuidas proporcionalmente e infinitas cedulas");
                Console.WriteLine("\n\t3 - Sacar notas (10,20,50,100) com o minimo possivel e COM LIMITE de cedulas");
                /*
                Console.WriteLine("\n\t3 - Sacar notas de 10 com o minimo possivel e infinitas cedulas");
                Console.WriteLine("\n\t4 - Sacar notas de 10 com o minimo possivel e COM LIMITE de cedulas");
                Console.WriteLine("\n\t5 - Sacar notas de 2 e 5 com o minimo possivel e infinitas cedulas");
                Console.WriteLine("\n\t6 - Sacar notas de 2 e 5 com o minimo possivel e COM LIMITE de cedulas");
                */
                Console.WriteLine("\n\t7 - Depositar");
                //Console.WriteLine("\n\t8 - Transferencia");
                Console.WriteLine("\n\t9 - Configurar contas");
                Console.Write("\ndigite sua opção: ");
                opcoes_caixa = int.Parse(Console.ReadLine());
                Console.Clear();
                Console.WriteLine("-------------------------------------------------------- " + opcoes_caixa);
                switch (opcoes_caixa)
                {
                    case 0:
                        break;
                    case 1:
                        ContaEmUso.Saldo();
                        //contaCorrente.Saldo();
                        break;
                    case 2:
                        ContaEmUso.Sacar10proporcionalInfinitasNotas();
                        // contaCorrente.Sacar10proporcionalInfinitasNotas();
                        break;
                    case 3:
                        ContaEmUso.Sacar10minimoLimiteNotas();
                        //contaCorrente.Sacar10minimoInfinitasNotas();
                        break;
                    case 4:
                        //contaCorrente.Sacar10minimoLimiteNotas();
                        break;
                    case 5:
                        //contaCorrente.Sacar2e5minimoInfinitasNotas();
                        break;
                    case 6:
                        //contaCorrente.Sacar2e5minimoLimiteNotasFinal();
                        break;
                    case 7:
                        ContaEmUso.Depositar();
                        //contaCorrente.Depositar();
                        break;
                    case 8:
                        //contaCorrente.Transferir();
                        break;
                    case 9:
                        ConfigurarContas(contasCadastradas, ContaEmUso);
                        //ContaEmUso.ConfigurarContas(contasCadastradas);
                        /* cadastrar conta
                        Console.WriteLine("exibir contas:");
                        for (int i = 0; i < contasCadastradas.Count; i++)
                        {
                            Console.WriteLine(contasCadastradas[i].titularConta);
                            //Console.WriteLine()
                        }
                        Console.ReadKey();
                        novaConta = new ClasseConta();
                        novaConta.criarConta();                        
                        contasCadastradas.Add(novaConta);
                        */
                        break;
                    default:
                        break;
                }
                if ((opcoes_caixa !=0))
                {
                    Console.WriteLine("\nPressione uma tecla para continuar");
                    Console.ReadKey();
                    Console.WriteLine("----------------------");
                }
                
            } while (opcoes_caixa != 0);
        }

        private static ClasseConta ConfigurarContas(List<ClasseConta> contasCadastradas, ClasseConta ContaEmUso)
        {
            int controle = 10;
            do
            {
                Console.Clear();
                Console.WriteLine("\nConfigurar contas cadastradas");
                Console.WriteLine("\n \nEscolha uma das opções:");
                Console.WriteLine("\t\t\t\t\t\t\t\t    Sair - 0");
                Console.WriteLine("\n\t1 - Exibir Contas cadastras");
                Console.WriteLine("\n\t2 - Cadastrar Conta");
                Console.WriteLine("\n\t3 - Editar Conta");
                Console.WriteLine("\n\t4 - Excluir Conta");
                Console.WriteLine("\n\t5 - Definir Conta utilizada pelo caixa eletronico para saque/deposito");
                Console.Write("\ndigite sua opção: ");
                controle = int.Parse(Console.ReadLine());
                Console.Clear();
                Console.WriteLine("-------------------------------------------------------- " + controle);
                int posicao;
                switch (controle)
                {
                    case 0:
                        break;
                    case 1:
                        Console.WriteLine("\nExibir contas cadastradas");
                        for (int i = 0; i < contasCadastradas.Count; i++)
                        {
                            Console.WriteLine(string.Format("\nPOSICAO NA LISTA: {0}, \t\tTitular da Conta: {1}", i, contasCadastradas[i].titularConta));
                            Console.WriteLine(string.Format("Saldo disponivel: {0}, numero da conta: {1}, numero da agencia: {2}", contasCadastradas[i].saldo, contasCadastradas[i].numeroConta, contasCadastradas[i].agenciaConta));
                            Console.WriteLine("------------------------");
                        }

                        break;
                    case 2:
                        Console.WriteLine("\nCadastrar Conta");

                        ClasseConta novaConta = new ClasseConta();
                        Console.WriteLine("\nCriar conta");
                        Console.Write("Numero da conta: ");
                        novaConta.numeroConta = Console.ReadLine();
                        Console.Write("Numero da agencia: ");
                        novaConta.agenciaConta = Console.ReadLine();
                        Console.Write("Nome do titular da conta: ");
                        novaConta.titularConta = Console.ReadLine();
                        Console.Write("Saldo disponivel: ");
                        novaConta.saldo = float.Parse(Console.ReadLine());
                        contasCadastradas.Add(novaConta);
                        break;
                    case 3:
                        Console.WriteLine("\nEditar Conta\n");
                        for (int i = 0; i < contasCadastradas.Count; i++)
                        {
                            Console.WriteLine(string.Format("POSICAO NA LISTA: {0}, \t\tTitular da Conta: {1}", i, contasCadastradas[i].titularConta));
                            Console.WriteLine("------------------------");
                        }
                        Console.Write("\nDigite a posicao da conta: ");
                        posicao = int.Parse(Console.ReadLine());
                        Console.WriteLine(string.Format("POSICAO da conta {0}: ", posicao));
                        Console.WriteLine(string.Format("Digite o numero da conta : "));
                        contasCadastradas[posicao].numeroConta = Console.ReadLine();
                        Console.WriteLine(string.Format("Digite o numero da agencia : "));
                        contasCadastradas[posicao].agenciaConta = Console.ReadLine();
                        Console.WriteLine(string.Format("Digite o nome do titular da conta : "));
                        contasCadastradas[posicao].titularConta = Console.ReadLine();
                        Console.WriteLine(string.Format("Digite o saldo da conta : "));
                        contasCadastradas[posicao].saldo = int.Parse(Console.ReadLine());
                        if (ContaEmUso.titularConta == contasCadastradas[posicao].titularConta)
                        {
                            ContaEmUso.agenciaConta = contasCadastradas[posicao].agenciaConta;
                            ContaEmUso.numeroConta = contasCadastradas[posicao].numeroConta;
                            ContaEmUso.titularConta = contasCadastradas[posicao].titularConta;
                            ContaEmUso.saldo = contasCadastradas[posicao].saldo;
                            //return ContaEmUso;
                        }
                        break;
                    case 4:
                        Console.WriteLine("\nExcluir Conta\n");
                        for (int i = 0; i < contasCadastradas.Count; i++)
                        {
                            Console.WriteLine(string.Format("POSICAO NA LISTA: {0}, \t\tTitular da Conta: {1}", i, contasCadastradas[i].titularConta));
                            Console.WriteLine("------------------------");
                        }
                        Console.Write("\nDigite a posicao da conta: ");
                        posicao = int.Parse(Console.ReadLine());
                        if (posicao<=contasCadastradas.Count)
                        {
                            contasCadastradas.RemoveAt(posicao);
                            if (ContaEmUso.titularConta == contasCadastradas[posicao - 1].titularConta)
                            {
                                ContaEmUso.agenciaConta = contasCadastradas[0].agenciaConta;
                                ContaEmUso.numeroConta = contasCadastradas[0].numeroConta;
                                ContaEmUso.titularConta = contasCadastradas[0].titularConta;
                                ContaEmUso.saldo = contasCadastradas[0].saldo;
                                //return ContaEmUso;
                            }
                        }                        
                        break;
                    case 5:
                        Console.WriteLine("\nDefinir Conta utilizada pelo caixa eletronico para saque/deposito\n");
                        for (int i = 0; i < contasCadastradas.Count; i++)
                        {
                            Console.WriteLine(string.Format("POSICAO NA LISTA: {0}, \t\tTitular da Conta: {1}", i, contasCadastradas[i].titularConta));
                            Console.WriteLine(string.Format("\tnumero da conta: {0}", contasCadastradas[i].numeroConta));
                            Console.WriteLine("--------------------------------------");
                        }
                        Console.Write("\nDigite a posicao da conta: ");
                        posicao = int.Parse(Console.ReadLine());
                        ContaEmUso.agenciaConta = contasCadastradas[posicao].agenciaConta; //>>>>>>>>comando que esta mudando a posicao
                        ContaEmUso.numeroConta = contasCadastradas[posicao].numeroConta;
                        ContaEmUso.titularConta = contasCadastradas[posicao].titularConta;
                        ContaEmUso.saldo = contasCadastradas[posicao].saldo;
                        //return ContaEmUso;
                        break;
                    default:
                        break;
                }
                if (controle != 0)
                {
                    Console.WriteLine("\nPressione uma tecla para continuar");
                    Console.ReadKey();
                    Console.WriteLine("----------------------");
                }
            } while (controle !=0);
            return ContaEmUso;
        }
    }
}
