using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Data;

namespace Banco.Core.Domain
{
    public abstract class CuentaBancaria : IServicioFinanciero
    {
        protected CuentaBancaria(string numero, string nombre, string ciudad)
        {
            Numero = numero;
            Nombre = nombre;
            Saldo = 0;
            _movimientos = new List<CuentaBancariaMovimiento>();
        }

        public string Numero { get; }
        public string Nombre { get; }
        public string Ciudad { get; set; }


 
        public decimal Saldo { get; set; }

        public virtual string Consignar(decimal valorConsignacion, string diaConsignacion, string mesConsignacion, string anioConsignacion, string ciudadConsignacion)
        {
    
            return $"Su Nuevo Saldo es de ${Saldo:n2} pesos m/c";
        }

        public bool NoTieneConsignacion()
        {
            return !_movimientos.Any(t => t.Tipo == "CONSIGNACION");
        }



        public virtual string Retirar(decimal valorRetiro, string diaRetiro, string mesRetiro, string anioRetiro, string ciudadRetiro)

        {

            return $"Su Nuevo Saldo es de ${Saldo:n2} pesos m/c";

        }



        public readonly List<CuentaBancariaMovimiento> _movimientos;
    }

       


    public class CuentaBancariaMovimiento
    {
        public CuentaBancariaMovimiento(decimal saldoAnterior, decimal valorCredito, decimal valorDebito, string tipo, string diaMovimiento, string mesMovimiento, string anioMovimiento, string ciudadMovimiento)
        {
            SaldoAnterior = saldoAnterior;
            ValorCredito = valorCredito;
            ValorDebito = valorDebito;
            Tipo = tipo;
            DiaMovimiento = diaMovimiento;
            MesMovimiento = mesMovimiento;
            AnioMovimiento = anioMovimiento;
            CiudadMovimiento = ciudadMovimiento;
        }

        public decimal SaldoAnterior { get; private set; }
        public decimal ValorCredito { get; private set; }
        public decimal ValorDebito { get; private set; }
        public string Tipo { get; private set; }
        public string DiaMovimiento { get; private set; }
        public string MesMovimiento { get; private set; }
        public string AnioMovimiento { get; private set; }
        public string CiudadMovimiento { get; private set; }

    }
}
