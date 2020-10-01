using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Banco.Core.Domain
{
    public class CuentaCorriente : CuentaBancaria
    {
        public decimal sobreGiro;
       
        public CuentaCorriente(string numero, string nombre, string ciudad) : base(numero, nombre, ciudad)
        {
          SobreGiro = 0;
        }
        public decimal SobreGiro { get; set; }


        public override string Consignar(decimal valorConsignacion, string diaConsignacion, string mesConsignacion, string anioConsignacion)
        {
            
            if (valorConsignacion < 100000 && NoTieneConsignacion()) return "El valor mínimo de la primera consignación debe ser de $100.000 mil pesos. Su nuevo saldo es $0 pesos";

            var saldoAnterior = Saldo;

         
            Saldo += valorConsignacion;
            SobreGiro += valorConsignacion;
            _movimientos.Add(new CuentaBancariaMovimiento(saldoAnterior, valorConsignacion, 0, "CONSIGNACION", diaConsignacion, mesConsignacion, anioConsignacion));
            return "Su consignación ha sido exitosa";

        }

        public override string Retirar(decimal valorRetiro, string diaRetiro, string mesRetiro, string anioRetiro)
        {
              

            var saldoAnterior = Saldo;
            SobreGiro -= valorRetiro;
            var cuatroPorMil = (valorRetiro * 4) / 1000;

            Saldo -= valorRetiro - cuatroPorMil;

            _movimientos.Add(new CuentaBancariaMovimiento(saldoAnterior, 0, valorRetiro, "RETIRO", diaRetiro, mesRetiro, anioRetiro));

            return "Retiro Exitoso";
        }

        

      
    }
}
