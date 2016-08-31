
using System;
namespace FormacionPOO.Herencia
{
    public abstract class Vehiculo : IVehiculo
    {
        #region Campos
        private string _color;
        private string _marca;
        private string _modelo;
        protected int _velocidad;
        protected string _estado;
        #endregion

        #region Propiedades
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

        public int Velocidad
        {
            get
            {
                return _velocidad;
            }
        }

        /// <summary>
        /// Valores: Parado, Arrancado, En movimiento.
        /// </summary>
        public string Estado
        {
            get
            {
                return _estado;
            }
        }
        #endregion

        #region Métodos
        public void Arrancar()
        {
            if (this._estado == "Parado")
            {
                this._estado = "Arrancado";
            }
        }

        public void Parar()
        {
            if (this._estado == "Arrancado")
            {
                this._estado = "Parado";
            }
        }

        public void Acelerar(int velocidad) 
        {
            if (this._estado == "Parado")
            {
                throw new Exception("El vehículo está parado. Arráncalo.");
            }

            if (this._estado != "En movimiento")
            {
                this._estado = "En movimiento";
            }

            this._velocidad = this._velocidad + velocidad;
        }

        public abstract void Frenar(int velocidad);
        #endregion

        // Constructor
        public Vehiculo(string color, string marca, string modelo)
        {
            _velocidad = 0;
            _estado = "Parado";
            _color = color;
            _marca = marca;
            _modelo = modelo;
        }

        // Destructor
        ~Vehiculo()
        {
            _velocidad = 0;
        }
    }
}
