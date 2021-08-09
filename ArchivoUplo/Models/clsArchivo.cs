using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ArchivoUplo.Models
{
    public class clsArchivo
    {
        [Key]
        public int id { get; set; }
        public string nombre { get; set; }
        public string extension { get; set; }
        public double tamanio { get; set; }
        public string ubicacion { get; set; }
    }
}
