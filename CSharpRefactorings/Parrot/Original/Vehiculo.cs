using System;

namespace RefactorizacionEjercicio2
{
    public class Vehiculo
    {
        private TipoVehiculo _tipo;
        private int _numeroAsientos = 0;
        private double _promedioVelocididad;
        private bool _poseeTurbo;


        public Vehiculo(TipoVehiculo tipo, int asientos, double velocidad, bool turbo)
        {
            _tipo = tipo;
            _numeroAsientos = asientos;
            _promedioVelocididad = velocidad;
            _poseeTurbo = turbo;
        }

        public double ObtenerVelocidad()
        {
            switch (_tipo)
            {
                case TipoVehiculo.Particular:
                    return ObtenerVelocidadBase();
                case TipoVehiculo.Camioneta:
                    return Math.Max(0, ObtenerVelocidadBase() - ObtenerVelocidadTurbo() * _numeroAsientos);
                case TipoVehiculo.Carga:
                    return (!_poseeTurbo) ? 0 : ObtenerVelocidadBase(_promedioVelocididad);
            }
            throw new Exception("Inalcanzable");
        }

        private double ObtenerVelocidadBase(double promedio)
        {
            return Math.Min(24.0, promedio * ObtenerVelocidadBase());
        }

        private double ObtenerVelocidadTurbo()
        {
            return 9.0;
        }

        private double ObtenerVelocidadBase()
        {
            return 12.0;
        }
    }
}
