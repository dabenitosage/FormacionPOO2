using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FormacionPOO.Test
{
    [TestClass]
    public class FormacionPOOTest
    {
        [TestMethod]
        public void FormacionPOOTest_Ejemplo1() 
        {
            // Crear coche 1: turismo.
            var _motorTurismo = new Motor
            {
                Cilindrada = 1500,
                Combustible = "DIESEL",
                Potencia = 70
            };

            var _turismo = new Coche("CELESTE", "SEAT", "PANDA", 3, _motorTurismo);

            // Crear coche 2: deportivo.
            var _motorDeportivo = new Motor
            {
                Cilindrada = 3000,
                Combustible = "GASOLINA",
                Potencia = 300
            };

            var _deportivo = new Coche("ROJO", "FERRARI", "TESTARROSA", 2, _motorDeportivo);

            Assert.IsNotNull(_turismo);
        }

        

        private Coche CrearDeportivo()
        {
            var _motorDeportivo = new Motor
            {
                Cilindrada = 3000,
                Combustible = "GASOLINA",
                Potencia = 300
            };

            var _coche = new Coche("ROJO", "FERRARI", "TESTARROSA", 2, _motorDeportivo);

            return _coche;
        }

        private Coche CrearTurismo()
        {
            var _motorTurismo = new Motor
            {
                Cilindrada = 1500,
                Combustible = "GASOLINA",
                Potencia = 70
            };

            var _coche = new Coche("BLANCO", "SEAT", "PANDA", 3, _motorTurismo);

            return _coche;
        }
    }
}
