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




        //Escenario 1: La consignación inicial debe ser de mínimo 100 mil pesos.
        //HU 3.
        //Como Usuario quiero realizar consignaciones a una cuenta corriente para salvaguardar el dinero.
        //Criterios de Aceptación
        //3.1 La consignación inicial debe ser de mínimo 100 mil pesos.
        //3.2 El valor consignado debe ser adicionado al saldo de la cuenta.
        //Ejemplo
        //Dado El cliente tiene una cuenta corriente                                   
        //Número 10001, Nombre “Cuenta ejemplo”, Sobregiro: 1000000 , ciudad Valledupar                               
        //Cuando Va a consignar un valor inicial de $99999 o igual 
        //Entonces El sistema presentará el mensaje. “El valor mínimo de la primera consignación debe ser de $100.000 mil pesos. Su nuevo saldo es $0 pesos”  

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


        //Escenario 1: La consignación inicial debe ser de mínimo 100 mil pesos.
        //HU 3.
        //Como Usuario quiero realizar consignaciones a una cuenta corriente para salvaguardar el dinero.
        //Criterios de Aceptación
        //3.1 La consignación inicial debe ser de mínimo 100 mil pesos.
        //3.2 El valor consignado debe ser adicionado al saldo de la cuenta.
        //Ejemplo
        //Dado El cliente tiene una cuenta corriente                                   
        //Número 10001, Nombre “Cuenta ejemplo”, Sobregiro de 1000000, ciudad Valledupar                               
        //Cuando Va a consignar un valor de  de $700000  
        //Entonces El sistema  adicionara la consignacion al saldo de la cuenta AND presentará el mensaje. “Su consignación ha sido exitosa” 


        [Test]

        public void AdicionarValorConsignadoACuentaCorrienteTest()
        {
            //Preparar
            var cuentaCorriente = new CuentaCorriente(numero: "10001", nombre: "Cuenta Corriente", ciudad: "Valledupar", sobreGiro: 1000000);
            //Acción
            var resultado = cuentaCorriente.Consignar(700000, "01", "12", "2020", "Valledupar");
            //Verificación
            Assert.AreEqual("Su consignación ha sido exitosa", resultado);
            Assert.AreEqual(cuentaCorriente.SobreGiro, 1700000);

        }


        //El valor a retirar se debe descontar del saldo de la cuenta.
        //HU: Como Usuario quiero realizar retiros a una cuenta corriente para salvaguardar el dinero.
        //Criterios de Aceptación
        //4.1 El valor a retirar se debe descontar del saldo de la cuenta.
        //4.2 El saldo mínimo deberá ser mayor o igual al cupo de sobregiro.
        //4.3 El retiro tendrá un costo del 4×Mil
        //Ejemplo
        //Dado El cliente tiene una cuenta corriente                                   
        //Número 10001, Nombre “Cuenta ejemplo”, Sobregiro de 1000000, ciudad Valledupar                               
        //Cuando Va a retirar un valor de  de $7000  
        //Entonces El sistema  descontará el saldo de la cuenta AND presentará el mensaje. "Su retiro ha sido exitoso" 

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



        //El valor a retirar se debe descontar del saldo de la cuenta.
        //HU: Como Usuario quiero realizar retiros a una cuenta corriente para salvaguardar el dinero.
        //Criterios de Aceptación
        //4.1 El valor a retirar se debe descontar del saldo de la cuenta.
        //4.2 El saldo mínimo deberá ser mayor o igual al cupo de sobregiro.
        //4.3 El retiro tendrá un costo del 4×Mil
        //Ejemplo
        //Dado El cliente tiene una cuenta corriente                                   
        //Número 10001, Nombre “Cuenta ejemplo”, Sobregiro de 1000000, ciudad Valledupar                               
        //Cuando Va a retirar un valor de  de $7000  
        //Entonces El sistema  descontará el saldo de la cuenta AND presentará el mensaje. "Su retiro ha sido exitoso" 
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


 

        //Consignar teniendo una deuda
        //HU: Como Usuario quiero realizar retiros a una cuenta corriente para salvaguardar el dinero.
        //Criterios de Aceptación
        //4.1 El valor a retirar se debe descontar del saldo de la cuenta.
        //4.2 El saldo mínimo deberá ser mayor o igual al cupo de sobregiro.
        //4.3 El retiro tendrá un costo del 4×Mil
        //Ejemplo
        //Dado El cliente tiene una cuenta corriente                                   
        //Número 10001, Nombre “Cuenta ejemplo”, Sobregiro de 1000000, ciudad Valledupar, con deuda de 1700000                       
        //Cuando Va a consignar un valor de  de $500000
        //Entonces El sistema  descontará el saldo de la deuda  AND presentará el mensaje. "Su consignacion ha sido exitosa" 
        [Test]

        public void ConsignarALaCuentaTeniendoDeudaCuentaCorrienteTest()
        {
            //Preparar
            var cuentaCorriente = new CuentaCorriente(numero: "10001", nombre: "Cuenta Corriente", ciudad: "Valledupar", sobreGiro: 1000000);
            //Acción
            var consignacion1 = cuentaCorriente.Consignar(700000, "01", "12", "2020", "Valledupar");
            var retiro = cuentaCorriente.Retirar(1700000, "01", "12", "2020", "Valledupar");
            var consignacion2 = cuentaCorriente.Consignar(700000, "01", "12", "2020", "Valledupar");
            //Verificación
            Assert.AreEqual("Su consignación ha sido exitosa", consignacion2);
            Assert.AreEqual(cuentaCorriente.deuda, 1006800);

        }



    }
}
