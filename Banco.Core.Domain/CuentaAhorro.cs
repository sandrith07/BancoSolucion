using System;
using System.Collections.Generic;
using System.Text;

namespace Banco.Core.Domain
{
    public class CuentaAhorro : CuentaBancaria
    {
        public CuentaAhorro(string numero, string nombre, string ciudad) : base(numero, nombre, ciudad)
        {
            Ciudad = ciudad;
        }

        public override string Consignar(decimal valorConsignacion, string diaConsignacion, string mesConsignacion, string anioConsignacion, string ciudadConsignacion)
        {
            var costoTransaccion = 0;
            string resultado = "";
            if (valorConsignacion <= 0) return "El valor a consignar es incorrecto";

            if (valorConsignacion < 50000 && NoTieneConsignacion())  return "El valor mínimo de la primera consignación debe ser de $50.000 mil pesos. Su nuevo saldo es $0 pesos";

            if (Ciudad != ciudadConsignacion) {
                costoTransaccion = 10000;
                 resultado = $"Su Nuevo Saldo es de ${Saldo:n2} pesos m/c";
            }
            

            var saldoAnterior = Saldo;
            Saldo += valorConsignacion;

            _movimientos.Add(new CuentaBancariaMovimiento(saldoAnterior, valorConsignacion, 0, "CONSIGNACION", diaConsignacion, mesConsignacion, anioConsignacion, ciudadConsignacion));
            Saldo -= costoTransaccion;
            resultado = $"Su Nuevo Saldo es de ${Saldo:n2} pesos m/c";
            return resultado;

        }

        public override string Retirar(decimal valorRetiro, string diaRetiro, string mesRetiro, string anioRetiro, string ciudadRetiro)
        {
            var costoRetiro = 0;
            var resultado = "";

            if (SaldoMenorVeinteMil()) return "No tiene fondos suficientes (minimo 20000)";


            if (CantidadRetiroMes(mesRetiro, anioRetiro) <= 3) resultado = "transaccion sin costo";

            if (CantidadRetiroMes(mesRetiro, anioRetiro) > 4)
            {
                costoRetiro = 5000;
                resultado = "usted sobrepaso el número de transacciones gratis, por lo tanto se le descontaran 5 mil ";
            }
            

            var saldoAnterior = Saldo;
            Saldo = Saldo - valorRetiro;

            _movimientos.Add(new CuentaBancariaMovimiento(saldoAnterior, 0, valorRetiro, "RETIRO", diaRetiro, mesRetiro, anioRetiro, ciudadRetiro));
            Saldo -= costoRetiro;
            _movimientos.Add(new CuentaBancariaMovimiento(saldoAnterior, 0, costoRetiro, "RETIRO", diaRetiro, mesRetiro, anioRetiro, ciudadRetiro));

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
