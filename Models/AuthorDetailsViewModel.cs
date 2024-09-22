namespace MVCWeek9.Models;

public class AuthorDetailsViewModel  // to exchange data from Authorcontroller to Detais view
{
    public int Id {get;set;}
    public string FirstName {get;set;}
    public string LastName {get;set;}
    public DateTime DateOfBirth {get;set;}    
}