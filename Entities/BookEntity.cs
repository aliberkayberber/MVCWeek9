namespace MVCWeek9.Entities;

public class BookEntity
{
    public int Id{get;set;}
    public string Title{get;set;}
    public int AuthorId{get;set;}  // author referans
    public string Genre {get;set;}
    public DateTime? PublishedDate{get;set;}
    public string? ISBN {get;set;}
    public int? CopiesAvailable{get;set;}

    public bool IsDeleted {get;set;}
}