using PeriodoAcademico.Infra.Data.Context;
using Projeto.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeriodoAcademico.Infra.Data.Repositories
{
    public class TurmaRepositorio
    {
        public void Insert(Turma t)
        {
            using (DataContext d = new DataContext())
            {
                d.Entry(t).State = EntityState.Added;
                d.SaveChanges();
            }

        }

        public void Update(Turma t)
        {

            using (DataContext d = new DataContext())
            {
                d.Entry(t).State = EntityState.Modified;
                d.SaveChanges();
            }

        }

        public void Delete(Turma t)
        {
            using (DataContext d = new DataContext())
            {
                d.Entry(t).State = EntityState.Deleted;
                d.SaveChanges();
            }
        }

        public List<Turma> FindAll()
        {
            using (DataContext d = new DataContext())
            {
                return d.Turma.ToList();
            }
        }

        public Turma FindById(int id)
        {
            using (DataContext d = new DataContext())
            {
                return d.Turma.Find(id);
            }
        }

    }
}
