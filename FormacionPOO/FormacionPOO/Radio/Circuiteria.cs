using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormacionPOO
{
    /// <summary>
    /// Componentes electronicos que forman la radio.
    /// </summary>
    public class Circuteria
    {
        #region Campos (Atributos - Estado)

        private int diodos = 3;
        private int _puntoVolumen = 0;
        private double _puntoFrecuencia = 0;
        private AntenaReceptora _antena;
        private AmplificadorRadioFrecuencia _amplificador;
        private PantallaLcd _lcd;

        #endregion

        //Constructor
        public Circuteria()
        {
            _antena = new AntenaReceptora();
            _amplificador = new AmplificadorRadioFrecuencia(diodos);
            _lcd = new PantallaLcd();
        }

        // Destructor
        ~Circuteria()
        {
            _puntoVolumen = 0;
            _puntoFrecuencia = 0;
        }

        #region Métodos (Comportamiento)

        public void CambiarVolumen(int nuevoVolumen)
        {
            int nuevoPuntoVolumen = nuevoVolumen * 10;
            if (nuevoPuntoVolumen > 0 && nuevoPuntoVolumen <= 100)
            {

                int diferenciaAumento = nuevoPuntoVolumen - _puntoVolumen;
                for (int i = 0; i < Math.Abs(diferenciaAumento); i++)
                {

                    if (diferenciaAumento < 1)
                    {

                        _amplificador.DisminuirDecibelios();
                    }
                    else

                        _amplificador.AumentarDecibelios();
                }
                _puntoVolumen = nuevoPuntoVolumen;
            }

            if (_puntoVolumen > 0)
                _antena.Encender();
            else
                _antena.Apagar();

        }

        public double EscanearSiguienteFrecuencia(int numAumentos)
        {
            if (_antena.Encendido)
            {
                _puntoFrecuencia = _amplificador.NuevaSeñalEscaneada(numAumentos);
            }
            return _puntoFrecuencia;
        }

        public string VerPantallaLcd()
        {
            return _lcd.ObtenerPantalla(_puntoVolumen / 10, _puntoFrecuencia, _amplificador.Tiposintonizado);
        }

        #endregion
    }
}
