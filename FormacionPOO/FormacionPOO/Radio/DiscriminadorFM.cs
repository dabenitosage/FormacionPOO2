using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormacionPOO
{
    /// <summary>
    /// Calcula mediante metodos de sintonización la señal a partir del numero de aumentos.
    /// </summary>
    public class DiscriminadorFM
    {
        #region Campos (Atributos - Estado)

        int _numDiodos;
        double _señalModulada;
        enumDiscriminador _tipoDiscriminador;

        #endregion

        //Constructor
        public DiscriminadorFM(int diodos, enumDiscriminador tipoDiscriminador)
        {
            _numDiodos = diodos;
            _tipoDiscriminador = tipoDiscriminador;
        }

        // Destructor
        ~DiscriminadorFM()
        {
            _señalModulada = 0;
        }


        #region Métodos (Comportamiento)

        public double DemodularSeñal(int numeroAumentos)
        {
            if (_tipoDiscriminador == enumDiscriminador.DeFoster)
                _señalModulada += (_numDiodos * numeroAumentos / Math.PI);
            else if (_tipoDiscriminador == enumDiscriminador.DetectorRelacion)
                _señalModulada += ((_numDiodos * ((numeroAumentos * 2) * Math.Sin(3) / Math.PI) * 4));
            else
                _señalModulada += 10.7;

            if (_señalModulada > 120)
            {
                _señalModulada = _señalModulada % 120;
            }



            return _señalModulada;

        }

        #endregion
    }
}
