using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication.Models.viewModels
{
    public class listUsuarioViewModel
    {
        public int id { get; set; }
        public String nombre { get; set; }
        public String apellido { get; set; }
        public DateTime fecha_nacimiento { get; set; }
        public int edad { get; set; }
    }
}