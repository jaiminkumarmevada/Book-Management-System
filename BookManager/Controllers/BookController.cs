using BookManager.Context;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web; 
using System.Web.Mvc;

namespace BookManager.Controllers
{
    public class BookController : Controller
    {
        BookManagerDBEntities dbContext = new BookManagerDBEntities();


        public ActionResult Form(Book obj)
        {

            return View(obj);

        }

        [HttpPost]
        public ActionResult AddBook(Book Model)
        {
            

            if (ModelState.IsValid)
            {
                Book obj = new Book();
                obj.ID = Model.ID;
                obj.Title = Model.Title;
                obj.Author = Model.Author;
                obj.Price = Model.Price;
                obj.PublishedDate = Model.PublishedDate;


                if (Model.ID == 0)
                {
                    dbContext.Books.Add(obj);
                    dbContext.SaveChanges();
                    TempData["SuccessMessage"] = "Book added successfully!";
                }
                else
                {
                    dbContext.Entry(obj).State= EntityState.Modified;
                    dbContext.SaveChanges();
                    TempData["SuccessMessage"] = "Book updated successfully!";
                }
                
            }
            ModelState.Clear();
            return View("Form");
        }


        public ActionResult BookList()
        {
            var res = dbContext.Books.ToList();
            return View(res);
        }

        public ActionResult Delete(int ID)
        {
            var res = dbContext.Books.Where(model => model.ID == ID).FirstOrDefault();
            if (res != null)
            {
                dbContext.Books.Remove(res);
                dbContext.SaveChanges();
                TempData["SuccessMessage"] = "Book deleted successfully!";
            }
            return RedirectToAction("BookList");
        }


    }
}