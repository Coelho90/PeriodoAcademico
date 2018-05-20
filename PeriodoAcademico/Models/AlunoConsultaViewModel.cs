using Projeto.Entities.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PeriodoAcademico.Models
{
    public class AlunoConsultaViewModel
    {

        public int IdAluno { get; set; }
        public string Nome { get; set; }
        public double Prova1 { get; set; }
        public double Prova2 { get; set; }
        public double Prova3 { get; set; }
        public double ProvaFinal { get; set; }
        public double ProvaEspecial { get; set; }
        public Situacao Situacao { get; set; }
        public int IdTurma { get; set; }

    }
}