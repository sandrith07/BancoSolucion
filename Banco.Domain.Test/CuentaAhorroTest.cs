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


        //Escenario: Valor de consignaci�n negativo o cero 
        //H1: Como Usuario quiero realizar consignaciones a una cuenta de ahorro para salvaguardar el dinero.
        //Criterio de Aceptaci�n:
        //1.2 El valor a abono no puede ser menor o igual a 0
        //Ejemplo
        //Dado El cliente tiene una cuenta de ahorro                                       //A =>Arrange /Preparaci�n
        //N�mero 10001, Nombre �Cuenta ejemplo�, Saldo de 0 , ciudad Valledupar                               
        //Cuando Va a consignar un valor menor o igual a cero  (0)                            //A =>Act = Acci�n
        //Entonces El sistema presentar� el mensaje. �El valor a consignar es incorrecto�  //A => Assert => Validaci�n
        [Test]

        public void NoPuedeConsignacionValorNegativoCuentaAhorroTest()
        {
            //Preparar
            var cuentaAhorro = new CuentaAhorro(numero: "10001", nombre: "Cuenta Ahorro", ciudad: "Valledupar");
            //Acci�n
            var resultado = cuentaAhorro.Consignar(0, "01", "12", "2020", "Valledupar");
            //Verificaci�n
            Assert.AreEqual("El valor a consignar es incorrecto", resultado);
        }

        //Escenario: Consignaci�n Inicial Correcta
        //HU: Como Usuario quiero realizar consignaciones a una cuenta de ahorro para salvaguardar el dinero.
        //Criterio de Aceptaci�n:
        //1.1 La consignaci�n inicial debe ser mayor o igual a 50 mil pesos
        //1.3 El valor de la consignaci�n se le adicionar� al valor del saldo aumentar�
        //Dado El cliente tiene una cuenta de ahorro
        //N�mero 10001, Nombre �Cuenta ejemplo�, Saldo de 0
        //Cuando Va a consignar el valor inicial de 50 mil pesos
        //Entonces El sistema registrar� la consignaci�n
        //AND presentar� el mensaje. �Su Nuevo Saldo es de $50.000,00 pesos m/c�.
        [Test]
        public void PuedeConsignacionInicialCorrectaCuentaAhorroTest()
        {
            //Preparar
            var cuentaAhorro = new CuentaAhorro(numero: "10001", nombre: "Cuenta Ahorro", ciudad: "Valledupar");
            //Acci�n
            var resultado = cuentaAhorro.Consignar(50000, "01", "12", "2020", "Valledupar");
            //Verificaci�n
            Assert.AreEqual("Su Nuevo Saldo es de $50.000,00 pesos m/c", resultado);
        }

   
        //Escenario: Consignaci�n Inicial Incorrecta
        //HU: Como Usuario quiero realizar consignaciones a una cuenta de ahorro para salvaguardar el dinero.
        //Criterio de Aceptaci�n:
        //1.1 La consignaci�n inicial debe ser mayor o igual a 50 mil pesos
        //Dado El cliente tiene una cuenta de ahorro con
        //N�mero 10001, Nombre �Cuenta ejemplo�, Saldo de 0
        //Cuando Va a consignar el valor inicial de $49.999 pesos
        //Entonces El sistema no registrar� la consignaci�n
        //AND presentar� el mensaje. �El valor m�nimo de la primera consignaci�n debe ser de $50.000 mil pesos. Su nuevo saldo es $0 pesos�. 

        [Test]
        public void NoPuedeConsignarMenosDeCincuentaMilPesosTest()
        {
            //Preparar
            var cuentaAhorro = new CuentaAhorro(numero: "10001", nombre: "Cuenta Ahorro", ciudad: "Valledupar");
            //Acci�n
            var resultado = cuentaAhorro.Consignar(49999, "01", "12", "2020","Valledupar");
            //Verificaci�n
            Assert.AreEqual("El valor m�nimo de la primera consignaci�n debe ser de $50.000 mil pesos. Su nuevo saldo es $0 pesos", resultado);
        }


        //Escenario: Consignaci�n posterior a la inicial correcta
        //HU: Como Usuario quiero realizar consignaciones a una cuenta de ahorro para salvaguardar el dinero.
        //Criterio de Aceptaci�n:
        //1.3 El valor de la consignaci�n se le adicionar� al valor del saldo aumentar�
        //Dado El cliente tiene una cuenta de ahorro con un saldo de 30.000
        //Cuando Va a consignar el valor inicial de $49.950 pesos
        //Entonces El sistema registrar� la consignaci�n
        //AND presentar� el mensaje. �Su Nuevo Saldo es de $79.950,00 pesos m/c�.

        [Test]
        public void ConsignacionPosteriorALaInicialCorrectaTest()
        {
            //Preparar
            var cuentaAhorro = new CuentaAhorro(numero: "10001", nombre: "Cuenta Ahorro", ciudad: "Valledupar");
            //Acci�n
            var consignacion1 = cuentaAhorro.Consignar(50000, "01", "12", "2020", "Valledupar");
            var retiro1 = cuentaAhorro.Retirar(20000, "01", "12", "2020", "Valledupar");
            var consignacion2 = cuentaAhorro.Consignar(49950, "01", "12", "2020", "Valledupar");
            //Verificaci�n
            Assert.AreEqual("Su Nuevo Saldo es de $79.950,00 pesos m/c", consignacion2);
        }

        /*
        Escenario: Consignaci�n posterior a la inicial correcta
        HU: Como Usuario quiero realizar consignaciones a una cuenta de ahorro para salvaguardar el
        dinero.
        Criterio de Aceptaci�n:
        1.4 La consignaci�n nacional (a una cuenta de otra ciudad) tendr� un costo de $10 mil pesos.
        Dado El cliente tiene una cuenta de ahorro con un saldo de 30.000 perteneciente a una
        sucursal de la ciudad de Bogot� y se realizar� una consignaci�n desde una sucursal
        de la Valledupar.
        Cuando Va a consignar el valor inicial de $49.950 pesos.
        Entonces El sistema registrar� la consignaci�n restando el valor a consignar los 10 mil pesos.
        AND presentar� el mensaje. �Su Nuevo Saldo es de $69.950,00 pesos m/c�.
         */

        [Test]
        public void ConsignacionNacionalCorrectaTest()
        {
            //Preparar
            var cuentaAhorro = new CuentaAhorro(numero: "10001", nombre: "Cuenta Ahorro", ciudad: "Bogot�");
            //Acci�n
            var consignacion1 = cuentaAhorro.Consignar(50000, "01", "12", "2020", "Bogot�");
            var retiro1 = cuentaAhorro.Retirar(20000, "01", "12", "2020", "Bogot�");
            var consignacion2 = cuentaAhorro.Consignar(49950, "01", "12", "2020", "Valledupar");
            //Verificaci�n
            Assert.AreEqual("Su Nuevo Saldo es de $69.950,00 pesos m/c", consignacion2);
            

        }




        //Escenario1: El valor a retirar se debe descontar del saldo de la cuenta, la cual debe tener minimo 20000 de saldo
        //HU 2.
        //Como Usuario quiero realizar retiros a una cuenta de ahorro para obtener el dinero en efectivo
        //Criterios de Aceptaci�n
        //2.1 El valor a retirar se debe descontar del saldo de la cuenta.
        //2.2 El saldo m�nimo de la cuenta deber� ser de 20 mil pesos.
        //2.3 Los primeros 3 retiros del mes no tendr�n costo.
        //2.4 Del cuarto retiro en adelante del mes tendr�n un valor de 5 mil pesos.
        //Dado El cliente tiene una cuenta de ahorro con saldo de $10.000
        //N�mero 10001, Nombre �Cuenta ejemplo�,
        //Cuando Va a retirar el valor  de $15.000
        //Entonces El sistema no registrar� el retiro
        //AND presentar� el mensaje. �No tiene fondos suficientes (minimo 20000)"�.


        [Test]
        public void DescontarSaldoaRetirarCuentaAhorroTest()
        {
            //Preparar
            var cuentaAhorro = new CuentaAhorro(numero: "10001", nombre: "Cuenta Ahorro", ciudad: "Valledupar");
            //Acci�n
            var consignacion = cuentaAhorro.Consignar(50000, "01", "12", "2020", "Valledupar");
            var retiro1 = cuentaAhorro.Retirar(40000, "01", "12", "2020", "Valledupar");
            var retiro2 = cuentaAhorro.Retirar(15000, "01", "12", "2020", "Valledupar");
            //Verificaci�n
            Assert.AreEqual("No tiene fondos suficientes (minimo 20000)", retiro2);
            Assert.AreEqual(cuentaAhorro.Saldo, 10000);
        }



        //Escenario1: El valor a retirar se debe descontar del saldo de la cuenta, la cual debe tener minimo 20000 de saldo
        //HU 2.
        //Como Usuario quiero realizar retiros a una cuenta de ahorro para obtener el dinero en efectivo
        //Criterios de Aceptaci�n
        //2.1 El valor a retirar se debe descontar del saldo de la cuenta.
        //2.2 El saldo m�nimo de la cuenta deber� ser de 20 mil pesos.
        //2.3 Los primeros 3 retiros del mes no tendr�n costo.
        //2.4 Del cuarto retiro en adelante del mes tendr�n un valor de 5 mil pesos.
        //Dado El cliente tiene una cuenta de ahorro con saldo de $100.000
        //N�mero 10001, Nombre �Cuenta ejemplo�, 
        //Cuando Va a retirar por tercera vez el valor de $20000
        //Entonces El sistema registrar� el retiro
        //AND presentar� el mensaje. �transaccion sin costo�.


        [Test]
        public void PrimerosRetirosSinCostoCuentaAhorroTest()
        {
            //Preparar
            var cuentaAhorro = new CuentaAhorro(numero: "10001", nombre: "Cuenta Ahorro", ciudad: "Valledupar");
            var consignacion = cuentaAhorro.Consignar(100000, "01", "12", "2020", "Valledupar");
            //Acci�n
            var retiro1 = cuentaAhorro.Retirar(20000, "01", "01", "2020", "Valledupar");
            var retiro2 = cuentaAhorro.Retirar(20000, "01", "01", "2020", "Valledupar");
            var retiro3 = cuentaAhorro.Retirar(20000, "01", "01", "2020", "Valledupar");
            //Verificaci�n
            Assert.AreEqual("transaccion sin costo", retiro2);
            Assert.AreEqual(cuentaAhorro.Saldo, 40000);
            
        }


        //Escenario1: El valor a retirar se debe descontar del saldo de la cuenta, la cual debe tener minimo 20000 de saldo
        //HU 2.
        //Como Usuario quiero realizar retiros a una cuenta de ahorro para obtener el dinero en efectivo
        //Criterios de Aceptaci�n
        //2.1 El valor a retirar se debe descontar del saldo de la cuenta.
        //2.2 El saldo m�nimo de la cuenta deber� ser de 20 mil pesos.
        //2.3 Los primeros 3 retiros del mes no tendr�n costo.
        //2.4 Del cuarto retiro en adelante del mes tendr�n un valor de 5 mil pesos.
        //Dado El cliente tiene una cuenta de ahorro con saldo de $100.000
        //N�mero 10001, Nombre �Cuenta ejemplo�, 
        //Cuando Va a retirar por cuarta vez el valor de $10000
        //Entonces El sistema registrar� el retiro cobrando una comision de 5 mil pesos
        //AND presentar� el mensaje. "usted sobrepaso el n�mero de transacciones gratis, por lo tanto se le descontaran 5 mil ".


        [Test]
        public void RetirosConCostoCuentaAhorroTest()
        {  
            //Preparar
            var cuentaAhorro = new CuentaAhorro(numero: "10001", nombre: "Cuenta Ahorro", ciudad: "Valledupar");
            var consignacion = cuentaAhorro.Consignar(100000, "01", "12", "2020", "Valledupar");
            //Acci�n
            var retiro1 = cuentaAhorro.Retirar(10000, "01", "12", "2020", "Valledupar");
            var retiro2 = cuentaAhorro.Retirar(10000, "01", "12", "2020", "Valledupar");
            var retiro3 = cuentaAhorro.Retirar(10000, "01", "12", "2020", "Valledupar");
            var retiro4 = cuentaAhorro.Retirar(10000, "01", "12", "2020", "Valledupar");
            //Verificaci�n
            Assert.AreEqual("usted sobrepaso el n�mero de transacciones gratis, por lo tanto se le descontaran 5 mil ", retiro4);
            Assert.AreEqual(cuentaAhorro.Saldo, 55000);
            
        }
        






    }

}