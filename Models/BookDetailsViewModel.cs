using System.ComponentModel.DataAnnotations;
using MVCWeek9.Entities;

namespace MVCWeek9.Models;

public class BookDetailsViewModel  // to exchange data from Bookcontroller to Details view
{
    public string Title{get;set;}
    public int AuthorId{get;set;}  // author referans
    public string Genre {get;set;}
    public DateTime? PublishedDate{get;set;}
    public string? ISBN {get;set;}
    public int? CopiesAvailable{get;set;}

}