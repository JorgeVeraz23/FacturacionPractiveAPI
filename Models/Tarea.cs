﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace backend_tareas.Models
{
    public class Tarea
    {
        [Key]
        public int IdTarea { get; set; }
        [Required]
        [Column(TypeName = "varchar(100)")]
        public string Nombre { get; set; }
        [Required]
        public bool Estado { get; set; }

    }
}
