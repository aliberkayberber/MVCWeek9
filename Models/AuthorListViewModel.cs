namespace MVCWeek9.Models;

public class AuthorListViewModel  // to exchange data from Authorcontroller to List view
{
    public int Id {get;set;}
    public string FirstName {get;set;}
    public string LastName {get;set;}
    public DateTime DateOfBirth {get;set;}
}