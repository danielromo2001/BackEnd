using System;
using System.Collections.Generic;

#nullable disable

namespace BackEnd.Models
{
    public partial class Producto
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public int Cantidad { get; set; }
        public decimal Costo { get; set; }
    }
}
