using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FormacionPOO;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
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
            _turismo.Acelerar(30);
            Console.ReadLine();
            _turismo.Frenar(10); 
            Console.ReadLine();
            _turismo.Frenar(20);
            Console.ReadLine();
            _turismo.Parar();
            Console.ReadLine();
        }

        private static Coche CrearDeportivo()
        {
            var _motorDeportivo = new Motor
            {
                Cilindrada = 3000,
                Combustible = "GASOLINA",
                Potencia = 300
            };

            var _coche = CrearCoche("ROJO", "FERRARI", "TESTARROSA", 2, _motorDeportivo);

            return _coche;
        }

        private static Coche CrearTurismo()
        {
            var _motorTurismo = new Motor
            {
                Cilindrada = 1500,
                Combustible = "GASOLINA",
                Potencia = 70
            };

            var _coche = CrearCoche("BLANCO", "SEAT", "PANDA", 3, _motorTurismo);

            return _coche;
        }

        private static Coche CrearCoche(string color, string marca, string modelo, int numeroPuertas, Motor motor) 
        {
            var _coche = new Coche(color, marca, modelo, numeroPuertas, motor); 
            
            return _coche;
        }
    }
}
