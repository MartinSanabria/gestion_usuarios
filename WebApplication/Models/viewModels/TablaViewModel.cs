using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication.Models.viewModels
{
    public class TablaViewModel
    {
        [Required]
        [Display(Name = "Clave")]
        public int id { get; set; }
        [Required]
        [StringLength(150)]
        [Display(Name ="Nombre")]
        public String nombre { get; set; }
        [Required]
        [StringLength(150)]
        [Display(Name = "Apellido")]
        public String apellido { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Fecha de nacimiento")]
        [DisplayFormat(DataFormatString ="{0:yyyy-MM-dd}",ApplyFormatInEditMode =true)]
        public DateTime fecha_nacimiento { get; set; }
        public int edad { get; set; }
    }
}