using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormacionPOO
{
    public enum enumFrecuenciaSintonizado
    {
        AM,
        FM,
    }

    public enum enumDiscriminador
    {
        DeFoster,
        DetectorRelacion,
        Error
    }

    /// <summary>
    /// Radio común en POO.
    /// </summary>
    public class Radio
    {
        #region Campos (Atributos - Estado)
        private int _volumen;
        private double _frecuencia;
        private Circuteria _circuteria; //Relación agregación
        #endregion

        // Constructor
        public Radio()
        {
            _circuteria = new Circuteria();
            _volumen = 0;
            _frecuencia = 0;
        }

        // Destructor
        ~Radio()
        {
            _volumen = 0;
            _frecuencia = 0;
        }

        #region Métodos (Comportamiento)

        public void SubirVolumen()
        {
            if (_volumen < 10) _volumen++;
            _circuteria.CambiarVolumen(_volumen);
            VerPantallaLcd();
        }

        public void BajarVolumen()
        {
            if (_volumen > 0) _volumen--;
            _circuteria.CambiarVolumen(_volumen);
            VerPantallaLcd();
        }

        public void BuscarNuevaEmisora()
        {
            _frecuencia = _circuteria.EscanearSiguienteFrecuencia(Convert.ToInt16(_frecuencia) + 100);
            VerPantallaLcd();
        }

        public void VerPantallaLcd()
        {

            Debug.WriteLine(_circuteria.VerPantallaLcd());
        }

        #endregion

    }

    


}
