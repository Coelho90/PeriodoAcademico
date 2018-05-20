using Projeto.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PeriodoAcademico.Models
{
    public class AlunoCadastroViewModel
    {
        [Required(ErrorMessage = "Informe o nome do Aluno")]
        public string Nome{ get; set; }


        [Required(ErrorMessage = "Informe a Turma")]
        public int IdTurma { get; set; }
        



    }
}