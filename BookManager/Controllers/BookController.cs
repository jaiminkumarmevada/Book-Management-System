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
        BookManagerDBEntities dbObj= new BookManagerDBEntities();


        // GET: Book

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
                    dbObj.Books.Add(obj);
                    dbObj.SaveChanges();
                    TempData["SuccessMessage"] = "Book added successfully!";
                }
                else
                {
                    dbObj.Entry(obj).State= EntityState.Modified;
                    dbObj.SaveChanges();
                    TempData["SuccessMessage"] = "Book updated successfully!";
                }
                
            }
            ModelState.Clear();
            return View("Form");
        }


        public ActionResult BookList()
        {
            var res = dbObj.Books.ToList();
            return View(res);
        }

        public ActionResult Delete(int ID)
        {
            var res = dbObj.Books.Where(model => model.ID == ID).FirstOrDefault();
            if (res != null)
            {
                dbObj.Books.Remove(res);
                dbObj.SaveChanges();
                TempData["SuccessMessage"] = "Book deleted successfully!";
            }
            return RedirectToAction("BookList");
        }


    }
}