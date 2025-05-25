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
        

        //Form for Edit and Add 
        public ActionResult Form(int? id)
        {
            Book obj = new Book();

            if (id != null)
            {
                obj = dbContext.Books.FirstOrDefault(b => b.ID == id);
                if (obj == null)
                {
                    return HttpNotFound();
                }
            }

            return View(obj);
        }


        [HttpPost]
        public ActionResult AddBook(Book Model)
        {
            if (ModelState.IsValid)
            {
                Book obj = new Book
                {
                    ID = Model.ID,
                    Title = Model.Title,
                    Author = Model.Author,
                    Price = Model.Price,
                    PublishedDate = Model.PublishedDate
                };

                if (Model.ID == 0)
                {
                    dbContext.Books.Add(obj);
                    dbContext.SaveChanges();
                    TempData["SuccessMessage"] = "Book added successfully!";
                }
                else
                {
                    dbContext.Entry(obj).State = EntityState.Modified;
                    dbContext.SaveChanges();
                    TempData["SuccessMessage"] = "Book updated successfully!";
                }

         
                return RedirectToAction("Form");
            }

           
            return View("Form", Model);
        }

        public ActionResult BookList()
        {
            var res = dbContext.Books.ToList();
            return View(res);
        }

        public ActionResult Delete(int ID)
        {
            var res = dbContext.Books.FirstOrDefault(model => model.ID == ID);
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
