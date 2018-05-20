using Projeto.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace PeriodoAcademico.Utils
{
    public static class AlunosUtil
    {

        public static double NotasAleatorias()
        {
            double max = 10;
            double min = 0.0001;
            System.Threading.Thread.Sleep(5);
            Random random = new Random();
            System.Threading.Thread.Sleep(5);
            return Math.Round(random.NextDouble() * (max - min) + min, 1);
        }

    }
}