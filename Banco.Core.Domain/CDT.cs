using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Banco.Core.Domain
{
    public class CDT : IServicioFinanciero
    {
        public CDT(string numero, string nombre, string ciudad, string termino, double interes)
        {
            Numero = numero;
            Nombre = nombre;
            Termino = termino;
            Interes = interes;
            Saldo = 0;
            _movimientos = new List<CDTMovimiento>();
        }

        public string Numero { get; private set; }
        public string Nombre { get; private set; }
        public decimal Saldo { get; set; }
        public string Ciudad { get; set; }
        public double Interes { get; set; }
        public string Termino {get; set;}

        public string Consignar(decimal valorConsignacion, string diaConsignacion, string mesConsignacion, string anioConsignacion)
        {
            if (valorConsignacion < 1000000) return "El valor mínimo de la primera consignación debe de mínimo 1 millon de pesos";
            if (TieneConsignacion()) return "No puede realizar mas de una consignacion";

            _movimientos.Add(new CDTMovimiento(valorConsignacion, "CONSIGNACION", diaConsignacion, mesConsignacion, anioConsignacion));
            return "consignacion exitosa";
        }

        public bool TieneConsignacion()
        {
            return _movimientos.Any(t => t.Tipo == "CONSIGNACION");
        }

        public string Retirar(decimal valorRetiro, string diaRetiro, string mesRetiro, string anioRetiro)
        {
            
            return "";
        }


        public readonly List<CDTMovimiento> _movimientos;
    }

    public class CDTMovimiento
    {
        public CDTMovimiento(decimal saldoAnterior, string tipo, string diaMovimiento, string mesMovimiento, string anioMovimiento)
        {
            SaldoAnterior = saldoAnterior;
            Tipo = tipo;
            DiaMovimiento = diaMovimiento;
            MesMovimiento = mesMovimiento;
            AnioMovimiento = anioMovimiento;
        }

        public decimal SaldoAnterior { get; private set; }
        public string Tipo { get; private set; }
        public string DiaMovimiento { get; private set; }
        public string MesMovimiento { get; private set; }
        public string AnioMovimiento { get; private set; }

    }
}
