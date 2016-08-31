using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormacionPOO.Herencia
{
    public class Avion : Vehiculo, IVehiculo
    {
        #region Campos
        private int _numeroMotores;
        private int _maximaAltitud;
        private int _velocidadDespegue;
        private int _velocidadAterrizaje;
        private bool _volando;
        #endregion

        #region Propiedades
        public int NumeroMotores
        {
            get
            {
                return _numeroMotores;
            }
        }

        public int MaximaAltitud
        {
            get
            {
                return _maximaAltitud;
            }
        }

        public int VelocidadDespegue
        {
            get
            {
                return _velocidadDespegue;
            }
        }

        public int VelocidadAterrizaje
        {
            get
            {
                return _velocidadAterrizaje;
            }
        }

        public bool Volando
        {
            get
            {
                return _volando;
            }
        }
        #endregion

        #region Métodos
        public override void Frenar(int velocidad)
        {
            if (this._estado == "Parado" || this._estado == "Arrancado")
            {
                throw new Exception("El vehículo no está en movimiento. No se puede frenar.");
            }

            if (velocidad > this._velocidad)
            {
                if (this._volando == false)
                {
                    this._velocidad = 0;
                    this._estado = "Arrancado";
                }
                else
                {
                    throw new Exception("La velocidad del vehículo en el aire no puede ser 0 km/h.");
                }
            }

            this._velocidad = this._velocidad - velocidad;

            if (this._velocidad < this._velocidadAterrizaje)
            {
                throw new Exception(String.Format("La velocidad del vehículo no puede ser menor a la velocidad de aterrizaje: {0} km/h.", this._velocidadAterrizaje));
            }
        }

        public void Despegar()
        {
            if (this._estado == "En movimiento" && this._velocidad == this._velocidadDespegue && this._volando == false)
            {
                this._volando = true;
            }
            else
            {
                throw new Exception("El avión no puede despegar. Los parámetros de despegueno son correctos.");
            }
        }

        public void Aterrizar()
        {
            if (this._estado == "En movimiento" && this._velocidad == this._velocidadAterrizaje && this._volando == true)
            {
                this._volando = false;
            }
            else
            {
                throw new Exception("El avión no puede aterrizar. Los parámetros de aterrizaje no son correctos.");
            }
        }
        #endregion


        // Constructor
        public Avion(string color, string marca, string modelo, int numeroMotores, int maximaAltitud, int velocidadDespegue, int velocidadAterrizaje) : base(color, marca, modelo)
        {
            _numeroMotores = numeroMotores;
            _maximaAltitud = maximaAltitud;
            _velocidadDespegue = velocidadDespegue;
            _velocidadAterrizaje = velocidadAterrizaje;
        }
    }
}
