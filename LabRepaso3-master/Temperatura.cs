﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabRepaso3
{
    class Temperatura
    {
        int idDepartamento;
        int temperaturaLeida;
        DateTime fechaLectura;

        public int IdDepartamento { get => idDepartamento; set => idDepartamento = value; }
        public int TemperaturaLeida { get => temperaturaLeida; set => temperaturaLeida = value; }
        public DateTime FechaLectura { get => fechaLectura; set => fechaLectura = value; }
    }
}
