using PeriodoAcademico.Infra.Data.Repositories;
using PeriodoAcademico.Models;
using Projeto.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using PeriodoAcademico.Utils;

namespace PeriodoAcademico.Controllers
{
    [RoutePrefix("api/aluno")]
    public class AlunoController : ApiController
    {

        [HttpPost]
        [Route("cadastrar")]
        public HttpResponseMessage Post(AlunoCadastroViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Aluno a = new Aluno();
                    a.Nome = model.Nome;
                    a.IdTurma = model.IdTurma;
                    a.GerarNotas();
                    AlunoRepositorio rp = new AlunoRepositorio();
                    rp.Insert(a);

                    return Request.CreateResponse(HttpStatusCode.OK, "Aluno cadastrado com sucesso.");

                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest, ValidationUtil.GetValidationErrors(ModelState));
                }
            }
            catch (Exception e)
            {

                return Request.CreateResponse(HttpStatusCode.InternalServerError, e.Message);

            }
        }

        [HttpDelete]
        [Route("excluir")]
        public HttpResponseMessage Excluir(int id)
        {
            try
            {
                AlunoRepositorio rep = new AlunoRepositorio();

                Aluno a = rep.FindById(id);

                rep.Delete(a);

                return Request.CreateResponse(HttpStatusCode.OK, " Aluno excluído com sucesso");

            }
            catch (Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [HttpGet]
        [Route("listartodos")]
        public HttpResponseMessage GetAll()
        {
            try
            {
                List<AlunoConsultaViewModel> lista = new List<AlunoConsultaViewModel>();

                AlunoRepositorio rp = new AlunoRepositorio();
                foreach (Aluno a in rp.FindAll())
                {
                    AlunoConsultaViewModel model = new AlunoConsultaViewModel();
                    model.IdAluno = a.IdAluno;
                    model.Nome = a.Nome;
                    model.Prova1 = a.Prova1;
                    model.Prova2 = a.Prova2;
                    model.Prova3 = a.Prova3;
                    model.ProvaFinal = a.ProvaFinal;
                    model.ProvaEspecial = a.ProvaEspecial;
                    model.IdTurma = a.IdTurma;
                    model.Situacao = a.Situacao;
                    model.Media = a.Media;
                    model.FlagCompeticao = a.FlagCompeticao;

                    lista.Add(model);

                }              

                return Request.CreateResponse(HttpStatusCode.OK, lista );
            }
            catch (Exception e)
            {
                return Request.CreateResponse
                    (HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [HttpGet]
        [Route("listarcincoprimeiros")]
        public HttpResponseMessage GetTopFive()
        {
            try
            {
                int i = 0;
                List<AlunoConsultaViewModel> lista = new List<AlunoConsultaViewModel>();
                AlunoRepositorio rp = new AlunoRepositorio();
                foreach (Aluno a in rp.ListTopFive())
                {
                    AlunoConsultaViewModel model = new AlunoConsultaViewModel();

                    if (i == 0)
                    {
                        a.FlagCompeticao = true;
                    }

                    model.IdAluno = a.IdAluno;
                    model.Nome = a.Nome;
                    model.Prova1 = a.Prova1;
                    model.Prova2 = a.Prova2;
                    model.Prova3 = a.Prova3;
                    model.ProvaFinal = a.ProvaFinal;
                    model.ProvaEspecial = a.ProvaEspecial;
                    model.IdTurma = a.IdTurma;
                    model.Situacao = a.Situacao;
                    model.Media = a.Media;
                    model.MediaCompeticao = a.CalcularMediaCompeticao();
                    model.FlagCompeticao = a.FlagCompeticao;

                    rp.Update(a);
                    lista.Add(model);
                    i++;
                    

                }
                


                return Request.CreateResponse(HttpStatusCode.OK, lista);
            }
            catch (Exception e)
            {
                return Request.CreateResponse
                    (HttpStatusCode.InternalServerError, e.Message);
            }
        }







    }
}
