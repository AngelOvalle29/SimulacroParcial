using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabRepaso3
{
    class Reporte
    {
        string nombreDepartamento;
        int temperatura;
        DateTime fecha;

        public string NombreDepartamento { get => nombreDepartamento; set => nombreDepartamento = value; }
        public int Temperatura { get => temperatura; set => temperatura = value; }
        public DateTime Fecha { get => fecha; set => fecha = value; }
    }
}
