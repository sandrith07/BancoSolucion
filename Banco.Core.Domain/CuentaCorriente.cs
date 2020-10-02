using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Banco.Core.Domain
{
    public class CuentaCorriente : CuentaBancaria
    {
        public decimal deuda = 0;

        public CuentaCorriente(string numero, string nombre, string ciudad, decimal sobreGiro) : base(numero, nombre, ciudad) => SobreGiro = sobreGiro;
        public decimal SobreGiro { get; set; }
       


        public override string Consignar(decimal valorConsignacion, string diaConsignacion, string mesConsignacion, string anioConsignacion, string ciudadConsignacion)
        {
            
            if (valorConsignacion < 100000 && NoTieneConsignacion()) return "El valor mínimo de la primera consignación debe ser de $100.000 mil pesos. Su nuevo saldo es $0 pesos";

            var saldoAnterior = Saldo;
            

            deuda -= valorConsignacion;
            SobreGiro += valorConsignacion;
            Saldo = SobreGiro;

            _movimientos.Add(new CuentaBancariaMovimiento(saldoAnterior, valorConsignacion, 0, "CONSIGNACION", diaConsignacion, mesConsignacion, anioConsignacion, ciudadConsignacion));
            return "Su consignación ha sido exitosa";

        }

        public override string Retirar(decimal valorRetiro, string diaRetiro, string mesRetiro, string anioRetiro, string ciudadRetiro)
        {
            Saldo = SobreGiro;
            if (valorRetiro <= 0) return "No puede retirar menos de cero pesos";

            var cuatroPorMil = valorRetiro+(valorRetiro * 4) / 1000;
            var saldoAnterior = Saldo;
            deuda = cuatroPorMil;
            SobreGiro -= valorRetiro;
            Saldo = SobreGiro;
            _movimientos.Add(new CuentaBancariaMovimiento(saldoAnterior, 0, valorRetiro, "RETIRO", diaRetiro, mesRetiro, anioRetiro, ciudadRetiro));
            return "Su retiro ha sido exitoso";

        }



    }
}
