using Microsoft.AspNetCore.Mvc;
using MVCWeek9.Entities;
using MVCWeek9.Models;

namespace MVCWeek9.Controllers;

public class AuthorController : Controller
{
    static List<AuthorEntity> _author = new List<AuthorEntity>() // static author list
    {
        new AuthorEntity{Id=1,FirstName="Fyodor",LastName="Dostoyevski",DateOfBirth=new DateTime(1821,11,11)},
        new AuthorEntity{Id=2,FirstName="Victor",LastName="Hugo",DateOfBirth=new DateTime(1802,02,26)}
    };
    public IActionResult List() // list view
    {

        var viewModel = _author.Where(x=> x.IsDeleted == false).Select(x=> new AuthorListViewModel // list all author without deleted
        {
            Id= x.Id,
            FirstName= x.FirstName,
            LastName=x.LastName,
            DateOfBirth= x.DateOfBirth
        }).ToList();


        return View(viewModel);
    }    

    [HttpGet]
    public IActionResult Creat() // new add author 
    {
        return View();
    }

    [HttpPost]
    public IActionResult Creat(AuthorCreatViewModel formData) // Adding data from the view to the list
    {
        if(!ModelState.IsValid) // go back view with data 
        {
            return View(formData);
        }

        int maxId = _author.Max(x=>x.Id); // finding max id

        var newAuthor = new AuthorEntity() // new creat author
        {
            Id= maxId+1,
            FirstName= formData.FirstName,
            LastName = formData.LastName,
            DateOfBirth = formData.DateOfBirth
        };

        _author.Add(newAuthor); // adding list


        return RedirectToAction("List");  // orientation list
    }
    
    [HttpGet]
    public IActionResult Edit(int id) // editing the author
    {
        var author = _author.Find(x=> x.Id == id); // check which author

        var viewModel = new AuthorEditViewModel() // creat viewModel and  transfer data
        {
            Id = author.Id,
            FirstName = author.FirstName,
            LastName = author.LastName,
            DateOfBirth = author.DateOfBirth
        };

        return View(viewModel); // send view model
    }


    [HttpPost]
    public IActionResult Edit(AuthorEditViewModel formData) // Adding data from the view to the list
    {

        if(!ModelState.IsValid) // go back view with data 
        {
            return View(formData);
        }

        var author = _author.Find(x=> x.Id == formData.Id); // checking list and find 

        author.FirstName = formData.FirstName; // transfer data
        author.LastName = formData.LastName; // transfer data
        author.DateOfBirth = formData.DateOfBirth; // transfer data
 

        return RedirectToAction("List"); // orientation list
    }

    
    public IActionResult Details(int id) // details view 
    {
        var author = _author.Find(x=> x.Id == id); // checking list

        var viewModel = new AuthorDetailsViewModel()  // creat view model same author data
        {
            Id= author.Id,
            FirstName =author.FirstName,
            LastName = author.LastName,
            DateOfBirth = author.DateOfBirth
        };

        return View(viewModel); // send view model
    }


    public IActionResult Delete(int id)
    {
        var author = _author.Find(x => x.Id == id); // check id and found author

        author.IsDeleted = true; // this is soft delete

        return RedirectToAction("List"); // orientation list
    }


}