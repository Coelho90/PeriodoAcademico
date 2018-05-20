using PeriodoAcademico.Utils;
using Projeto.Entities.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
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

        public double MediaCompeticao { get; set; }

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
            double mediaFinal = 0;

            if (Situacao == Situacao.Recuperacao)
            {
                mediaFinal = (Media + ProvaFinal) / 2;
            }
            else
            {
                mediaFinal = (Prova1 * pesoProva1 + Prova2 * pesoProva2 + Prova3 * pesoProva3) / (pesoProva1 + pesoProva2 + pesoProva3);
            }
            DefineSituacao(mediaFinal);
            Media = Math.Round(mediaFinal, 1);
            return Media;
        }


        private void DefineSituacao(double mediaFinal)
        {
            double mediaAprovado = 6;
            double mediaReprovado = 4;
            double mediaRecuperacao = 5;

            if (ProvaFinal != 0 && mediaFinal < mediaRecuperacao)
            {
                Situacao = Situacao.Reprovado;

            }
            else if (mediaFinal < mediaAprovado && mediaFinal >= mediaReprovado)
            {
                Situacao = Situacao.Recuperacao;
            }
            else if (mediaFinal <= 4)
            {
                Situacao = Situacao.Reprovado;
            }
            else if (Situacao == Situacao.Recuperacao && mediaFinal >= mediaRecuperacao)
            {
                Situacao = Situacao.Aprovado;


            }
            else if (mediaFinal >= mediaAprovado)
            {
                Situacao = Situacao.Aprovado;

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

        private void GerarNotaCompeticao()
        {
            ProvaEspecial = AlunosUtil.NotasAleatorias();
        }

        public double CalcularMediaCompeticao()
        {
            double pesoProvasAnteriores = 1;
            double pesoProvaEspecial = 2;

            GerarNotaCompeticao();

            if (ProvaFinal != 0)
            {
                MediaCompeticao = Math.Round((Prova1 * pesoProvasAnteriores + Prova2 * pesoProvasAnteriores + Prova3 * pesoProvasAnteriores + ProvaFinal * pesoProvasAnteriores + ProvaEspecial * pesoProvaEspecial)
                                    / (pesoProvasAnteriores * 4 + ProvaEspecial), 1);


            }
            else
            {
                MediaCompeticao = Math.Round((Prova1 * pesoProvasAnteriores + Prova2 * pesoProvasAnteriores + Prova3 * pesoProvasAnteriores + ProvaEspecial * pesoProvaEspecial)
                                / (pesoProvasAnteriores * 3 + ProvaEspecial), 1);
            }

            return MediaCompeticao;
        }

        public override string ToString()
        {
            return $"Id: {IdAluno}, Nome: {Nome}, Turma: {Turma}";
        }









    }







}
