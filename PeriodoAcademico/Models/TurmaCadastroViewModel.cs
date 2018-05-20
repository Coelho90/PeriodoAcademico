using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PeriodoAcademico.Models
{
    public class TurmaCadastroViewModel
    {
        [Required(ErrorMessage = "Informe o nome da Turma")]
        public string Nome { get; set; }

    }
}