using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.WindowsUi.Models
{
    public class Operaciones
    {
        public long numeroAnterior { get; } 
        public string signo { get; }
        public long numeroNuevo { get; }
        public long resultado { get; }

        public Operaciones(long numeroAnterior, string signo, long numeroNuevo, long resultado)
        {
            this.numeroAnterior = numeroAnterior;
            this.signo = signo;
            this.numeroNuevo = numeroNuevo;
            this.resultado = resultado;
        }
    }
}
