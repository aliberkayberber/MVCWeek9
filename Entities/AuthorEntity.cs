namespace MVCWeek9.Entities;

public class AuthorEntity  // a Author data
{
    public int Id {get;set;}
    public string FirstName {get;set;}
    public string LastName {get;set;}
    public DateTime DateOfBirth {get;set;}

    public bool IsDeleted {get;set;}
}