using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormacionPOO
{
    public class Coche
    {
        #region Campos (Atributos - Estado)
        private string _matricula;
        private string _color;
        private string _marca;
        private string _modelo;
        private int _numeroRuedas;
        private int _numeroPuertas;
        private Motor _motor;
        private int _velocidad;
        #endregion

        #region Propiedades
        public string Matricula     
        {
            get 
            {
                return _matricula; 
            }
        }

        public string Color
        {
            get
            {
                return _color;
            }
        }

        public string Marca
        {
            get
            {
                return _marca;
            }
        }

        public string Modelo
        {
            get
            {
                return _modelo;
            }
        }

        public int NumeroRuedas
        {
            get
            {
                return _numeroRuedas;
            }
        }

        public int NumeroPuertas
        {
            get
            {
                return _numeroPuertas;
            }
        }

        public Motor Motor
        {
            get
            {
                return _motor;
            }
        }

        public int Velocidad
        {
            get
            {
                return _velocidad;
            }
        }
        #endregion
        
        
        // Constructor
        public Coche(string color, string marca, string modelo, int numeroPuertas, Motor motor) 
        {
            _numeroRuedas = 4; //rueda firestone especial
            _velocidad = 0;
            _color = color;
            _marca = marca;
            _modelo = modelo;
            _numeroPuertas = numeroPuertas;
            _motor = motor;
        }

        // Destructor
        ~Coche() 
        {
            _velocidad = 0;
        }


        #region Métodos (Comportamiento)

        public void Matricular(string matricula) 
        {
            this._matricula = matricula;
            Console.WriteLine("El vehículo {0} {1} ha sido matriculado con el número de matrícula: {2}.", _marca, _modelo, _matricula);
        }

        public void Arrancar() 
        {
            Console.WriteLine("El vehículo {0} {1} ha arrancado.", _marca, _modelo);
        }

        public void Parar()
        {
            this._velocidad = 0;
            Console.WriteLine("El vehículo {0} {1} ha parado.", _marca, _modelo);
        }

        public void Acelerar(int velocidad) 
        {
            this._velocidad = this._velocidad + velocidad;
            Console.WriteLine("El vehículo {0} {1} ha aumentado la velocidad {2} km/h. Su velocidad actual es: {3}.", _marca, _modelo, velocidad.ToString(), _velocidad.ToString());
        }
                
        public void Frenar(int velocidad) 
        {
            if (this._velocidad == 0)
            {
                throw new ArgumentException("El vehículo ya está frenado.");
            }

            this._velocidad = this._velocidad - velocidad;
            Console.WriteLine("El vehículo {0} {1} ha disminuido la velocidad {2} km/h. Su velocidad actual es: {3}.", _marca, _modelo, velocidad.ToString(), _velocidad.ToString());
        }

        public void GirarIzquierda(int grados) 
        {
            Console.WriteLine("El vehículo {0} {1} ha girado a la izquierda {2} grados.", _marca, _modelo, grados.ToString());
        }

        public void GirarDerecha(int grados) 
        {
            Console.WriteLine("El vehículo {0} {1} ha girado a la derecha {2} grados.", _marca, _modelo, grados.ToString());
        }

        public void Retroceder(int velocidad) 
        {
            Console.WriteLine("El vehículo {0} {1} ha retrocedido a {2} km/h.", _marca, _modelo, velocidad.ToString());
        }

        #endregion
    }
}
