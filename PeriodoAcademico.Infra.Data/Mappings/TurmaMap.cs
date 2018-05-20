using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;
using Projeto.Entities;

namespace PeriodoAcademico.Infra.Data.Mappings
{
    public class TurmaMap : EntityTypeConfiguration<Turma>
    {

        public TurmaMap()
        {
            ToTable("Turma");

            HasKey(t => t.IdTurma);
            HasMany<Aluno>(t => t.Alunos);

            Property(t => t.IdTurma)
                .HasColumnName("IdTurma")
                .IsRequired();

           
        }



    }
}
