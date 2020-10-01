using System;
using System.Collections.Generic;
using System.Text;

namespace Banco.Core.Domain
{
    public class TarjetaCredito : IServicioFinanciero
    {
        public TarjetaCredito(string numero, string nombre, string ciudad, decimal cupo)
        {
            Numero = numero;
            Nombre = nombre;
            Saldo = 0;
            Cupo = cupo;
        }

        public string Numero { get; private set; }
        public string Nombre { get; private set; }
        public decimal Saldo { get; set; }
        public decimal Cupo { get; private set; }

        public string Ciudad { get; set; }

        public string Consignar(decimal valorConsignacion, string diaConsignacion, string mesConsignacion, string anioConsignacion)
        {

            if (valorConsignacion <= 0) return "El valor mínimo de la primera consignación debe ser mayor a cero pesos";

            Saldo = Cupo;
            Cupo = 0;
            if (valorConsignacion > Saldo) return "El valor a consignar supera el saldo";

           
            Cupo += valorConsignacion;
            Saldo -= valorConsignacion;
           return "Abono exitoso";
        }

        public string Retirar(decimal valorRetiro, string diaRetiro, string mesRetiro, string anioRetiro)
        {
            if (valorRetiro <= 0) return "El Avance debe ser mayor a cero pesos";
            if (valorRetiro > Cupo) return "El Avance no puede ser mayor al cupo disponible";
            Cupo -= valorRetiro;

            return "Avance exitoso";
        }
    }
}
