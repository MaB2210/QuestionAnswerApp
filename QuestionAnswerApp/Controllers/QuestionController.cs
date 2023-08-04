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
    public class QuestionController : Controller
    {
        public readonly ApplicationDbContext _context;

        public QuestionController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Question
        public async Task<IActionResult> Index()
        {
            return View(_context.Questions.ToList());


        }

        // GET: Question/Details/5
        public async Task<IActionResult> Details(int? id)
        {

            //var question = DataHelper.GetQuestions().FirstOrDefault(e => e.Id == id);
            var questionmodel = _context.Questions.Include(t => t.Answers).FirstOrDefault(m => m.Id == id);
            return View(questionmodel);
        }

        // GET: Question/Create
        public IActionResult Create()
        {
            
            return View();
        }

        // POST: Question/Create
        [HttpPost]
        public async Task<IActionResult> Create(QuestionModel questionModel)
        {
            /*var allQuestions = DataHelper.GetQuestions();
            questionModel.Id = allQuestions.Count > 0 ? allQuestions.Max(e => e.Id) + 1 : 1;
            questionModel.DateAdded = DateTime.Now;
            DataHelper.GetQuestions().Add(questionModel);
            return RedirectToAction("Index"); */
            _context.Questions.Add(questionModel);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        // GET: Question/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
           // var question = DataHelper.GetQuestions().FirstOrDefault(e => e.Id == id);
            var question = _context.Questions.Find(id);
            return View(question);
        }

        // POST: Question/Edit/5
        [HttpPost]
        public async Task<IActionResult> Edit(QuestionModel questionModel)
        {
           /* var question = DataHelper.GetQuestions().FirstOrDefault(e => e.Id == questionModel.Id);

            if (question == null)
            {
                return RedirectToAction("Index");
            }

            question.Title = questionModel.Title;
            question.Category = questionModel.Category;
            question.Question = questionModel.Question;*/

            _context.Questions.Update(questionModel);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        // GET: Question/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var question = _context.Questions.Find(id);
            return View(question);
            // var question = DataHelper.GetQuestions().FirstOrDefault(e => e.Id == id);
            //return View(question);
        }

        // POST: Question/Delete/5
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(QuestionModel questionModel)
        {
            /*DataHelper.GetQuestions().RemoveAll(e => e.Id == questionModel.Id);

            return RedirectToAction("Index");*/
            _context.Questions.Remove(questionModel);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}
