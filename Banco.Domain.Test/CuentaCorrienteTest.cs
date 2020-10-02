using Banco.Core.Domain;
using NUnit.Framework;

namespace Banco.Domain.Test
{
    class CuentaCorrienteTest
    {
        [SetUp]
        public void Setup()
        {
        }

        
  

        /* Escenario 1: La consignación inicial debe ser de mínimo 100 mil pesos.
        HU 3.
        Como Usuario quiero realizar consignaciones a una cuenta corriente para salvaguardar el dinero.
        Criterios de Aceptación
        3.1 La consignación inicial debe ser de mínimo 100 mil pesos.
        3.2 El valor consignado debe ser adicionado al saldo de la cuenta.*/
        [Test]

        public void NoPuedeConsignaciorMenosDeCienMilCuentaCorrienteTest()
        {
            //Preparar
            var cuentaCorriente = new CuentaCorriente(numero: "10001", nombre: "Cuenta Corriente", ciudad: "Valledupar", sobreGiro: 1000000);
            //Acción
            var resultado = cuentaCorriente.Consignar(99999, "01", "12", "2020", "Valledupar");
            //Verificación
            Assert.AreEqual("El valor mínimo de la primera consignación debe ser de $100.000 mil pesos. Su nuevo saldo es $0 pesos", resultado);
        }


        /* Escenario 2: El valor consignado debe ser adicionado al saldo de la cuenta.
       HU 3.
       Como Usuario quiero realizar consignaciones a una cuenta corriente para salvaguardar el dinero.
       Criterios de Aceptación
       3.1 La consignación inicial debe ser de mínimo 100 mil pesos.
       3.2 El valor consignado debe ser adicionado al saldo de la cuenta.*/
        [Test]

        public void AdicionarValorConsignadoACuentaCorrienteTest()
        {
            //Preparar
            var cuentaCorriente = new CuentaCorriente(numero: "10001", nombre: "Cuenta Corriente", ciudad: "Valledupar", sobreGiro: 1000000);
            //Acción
            var resultado = cuentaCorriente.Consignar(700000, "01", "12", "2020", "Valledupar");
            //Verificación
            Assert.AreEqual("Su consignación ha sido exitosa", resultado);
            Assert.AreEqual(cuentaCorriente.SobreGiro, 1000000);

        }


        /* El valor a retirar se debe descontar del saldo de la cuenta.
        HU: Como Usuario quiero realizar retiros a una cuenta corriente para salvaguardar el dinero.
        Criterios de Aceptación
        4.1 El valor a retirar se debe descontar del saldo de la cuenta.
        4.2 El saldo mínimo deberá ser mayor o igual al cupo de sobregiro.
        4.3 El retiro tendrá un costo del 4×Mil
        */
        [Test]

        public void DescontarValorARetirarDeCuentaCorrienteTest()
        {
            //Preparar
            var cuentaCorriente = new CuentaCorriente(numero: "10001", nombre: "Cuenta Corriente", ciudad: "Valledupar", sobreGiro: 1000000);
            //Acción
            var resultado = cuentaCorriente.Retirar(7000, "01", "12", "2020", "Valledupar");
            //Verificación
            Assert.AreEqual("Su retiro ha sido exitoso", resultado);
            Assert.AreEqual(cuentaCorriente.SobreGiro, 993000);

        }

        /* El retiro tendrá un costo del 4×Mil
       HU: Como Usuario quiero realizar retiros a una cuenta corriente para salvaguardar el dinero.
       Criterios de Aceptación
       4.1 El valor a retirar se debe descontar del saldo de la cuenta.
       4.2 El saldo mínimo deberá ser mayor o igual al cupo de sobregiro.
       4.3 El retiro tendrá un costo del 4×Mil
       */
        [Test]

        public void CobroCuatroPorMilCuentaCorrienteTest()
        {
            //Preparar
            var cuentaCorriente = new CuentaCorriente(numero: "10001", nombre: "Cuenta Corriente", ciudad: "Valledupar", sobreGiro: 1000000);
            //Acción
            var resultado = cuentaCorriente.Retirar(7000, "01", "12", "2020", "Valledupar");
            //Verificación
            Assert.AreEqual("Su retiro ha sido exitoso", resultado);
            Assert.AreEqual(cuentaCorriente.deuda, 6972);

        }




    }
}
