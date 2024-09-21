namespace MVCWeek9.Models;

public class BookListViewModel
{
    public int Id{get;set;}
    public string Title{get;set;}
    public int AuthorId{get;set;}  // author referans
    public string Genre {get;set;}
    public string AuthorName{get;set;}
    //public DateTime PublishedDate{get;set;}
    //public string ISBN {get;set;}
    //public int CopiesAvailable{get;set;}
}