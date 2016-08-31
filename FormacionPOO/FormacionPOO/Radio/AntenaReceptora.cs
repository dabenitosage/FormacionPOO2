using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormacionPOO
{
    /// <summary>
    /// Activa o desactiva la antena de la radio
    /// </summary>
    public class AntenaReceptora
    {
        #region Campos (Atributos - Estado)

        private bool _encendido;

        #endregion

        #region Propiedades

        public bool Encendido
        {
            get { return _encendido; }
            set { _encendido = value; }
        }

        #endregion

        //Constructor
        public AntenaReceptora()
        {
        }

        // Destructor
        ~AntenaReceptora()
        {
            _encendido = false;
        }

        #region Métodos (Comportamiento)

        public void Encender()
        {
            _encendido = true;
        }

        public void Apagar()
        {
            _encendido = false;
        }

        #endregion
    }
}
