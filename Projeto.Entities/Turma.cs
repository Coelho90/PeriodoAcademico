using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto.Entities
{
    public class Turma
    {

        public int IdTurma{ get; set; }
        public string Nome { get; set; }
        public List<Aluno> Alunos { get; set; }
        
        public Turma()
        {
                    
        }

        public Turma(int idTurma, string nome, List<Aluno> alunos)
        {
            IdTurma = idTurma;
            Nome = nome;
            Alunos = alunos;
        }

        public override string ToString()
        {
            return $"Id: {IdTurma}, Nome: { Nome}";
        }




    }
}
