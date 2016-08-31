using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormacionPOO.Herencia
{
    public class Coche : Vehiculo, IVehiculo
    {
        #region Campos
        private string _matricula;
        private int _numeroRuedas;
        private int _numeroPuertas;
        private Motor _motor;
        #endregion

        #region Propiedades
        public string Matricula
        {
            get
            {
                return _matricula;
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
        #endregion

        #region Métodos
        public void Matricular(string matricula)
        {
            this._matricula = matricula;
        }

        public override void Frenar(int velocidad)
        {
            if (base._estado == "Parado" || base._estado == "Arrancado")
            {
                throw new Exception("El vehículo no está en movimiento. No se puede frenar.");
            }

            if (velocidad > base._velocidad)
            {
                base._velocidad = 0;
                base._estado = "Arrancado";
            }

            base._velocidad = base._velocidad - velocidad;

            if (base._velocidad == 0)
            {
                base._estado = "Arrancado";
            }
        }
        #endregion
        

        public Coche(string color, string marca, string modelo, int numeroPuertas, Motor motor) : base(color, marca, modelo)
        {
            this._numeroRuedas = 4;
            this._numeroPuertas = numeroPuertas;
            this._motor = motor;
        }
    }
}
