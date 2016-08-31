using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormacionPOO
{
    /// <summary>
    /// Componente amplificador que calcula el tipo de frecuencia, volumen en decibilios y obtiene la nueva señal escaneada de emisora.
    /// </summary>
    public class AmplificadorRadioFrecuencia
    {
        #region Campos (Atributos - Estado)

        private int _diodos;
        private enumFrecuenciaSintonizado _tiposintonizado;
        private DiscriminadorFM _discriminador;
        private int numeroDecibelios = 0;

        #endregion

        #region Propiedades

        public enumFrecuenciaSintonizado Tiposintonizado
        {
            get { return _tiposintonizado; }
            set { _tiposintonizado = value; }
        }

        #endregion

        //Constructor
        public AmplificadorRadioFrecuencia(int numDiodos)
        {
            _diodos = numDiodos;
        }

        #region Métodos (Comportamiento)

        public void AumentarDecibelios()
        {
            numeroDecibelios += 20;
        }

        public void DisminuirDecibelios()
        {
            if (numeroDecibelios != 0)
                numeroDecibelios -= 20;
        }

        public double NuevaSeñalEscaneada(int numAumentos)
        {
            enumDiscriminador tipoDiscriminador = CalcularDiscriminador(numAumentos);
            _discriminador = new DiscriminadorFM(_diodos, tipoDiscriminador);
            return _discriminador.DemodularSeñal(numAumentos);
        }

        private enumDiscriminador CalcularDiscriminador(int numAumentos)
        {
            if (numAumentos > 10 && numeroDecibelios < 60)
            {
                _tiposintonizado = enumFrecuenciaSintonizado.AM;
            }
            else
            {
                _tiposintonizado = enumFrecuenciaSintonizado.FM;
            }

            enumDiscriminador tipodiscriminador;
            switch (_tiposintonizado)
            {
                case enumFrecuenciaSintonizado.AM:
                    tipodiscriminador = enumDiscriminador.DeFoster;
                    break;
                case enumFrecuenciaSintonizado.FM:
                    tipodiscriminador = enumDiscriminador.DetectorRelacion;
                    break;
                default:
                    tipodiscriminador = enumDiscriminador.Error;
                    break;
            }

            return tipodiscriminador;
        }

        #endregion

    }
}
