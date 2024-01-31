using BooksApp.Data;
using BooksApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace BooksApp.Controllers
{
    public class BookController : Controller
    {
        private BooksDBContext _context;// will hold reference to the database object

        public BookController(BooksDBContext context)
        {
            _context = context; //passes the reference of the database into the _context variable
        }

        public IActionResult Index()// method that allows us to read the information from the database
        {
           List<Book> booksList = _context.books.ToList(); // database.table.ToList(). gets list of all books in books table
            return View(booksList);
        }

        [HttpGet]
        public IActionResult Create()  //https get request
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Book bookObj) //https post request
        {
            _context.books.Add(bookObj); //getting ready to add book
            _context.SaveChanges(); // actually added book to database
            return RedirectToAction("Index", "Book");

        }

        public IActionResult Details(int id)
        {
            //connect to the book table in the database and fetch the book with the ID that has been provided as a parameter
            var myBook =_context.books.Find(id);
            return View(myBook);    
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            //fetch the book associated with the id provided
            var myBook = _context.books.Find(id);
            return View(myBook);
        }

        [HttpPost]
        public IActionResult Edit(int id, [Bind("BookID, Title, Description, Author, DatePublished, Genre, Price")]Book myBook) 
        {
            if (ModelState.IsValid)
            {
                _context.books.Update(myBook);
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }

    }
}
