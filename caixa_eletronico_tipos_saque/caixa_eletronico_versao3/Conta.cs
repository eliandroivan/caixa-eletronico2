﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace caixa_eletronico_versao3
{
    class Conta
    {
        public string numeroConta { get; set; }
        public string agenciaConta { get; set; }
        public string titularConta { get; set; }
        public float saldo { get; set; }

        
        
        public void Sacar10proporcionalInfinitasNotas()
        {
            Console.WriteLine("Sacar notas (10,20,50,100) distribuidas proporcionalmente com infinitas notas disponiveis");
            Console.Write("\nDigite o valor do saque: ");
            int solicitacaoSaque = int.Parse(Console.ReadLine());
            if ((solicitacaoSaque <= saldo) && (solicitacaoSaque > 1) && ((solicitacaoSaque % 10) == 0))
            {
                saldo -= solicitacaoSaque;
                int[] cedulasValorIndividual = new int[] { 100, 50, 20, 10 };
                int[] cedulasUsadas = new int[4];
                do
                {
                    for (int i = 0; i < cedulasValorIndividual.Length; i++)
                    {
                        if (cedulasValorIndividual[i] <= solicitacaoSaque)
                        {
                            solicitacaoSaque -= cedulasValorIndividual[i];
                            cedulasUsadas[i]++;
                        }
                    }
                } while (solicitacaoSaque > 0);
                Console.WriteLine("\nContagem de cedulas sacadas:");
                int somaNotasSaque = 0;
                for (int i = 0; i < cedulasUsadas.Length; i++)
                {
                    somaNotasSaque += (cedulasUsadas[i] * cedulasValorIndividual[i]);
                    Console.WriteLine(string.Format("Valor da cédula: {0}, \tquantidade de cedulas: {1}", cedulasValorIndividual[i], cedulasUsadas[i]));
                }
                Console.WriteLine("Somatorio das notas: $ " + somaNotasSaque);
                Console.WriteLine("\nPressione uma tecla para continuar");
                Console.ReadKey();
                Console.WriteLine("----------------------");
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
                Console.WriteLine("\nPressione uma tecla para continuar");
                Console.ReadKey();
                Console.WriteLine("----------------------");
            }
        }
    
        public void Sacar10minimoInfinitasNotas()
        {
            Console.WriteLine("Sacar notas (10,20,50,100) distribuindo o minimo com infinitas notas disponiveis");
            Console.Write("\nDigite o valor do saque: ");
            int solicitacaoSaque = int.Parse(Console.ReadLine());
            if ((solicitacaoSaque <= saldo) && (solicitacaoSaque > 1) && ((solicitacaoSaque % 10) == 0))
            {
                saldo -= solicitacaoSaque;
                int[] cedulasValorIndividual = new int[] { 100, 50, 20, 10 };
                int[] cedulasUsadas = new int[4];

                for (int i = 0; i < cedulasValorIndividual.Length; i++)
                {
                    while (cedulasValorIndividual[i] <= solicitacaoSaque)
                    {
                        solicitacaoSaque -= cedulasValorIndividual[i];
                        cedulasUsadas[i]++;
                    }
                }

                Console.WriteLine("\nContagem de cedulas sacadas:");
                int somaNotasSaque = 0;
                for (int i = 0; i < cedulasUsadas.Length; i++)
                {
                    somaNotasSaque += (cedulasUsadas[i] * cedulasValorIndividual[i]);
                    Console.WriteLine(string.Format("Valor da cédula: {0}, \tquantidade de cedulas: {1}", cedulasValorIndividual[i], cedulasUsadas[i]));
                }
                Console.WriteLine("Somatorio das notas: $ " + somaNotasSaque);
                Console.WriteLine("\nPressione uma tecla para continuar");
                Console.ReadKey();
                Console.WriteLine("----------------------");
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
                Console.WriteLine("\nPressione uma tecla para continuar");
                Console.ReadKey();
                Console.WriteLine("----------------------");
            }
        }

        public void Sacar10minimoLimiteNotas()
        {            
            int[] cedulasValorIndividual = new int[] { 100, 50, 20, 10 };
            int[] cedulasQtd = new int[] { 10, 0, 1, 4 };
            int[] cedulasContagem = new int[4];
            Console.WriteLine("Sacar notas (10,20,50,100) distribuindo o minimo com limite de notas na maquina");
            Console.Write("\nDigite o valor do saque: ");
            int solicitacaoSaque = int.Parse(Console.ReadLine());
            bool temNotas = false;
            int TotalEmDinheiro = solicitacaoSaque;
            for (int i = 0; i < cedulasValorIndividual.Length; i++)
            {
                while ((cedulasValorIndividual[i] <= TotalEmDinheiro) && (cedulasQtd[i] > 0) && (cedulasContagem[i]<cedulasQtd[i]))
                {
                    TotalEmDinheiro -= cedulasValorIndividual[i];
                    cedulasContagem[i]++;
                }
            }
            if (TotalEmDinheiro==0)
            {
                temNotas = true;
            }

            Console.WriteLine("\nContagem de cedulas:");
            TotalEmDinheiro = 0;
            for (int i = 0; i < cedulasValorIndividual.Length; i++)
            {
                TotalEmDinheiro += (cedulasValorIndividual[i] * cedulasQtd[i]);
                Console.WriteLine(string.Format("valor: {0}, \tquantidade em caixa: {1}, \tcontagem: {2}", cedulasValorIndividual[i], cedulasQtd[i], cedulasContagem[i]));
            }            
            Console.WriteLine("Valor total em dinheiro no caixa eletronico: $ " + TotalEmDinheiro);

            if ((solicitacaoSaque <= saldo) && (solicitacaoSaque > 1) && ((solicitacaoSaque % 10) == 0))
            {
                if (temNotas)
                {
                    saldo -= solicitacaoSaque;

                    int[] cedulasUsadas = new int[4];
                    for (int i = 0; i < cedulasValorIndividual.Length; i++)
                    {
                        while ((cedulasValorIndividual[i] <= solicitacaoSaque) && (cedulasQtd[i] > 0))
                        {
                            solicitacaoSaque -= cedulasValorIndividual[i];
                            cedulasUsadas[i]++;
                            cedulasQtd[i]--;
                        }
                    }

                    Console.WriteLine("\nContagem de cedulas sacadas:");
                    int somaNotasSaque = 0;
                    for (int i = 0; i < cedulasUsadas.Length; i++)
                    {
                        somaNotasSaque += (cedulasUsadas[i] * cedulasValorIndividual[i]);
                        Console.WriteLine(string.Format("Valor da cédula: {0}, \tquantidade de cedulas: {1}", cedulasValorIndividual[i], cedulasUsadas[i]));
                    }
                    Console.WriteLine("Somatorio das notas sacadas: $ " + somaNotasSaque);
                    TotalEmDinheiro = 0;
                    Console.WriteLine("\nCedulas disponiveis:");
                    for (int i = 0; i < cedulasValorIndividual.Length; i++)
                    {
                        Console.WriteLine(string.Format("Valor da cédula: {0}, \tquantidade de cedulas: {1}", cedulasValorIndividual[i], cedulasQtd[i]));
                        TotalEmDinheiro += (cedulasValorIndividual[i] * cedulasQtd[i]);
                    }
                    Console.WriteLine("Valor total em dinheiro no caixa eletronico: $ " + TotalEmDinheiro);
                    Console.WriteLine("\nPressione uma tecla para continuar");
                    Console.ReadKey();
                    Console.WriteLine("----------------------");
                }
                else
                {
                    Console.WriteLine("\nNao ha notas disponiveis. Operacao nao realizada.");
                    Console.WriteLine("\nCedulas disponiveis no caixa eletronico:");
                    TotalEmDinheiro = 0;
                    for (int i = 0; i < cedulasValorIndividual.Length; i++)
                    {
                        Console.WriteLine(string.Format("Valor da cédula: {0}, \tquantidade de cedulas: {1}", cedulasValorIndividual[i], cedulasQtd[i]));
                        TotalEmDinheiro += (cedulasValorIndividual[i] * cedulasQtd[i]);
                    }
                    Console.WriteLine("Valor total em dinheiro no caixa eletronico: $ " + TotalEmDinheiro);
                    Console.WriteLine("\nPressione uma tecla para continuar");
                    Console.ReadKey();
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
                Console.WriteLine("\nPressione uma tecla para continuar");
                Console.ReadKey();
                Console.WriteLine("----------------------");
            }
        }

        public void Sacar2e5minimoInfinitasNotas()
        {
            Console.WriteLine("Sacar cedulas (2,5,10,20,50,100) distribuindo o minimo com infinitas notas disponiveis");
            Console.Write("\nDigite o valor do saque: ");
            int solicitacaoSaque = int.Parse(Console.ReadLine());
            if ((solicitacaoSaque <= saldo) && (solicitacaoSaque > 1) && (solicitacaoSaque != 3))
            {
                saldo -= solicitacaoSaque;
                int[] cedulasValorIndividual = new int[] { 100, 50, 20, 10, 5, 2 };
                int[] cedulasUsadas = new int[6];

                for (int i = 0; i < cedulasValorIndividual.Length; i++)
                {
                    string teste1e3 = solicitacaoSaque.ToString();
                    if (((teste1e3.Substring(teste1e3.Length - 1, 1) == "1")) || ((teste1e3.Substring(teste1e3.Length - 1, 1) == "3")))
                    {
                        solicitacaoSaque -= 5;
                        cedulasUsadas[4]++;
                    }
                    while (cedulasValorIndividual[i] <= solicitacaoSaque)
                    {
                        if ((solicitacaoSaque < 10) && ((solicitacaoSaque % 2) == 0))
                        {
                            solicitacaoSaque -= 2;
                            cedulasUsadas[5]++;
                        }
                        else
                        {
                            solicitacaoSaque -= cedulasValorIndividual[i];
                            cedulasUsadas[i]++;
                        }

                        if ((solicitacaoSaque < 10) && ((solicitacaoSaque % 2) == 0) && (solicitacaoSaque != 0))
                        {
                            solicitacaoSaque -= 2;
                            cedulasUsadas[5]++;
                        }
                    }
                }

                Console.WriteLine("\nContagem de cedulas sacadas:");
                int somaNotasSaque = 0;
                for (int i = 0; i < cedulasUsadas.Length; i++)
                {
                    somaNotasSaque += (cedulasUsadas[i] * cedulasValorIndividual[i]);
                    Console.WriteLine(string.Format("Valor da cédula: {0}, \tquantidade de cedulas: {1}", cedulasValorIndividual[i], cedulasUsadas[i]));
                }
                Console.WriteLine("Somatorio das notas: $ " + somaNotasSaque);
                Console.WriteLine("\nPressione uma tecla para continuar");
                Console.ReadKey();
                Console.WriteLine("----------------------");
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
                Console.WriteLine("\nPressione uma tecla para continuar");
                Console.ReadKey();
                Console.WriteLine("----------------------");
            }
        }
        
        public void Sacar2e5minimoLimiteNotasQuase()
        {
            Console.WriteLine("Sacar cedulas (2,5,10,20,50,100) distribuindo o minimo com notas limitadas");
            int[] cedulasValorIndividual = new int[] { 100, 50, 20, 10, 5, 2 };
            int[] cedulasQtd = new int[] { 100, 0, 0, 4, 0, 0 };
            int TotalEmDinheiro = 0;
            for (int i = 0; i < cedulasValorIndividual.Length; i++)
            {
                TotalEmDinheiro += (cedulasValorIndividual[i] * cedulasQtd[i]);
            }
            Console.WriteLine("\nValor total em dinheiro no caixa eletronico: $ " + TotalEmDinheiro);
            Console.Write("\nDigite o valor do saque: ");
            int solicitacaoSaque = int.Parse(Console.ReadLine());
            bool temNotas = false;
            if ((solicitacaoSaque <= saldo) && (solicitacaoSaque > 1) && (solicitacaoSaque != 3))
            {
                for (int i = cedulasQtd.Length - 1; i >= 0; i--)
                {
                    if (temNotas == true)
                    {
                        break;
                    }
                    if ((cedulasQtd[i] == 0) || ((solicitacaoSaque % cedulasValorIndividual[i]) != 0))
                    {
                        temNotas = false;
                    }
                    else
                    {
                        temNotas = true;
                        break;
                    }
                }
                if (temNotas)
                {
                    saldo -= solicitacaoSaque;
                    int[] cedulasUsadas = new int[6];

                    for (int i = 0; i < cedulasValorIndividual.Length; i++)
                    {
                        string teste1e3 = solicitacaoSaque.ToString();
                        if (((teste1e3.Substring(teste1e3.Length - 1, 1) == "1")) || ((teste1e3.Substring(teste1e3.Length - 1, 1) == "3")))
                        {
                            solicitacaoSaque -= 5;
                            cedulasUsadas[4]++;
                            cedulasQtd[4]--;
                        }
                        while ((cedulasValorIndividual[i] <= solicitacaoSaque) && (cedulasQtd[i] > 0))
                        {
                            if ((solicitacaoSaque < 10) && ((solicitacaoSaque % 2) == 0))
                            {
                                solicitacaoSaque -= 2;
                                cedulasUsadas[5]++;
                                cedulasQtd[5]--;
                            }
                            else
                            {
                                solicitacaoSaque -= cedulasValorIndividual[i];
                                cedulasUsadas[i]++;
                                cedulasQtd[i]--;
                            }

                            if ((solicitacaoSaque < 10) && ((solicitacaoSaque % 2) == 0) && (solicitacaoSaque != 0))
                            {
                                solicitacaoSaque -= 2;
                                cedulasUsadas[5]++;
                                cedulasQtd[5]--;
                            }
                        }
                    }

                    Console.WriteLine("\nContagem de cedulas:");
                    int somaNotasSaque = 0;
                    for (int i = 0; i < cedulasUsadas.Length; i++)
                    {
                        somaNotasSaque += (cedulasUsadas[i] * cedulasValorIndividual[i]);
                        Console.WriteLine(string.Format("Valor da cédula: {0}, \tquantidade de cedulas: {1}", cedulasValorIndividual[i], cedulasUsadas[i]));
                    }
                    Console.WriteLine("Somatorio das notas sacadas: $ " + somaNotasSaque);
                    TotalEmDinheiro = 0;
                    Console.WriteLine("\nCedulas disponiveis no caixa eletronico:");
                    for (int i = 0; i < cedulasValorIndividual.Length; i++)
                    {
                        Console.WriteLine(string.Format("Valor da cédula: {0}, \tquantidade de cedulas: {1}", cedulasValorIndividual[i], cedulasQtd[i]));
                        TotalEmDinheiro += (cedulasValorIndividual[i] * cedulasQtd[i]);
                    }
                    Console.WriteLine("Valor total em dinheiro no caixa eletronico: $ " + TotalEmDinheiro);
                    Console.WriteLine("\nPressione uma tecla para continuar");
                    Console.ReadKey();
                    Console.WriteLine("----------------------");
                }

                else
                {
                    Console.WriteLine("\nNao ha notas disponiveis.");
                    Console.WriteLine("\nCedulas disponiveis no caixa eletronico:");
                    for (int i = 0; i < cedulasValorIndividual.Length; i++)
                    {
                        Console.WriteLine(string.Format("Valor da cédula: {0}, \tquantidade de cedulas: {1}", cedulasValorIndividual[i], cedulasQtd[i]));
                        TotalEmDinheiro += (cedulasValorIndividual[i] * cedulasQtd[i]);
                    }
                    Console.WriteLine("\nPressione uma tecla para continuar");
                    Console.ReadKey();
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
                Console.WriteLine("\nPressione uma tecla para continuar");
                Console.ReadKey();
                Console.WriteLine("----------------------");
            }
        }

        public void Sacar2e5minimoLimiteNotasFinal()
        {
            Console.WriteLine("Sacar cedulas (2,5,10,20,50,100) distribuindo o minimo com limite de notas na maquina");
            int[] cedulasValorIndividual = new int[] { 100, 50, 20, 10, 5, 2 };
            int[] cedulasQtd = new int[] { 100, 1, 0, 1, 4, 4 };
            int[] cedulasContagem = new int[6];

            Console.Write("\nDigite o valor do saque: ");
            int solicitacaoSaque = int.Parse(Console.ReadLine());
            bool temNotas = false;
            int TotalEmDinheiro = solicitacaoSaque;
            string teste1e3;
            for (int i = 0; i < cedulasValorIndividual.Length; i++)
            {
                teste1e3 = TotalEmDinheiro.ToString();
                if (((teste1e3.Substring(teste1e3.Length - 1, 1) == "1")) || ((teste1e3.Substring(teste1e3.Length - 1, 1) == "3")))
                {
                    if (cedulasQtd[4]>0)
                    {
                        TotalEmDinheiro -= 5;
                        cedulasContagem[4]++;
                        cedulasQtd[4]--; //precisa incrementar +1 no inicio do trecho que faz a distribuicao das notas se este caso particular for verdadeiro
                    }
                }

                while ((cedulasValorIndividual[i] <= TotalEmDinheiro) && (cedulasQtd[i] > 0) && (cedulasContagem[i] < cedulasQtd[i]))
                {
                    if ((TotalEmDinheiro < 10) && ((TotalEmDinheiro % 2) == 0))
                    {
                        TotalEmDinheiro -= 2;
                        cedulasContagem[5]++;
                    }
                    else
                    {
                        TotalEmDinheiro -= cedulasValorIndividual[i];
                        cedulasContagem[i]++;
                    }

                    if ((TotalEmDinheiro < 10) && ((TotalEmDinheiro % 2) == 0) && (TotalEmDinheiro != 0) && (cedulasContagem[i] < cedulasQtd[i]))
                    {
                        TotalEmDinheiro -= 2;
                        cedulasContagem[5]++;
                    }
                }
            }
            if (TotalEmDinheiro == 0)
            {
                temNotas = true;
            }

            teste1e3 = solicitacaoSaque.ToString();
            if (((teste1e3.Substring(teste1e3.Length - 1, 1) == "1")) || ((teste1e3.Substring(teste1e3.Length - 1, 1) == "3")))
            {
                if (temNotas)
                {
                    cedulasQtd[4]++; //precisa incrementar +1 que foi tirado durante a contagem de cedulas
                }
            }
            
            Console.WriteLine("\nContagem de cedulas:");
            TotalEmDinheiro = 0;
            for (int i = 0; i < cedulasValorIndividual.Length; i++)
            {
                TotalEmDinheiro += (cedulasValorIndividual[i] * cedulasQtd[i]);
                Console.WriteLine(string.Format("valor: {0}, \tquantidade em caixa: {1}, \tcontagem: {2}", cedulasValorIndividual[i], cedulasQtd[i], cedulasContagem[i]));
            }
            Console.WriteLine("Valor total em dinheiro no caixa eletronico: $ " + TotalEmDinheiro);
            
            if ((solicitacaoSaque <= saldo) && (solicitacaoSaque > 1) && (solicitacaoSaque != 3))
            {                
                if (temNotas)
                {
                    saldo -= solicitacaoSaque;
                    int[] cedulasUsadas = new int[6];

                    for (int i = 0; i < cedulasValorIndividual.Length; i++)
                    {
                        teste1e3 = solicitacaoSaque.ToString();
                        if (((teste1e3.Substring(teste1e3.Length - 1, 1) == "1")) || ((teste1e3.Substring(teste1e3.Length - 1, 1) == "3")))
                        {
                            solicitacaoSaque -= 5;
                            cedulasUsadas[4]++;
                            cedulasQtd[4]--;
                        }
                        while ((cedulasValorIndividual[i] <= solicitacaoSaque) && (cedulasQtd[i] > 0))
                        {
                            if ((solicitacaoSaque < 10) && ((solicitacaoSaque % 2) == 0))
                            {
                                solicitacaoSaque -= 2;
                                cedulasUsadas[5]++;
                                cedulasQtd[5]--;
                            }
                            else
                            {
                                solicitacaoSaque -= cedulasValorIndividual[i];
                                cedulasUsadas[i]++;
                                cedulasQtd[i]--;
                            }

                            if ((solicitacaoSaque < 10) && ((solicitacaoSaque % 2) == 0) && (solicitacaoSaque != 0))
                            {
                                solicitacaoSaque -= 2;
                                cedulasUsadas[5]++;
                                cedulasQtd[5]--;
                            }
                        }
                    }

                    Console.WriteLine("\nContagem de cedulas sacadas:");
                    int somaNotasSaque = 0;
                    for (int i = 0; i < cedulasUsadas.Length; i++)
                    {
                        somaNotasSaque += (cedulasUsadas[i] * cedulasValorIndividual[i]);
                        Console.WriteLine(string.Format("Valor da cédula: {0}, \tquantidade de cedulas: {1}", cedulasValorIndividual[i], cedulasUsadas[i]));
                    }
                    Console.WriteLine("Somatorio das notas sacadas: $ " + somaNotasSaque);
                    TotalEmDinheiro = 0;
                    Console.WriteLine("\nCedulas disponiveis no caixa eletronico:");
                    for (int i = 0; i < cedulasValorIndividual.Length; i++)
                    {
                        Console.WriteLine(string.Format("Valor da cédula: {0}, \tquantidade de cedulas: {1}", cedulasValorIndividual[i], cedulasQtd[i]));
                        TotalEmDinheiro += (cedulasValorIndividual[i] * cedulasQtd[i]);
                    }
                    Console.WriteLine("Valor total em dinheiro no caixa eletronico: $ " + TotalEmDinheiro);
                    Console.WriteLine("\nPressione uma tecla para continuar");
                    Console.ReadKey();
                    Console.WriteLine("----------------------");
                }

                else
                {
                    Console.WriteLine("\nNao ha notas disponiveis.");
                    TotalEmDinheiro = 0;
                    Console.WriteLine("\nCedulas disponiveis no caixa eletronico:");
                    for (int i = 0; i < cedulasValorIndividual.Length; i++)
                    {
                        Console.WriteLine(string.Format("Valor da cédula: {0}, \tquantidade de cedulas: {1}", cedulasValorIndividual[i], cedulasQtd[i]));
                        TotalEmDinheiro += (cedulasValorIndividual[i] * cedulasQtd[i]);
                    }
                    Console.WriteLine("Valor total em dinheiro no caixa eletronico: $ " + TotalEmDinheiro);
                    Console.WriteLine("\nPressione uma tecla para continuar");
                    Console.ReadKey();
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
                Console.WriteLine("\nPressione uma tecla para continuar");
                Console.ReadKey();
                Console.WriteLine("----------------------");
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
                Console.WriteLine("\nPressione uma tecla para continuar");
                Console.ReadKey();
                Console.WriteLine("----------------------");
            }
            else
            {
                Console.WriteLine("\nValor inválido");
                Console.WriteLine("\nPressione uma tecla para continuar");
                Console.ReadKey();
                Console.WriteLine("----------------------");
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
            Console.WriteLine("\nPressione uma tecla para continuar");
            Console.ReadKey();
            Console.WriteLine("----------------------");
        }
    }
}
