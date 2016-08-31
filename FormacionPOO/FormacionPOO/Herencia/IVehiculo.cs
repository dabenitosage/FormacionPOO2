using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormacionPOO.Herencia
{
    public interface IVehiculo
    {
        string Color { get; }
        string Marca { get; }
        string Modelo { get; }
        int Velocidad { get; }
        string Estado { get; }

        void Arrancar();
        void Parar();
        void Acelerar(int velocidad);
        void Frenar(int velocidad);
    }
}
