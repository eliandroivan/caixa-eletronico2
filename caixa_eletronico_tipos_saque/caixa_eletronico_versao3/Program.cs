using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace caixa_eletronico_versao3
{
    class Program
    {
        static void Main(string[] args)
        {
             

            Conta contaCorrente = new Conta(); //instanciar o objeto
            contaCorrente.agenciaConta = "0333";
            contaCorrente.numeroConta = "65333";
            contaCorrente.titularConta = "joao";
            contaCorrente.saldo = 100003;

            int opcoes_caixa;
            do
            {
                Console.Clear();
                Console.WriteLine("Caixa eletronico");
                Console.WriteLine("--------------------------------------------------------------------------------");
                Console.WriteLine("\n \nEscolha uma das opções:");
                Console.WriteLine("\t\t\t\t\t\t\t\t    Sair - 0");
                Console.WriteLine("\n\t1 - Saldo");
                Console.WriteLine("\n\tSaque com limite de cedulas na maquina e distribuindo o minimo possivel:");
                Console.WriteLine("\t2 - Sacar notas (2,5,10,20,50,100)");
                Console.WriteLine("\t3 - Sacar notas (10,20,50,100)");
                Console.WriteLine("\n\tSaque com distribuicao de cedulas diferente:");
                Console.WriteLine("\t4 - Sacar notas (10,20,50,100) distribuidas proporcionalmente");
                Console.WriteLine("\t5 - Sacar notas (10,20,50,100) com o minimo possivel");                
                Console.WriteLine("\t6 - Sacar notas (2,5,10,20,50,100) com o minimo possivel");
                
                Console.WriteLine("\n\t7 - Depositar");
                Console.WriteLine("\n\t8 - Transferencia");
                Console.Write("\ndigite sua opção: ");
                opcoes_caixa = int.Parse(Console.ReadLine());
                Console.Clear();
                Console.WriteLine("-------------------------------------------------------- "+opcoes_caixa);                
                switch (opcoes_caixa)
                {
                    case 0:
                        break;
                    case 1:
                        contaCorrente.Saldo();
                        break;
                    case 2:
                        contaCorrente.Sacar2e5minimoLimiteNotasFinal();
                        break;
                    case 3:
                        contaCorrente.Sacar10minimoLimiteNotas();
                        break;
                    case 4:
                        contaCorrente.Sacar10proporcionalInfinitasNotas();
                        break;
                    case 5:
                        contaCorrente.Sacar10minimoInfinitasNotas();
                        break;                    
                    case 6:
                        contaCorrente.Sacar2e5minimoInfinitasNotas();
                        break;
                    
                    case 7:
                        contaCorrente.Depositar();
                        break;
                    case 8:
                        contaCorrente.Transferir();
                        break;
                    default:
                        break;
                }
                
            } while (opcoes_caixa != 0);
            
        }
        
    }
}
