using BookManager.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookManager.Controllers
{
    public class BookController : Controller
    {
        BookManagerDBEntities dbObj= new BookManagerDBEntities();


        // GET: Book
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddBook(Book Model)
        {

            if (ModelState.IsValid)
            {
                Book obj = new Book();
                // obj.ID = Model.ID;
                obj.Title = Model.Title;
                obj.Author = Model.Author;
                obj.Price = Model.Price;
                obj.PublishedDate = Model.PublishedDate;
                dbObj.Books.Add(obj);
                dbObj.SaveChanges();
            }
            ModelState.Clear();
            return View("Index");
        }


        public ActionResult BookList()
        {
            var res = dbObj.Books.ToList();
            return View(res);
        }
        public ActionResult Delete(int ID)
        {
            var res = dbObj.Books.Where(model => model.ID == ID).First();
            return View(res);
        }

    }
}