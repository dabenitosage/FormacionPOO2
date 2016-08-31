using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormacionPOO
{
    /// <summary>
    /// Radio simulando programación secuencial.
    /// </summary>
    public class RadioSecuencial
    {
        private int _numdiodos = 3;
        private int _volumen;
        private double _frecuencia = 0;
        private int _puntoVolumen = 0;
        private double _puntoFrecuencia = 0;
        private bool _encendidoAntena;
        private int numeroDecibelios = 0;
        private double _señalModulada = 0;
        private enumFrecuenciaSintonizado _tiposintonizado;
        private string mascaraLcd = "LCD: Emisora {0}: {1} - Volumen: {2}";



        public double DemodularSeñal(int numeroAumentos, enumDiscriminador tipoDiscriminador)
        {
            if (tipoDiscriminador == enumDiscriminador.DeFoster)
                _señalModulada += (_numdiodos * numeroAumentos / Math.PI);
            else if (tipoDiscriminador == enumDiscriminador.DetectorRelacion)
                _señalModulada += ((_numdiodos * ((numeroAumentos * 2) * Math.Sin(3) / Math.PI) * 4));
            else
                _señalModulada += 10.7;

            if (_señalModulada > 120)
            {
                _señalModulada = _señalModulada % 120;
            }



            return _señalModulada;

        }

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
            return DemodularSeñal(numAumentos, tipoDiscriminador);
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

        public void EncenderAntena()
        {
            _encendidoAntena = true;
        }

        public void ApagarAntena()
        {
            _encendidoAntena = false;
        }

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

                        DisminuirDecibelios();
                    }
                    else

                        AumentarDecibelios();
                }
                _puntoVolumen = nuevoPuntoVolumen;
            }

            if (_puntoVolumen > 0)
                EncenderAntena();
            else
                ApagarAntena();

        }

        public void SubirVolumen()
        {
            if (_volumen < 10) _volumen++;
            CambiarVolumen(_volumen);


            VerPantallaLcd();
        }

        public void BajarVolumen()
        {
            if (_volumen > 0) _volumen--;
            CambiarVolumen(_volumen);
            VerPantallaLcd();
        }

        public void BuscarNuevaEmisora()
        {
            _frecuencia = EscanearSiguienteFrecuencia(Convert.ToInt16(_frecuencia) + 100);
            VerPantallaLcd();
        }

        public double EscanearSiguienteFrecuencia(int numAumentos)
        {
            if (_encendidoAntena)
            {
                _puntoFrecuencia = NuevaSeñalEscaneada(numAumentos);
            }
            return _puntoFrecuencia;
        }


        public void VerPantallaLcd()
        {
            string pantalla = ObtenerPantalla(_puntoVolumen / 10, _puntoFrecuencia, _tiposintonizado);
            Debug.WriteLine(pantalla);
        }

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



    }
}
