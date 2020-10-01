using Banco.Core.Domain;
using NUnit.Framework;

namespace Banco.Domain.Test
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            Assert.Pass();
        }


        //Escenario: Valor de consignación negativo o cero 
        //H1: Como Usuario quiero realizar consignaciones a una cuenta de ahorro para salvaguardar el dinero.
        //Criterio de Aceptación:
        //1.2 El valor a abono no puede ser menor o igual a 0
        //Ejemplo
        //Dado El cliente tiene una cuenta de ahorro                                       //A =>Arrange /Preparación
        //Número 10001, Nombre “Cuenta ejemplo”, Saldo de 0 , ciudad Valledupar                               
        //Cuando Va a consignar un valor menor o igual a cero  (0)                            //A =>Act = Acción
        //Entonces El sistema presentará el mensaje. “El valor a consignar es incorrecto”  //A => Assert => Validación
        [Test]

        public void NoPuedeConsignacionValorNegativoCuentaAhorroTest()
        {
            //Preparar
            var cuentaAhorro = new CuentaAhorro(numero: "10001", nombre: "Cuenta Ahorro", ciudad: "Valledupar");
            //Acción
            var resultado = cuentaAhorro.Consignar(0, "01", "12", "2020");
            //Verificación
            Assert.AreEqual("El valor a consignar es incorrecto", resultado);
        }

        //Escenario: Consignación Inicial Correcta
        //HU: Como Usuario quiero realizar consignaciones a una cuenta de ahorro para salvaguardar el dinero.
        //Criterio de Aceptación:
        //1.1 La consignación inicial debe ser mayor o igual a 50 mil pesos
        //1.3 El valor de la consignación se le adicionará al valor del saldo aumentará
        //Dado El cliente tiene una cuenta de ahorro
        //Número 10001, Nombre “Cuenta ejemplo”, Saldo de 0
        //Cuando Va a consignar el valor inicial de 50 mil pesos
        //Entonces El sistema registrará la consignación
        //AND presentará el mensaje. “Su Nuevo Saldo es de $50.000,00 pesos m/c”.
        [Test]
        public void PuedeConsignacionInicialCorrectaCuentaAhorroTest()
        {
            //Preparar
            var cuentaAhorro = new CuentaAhorro(numero: "10001", nombre: "Cuenta Ahorro", ciudad: "Valledupar");
            //Acción
            var resultado = cuentaAhorro.Consignar(50000, "01", "12", "2020");
            //Verificación
            Assert.AreEqual("Su Nuevo Saldo es de $50.000,00 pesos m/c", resultado);
        }

   
        //Escenario: Consignación Inicial Incorrecta
        //HU: Como Usuario quiero realizar consignaciones a una cuenta de ahorro para salvaguardar el dinero.
        //Criterio de Aceptación:
        //1.1 La consignación inicial debe ser mayor o igual a 50 mil pesos
        //Dado El cliente tiene una cuenta de ahorro con
        //Número 10001, Nombre “Cuenta ejemplo”, Saldo de 0
        //Cuando Va a consignar el valor inicial de $49.999 pesos
        //Entonces El sistema no registrará la consignación
        //AND presentará el mensaje. “El valor mínimo de la primera consignación debe ser de $50.000 mil pesos. Su nuevo saldo es $0 pesos”. 

        [Test]
        public void NoPuedeConsignarMenosDeCincuentaMilPesosTest()
        {
            //Preparar
            var cuentaAhorro = new CuentaAhorro(numero: "10001", nombre: "Cuenta Ahorro", ciudad: "Valledupar");
            //Acción
            var resultado = cuentaAhorro.Consignar(49999, "01", "12", "2020");
            //Verificación
            Assert.AreEqual("El valor mínimo de la primera consignación debe ser de $50.000 mil pesos. Su nuevo saldo es $0 pesos", resultado);
        }


        //Escenario: Consignación posterior a la inicial correcta
        //HU: Como Usuario quiero realizar consignaciones a una cuenta de ahorro para salvaguardar el dinero.
        //Criterio de Aceptación:
        //1.3 El valor de la consignación se le adicionará al valor del saldo aumentará
        //Dado El cliente tiene una cuenta de ahorro con un saldo de 30.000
        //Cuando Va a consignar el valor inicial de $49.950 pesos
        //Entonces El sistema registrará la consignación
        //AND presentará el mensaje. “Su Nuevo Saldo es de $79.950,00 pesos m/c”.

        [Test]
        public void ConsignacionPosteriorALaInicialCorrectaTest()
        {
            //Preparar
            var cuentaAhorro = new CuentaAhorro(numero: "10001", nombre: "Cuenta Ahorro", ciudad: "Valledupar");
            //Acción
            var consignacion1 = cuentaAhorro.Consignar(50000, "01", "12", "2020");
            var retiro1 = cuentaAhorro.Retirar(20000, "01", "12", "2020");
            var consignacion2 = cuentaAhorro.Consignar(49950, "01", "12", "2020");
            //Verificación
            Assert.AreEqual("Su Nuevo Saldo es de $79.950,00 pesos m/c", consignacion2);
        }




        //Escenario1: El valor a retirar se debe descontar del saldo de la cuenta, la cual debe tener minimo 20000 de saldo
        //HU 2.
        //Como Usuario quiero realizar retiros a una cuenta de ahorro para obtener el dinero en efectivo
        //Criterios de Aceptación
        //2.1 El valor a retirar se debe descontar del saldo de la cuenta.
        //2.2 El saldo mínimo de la cuenta deberá ser de 20 mil pesos.
        //2.3 Los primeros 3 retiros del mes no tendrán costo.
        //2.4 Del cuarto retiro en adelante del mes tendrán un valor de 5 mil pesos.


        [Test]
        public void DescontarSaldoaRetirarCuentaAhorroTest()
        {
            //Preparar
            var cuentaAhorro = new CuentaAhorro(numero: "10001", nombre: "Cuenta Ahorro", ciudad: "Valledupar");
            //Acción
            var resultado = cuentaAhorro.Retirar(10000, "01", "12", "2020");
            //Verificación
            Assert.AreEqual("No tiene fondos suficientes (minimo 20000)", resultado);
        }



        //Escenario2: Los primeros 3 retiros del mes no tendrán costo
        //HU 2.
        //Como Usuario quiero realizar retiros a una cuenta de ahorro para obtener el dinero en efectivo
        //Criterios de Aceptación
        //2.1 El valor a retirar se debe descontar del saldo de la cuenta.
        //2.2 El saldo mínimo de la cuenta deberá ser de 20 mil pesos.
        //2.3 Los primeros 3 retiros del mes no tendrán costo.
        //2.4 Del cuarto retiro en adelante del mes tendrán un valor de 5 mil pesos.


        [Test]
        public void PrimerosRetirosSinCostoCuentaAhorroTest()
        {
            //Preparar
            var cuentaAhorro = new CuentaAhorro(numero: "10001", nombre: "Cuenta Ahorro", ciudad: "Valledupar");
            var consignacion = cuentaAhorro.Consignar(50000, "01", "12", "2020");
            //Acción
            var resultado = cuentaAhorro.Retirar(20000, "01", "12", "2020");
            //Verificación
             Assert.AreEqual("transaccion sin costo", resultado);
        }


        //Escenario2: Del cuarto retiro en adelante del mes tendrán un valor de 5 mil pesos.
        //HU 2.
        //Como Usuario quiero realizar retiros a una cuenta de ahorro para obtener el dinero en efectivo
        //Criterios de Aceptación
        //2.1 El valor a retirar se debe descontar del saldo de la cuenta.
        //2.2 El saldo mínimo de la cuenta deberá ser de 20 mil pesos.
        //2.3 Los primeros 3 retiros del mes no tendrán costo.
        //2.4 Del cuarto retiro en adelante del mes tendrán un valor de 5 mil pesos.


        [Test]
        public void RetirosConCostoCuentaAhorroTest()
        {  
            //Preparar
            var cuentaAhorro = new CuentaAhorro(numero: "10001", nombre: "Cuenta Ahorro", ciudad: "Valledupar");
            var consignacion = cuentaAhorro.Consignar(70000, "01", "12", "2020");
            //Acción
            var retiro1 = cuentaAhorro.Retirar(2000, "01", "12", "2020");
            var retiro2 = cuentaAhorro.Retirar(2000, "01", "12", "2020");
            var retiro3 = cuentaAhorro.Retirar(2000, "01", "12", "2020");
            var retiro4 = cuentaAhorro.Retirar(2000, "01", "12", "2020");
            //Verificación
            Assert.AreEqual("usted sobrepaso el número de transacciones gratis, por lo tanto se le descontaran 5 mil ", retiro4);
            Assert.AreEqual(cuentaAhorro.Saldo, 57000);
            
        }







    }

}