
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.Mvc;
using Antlr.Runtime.Misc;
using AutoMapper;
using StackOverflow.data;
using StackOverflowOsc.Domain.Entities;
using StackOverflowOsc.Web.Models;

namespace StackOverflowOsc.Web.Controllers
{
    [Authorize]
    public class QuestionController : Controller
    {
        //
        // GET: /Question/
        [AllowAnonymous]
        public ActionResult Index(QuestionListModel modelQuestion)
        {
            List<QuestionListModel> models = new List<QuestionListModel>();
            AutoMapper.Mapper.CreateMap<Question, QuestionListModel>().ReverseMap();
            var Context = new StackOverflowContext();
            var contats = from contact in Context.Questions select contact;

            foreach (var i in contats)
            {
                var model = Mapper.Map < Question, QuestionListModel>(i);
                model.OwnerName = "Oscar";
                model.OwnerId = Guid.NewGuid();
                model.CreationName = i.CreationDate;
                if (model.Tittle == null)
                    model.Tittle = "Hola";
                models.Add(model);
            }

            return View(models);
            
        }

        [HttpPost]
        public ActionResult AskQuestion(AskQuestionModel modelQuestion)
        {
            AutoMapper.Mapper.CreateMap<Question, AskQuestionModel>().ReverseMap();
            Question newQuestion = AutoMapper.Mapper.Map<AskQuestionModel, Question>(modelQuestion);
            newQuestion.Tittle = modelQuestion.Title;
            newQuestion.Description = modelQuestion.Description;
            var Context = new StackOverflowContext();
            Context.Questions.Add(newQuestion);
            Context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult AskQuestion()
        {
            return View(new AskQuestionModel());
        }

        [HttpPost]
        public ActionResult ShowQuestion(ShowQuestionModel modelQuestion)
        {
            List<QuestionListModel> models = new List<QuestionListModel>();
            AutoMapper.Mapper.CreateMap<Question, QuestionListModel>().ReverseMap();
            var Context = new StackOverflowContext();
            var contats = from contact in Context.Questions select contact;

            foreach (var i in contats)
            {
                var model = Mapper.Map<Question, QuestionListModel>(i);
                if (model.Tittle == null)
                    model.Tittle = "Hola";
                models.Add(model);
            }

            return View(modelQuestion);
        }
        public ActionResult ShowQuestion()
        {
            return View(new ShowQuestionModel());
        }

        public ActionResult Answers()
        {
            return View(new AnsWersModel());
        }
	}
}