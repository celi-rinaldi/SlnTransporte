using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Models
{
    public class Auto
    {
        
        public int Id { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public string Matricula { get; set; }
        public decimal Precio { get; set; }

        public Auto()
        {

        }
        public Auto(string marca, string modelo, string matricula, decimal precio)
        {
            Marca = marca;
            Modelo = modelo;
            Matricula = matricula;
            Precio = precio;
        }
    }
}
