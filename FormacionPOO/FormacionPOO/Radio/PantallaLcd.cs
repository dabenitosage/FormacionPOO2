using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormacionPOO
{
    /// <summary>
    /// Pantalla LCD de la radio con información de la radio (emisora - volumen)
    /// </summary>
    public class PantallaLcd
    {
        #region Campos (Atributos - Estado)

        private string lcd;
        private string mascaraLcd = "LCD: Emisora {0}: {1} - Volumen: {2}";

        #endregion

        //Constructor
        public PantallaLcd()
        {
        }

        // Destructor
        ~PantallaLcd()
        {
            lcd = "";
        }

        #region Métodos (Comportamiento)

        public string ObtenerPantalla(int _volumen, double _frecuencia, enumFrecuenciaSintonizado _tiposintonizado)
        {
            string pantalla = "";
            if (_volumen > 0)
            {
                string _volumenDibujo = DibujarVolumen(_volumen);
                pantalla = String.Format(mascaraLcd, _tiposintonizado.ToString(), _frecuencia.ToString("000.00 Mhz"), _volumenDibujo);
            }
            else
            {
                pantalla = "LCD: --- RADIO APAGADA ---";
            }
            return pantalla;
        }

        private string DibujarVolumen(int volumen)
        {
            char[] _volumenDibujo = new Char[10];
            for (int i = 0; i < volumen; i++)
            {
                _volumenDibujo[i] = '#';
            }
            string volumenString = new String(_volumenDibujo);
            volumenString = volumenString.Replace("\0", "·");
            return volumenString;
        }

        #endregion
    }
}
