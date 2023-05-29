using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Models
{
    [MetadataType (typeof (TaskDB))]
    internal partial class TaskMetaData
    {
        public int id { get; set; }
        [Display(Name = "Titulo")]
        [Required(ErrorMessage = "{0} Es un Dato Requerido")]
        public string title { get; set; }

        [Display(Name = "Descripcion")]
        [Required(ErrorMessage = "{0} Es un Dato Requerido")]
        public string description { get; set; }

        [Display(Name = "Registro del dia")]
        [Required(ErrorMessage = "{0} Es un Dato Requerido")]
        public Nullable<System.DateTime> registerDate { get; set; }

        [Display(Name = "Tarea Completa")]
        [Required(ErrorMessage = "{0} Es un Dato Requerido")]
        public string completeTask { get; set; }

        [Display(Name = "Fecha de la tarea finalizada")]
        [Required(ErrorMessage = "{0} Es un Dato Requerido")]
        public Nullable<System.DateTime> completeDateTask { get; set; }
    }
}
