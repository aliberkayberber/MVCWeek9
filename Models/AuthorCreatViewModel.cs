using System.ComponentModel.DataAnnotations;

namespace MVCWeek9.Models;

public class AuthorCreatViewModel  // to exchange data from Authorcontroller to Creat view
{
    [Required (ErrorMessage ="Boş bırakılamaz.")]
    public string FirstName {get;set;}

    [Required (ErrorMessage ="Boş bırakılamaz.")]
    public string LastName {get;set;}

    [Required (ErrorMessage ="Boş bırakılamaz.")]
    public DateTime DateOfBirth {get;set;}
    
}