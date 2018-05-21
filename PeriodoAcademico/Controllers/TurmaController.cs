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
    [RoutePrefix("api/turma")]
    public class TurmaController : ApiController
    {

        [HttpPost]
        [Route("cadastrar")]
        public HttpResponseMessage Post(TurmaCadastroViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Turma t = new Turma();
                    t.Nome = model.Nome;
                    TurmaRepositorio rp = new TurmaRepositorio();
                    rp.Insert(t);

                    return Request.CreateResponse(HttpStatusCode.OK, "Turma cadastrada com sucesso.");

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
                TurmaRepositorio rep = new TurmaRepositorio();

                Turma t = rep.FindById(id);

                rep.Delete(t);

                return Request.CreateResponse(HttpStatusCode.OK, " Turma excluída com sucesso");

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
                List<TurmaConsultaViewModel> lista = new List<TurmaConsultaViewModel>();

                TurmaRepositorio rp = new TurmaRepositorio();
                foreach (Turma t in rp.FindAll())
                {
                    TurmaConsultaViewModel model = new TurmaConsultaViewModel();
                    model.IdTurma = t.IdTurma;
                    model.Nome = t.Nome;
                   
                    lista.Add(model);

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
