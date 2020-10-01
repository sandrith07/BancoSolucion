using Banco.Core.Domain;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Banco.Domain.Test
{
    class CDTTest
    {

        [SetUp]
        public void Setup()
        {
        }

        /*
        Escenario 1: El valor de consignación inicial debe ser de mínimo 1 millón de pesos.
        HU 7.
        Como Usuario quiero realizar consignar mi dinero a mi CDT para ahorrar el dinero sin tener
        acceso al de acuerdo al término definido.
        Criterios de Aceptación
        7.1 El valor de consignación inicial debe ser de mínimo 1 millón de pesos.
        7.2 Sólo se podrá realizar una sola consignación. 
        */

        [Test]

        public void ConsigancionInicialMinimoUnMillonCDTTest()
        {
            //Preparar
            var cdt = new CDT(numero: "10001", nombre: "CDT", ciudad: "Valledupar", termino: "Anual", interes: 0.5);
            //Acción
            var resultado = cdt.Consignar(999999, "01", "12", "2020");
            //Verificación
            Assert.AreEqual("El valor mínimo de la primera consignación debe de mínimo 1 millon de pesos", resultado);
        }

        /*
        Escenario 2: Sólo se podrá realizar una sola consignación. 
        HU 7.
        Como Usuario quiero realizar consignar mi dinero a mi CDT para ahorrar el dinero sin tener
        acceso al de acuerdo al término definido.
        Criterios de Aceptación
        7.1 El valor de consignación inicial debe ser de mínimo 1 millón de pesos.
        7.2 Sólo se podrá realizar una sola consignación. 
        */


        [Test]

        public void SoloUnaConsignacionCDTTest()
        {
            //Preparar
            var cdt = new CDT(numero: "10001", nombre: "CDT", ciudad: "Valledupar", termino: "Anual", interes: 0.5);
            //Acción
            var consignacion1 = cdt.Consignar(1200000, "01", "12", "2020");
            var consignacion2 = cdt.Consignar(3000000, "01", "12", "2020");
            //Verificación
            Assert.AreEqual("No puede realizar mas de una consignacion", consignacion2);
        }


       
    }
}
