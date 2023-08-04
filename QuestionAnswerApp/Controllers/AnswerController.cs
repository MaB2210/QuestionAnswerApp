using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using QuestionAnswerApp.Data;
using QuestionAnswerApp.Models;

namespace QuestionAnswerApp.Controllers
{
    public class AnswerController : Controller
    {
        public readonly ApplicationDbContext _context;

        public AnswerController(ApplicationDbContext context)
        {
            _context = context;
        }


        // GET: Answer/Create
        public IActionResult Create(int questionId)
        {
            //var quest = DataHelper.GetQuestions().FirstOrDefault(e => e.Id == questionId);
            //var answer = new AnswerModel() { QuestionID = questionId };
            //return View(answer);
            ViewBag.QuestionID = questionId;
            return View();
        }

        // POST: Answer/Create
        [HttpPost]
        public async Task<IActionResult> Create(AnswerModel answerModel)
        {
            /* var question = DataHelper.GetQuestions().FirstOrDefault(e => e.Id == answerModel.QuestionID);

            answerModel.Id = question.Answers.Count > 0 ? question.Answers.Max(e => e.Id) + 1 : 1;
            answerModel.DateAdded = DateTime.Now;
            question.Answers.Add(answerModel);
            return RedirectToAction("Details", "Question", question); */
            _context.Answers.Add(answerModel);
            _context.SaveChanges();
            return RedirectToAction("Details", "Question", new { id = answerModel.QuestionID });
        }


        // GET: Answer/Delete/5
        public async Task<IActionResult> Delete(int id, int questionID)
        {
            /*  var quest = DataHelper.GetQuestions().FirstOrDefault(e => e.Id == questionID);
            var ans = quest.Answers.FirstOrDefault(e => e.Id == id);
            return View(ans);  */
            var tasktodelete = _context.Answers.FirstOrDefault(t => t.Id == id && t.QuestionID == questionID);
            tasktodelete.QuestionID = questionID;
            return View("Delete", tasktodelete);
        }

        // POST: Answer/Delete/5
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(AnswerModel answerModel)
        {
            /* var quest = DataHelper.GetQuestions().FirstOrDefault(e => e.Id == answerModel.QuestionID);
            quest.Answers.RemoveAll(e => e.Id == answerModel.Id);
            return RedirectToAction("Details", "Question", quest);  */
            _context.Answers.Remove(answerModel);
            _context.SaveChanges();
            return RedirectToAction("Details", "Question", new { id = answerModel.QuestionID });
        }

    }
}
