using Microsoft.AspNetCore.Mvc;
using MVCWeek9.Entities;
using MVCWeek9.Models;

namespace MVCWeek9.Controllers;

public class BookController : Controller
{

    static List<BookEntity> _book = new List<BookEntity>() // creat static book list
    {
        new BookEntity{Id=1,Title="Suç ve Ceza",AuthorId=1,Genre="Polisiye",PublishedDate = new DateTime(1986,01,12),ISBN = "12424674-C",CopiesAvailable = 7000000},
        new BookEntity{Id=2,Title="Sefiller",AuthorId=2,Genre="Dram",PublishedDate = new DateTime(1862,01,01),ISBN="421827244-A",CopiesAvailable=750500}
    };

    static List<OwnerEntity> _owners = new List<OwnerEntity>() // creat static owner list
    {
        new OwnerEntity{Id=1,FullName = "Fyodor Dostoyevski"},
        new OwnerEntity{Id=2,FullName= "Victor Hugo"}
    };


    public IActionResult List() // list view 
    {

        var viewModel = _book.Where(x => x.IsDeleted == false).Join(  // list book and book owner without deleted

                                _owners,
                                book => book.AuthorId,
                                owner => owner.Id,
                                (book,owner) =>new {book , owner}
                                )
                                .Select(x => new BookListViewModel
                                {
                                    Id = x.book.Id,
                                    Title = x.book.Title,
                                    Genre = x.book.Genre,
                                    AuthorName = x.owner.FullName
                                
                                }).ToList();
        
        return View(viewModel); // send view model
    }

    [HttpGet]
    public IActionResult Creat() // send creat view
    {
        ViewBag.Owners = _owners; // send view owners

        return View();
    }

    [HttpPost]
    public IActionResult Creat(BookCreatViewModel formData) // get creat book data
    {
        if(!ModelState.IsValid) // go back view with data 
        {
            return View(formData);
        }

        int maxId = _book.Max(x => x.Id); // finding max id

        var newBook = new BookEntity() // new creat book
        {
            Id= maxId +1,
            Title = formData.Title,
            Genre = formData.Genre,
            AuthorId = formData.AuthorId
        };

        _book.Add(newBook); // adding list

        return RedirectToAction("List"); // orientation list
    }

    [HttpGet]
    public IActionResult Edit(int id) // editing the book
    {

        var book = _book.Find(x => x.Id == id); // check which book

        var viewModel = new BookEditViewModel // creat viewModel and  transfer data
        {
            Id=book.Id,
            Title = book.Title,
            Genre = book.Genre,
            AuthorId = book.AuthorId,
        };

        ViewBag.Owners = _owners; // send owners

        return View(viewModel); // send view model
    }

    [HttpPost]
    public IActionResult Edit(BookEditViewModel formData) // Adding data from the view to the list
    {
        if(!ModelState.IsValid) // go back view with data 
        {
            return View(formData);
        }

        var book = _book.Find(x => x.Id == formData.Id); // checking list and find 

        book.Title = formData.Title; // transfer data
        book.Genre= formData.Genre; // transfer data
        book.AuthorId = formData.AuthorId; // transfer data

        return RedirectToAction("List"); // orientation list
    }


    public IActionResult Details(int id) // details view  the book
    {
        var book = _book.Find(x=> x.Id == id); // checking list

        var viewModel = new BookDetailsViewModel // creat view model same book data
        {
            Title = book.Title,
            Genre = book.Genre,
            AuthorId = book.AuthorId,
            PublishedDate = book.PublishedDate,
            ISBN =book.ISBN,
            CopiesAvailable= book.CopiesAvailable
        };

        ViewBag.Owners = _owners; // send owners
 
        return View(viewModel); // send view model
    }

    public IActionResult Delete(int id)
    {

        var book = _book.Find(x => x.Id == id); // check id and found book

        book.IsDeleted= true; // this is soft delete

        return RedirectToAction("List"); // orientation list
    }
}