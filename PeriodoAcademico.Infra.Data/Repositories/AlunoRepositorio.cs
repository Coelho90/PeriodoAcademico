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
    public class AlunoRepositorio
    {

        public void Insert(Aluno a)
        {
            using (DataContext d = new DataContext())
            {
                d.Entry(a).State = EntityState.Added;
                d.SaveChanges();
            }
            
        }

        public void Update(Aluno a)
        {

            using (DataContext d = new DataContext())
            {
                d.Entry(a).State = EntityState.Modified;
                d.SaveChanges();
            }

        }

        public void Delete(Aluno a)
        {
            using (DataContext d = new DataContext())
            {
                d.Entry(a).State = EntityState.Deleted;
                d.SaveChanges();
            }
        }

        public List<Aluno> FindAll()
        {
            using (DataContext d = new DataContext())
            {
                return d.Aluno.ToList();
            }
        }

        public Aluno FindById(int id)
        {
            using (DataContext d = new DataContext())
            {
                return d.Aluno.Find(id);
            }
        }

        public List<Aluno> ListTopFive()
        {
            using (DataContext d = new DataContext())
            {

                return d.Aluno.Where(a => a.Situacao == Projeto.Entities.Enum.Situacao.Aprovado).OrderByDescending(a => a.Media).Take(5).ToList();
            }
        }

     
       
    }
}
