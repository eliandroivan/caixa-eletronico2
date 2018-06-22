using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace caixa_eletronico_versao3
{
    class Cedula
    {
        public int qtdCedula100 { get; set; }
        public int qtdCedula50 { get; set; }
        public int qtdCedula20 { get; set; }
        public int qtdCedula10 { get; set; }
        public int qtdCedula5 { get; set; }
        public int qtdCedula2 { get; set; }

        public void SomarCedulas()
        {
            int totalEmDinheiro = qtdCedula100 + qtdCedula50 + qtdCedula20 + qtdCedula10 + qtdCedula5 + qtdCedula2;
            
        }

    }
}
