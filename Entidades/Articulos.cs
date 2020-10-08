using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace RegistroParcial1_JohanLuis.Entidades
{
    public class Articulos
    {
        [Key]
        public int ArticulosID { get; set; }
        public string Descripcion { get; set; }
        public int Existencia { get; set; }
        public int Costo { get; set; }
        public int ValorInventario { get; set; }
    }
    public Articulos()
    {
        ArticulosID = 0;
        Descripcion = string.Empty;
        Existencia = 0;
        Costo = 0;
        ValorInventatrio = 0;

    }
