﻿using Banco.Core.Domain;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Banco.Domain.Test
{
    class TarjetaCreditoTest
    {

        [SetUp]
        public void Setup()
        {
        }

        /*
        Escenario 1: El valor a abono no puede ser menor o igual a 0.
        HU 5.
        Como Usuario quiero realizar consignaciones (abonos) a una Tarjeta Crédito para abonar al saldo
        del servicio.
        Criterios de Aceptación
        5.1 El valor a abono no puede ser menor o igual a 0.
        5.2 El abono podrá ser máximo el valor del saldo de la tarjeta de crédito.
        5.3 Al realizar un abono el cupo disponible aumentará con el mismo valor que el valor del abono
        y reducirá de manera equivalente el saldo.         
        */

        [Test]

        public void NoPuedeAbonarMenorIgualACeroTarjetaCreditoTest()
        {
            //Preparar
            var tarjetaCredito = new TarjetaCredito(numero: "10001", nombre: "Cuenta Corriente", ciudad: "Valledupar", cupo: 5000000);
            //Acción
            var resultado = tarjetaCredito.Consignar(0, "01", "12", "2020", "Valledupar");
            //Verificación
            Assert.AreEqual("El valor mínimo de la primera consignación debe ser mayor a cero pesos", resultado);
        }

        /*
       Escenario 2: El abono podrá ser máximo el valor del saldo de la tarjeta de crédito.
       HU 5.
       Como Usuario quiero realizar consignaciones (abonos) a una Tarjeta Crédito para abonar al saldo
       del servicio.
       Criterios de Aceptación
       5.1 El valor a abono no puede ser menor o igual a 0.
       5.2 El abono podrá ser máximo el valor del saldo de la tarjeta de crédito.
       5.3 Al realizar un abono el cupo disponible aumentará con el mismo valor que el valor del abono
       y reducirá de manera equivalente el saldo.         
       */

        [Test]

        public void AbonoNoMayorAlSaldoTarjetaCreditoTest()
        {
            //Preparar
            var tarjetaCredito = new TarjetaCredito(numero: "10001", nombre: "Cuenta Corriente", ciudad: "Valledupar", cupo: 30000);
            //Acción
            var resultado = tarjetaCredito.Consignar(31000, "01", "12", "2020", "Valledupar");
            //Verificación
            Assert.AreEqual("El valor a consignar supera el saldo", resultado);
        }

        /*
        Escenario 3: Al realizar un abono el cupo disponible aumentará con el mismo valor que el valor del abono
        y reducirá de manera equivalente el saldo.
        HU 5.
        Como Usuario quiero realizar consignaciones (abonos) a una Tarjeta Crédito para abonar al saldo
        del servicio.
        Criterios de Aceptación
        5.1 El valor a abono no puede ser menor o igual a 0.
        5.2 El abono podrá ser máximo el valor del saldo de la tarjeta de crédito.
        5.3 Al realizar un abono el cupo disponible aumentará con el mismo valor que el valor del abono
        y reducirá de manera equivalente el saldo.         
        */

        [Test]

        public void AumentarCupoConElValorDelAbonoTarjetaCreditoTest()
        {
            //Preparar
            var tarjetaCredito = new TarjetaCredito(numero: "10001", nombre: "Tarjeta de Credito", ciudad: "Valledupar", cupo: 300000);
            //Acción
            var resultado = tarjetaCredito.Consignar(5000, "01", "12", "2020", "Valledupar");
            //Verificación
            Assert.AreEqual("Abono exitoso", resultado);
            Assert.AreEqual(tarjetaCredito.Saldo, 295000);
            Assert.AreEqual(tarjetaCredito.Cupo, 5000);
        }

        /*
        Escenario 1: El valor del avance debe ser mayor a 0.
        HU 6.
        Como Usuario quiero realizar retiros (avances) a una cuenta de crédito para retirar dinero en
        forma de avances del servicio de crédito.
        Criterios de Aceptación
        6.1 El valor del avance debe ser mayor a 0.
        6.2 Al realizar un avance se debe reducir el valor disponible del cupo con el valor del avance.
        6.3 Un avance no podrá ser mayor al valor disponible del cupo.
         */

        [Test]

        public void AvanceMayorACeroTarjetaCreditoTest()
        {
            //Preparar
            var tarjetaCredito = new TarjetaCredito(numero: "10001", nombre: "Tarjeta de Credito", ciudad: "Valledupar", cupo: 300000);
            //Acción
            var resultado = tarjetaCredito.Retirar(0, "01", "12", "2020", "Valledupar");
            //Verificación
            Assert.AreEqual("El Avance debe ser mayor a cero pesos", resultado);
        }

        /*
       Escenario 2: Al realizar un avance se debe reducir el valor disponible del cupo con el valor del avance.
       HU 6.
       Como Usuario quiero realizar retiros (avances) a una cuenta de crédito para retirar dinero en
       forma de avances del servicio de crédito.
       Criterios de Aceptación
       6.1 El valor del avance debe ser mayor a 0.
       6.2 Al realizar un avance se debe reducir el valor disponible del cupo con el valor del avance.
       6.3 Un avance no podrá ser mayor al valor disponible del cupo.
        */

        [Test]

        public void ReducirElValorDelCupoTarjetaCreditoTest()
        {
            //Preparar
            var tarjetaCredito = new TarjetaCredito(numero: "10001", nombre: "Tarjeta de Credito", ciudad: "Valledupar", cupo: 300000);
            //Acción
            var resultado = tarjetaCredito.Retirar(50000, "01", "12", "2020", "Valledupar");
            //Verificación
            Assert.AreEqual("Avance exitoso", resultado);
        }

        /*
         Escenario 3: Un avance no podrá ser mayor al valor disponible del cupo.
         HU 6.
         Como Usuario quiero realizar retiros (avances) a una cuenta de crédito para retirar dinero en
         forma de avances del servicio de crédito.
         Criterios de Aceptación
         6.1 El valor del avance debe ser mayor a 0.
         6.2 Al realizar un avance se debe reducir el valor disponible del cupo con el valor del avance.
         6.3 Un avance no podrá ser mayor al valor disponible del cupo.
          */

        [Test]

        public void AvanceNoMayorAlCupoTarjetaCreditoTest()
        {
            //Preparar
            var tarjetaCredito = new TarjetaCredito(numero: "10001", nombre: "Tarjeta de Credito", ciudad: "Valledupar", cupo: 300000);
            //Acción
            var resultado = tarjetaCredito.Retirar(301000, "01", "12", "2020", "Valledupar");
            //Verificación
            Assert.AreEqual("El Avance no puede ser mayor al cupo disponible", resultado);
        }
    }
}
