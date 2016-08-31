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

        /// <summary>
        /// Diapositiva 
        /// </summary>
        [TestMethod]
        public void FormacionPOOTest_Ejemplox() 
        {
            // Crear coche 1: turismo.
            var _turismo = CrearTurismo();

            // Crear coche 2: deportivo.
            var _deportivo = CrearDeportivo();

            // Recorrido turismo.
            _turismo.Arrancar();
            Console.ReadLine();
            _turismo.Acelerar(60);
            Console.ReadLine();
            _turismo.Frenar(10);
            Console.ReadLine();
            _turismo.GirarDerecha(90);
            Console.ReadLine();
            _turismo.Acelerar(30);
            Console.ReadLine();
            _turismo.Frenar(10);
            Console.ReadLine();
            _turismo.GirarIzquierda(90);
            Console.ReadLine();
            _turismo.Frenar(20);
            Console.ReadLine();
            _turismo.Parar();
            Console.ReadLine();

            Assert.IsTrue(_turismo.Velocidad == 0);
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

        /// <summary>
        /// Diapositiva 
        /// </summary>
        [TestMethod]
        public void FormacionPOOTest_Ejemplo2_POO()
        {
            // Crear radio POO.
            var _radio = new Radio();

           

            // Recorrido turismo.
            _radio.VerPantallaLcd();
            _radio.SubirVolumen();
            _radio.SubirVolumen();
            _radio.SubirVolumen();
            _radio.BajarVolumen();
            _radio.BuscarNuevaEmisora();
            _radio.SubirVolumen();
            _radio.BuscarNuevaEmisora();
            _radio.BajarVolumen();
            _radio.BajarVolumen();
            _radio.BajarVolumen();

            Assert.IsTrue(true);
        }

        [TestMethod]
        public void FormacionPOOTest_Ejemplo2_Secuencial()
        {
            // Crear radio secuencial.
            var _radio = new RadioSecuencial();



            // Recorrido turismo.
            _radio.VerPantallaLcd();
            _radio.SubirVolumen();
            _radio.SubirVolumen();
            _radio.SubirVolumen();
            _radio.BajarVolumen();
            _radio.BuscarNuevaEmisora();
            _radio.SubirVolumen();
            _radio.BuscarNuevaEmisora();
            _radio.BajarVolumen();
            _radio.BajarVolumen();
            _radio.BajarVolumen();

            Assert.IsTrue(true);
        }

    }
}
