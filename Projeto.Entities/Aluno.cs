using PeriodoAcademico.Utils;
using Projeto.Entities.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto.Entities
{
    public class Aluno
    {

        public int IdAluno { get; set; }
        public string Nome { get; set; }
        public double Prova1 { get; set; }
        public double Prova2 { get; set; }
        public double Prova3 { get; set; }
        public double ProvaFinal { get; set; }
        public double ProvaEspecial { get; set; }
        public Situacao Situacao { get; set; }
        public bool FlagCompeticao { get; set; }
        public double Media { get; set; }

        public int IdTurma { get; set; }
        public Turma Turma { get; set; }




        public Aluno()
        {

        }

        public Aluno(int idAluno, string nome, double prova1, double prova2, double prova3, double provaFinal, double provaEspecial, Situacao situacao, bool flagCompeticao, double media, int idTurma, Turma turma)
        {
            IdAluno = idAluno;
            Nome = nome;
            Prova1 = prova1;
            Prova2 = prova2;
            Prova3 = prova3;
            ProvaFinal = provaFinal;
            ProvaEspecial = provaEspecial;
            Situacao = situacao;
            FlagCompeticao = flagCompeticao;
            Media = media;
            IdTurma = idTurma;
            Turma = turma;
        }

        public double MediaFinal()
        {
            double pesoProva1 = 1;
            double pesoProva2 = 1.2;
            double pesoProva3 = 1.4;
            double pesoProvaFinal = 1;
            double mediaFinal = 0;

            if (Situacao == Situacao.Recuperacao)
            {
                mediaFinal = (Prova1 * pesoProva1 + Prova2 * pesoProva2 + Prova3 * pesoProva3 + ProvaFinal * pesoProvaFinal) / (pesoProva1 + pesoProva2 + pesoProva3 + pesoProvaFinal);
            }
            else
            {
                mediaFinal = (Prova1 * pesoProva1 + Prova2 * pesoProva2 + Prova3 * pesoProva3) / (pesoProva1 + pesoProva2 + pesoProva3);
            }
            DefineSituacao(mediaFinal);
            Media = mediaFinal;
            return mediaFinal;
        }


        private void DefineSituacao(double mediaFinal)
        {
            double mediaAprovado = 6;
            double mediaReprovado = 4;

            if (ProvaFinal != 0 && mediaFinal < mediaAprovado && mediaFinal >= mediaReprovado)
            {
                Situacao = Situacao.Reprovado;


            }
            else if (mediaFinal >= mediaAprovado)
            {
                Situacao = Situacao.Aprovado;
            }
            else if (mediaFinal < mediaAprovado && mediaFinal >= mediaReprovado)
            {
                Situacao = Situacao.Recuperacao;
            }
            else if (mediaFinal <= 4)
            {
                Situacao = Situacao.Reprovado;
            }

        }

        public void GerarNotas()
        {
            Prova1 = AlunosUtil.NotasAleatorias();
            Prova2 = AlunosUtil.NotasAleatorias();
            Prova3 = AlunosUtil.NotasAleatorias();
            DefineSituacao(MediaFinal());
            if (Situacao == Situacao.Recuperacao)
            {
                ProvaFinal = AlunosUtil.NotasAleatorias();
                DefineSituacao(MediaFinal());
            }
            
        }
        

        public override string ToString()
        {
            return $"Id: {IdAluno}, Nome: {Nome}, Turma: {Turma}";
        }









    }







}
