
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Antlr.Runtime.Misc;
using StackOverflowOsc.Web.Models;

namespace StackOverflowOsc.Web.Controllers
{
    public class QuestionController : Controller
    {
        //
        // GET: /Question/
        public ActionResult Index()
        {
            List<QuestionListModel> models = new ListStack<QuestionListModel>();
            QuestionListModel modelTest = new QuestionListModel();
            modelTest.Tittle = "Title Test";
            modelTest.OwnerName = "Oscar";
            modelTest.Votes = 1;
            modelTest.CreationName = DateTime.Now;
            modelTest.OwnerId = Guid.NewGuid();
            modelTest.QuestionId = Guid.NewGuid();
            models.Add(modelTest);

            QuestionListModel modelTest1 = new QuestionListModel();
            modelTest1.Tittle = "Title Test";
            modelTest1.OwnerName = "Mendez";
            modelTest1.Votes = 1;
            modelTest1.CreationName = DateTime.Now;
            modelTest1.OwnerId = Guid.NewGuid();
            modelTest1.QuestionId = Guid.NewGuid();
            models.Add(modelTest1);

            return View(models);
        }
	}
}