using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;
using Projeto.Entities;

namespace PeriodoAcademico.Infra.Data.Mappings
{
    public class AlunoMap : EntityTypeConfiguration<Aluno>
    {

        public AlunoMap()
        {
            ToTable("Aluno");

            HasKey(a => a.IdAluno);
                      

            Property(a => a.IdAluno)
                .HasColumnName("IdAluno")
                .IsRequired();

            Property(a => a.Nome)
                .HasColumnName("Nome")
                .HasMaxLength(50)
                .IsRequired();

            Property(a => a.Prova1)
                .HasColumnName("Prova1")
                .IsRequired();

            Property(a => a.Prova2)
                .HasColumnName("Prova2")
                .IsRequired();

            Property(a => a.Prova3)
                .HasColumnName("Prova3")
                .IsRequired();

            Property(a => a.ProvaFinal)
                .HasColumnName("ProvaFinal")
                .IsOptional();

            Property(a => a.ProvaEspecial)
                .HasColumnName("ProvaEspecial")
                .IsOptional();

            Property(a => a.Situacao)
                .HasColumnName("Situacao")
                .IsRequired();

            Property(a => a.IdTurma)
                .HasColumnName("IdTurma")
                .IsRequired();

            Property(a => a.Media)
                .HasColumnName("Media")
                .IsOptional();

            Property(a => a.FlagCompeticao)
                .HasColumnName("FlagCompeticao")
                .IsOptional();


        }



    }
}
