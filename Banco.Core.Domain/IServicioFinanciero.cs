using System;
using System.Collections.Generic;
using System.Text;

namespace Banco.Core.Domain
{
    interface IServicioFinanciero
    {
        string Numero { get; }
        string Ciudad { get; }

        decimal Saldo { get; }


        string Consignar(decimal valorConsignacion, string diaConsignacion, string mesConsignacion, string anioConsignacion, string ciudadConsignacion);
        string Retirar(decimal valorRetiro, string diaRetiro, string mesRetiro,string anioRetiro, string ciudadRetiro);
  
    }
}
