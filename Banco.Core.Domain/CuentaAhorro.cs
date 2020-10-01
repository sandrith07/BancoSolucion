using System;
using System.Collections.Generic;
using System.Text;

namespace Banco.Core.Domain
{
    public class CuentaAhorro : CuentaBancaria
    {
        public CuentaAhorro(string numero, string nombre, string ciudad) : base(numero, nombre, ciudad)
        {
        }

        public override string Consignar(decimal valorConsignacion, string diaConsignacion, string mesConsignacion, string anioConsignacion)
        {
            if (valorConsignacion <= 0) return "El valor a consignar es incorrecto";

            if (valorConsignacion < 50000 && NoTieneConsignacion())  return "El valor mínimo de la primera consignación debe ser de $50.000 mil pesos. Su nuevo saldo es $0 pesos";
            
            var saldoAnterior = Saldo;
            Saldo += valorConsignacion;

            _movimientos.Add(new CuentaBancariaMovimiento(saldoAnterior, valorConsignacion, 0, "CONSIGNACION", diaConsignacion, mesConsignacion, anioConsignacion));
            return $"Su Nuevo Saldo es de ${Saldo:n2} pesos m/c";

        }

        public override string Retirar(decimal valorRetiro, string diaRetiro, string mesRetiro, string anioRetiro)
        {
            var costoTransaccion = 0;
            var resultado = "";

            if (SaldoMenorVeinteMil()) return "No tiene fondos suficientes (minimo 20000)";


            if (CantidadRetiroMes(mesRetiro, anioRetiro) <= 3) resultado = "transaccion sin costo";

            if (CantidadRetiroMes(mesRetiro, anioRetiro) >= 3)
            {
                costoTransaccion = 5000;
                resultado = "usted sobrepaso el número de transacciones gratis, por lo tanto se le descontaran 5 mil ";
            }




            var saldoAnterior = Saldo;
            Saldo = Saldo - (valorRetiro + costoTransaccion);

            _movimientos.Add(new CuentaBancariaMovimiento(saldoAnterior, 0, valorRetiro, "RETIRO", diaRetiro, mesRetiro, anioRetiro));

            return resultado;
        }


        private bool SaldoMenorVeinteMil()
        {
            return Saldo < 20000;
        }

        private int CantidadRetiroMes(string mesRetiro, string anioRetiro)
        {

            var cantidadMovimientoMes = _movimientos.FindAll(x => x.MesMovimiento == mesRetiro && x.AnioMovimiento == anioRetiro && x.Tipo == "RETIRO").Count;


            return cantidadMovimientoMes;
        }
    }
}
