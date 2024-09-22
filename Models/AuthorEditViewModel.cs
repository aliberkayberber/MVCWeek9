using System.ComponentModel.DataAnnotations;

namespace MVCWeek9.Models;

public class AuthorEditViewModel  // to exchange data from Authorcontroller to Edit view
{
    public int Id {get;set;}

    [Required (ErrorMessage ="Boş bırakılamaz.")]
    public string FirstName {get;set;}

    [Required (ErrorMessage ="Boş bırakılamaz.")]
    public string LastName {get;set;}

    [Required (ErrorMessage ="Boş bırakılamaz.")]
    public DateTime DateOfBirth {get;set;}
}