using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace caixa_eletronico_versao4
{
    class Cedula
    {
        public static int[] cedulasValorIndividual10 { get; set; }
        public static int[] cedulasQtd10 { get; set; }
        public static int[] cedulasUsadas10 { get; set; }
        public static int[] cedulasContagem10 { get; set; }
        public int[] cedulasValorIndividual { get; set; }
        public int[] cedulasUsadas { get; set; }
        public int[] cedulasQtd { get; set; }
        public int[] cedulasContagem{ get; set; }

        public void SomarCedulas()
        {
            int totalEmDinheiro=0;
            for (int i = 0; i < cedulasValorIndividual10.Length; i++)
            {
                totalEmDinheiro += (cedulasValorIndividual10[i]*cedulasQtd10[i]);
            }
            Console.WriteLine("total em dinheiro: " + totalEmDinheiro);
        }


       
    }
}

