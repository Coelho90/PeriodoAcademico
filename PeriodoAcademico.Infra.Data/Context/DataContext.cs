using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using PeriodoAcademico.Infra.Data.Mappings;
using Projeto.Entities;

namespace PeriodoAcademico.Infra.Data.Context
{
    public class DataContext : DbContext
    {

        public DataContext() : base(ConfigurationManager.ConnectionStrings["base"].ConnectionString)
        {


        }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new AlunoMap());
            modelBuilder.Configurations.Add(new TurmaMap());


        }
        public DbSet<Aluno> Aluno { get; set; }
        public DbSet<Turma> Turma { get; set; }

    }
}
