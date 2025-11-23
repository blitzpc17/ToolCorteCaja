using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRESENTACION
{
    public class CorteData
    {
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public decimal TotalEntradas { get; set; }
        public decimal TotalSalidas { get; set; }
        public decimal TotalCaja { get; set; }
        public decimal TotalEfectivoInicial { get; set; }
        public decimal TotalEfectivoFinal { get; set; }
        public decimal Diferencia { get; set; }
    }
}
